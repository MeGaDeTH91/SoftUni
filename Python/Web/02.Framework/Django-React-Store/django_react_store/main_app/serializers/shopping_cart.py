from rest_framework import serializers

from main_app.models import Customer
from main_app.serializers.product import ProductSerializer


class CustomerShoppingCartSerializer(serializers.ModelSerializer):
    cart = ProductSerializer(many=True)

    class Meta:
        model = Customer
        fields = ('id', 'username', 'cart')
