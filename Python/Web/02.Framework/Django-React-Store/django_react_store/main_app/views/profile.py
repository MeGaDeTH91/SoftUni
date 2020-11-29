from django.utils.decorators import method_decorator
from rest_framework import status
from rest_framework.response import Response
from rest_framework.views import APIView

from main_app.middleware.authenticate_user_middleware import authenticate_user_middleware
from main_app.models import Customer, Product, Order
from main_app.serializers.customer_order import CustomerOrdersSerializer
from main_app.serializers.profile_concise import ProfileSerializer
from main_app.serializers.profile_details import ProfileDetailsSerializer
from main_app.serializers.shopping_cart import CustomerShoppingCartSerializer


class ProfileDetails(APIView):
    """
    Profile edit view.
    """

    @method_decorator(authenticate_user_middleware)
    def get(self, request, pk):
        if request.user.id != pk:
            return Response('You are not allowed to perform this action.', status=status.HTTP_401_UNAUTHORIZED)
        user = Customer.objects.get(pk=pk)
        serializer = ProfileDetailsSerializer(user)
        return Response(serializer.data, status=status.HTTP_200_OK)

    @method_decorator(authenticate_user_middleware)
    def put(self, request, pk, format=None):
        if request.user.id != pk:
            return Response('You are not allowed to perform this action.', status=status.HTTP_401_UNAUTHORIZED)
        user = Customer.objects.get(pk=pk)

        if not user:
            return Response('No such user!', status=status.HTTP_404_NOT_FOUND)

        serializer = ProfileSerializer(instance=user, data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response('Please provide valid data.', status=status.HTTP_400_BAD_REQUEST)


class ProfileShoppingCart(APIView):
    """
    Profile shopping-cart.
    """

    @method_decorator(authenticate_user_middleware)
    def get(self, request, pk):
        if request.user.id != pk:
            return Response('You are not allowed to perform this action.', status=status.HTTP_401_UNAUTHORIZED)
        user = Customer.objects.get(pk=pk)
        serializer = CustomerShoppingCartSerializer(user)
        return Response(serializer.data, status=status.HTTP_200_OK)

    @method_decorator(authenticate_user_middleware)
    def post(self, request, pk, format=None):
        user = Customer.objects.get(pk=request.user.id)
        product = Product.objects.get(pk=pk)

        if not user:
            return Response('No such user!', status=status.HTTP_404_NOT_FOUND)

        if not product:
            return Response('No such product!', status=status.HTTP_404_NOT_FOUND)

        user.cart.add(product)
        user.save()

        return Response('Product added to cart successfully!', status=status.HTTP_200_OK)

    @method_decorator(authenticate_user_middleware)
    def delete(self, request, pk, format=None):
        user = Customer.objects.get(pk=request.user.id)
        product = Product.objects.get(pk=pk)

        if not user:
            return Response('No such user!', status=status.HTTP_404_NOT_FOUND)

        if not product:
            return Response('No such product!', status=status.HTTP_404_NOT_FOUND)

        user.cart.remove(product)
        user.save()

        return Response('Product removed from cart successfully!', status=status.HTTP_200_OK)


class ProfileOrders(APIView):
    """
    Customer orders.
    """

    @method_decorator(authenticate_user_middleware)
    def get(self, request):
        user = Customer.objects.get(pk=request.user.id)
        if not user:
            return Response('No such user!', status=status.HTTP_404_NOT_FOUND)

        serializer = CustomerOrdersSerializer(user)
        return Response(serializer.data, status=status.HTTP_200_OK)

    @method_decorator(authenticate_user_middleware)
    def post(self, request, format=None):
        user = Customer.objects.get(pk=request.user.id)

        if not user:
            return Response('No such user!', status=status.HTTP_404_NOT_FOUND)

        if not user.cart.exists:
            return Response('Cart is empty!', status=status.HTTP_400_BAD_REQUEST)

        order_products = user.cart.all()
        order = Order()

        try:
            order.customer = user
            order.save()
            order.products.add(*order_products)
            order.save()

            for prod in order_products:
                db_product = Product.objects.get(pk=prod.id)
                db_product.quantity -= 1
                db_product.save()

            user.cart.clear()
            user.save()
        except Exception as ex:
            return Response(str(ex), status=status.HTTP_409_CONFLICT)

        return Response('Order created successfully!', status=status.HTTP_200_OK)
