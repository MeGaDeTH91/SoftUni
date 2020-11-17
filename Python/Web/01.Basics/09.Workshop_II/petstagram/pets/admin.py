from django.contrib import admin

# Register your models here.
from pets import models

admin.site.register(models.Pet)
admin.site.register(models.Like)
