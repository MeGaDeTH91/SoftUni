from rest_framework import serializers

from main_app.models import Customer
from main_app.serializers.customer_review import CustomerReviewSerializer


class ProfileDetailsSerializer(serializers.ModelSerializer):
    review_set = CustomerReviewSerializer(many=True)

    class Meta:
        model = Customer
        fields = ('id', 'username', 'review_set', 'email', 
                  'first_name', 'last_name', 'is_active', 'is_superuser', 'address')
