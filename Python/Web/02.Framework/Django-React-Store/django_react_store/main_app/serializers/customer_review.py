from rest_framework import serializers

from main_app.models import Review, Product


class ProductReviewSerializer(serializers.ModelSerializer):
    class Meta:
        model = Product
        fields = '__all__'


class CustomerReviewSerializer(serializers.ModelSerializer):
    product_title = serializers.ReadOnlyField(source='product.title')

    class Meta:
        model = Review
        fields = '__all__'
