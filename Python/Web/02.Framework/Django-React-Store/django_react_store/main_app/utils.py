from django.utils.encoding import smart_text

from main_app.serializers.customer import CustomerSerializer
from django.conf import settings
from django.contrib.auth.middleware import get_user
import jwt

from django_react_store import settings
from main_app.models import Customer
from rest_framework.authentication import get_authorization_header
from rest_framework_jwt.settings import api_settings


def my_jwt_response_handler(token, user=None, request=None):
    return {
        'token': token,
        'user': CustomerSerializer(user, context={'request': request}).data
    }


def jwt_auth_token_validate(request):
    """Validates token and sets the user object from a JWT header"""

    user_jwt = get_user(request)
    if user_jwt.is_authenticated:
        return user_jwt

    token = parse_token(request)

    if token is not None:
        try:
            user_jwt = jwt.decode(
                token,
                settings.SECRET_KEY,
                algorithms=['HS256']
            )
            request.user = Customer.objects.get(
                id=user_jwt['user_id']
            )
        except Exception as _:
            pass


def parse_token(request):
    auth = get_authorization_header(request).split()
    auth_header_prefix = api_settings.JWT_AUTH_HEADER_PREFIX.lower()

    if len(auth) == 0 or smart_text(auth[0].lower()) != auth_header_prefix or len(auth) == 1 or len(auth) > 2:
        return None

    return auth[1]
