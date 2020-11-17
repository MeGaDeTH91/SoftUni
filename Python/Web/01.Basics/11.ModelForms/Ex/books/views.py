from django.shortcuts import render, redirect

# Create your views here.
from books.forms import BookForm
from books.models import Book


def index(req):
    context = {
        'books': Book.objects.all()
    }
    return render(req, 'index.html', context)


def create(req):
    if req.method == 'GET':
        context = {
            'form': BookForm()
        }

        return render(req, 'create.html', context)
    else:
        form = BookForm(req.POST, instance=Book())

        if form.is_valid():
            book = form.save()
            book.save()
            return redirect('books index')

        context = {
            'form': form
        }
        return render(req, 'create.html', context)


def edit(req, book_id):
    book = Book.objects.get(pk=book_id)

    if req.method == 'GET':
        context = {
            'form': BookForm(instance=book)
        }

        return render(req, 'create.html', context)
    else:
        form = BookForm(req.POST, instance=book)

        if form.is_valid():
            book = form.save()
            book.save()
            return redirect('books index')

        context = {
            'form': form
        }
        return render(req, 'edit.html', context)
