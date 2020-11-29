from django.utils.decorators import method_decorator
from rest_framework import status
from rest_framework.views import APIView

from rest_framework.response import Response

from ..middleware.authenticate_admin_middleware import authenticate_admin_middleware
from ..models import Category
from ..serializers.category_concise import ListCategorySerializer
from ..serializers.category_details import DetailsCategorySerializer


class ListCategoriesView(APIView):
    def get(self, request):
        categories = Category.objects.order_by('id').all()
        serializer = ListCategorySerializer(categories, many=True)
        return Response(serializer.data)


class DetailsCategoryView(APIView):
    def get(self, request, pk):
        category = Category.objects.get(pk=pk)

        if not category:
            return Response('No such category!', status=status.HTTP_404_NOT_FOUND)

        serializer = DetailsCategorySerializer(category)
        return Response(serializer.data, status=status.HTTP_200_OK)

    @method_decorator(authenticate_admin_middleware)
    def put(self, request, pk):
        category = Category.objects.get(pk=pk)

        if not category:
            return Response('No such category!', status=status.HTTP_404_NOT_FOUND)

        serializer = ListCategorySerializer(instance=category, data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response('Please provide valid data.', status=status.HTTP_400_BAD_REQUEST)

    @method_decorator(authenticate_admin_middleware)
    def post(self, request):
        serializer = ListCategorySerializer(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)
