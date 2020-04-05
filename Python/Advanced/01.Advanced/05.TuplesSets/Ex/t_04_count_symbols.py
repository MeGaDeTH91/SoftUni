text = list(input())

symbols = {}

for el in text:
    if el not in symbols:
        symbols[el] = 0

    symbols[el] += 1

sorted_keys = sorted(symbols.keys())

for key in sorted_keys:
    print(f'{key}: {symbols[key]} time/s')
