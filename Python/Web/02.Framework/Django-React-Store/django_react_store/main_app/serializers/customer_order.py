from rest_framework import serializers

from main_app.models import Customer, Order
from main_app.serializers.product import ProductSerializer


class OrderSerializer(serializers.ModelSerializer):
    products = ProductSerializer(many=True)

    class Meta:
        model = Order
        fields = '__all__'


class CustomerOrdersSerializer(serializers.ModelSerializer):
    order_set = OrderSerializer(many=True)

    class Meta:
        model = Customer
        fields = ('id', 'username', 'order_set')
