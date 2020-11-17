from django.shortcuts import render

from main_app.models import Recipe


def home_page(req):
    recipes = Recipe.objects.all()
    context = {
        'recipes': recipes
    }
    return render(req, 'index.html', context=context)
