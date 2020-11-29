from django.utils.decorators import method_decorator
from rest_framework import status
from rest_framework.views import APIView
from rest_framework.response import Response

from ..middleware.authenticate_admin_middleware import authenticate_admin_middleware
from ..middleware.authenticate_user_middleware import authenticate_user_middleware
from ..models import Product, Customer, Review
from ..serializers.product import ProductSerializer, ProductCreateSerializer


class ListProductsView(APIView):
    def get(self, request):
        products = Product.objects.order_by('created_at').all()
        serializer = ProductSerializer(products, many=True)
        return Response(serializer.data)


class DetailsProductView(APIView):
    def get(self, request, pk):
        product = Product.objects.get(pk=pk)

        if not product:
            return Response('No such product!', status=status.HTTP_404_NOT_FOUND)

        serializer = ProductSerializer(product)
        return Response(serializer.data, status=status.HTTP_200_OK)

    @method_decorator(authenticate_admin_middleware)
    def put(self, request, pk):
        product = Product.objects.get(pk=pk)

        if not product:
            return Response('No such product!', status=status.HTTP_404_NOT_FOUND)

        serializer = ProductCreateSerializer(instance=product, data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response('Please provide valid data.', status=status.HTTP_400_BAD_REQUEST)

    @method_decorator(authenticate_admin_middleware)
    def post(self, request, format=None):
        serializer = ProductCreateSerializer(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

    @method_decorator(authenticate_admin_middleware)
    def delete(self, request, pk):
        product = Product.objects.get(pk=pk)

        if not product:
            return Response('No such product!', status=status.HTTP_404_NOT_FOUND)

        product.delete()
        return Response('Product deleted successfully!', status=status.HTTP_200_OK)


class ReviewCreateView(APIView):
    @method_decorator(authenticate_user_middleware)
    def post(self, request, pk, format=None):
        user = Customer.objects.get(pk=request.user.id)
        product = Product.objects.get(pk=pk)
        content = request.data.get('content')

        if not user:
            return Response('No such user!', status=status.HTTP_404_NOT_FOUND)
        if not product:
            return Response('No such product!', status=status.HTTP_404_NOT_FOUND)
        if not content or len(content) < 3:
            return Response('Reviews must have content!', status=status.HTTP_400_BAD_REQUEST)

        review = Review()
        review.product = product
        review.reviewer = user
        review.content = content

        review.save()

        return Response('Review created successfully!', status=status.HTTP_200_OK)

