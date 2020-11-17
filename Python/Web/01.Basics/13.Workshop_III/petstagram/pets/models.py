from django.db import models
from django.core.validators import MinValueValidator


# Create your models here.
class Pet(models.Model):
    CAT = 'cat'
    DOG = 'dog'
    PARROT = 'parrot'
    TYPE_CHOICES = [
        (CAT, 'Cat'),
        (DOG, 'Dog'),
        (PARROT, 'Parrot')
    ]
    type = models.CharField(max_length=6, choices=TYPE_CHOICES)
    name = models.CharField(blank=False, max_length=6)
    age = models.PositiveIntegerField(blank=False, validators=[MinValueValidator(1)])
    description = models.TextField(blank=False)
    image_url = models.URLField(blank=False)

    def __str__(self):
        return self.name


class Like(models.Model):
    pet = models.ForeignKey(Pet, on_delete=models.CASCADE)


