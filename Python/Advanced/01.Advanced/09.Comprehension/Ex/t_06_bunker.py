category_names = input().split(', ')
categories = {key: {} for key in category_names}

n = int(input())
for _ in range(n):
    category, name, amounts = input().split(' - ')
    amount_tokens = amounts.split(';')
    quantity = int(amount_tokens[0].split(':')[1])
    quality = int(amount_tokens[1].split(':')[1])

    if category in categories:
        if name not in categories[category]:
            categories[category][name] = {'quantity': quantity, 'quality': quality}


