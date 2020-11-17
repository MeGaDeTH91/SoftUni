from django import forms

from pets.models import Pet


class CreatePetForm(forms.ModelForm):
    type = forms.ChoiceField(choices=[("dog", "Dog"), ("cat", "Cat"), ("parrot", "Parrot")], required=True,
                             widget=forms.Select(
                                 attrs={
                                     'class': 'form-control'
                                 },

                             ))
    name = forms.CharField(required=True, widget=forms.TextInput(
        attrs={
            'class': 'form-control'
        }
    ))
    age = forms.IntegerField(required=True, widget=forms.TextInput(
        attrs={
            'class': 'form-control',
            'type': 'number'
        }
    ))
    image_url = forms.URLField(required=True, widget=forms.TextInput(
        attrs={
            'class': 'form-control'
        }
    ))
    description = forms.CharField(required=True, widget=forms.Textarea(attrs={
        'class': 'form-control rounded-2'
    }))

    class Meta:
        model = Pet
        fields = ('type', 'name', 'age', 'description', 'image_url')
