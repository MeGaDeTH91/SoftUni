from django.http import HttpResponse

from main_app.utils import jwt_auth_token_validate


def authenticate_user_middleware(function=None, redirect_field_name=None):
    """
    Just make sure the user is authenticated to access a certain ajax view

    Otherwise return a HttpResponse 401 - authentication required
    instead of the 302 redirect of the original Django decorator
    """
    def _decorator(view_func):
        def _wrapped_view(request, *args, **kwargs):
            jwt_auth_token_validate(request)

            if request.user.is_authenticated:
                return view_func(request, *args, **kwargs)
            else:
                return HttpResponse(status=401, content="Only registered users can access this page.")
        return _wrapped_view

    if function is None:
        return _decorator
    else:
        return _decorator(function)
