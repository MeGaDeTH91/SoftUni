from rest_framework import serializers

from main_app.models import Category
from main_app.serializers.product import ProductSerializer


class DetailsCategorySerializer(serializers.ModelSerializer):
    products = ProductSerializer(many=True)

    class Meta:
        model = Category
        fields = '__all__'
