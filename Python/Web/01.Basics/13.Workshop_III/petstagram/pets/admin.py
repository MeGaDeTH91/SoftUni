from django.contrib import admin

# Register your models here.
from pets import models
from common import models as common_models

admin.site.register(models.Pet)
admin.site.register(models.Like)
admin.site.register(common_models.Comment)
