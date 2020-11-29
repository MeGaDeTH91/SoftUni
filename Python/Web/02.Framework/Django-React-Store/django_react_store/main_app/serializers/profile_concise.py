from rest_framework import serializers

from main_app.models import Customer


class ProfileSerializer(serializers.ModelSerializer):
    def update(self, instance, validated_data):
        email = validated_data.pop('email', None)
        first_name = validated_data.pop('first_name', None)
        last_name = validated_data.pop('last_name', None)
        address = validated_data.pop('address', None)

        instance.email = email
        instance.first_name = first_name
        instance.last_name = last_name
        instance.address = address

        instance.save()
        return instance

    class Meta:
        model = Customer
        fields = ('email', 'first_name', 'last_name', 'address')
