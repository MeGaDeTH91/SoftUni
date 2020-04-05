names = input().split()

valid_names = set(filter(lambda x: x[0].isupper() and x[1: len(x) - 1].islower(), names))

print(sum([len(x) for x in valid_names]))
