words = input().split(', ')

result = [f'{x} -> {len(x)}' for x in words]

print(', '.join(result))
