from collections import deque

ingredients = deque(map(int, input().split()))
freshness_levels = list(map(int, input().split()))

cocktails_freshness_levels = {
    150: 'Mimosa',
    250: 'Daiquiri',
    300: 'Sunshine',
    400: 'Mojito'
}

cocktails_counts = {
    'Daiquiri': 0,
    'Mimosa': 0,
    'Mojito': 0,
    'Sunshine': 0
}

while ingredients and freshness_levels:
    current_ingredient = ingredients.popleft()
    current_freshness = freshness_levels.pop()

    if current_ingredient == 0:
        freshness_levels.append(current_freshness)
        continue

    product = current_ingredient * current_freshness

    if product in cocktails_freshness_levels:
        cocktail_type = cocktails_freshness_levels[product]

        cocktails_counts[cocktail_type] += 1
    else:
        current_ingredient += 5
        ingredients.append(current_ingredient)

if all(cocktails_counts.values()) > 0:
    print("It's party time! The cocktails are ready!")
else:
    print("What a pity! You didn't manage to prepare all cocktails.")

if ingredients:
    print(f'Ingredients left: {sum(ingredients)}')

for key, value in cocktails_counts.items():
    if value > 0:
        print(f' # {key} --> {value}')
