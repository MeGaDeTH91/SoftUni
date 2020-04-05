countries = input().split(', ')
capitals = input().split(', ')

pairs = {country: capital for (country, capital) in zip(countries, capitals)}

[print(f'{country} -> {capital}') for (country, capital) in pairs.items()]
