from django.urls import path

from pets import views

urlpatterns = [
    path('', views.all_pets, name='list pets'),
    path('details/<int:pet_id>/', views.pet_details, name='pet details'),
    path('like/<int:pet_id>/', views.like_pet, name='like pet')
]