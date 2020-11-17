from app.models import Profile, Expense


def get_profile():
    return Profile.objects.all()[0]


def calculate_budget_left():
    profile = get_profile()
    expenses = Expense.objects.all()
    return profile.budget - sum([expense.price for expense in expenses])
