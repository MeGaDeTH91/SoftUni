# Generated by Django 3.1.2 on 2020-10-22 20:50

import django.core.validators
from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Pet',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('type', models.CharField(choices=[('cat', 'Cat'), ('dog', 'Dog'), ('parrot', 'Parrot')], max_length=6)),
                ('name', models.CharField(max_length=6)),
                ('age', models.PositiveIntegerField(validators=[django.core.validators.MinValueValidator(1)])),
                ('description', models.TextField()),
                ('image_url', models.URLField()),
            ],
        ),
        migrations.CreateModel(
            name='Like',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('pet', models.ForeignKey(on_delete=django.db.models.deletion.DO_NOTHING, to='pets.pet')),
            ],
        ),
    ]