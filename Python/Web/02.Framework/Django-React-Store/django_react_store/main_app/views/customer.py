from django.utils.decorators import method_decorator
from rest_framework import status
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework.views import APIView

from main_app.middleware.authenticate_admin_middleware import authenticate_admin_middleware
from main_app.middleware.authenticate_guest_middleware import authenticate_guest_middleware
from main_app.models import Customer
from main_app.serializers.customer import CustomerSerializer, CustomerSerializerWithToken


@api_view(['GET'])
def authenticate_user(request):
    """
    Determine the current user by their token, and return their data
    """

    serializer = CustomerSerializer(request.user)
    return Response(serializer.data, status=status.HTTP_200_OK)


@api_view(['PUT'])
@authenticate_admin_middleware
def user_change_role(request, pk):
    """
    Change user role, performed only by administrators.
    """
    user = Customer.objects.get(pk=pk)
    if not user:
        return Response('No such user!', status=status.HTTP_404_NOT_FOUND)

    user.is_superuser = not user.is_superuser

    user.save()
    return Response('User role changed successfully!', status=status.HTTP_200_OK)


@api_view(['PUT'])
@authenticate_admin_middleware
def user_change_status(request, pk):
    """
    Change user status, performed only by administrators.
    """
    user = Customer.objects.get(pk=pk)

    if not user:
        return Response('No such user!', status=status.HTTP_404_NOT_FOUND)
    user.is_active = not user.is_active

    user.save()
    return Response('User status changed successfully!', status=status.HTTP_200_OK)


class CustomerRegister(APIView):
    """
    Create a new user. It's called 'UserList' because normally we'd have a get
    method here too, for retrieving a list of all User objects.
    """

    @method_decorator(authenticate_admin_middleware)
    def get(self, request):
        users = Customer.objects.order_by('id').all()
        serializer = CustomerSerializer(users, many=True)
        return Response(serializer.data, status=status.HTTP_200_OK)

    @method_decorator(authenticate_guest_middleware)
    def post(self, request, format=None):
        serializer = CustomerSerializerWithToken(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)
