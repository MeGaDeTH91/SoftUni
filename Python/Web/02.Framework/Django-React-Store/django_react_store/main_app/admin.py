from django.contrib import admin
from django.contrib.auth.admin import UserAdmin

# Register your models here.
from main_app.models import Customer, Category, Order, Product, Review

admin.site.register(Category)
admin.site.register(Product)
admin.site.register(Customer, UserAdmin)
admin.site.register(Order)
admin.site.register(Review)
