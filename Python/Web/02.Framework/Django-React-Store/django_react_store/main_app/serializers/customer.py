from rest_framework import serializers
from rest_framework_jwt.settings import api_settings

from main_app.models import Customer


class CustomerSerializer(serializers.ModelSerializer):
    class Meta:
        model = Customer
        fields = ('id', 'username', 'review_set', 'email', 
                  'first_name', 'last_name', 'is_active', 'is_superuser', 'address')


class CustomerSerializerWithToken(serializers.ModelSerializer):

    token = serializers.SerializerMethodField()
    password = serializers.CharField(write_only=True)

    def get_token(self, obj):
        jwt_payload_handler = api_settings.JWT_PAYLOAD_HANDLER
        jwt_encode_handler = api_settings.JWT_ENCODE_HANDLER

        payload = jwt_payload_handler(obj)
        token = jwt_encode_handler(payload)
        return token

    def create(self, validated_data):
        password = validated_data.pop('password', None)
        email = validated_data.pop('email', None)
        first_name = validated_data.pop('first_name', None)
        last_name = validated_data.pop('last_name', None)
        address = validated_data.pop('address', None)
        instance = self.Meta.model(**validated_data)

        if password is not None and first_name is not None and last_name is not None and \
                email is not None and address is not None:
            instance.set_password(password)
            instance.first_name = first_name
            instance.last_name = last_name
            instance.email = email
            instance.address = address
        instance.save()
        return instance

    class Meta:
        model = Customer
        fields = ('token', 'username', 'id', 'password', 'email', 'address', 'first_name', 'last_name')
