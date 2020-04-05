n = int(input())

names = set()

for _ in range(n):
    names.add(input())

sorted_names = sorted(names)

for x in sorted_names:
    print(x)
