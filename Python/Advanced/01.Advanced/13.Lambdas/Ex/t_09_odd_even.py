command = input()

numbers = [int(x) for x in input().split()]

remainder = 0
if command == 'Odd':
    remainder = 1
elif command == 'Even':
    remainder = 0
print(sum(list(filter(lambda x: x % 2 == remainder, numbers))) * len(numbers))
