from django.shortcuts import render, redirect

from app.common.util import get_profile
from app.forms.expense_form import ExpenseForm, DeleteExpenseForm
from app.models import Expense


def expense_create(req):
    if req.method == 'GET':
        context = {
            'form': ExpenseForm()
        }
        return render(req, 'expense-create.html', context=context)
    else:
        form = ExpenseForm(req.POST)
        if form.is_valid():
            expense = form.save(commit=False)
            expense.profile = get_profile()
            expense.save()
            return redirect('home page')
        context = {
            'form': form
        }

        return render(req, 'expense-create.html', context=context)


def expense_edit(req, pk):
    expense = Expense.objects.get(pk=pk)
    if req.method == 'GET':
        context = {
            'expense': expense,
            'form': ExpenseForm(instance=expense)
        }
        return render(req, 'expense-edit.html', context=context)
    else:
        form = ExpenseForm(req.POST, instance=expense)
        if form.is_valid():
            form.save()
            return redirect('home page')
        context = {
            'form': form
        }

        return render(req, 'expense-edit.html', context=context)


def expense_delete(req, pk):
    expense = Expense.objects.get(pk=pk)
    if req.method == 'GET':
        context = {
            'expense': expense,
            'form': DeleteExpenseForm(instance=expense)
        }
        return render(req, 'expense-delete.html', context=context)
    else:
        expense.delete()
        return redirect('home page')
