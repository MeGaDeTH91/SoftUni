from django.urls import path

from books import views

urlpatterns = [
    path('', views.index, name='books index'),
    path('create/', views.create, name='books create'),
    path('edit/<int:book_id>', views.edit, name='books edit'),
]
