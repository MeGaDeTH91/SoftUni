from django.shortcuts import render, redirect

# Create your views here.
from pets.models import Pet, Like


def all_pets(req):
    pets = Pet.objects.all()
    context = {'pets': pets}
    return render(req, 'pets/pet_list.html', context=context)


def pet_details(req, pet_id):
    pet = Pet.objects.get(pk=pet_id)
    context = {'pet': pet}
    return render(req, 'pets/pet_detail.html', context=context)


def like_pet(req, pet_id):
    pet = Pet.objects.get(pk=pet_id)
    like = Like()
    like.pet = pet
    like.save()

    return redirect('list pets')
