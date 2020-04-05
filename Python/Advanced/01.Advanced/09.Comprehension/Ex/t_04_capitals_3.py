countries = input().split(', ')
capitals = input().split(', ')

[print(f'{countries[x]} -> {capitals[x]}') for x in range(len(countries))]
