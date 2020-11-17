from django.shortcuts import redirect, render

from app.common.util import get_profile, calculate_budget_left
from app.forms.profile_form import ProfileForm


def profile_details(req):
    profile = get_profile()
    profile.budget_left = calculate_budget_left
    context = {
        'profile': profile
    }

    return render(req, 'profile.html', context=context)


def profile_create(req):
    form = ProfileForm(req.POST)

    if form.is_valid():
        form.save()
        return redirect('home page')
    context = {
        'form': form
    }
    return render(req, 'home-no-profile.html', context=context)


def profile_edit(req):
    profile = get_profile()
    if req.method == 'GET':
        context = {
            'profile': profile,
            'form': ProfileForm(instance=profile)
        }
        return render(req, 'profile-edit.html', context=context)
    else:
        form = ProfileForm(req.POST, instance=profile)
        if form.is_valid():
            form.save()
            return redirect('profile details')
        context = {
            'form': form
        }

        return render(req, 'profile-edit.html', context=context)


def profile_delete(req):

    if req.method == 'GET':
        return render(req, 'profile-delete.html')
    else:
        profile = get_profile()

        profile.delete()

        return redirect('home page')
