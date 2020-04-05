numbers = [int(x) for x in input().split()]

result = abs(sum(filter(lambda x: x < 0, numbers)))

print(result)
