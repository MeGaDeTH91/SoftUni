n = int(input())

compounds = set()

for _ in range(n):
    tokens = input().split()

    for x in tokens:
        compounds.add(x)

for x in compounds:
    print(x)
