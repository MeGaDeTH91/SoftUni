from django import forms


class ToDoForm(forms.Form):
    title = forms.CharField(label='title', required=True, min_length=6, max_length=15)
    description = forms.CharField(label='description', required=True, min_length=6,
                                  max_length=200, widget=forms.Textarea)

    def __init__(self, *args, **kwargs):
        self.request = kwargs.pop("request", None)  # Pop the request off the passed in kwargs.
        super(ToDoForm, self).__init__(*args, **kwargs)
