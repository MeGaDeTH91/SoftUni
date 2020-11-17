from django.db import models


# Create your models here.
class Book(models.Model):
    title = models.CharField(blank=False, max_length=20)
    pages = models.IntegerField(default=0)
    description = models.TextField(blank=False, default='', max_length=100)
    author = models.CharField(blank=False, max_length=20)

    def __str__(self):
        return self.title
