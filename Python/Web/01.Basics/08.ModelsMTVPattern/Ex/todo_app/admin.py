from django.contrib import admin


# Register your models here.
from todo_app import models

admin.site.register(models.Todo)
