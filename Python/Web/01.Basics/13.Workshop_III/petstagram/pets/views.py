from django.shortcuts import render, redirect

# Create your views here.
from common.forms import CommentForm
from common.models import Comment
from pets.forms import CreatePetForm
from pets.models import Pet, Like


def all_pets(req):
    pets = Pet.objects.all()
    context = {'pets': pets}
    return render(req, 'pets/pet_list.html', context=context)


def pet_details(req, pet_id):
    pet = Pet.objects.get(pk=pet_id)
    if req.method == 'GET':
        context = {
            'pet': pet,
            'comment_form': CommentForm()
        }
        return render(req, 'pets/pet_detail.html', context=context)
    else:
        form = CommentForm(req.POST)
        if form.is_valid():
            comment = Comment(comment=form.cleaned_data['comment'])
            comment.pet = pet
            comment.save()
            return redirect('pet details', pet_id)

        context = {
            'pet': pet,
            'comment_form': form
        }

        return render(req, 'pets/pet_detail.html', context=context)


def pet_create(req):
    if req.method == 'GET':
        context = {
            'form': CreatePetForm()
        }
        return render(req, 'pets/pet_create.html', context=context)
    else:
        form = CreatePetForm(req.POST)
        if form.is_valid():
            pet = Pet(**form.cleaned_data)
            pet.save()
            return redirect('list pets')

        context = {
            'form': form
        }
        return render(req, 'pets/pet_create.html', context=context)


def pet_edit(req, pet_id):
    pet = Pet.objects.get(pk=pet_id)
    if req.method == 'GET':
        context = {
            'form': CreatePetForm(instance=pet)
        }
        return render(req, 'pets/pet_edit.html', context=context)
    else:
        form = CreatePetForm(req.POST, instance=pet)
        if form.is_valid():
            pet = form.save()
            pet.save()
            return redirect('list pets')

        context = {
            'form': form
        }
        return render(req, 'pets/pet_edit.html', context=context)


def pet_delete(req, pet_id):
    pet = Pet.objects.get(pk=pet_id)
    if req.method == 'GET':
        context = {
            'pet': pet
        }
        return render(req, 'pets/pet_delete.html', context=context)
    else:
        pet.delete()
        return redirect('list pets')


def like_pet(req, pet_id):
    pet = Pet.objects.get(pk=pet_id)
    like = Like()
    like.pet = pet
    like.save()

    return redirect('list pets')
