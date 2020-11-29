from rest_framework import serializers

from main_app.models import Product
from main_app.serializers.category_concise import ListCategorySerializer
from main_app.serializers.review import ReviewSerializer


class ProductSerializer(serializers.ModelSerializer):
    category = ListCategorySerializer()
    review_set = ReviewSerializer(many=True)

    class Meta:
        model = Product
        fields = '__all__'


class ProductCreateSerializer(serializers.ModelSerializer):
    class Meta:
        model = Product
        fields = '__all__'
