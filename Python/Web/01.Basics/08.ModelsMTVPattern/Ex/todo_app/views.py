from django.shortcuts import render


# Create your views here.
from todo_app.models import Todo


def index(req):
    todos = Todo.objects.all()
    context = {'todos': todos}
    return render(req, 'index.html', context=context)
