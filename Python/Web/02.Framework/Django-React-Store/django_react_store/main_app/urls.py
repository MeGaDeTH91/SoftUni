from django.urls import path
from rest_framework_jwt.views import obtain_jwt_token

from main_app.views.categories import ListCategoriesView, DetailsCategoryView
from main_app.views.customer import authenticate_user, CustomerRegister, user_change_role, user_change_status
from main_app.views.products import ListProductsView, DetailsProductView, ReviewCreateView
from main_app.views.profile import ProfileDetails, ProfileShoppingCart, ProfileOrders

urlpatterns = [
    # User urls
    path('users/login/', obtain_jwt_token, name='users-login'),
    path('users/verify/', authenticate_user, name='users-verify'),
    path('users/all/', CustomerRegister.as_view(), name='users-all'),
    path('users/register/', CustomerRegister.as_view(), name='users-register'),
    path('users/change-role/<int:pk>/', user_change_role, name='users-change-role'),
    path('users/change-status/<int:pk>/', user_change_status, name='users-change-status'),

    # Profile urls
    path('profile-details/<int:pk>/', ProfileDetails.as_view(), name='profile-details'),
    path('profile-edit/<int:pk>/', ProfileDetails.as_view(), name='profile-edit'),
    path('profile-cart/<int:pk>/', ProfileShoppingCart.as_view(), name='profile-cart'),

    # Product urls
    path('products/all/', ListProductsView.as_view(), name='products-all'),
    path('products/create/', DetailsProductView.as_view(), name='product-create'),
    path('products/<int:pk>/', DetailsProductView.as_view(), name='product-details'),
    path('products/edit/<int:pk>/', DetailsProductView.as_view(), name='product-edit'),
    path('products/delete/<int:pk>/', DetailsProductView.as_view(), name='product-delete'),
    path('products/create-review/<int:pk>/', ReviewCreateView.as_view(), name='product-create-review'),

    # Category urls
    path('categories/all/', ListCategoriesView.as_view(), name='categories-all'),
    path('categories/<int:pk>/', DetailsCategoryView.as_view(), name='category-details'),
    path('categories/create/', DetailsCategoryView.as_view(), name='category-create'),
    path('categories/edit/<int:pk>/', DetailsCategoryView.as_view(), name='category-edit'),

    # Order urls
    path('orders/all/', ProfileOrders.as_view(), name='orders-all'),
    path('orders/create/', ProfileOrders.as_view(), name='orders-create'),
    path('orders/add-to-cart/<int:pk>/', ProfileShoppingCart.as_view(), name='add-product-to-cart'),
    path('orders/remove-from-cart/<int:pk>/', ProfileShoppingCart.as_view(), name='remove-product-from-cart'),

    # # Expense pages
    # path('create/', expenses.expense_create, name='create expense'),
    # path('edit/<int:pk>', expenses.expense_edit, name='edit expense'),
    # path('delete/<int:pk>', expenses.expense_delete, name='delete expense'),
    #
    # # Profile pages
    # path('profile/', profiles.profile_details, name='profile details'),
    # path('profile/create/', profiles.profile_create, name='create profile'),
    # path('profile/edit/', profiles.profile_edit, name='edit profile'),
    # path('profile/delete/', profiles.profile_delete, name='delete profile'),
]
