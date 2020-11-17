from django.urls import path

from main_app.views import index, recipes

urlpatterns = [
    # Home page
    path('', index.home_page, name='home page'),

    # Recipe pages
    path('create/', recipes.recipe_create, name='create recipe'),
    path('edit/<int:pk>', recipes.recipe_edit, name='edit recipe'),
    path('delete/<int:pk>', recipes.recipe_delete, name='delete recipe'),
    path('details/<int:pk>', recipes.recipe_details, name='details recipe'),
]