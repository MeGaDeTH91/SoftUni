from django.db import models


# Create your models here.
from pets.models import Pet


class Comment(models.Model):
    comment = models.TextField(blank=False)
    pet = models.ForeignKey(Pet, on_delete=models.CASCADE)
