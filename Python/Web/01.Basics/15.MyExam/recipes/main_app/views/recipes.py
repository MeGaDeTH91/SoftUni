from django.shortcuts import render, redirect

from main_app.forms.recipe_form import RecipeForm, DeleteRecipeForm
from main_app.models import Recipe


def recipe_create(req):
    if req.method == 'GET':
        context = {
            'form': RecipeForm()
        }
        return render(req, 'create.html', context=context)
    else:
        form = RecipeForm(req.POST)
        if form.is_valid():
            recipe = form.save()
            recipe.save()
            return redirect('home page')
        context = {
            'form': form
        }

        return render(req, 'create.html', context=context)


def recipe_edit(req, pk):
    recipe = Recipe.objects.get(pk=pk)

    if req.method == 'GET':
        context = {
            'form': RecipeForm(instance=recipe),
            'recipe': recipe
        }
        return render(req, 'edit.html', context=context)
    else:
        form = RecipeForm(req.POST, instance=recipe)
        if form.is_valid():
            recipe = form.save()
            recipe.save()
            return redirect('home page')
        context = {
            'form': form
        }

        return render(req, 'edit.html', context=context)


def recipe_delete(req, pk):
    recipe = Recipe.objects.get(pk=pk)
    if req.method == 'GET':
        context = {
            'recipe': recipe,
            'form': DeleteRecipeForm(instance=recipe)
        }
        return render(req, 'delete.html', context=context)
    else:
        recipe.delete()
        return redirect('home page')


def recipe_details(req, pk):
    recipe = Recipe.objects.get(pk=pk)

    recipe.ingredient_list = recipe.ingredients.split(',')
    context = {
        'recipe': recipe
    }
    return render(req, 'details.html', context=context)
