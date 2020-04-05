n = int(input())

numbers = [int(x) for x in input().split()]

result = [str(x * n) for x in numbers]

print(' '.join(result))
