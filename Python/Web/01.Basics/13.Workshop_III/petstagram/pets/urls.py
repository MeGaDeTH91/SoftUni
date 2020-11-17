from django.urls import path

from pets import views

urlpatterns = [
    path('', views.all_pets, name='list pets'),
    path('create/', views.pet_create, name='pet create'),
    path('edit/<int:pet_id>/', views.pet_edit, name='pet edit'),
    path('delete/<int:pet_id>/', views.pet_delete, name='pet delete'),
    path('details/<int:pet_id>/', views.pet_details, name='pet details'),
    path('like/<int:pet_id>/', views.like_pet, name='like pet')
]