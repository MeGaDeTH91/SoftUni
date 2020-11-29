from rest_framework import serializers

from main_app.models import Review
from main_app.serializers.customer import CustomerSerializer


class ReviewSerializer(serializers.ModelSerializer):
    reviewer = CustomerSerializer()

    class Meta:
        model = Review
        fields = '__all__'
