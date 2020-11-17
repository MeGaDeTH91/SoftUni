from django.urls import path

from app.views import index, expenses, profiles

urlpatterns = [
    # Home page
    path('', index.home_page, name='home page'),

    # Expense pages
    path('create/', expenses.expense_create, name='create expense'),
    path('edit/<int:pk>', expenses.expense_edit, name='edit expense'),
    path('delete/<int:pk>', expenses.expense_delete, name='delete expense'),

    # Profile pages
    path('profile/', profiles.profile_details, name='profile details'),
    path('profile/create/', profiles.profile_create, name='create profile'),
    path('profile/edit/', profiles.profile_edit, name='edit profile'),
    path('profile/delete/', profiles.profile_delete, name='delete profile'),
]
