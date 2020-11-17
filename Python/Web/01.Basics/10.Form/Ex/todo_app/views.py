from django.shortcuts import render, redirect

# Create your views here.
from django.views.decorators.http import require_POST

from todo_app.forms import ToDoForm
from todo_app.models import Todo


def index(req):
    todos = Todo.objects.all().order_by('title')
    context = {'todos': todos}
    return render(req, 'todo_app/index.html', context=context)


def create(req):
    if req.method == 'GET':
        form = ToDoForm(req.POST)
        context = {
            'form': form
        }
        return render(req, 'todo_app/create.html', context)
    else:
        form = ToDoForm(req.POST)

        if form.is_valid():
            todo = Todo(title=form.cleaned_data['title'], description=form.cleaned_data['description'])
            todo.save()
            return redirect('index')
        return redirect('create_todo')


def update(req, todo_id):
    todo = Todo.objects.get(pk=todo_id)

    if not todo:
        return redirect('index')

    if req.method == 'GET':
        form = ToDoForm(instance=todo)

        context = {
            'form': form,
            'todo': todo
        }
        return render(req, 'todo_app/edit.html', context)
    else:
        form = ToDoForm(req.POST)

        if form.is_valid():
            todo.title = form.cleaned_data['title']
            todo.description = form.cleaned_data['description']
            todo.save()
            return redirect('index')
        return redirect('create_todo')


def delete(req, todo_id):
    Todo.objects.filter(pk=todo_id).delete()

    return redirect('index')
