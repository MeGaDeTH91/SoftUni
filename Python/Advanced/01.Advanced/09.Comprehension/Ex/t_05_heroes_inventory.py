hero_names = input().split(', ')
heroes = {key: {} for key in hero_names}

command = input()
while command != 'End':
    name, item, cost = command.split('-')

    if name in hero_names:
        if item not in heroes[name]:
            heroes[name][item] = int(cost)

    command = input()

[print(f'{key} -> Items: {len(heroes[key])}, Cost: {sum(heroes[key].values())}') for key in heroes]
