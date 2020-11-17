from django.shortcuts import render

from app.forms.profile_form import ProfileForm
from app.models import Profile, Expense
from app.common.util import get_profile, calculate_budget_left


def home_page(req):
    if Profile.objects.exists():
        profile = get_profile()
        expenses = Expense.objects.all()
        profile.budget_left = calculate_budget_left

        context = {
            'profile': profile,
            'expenses': expenses
        }
        return render(req, 'home-with-profile.html', context=context)
    else:
        context = {
            'form': ProfileForm()
        }
        return render(req, 'home-no-profile.html', context=context)
