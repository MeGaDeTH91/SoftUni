numbers = [float(x) for x in input().split()]

counts = {}

for x in numbers:
    if x not in counts:
        counts[x] = 0

    counts[x] += 1

for key, value in counts.items():
    print(f'{key} - {value} times')
