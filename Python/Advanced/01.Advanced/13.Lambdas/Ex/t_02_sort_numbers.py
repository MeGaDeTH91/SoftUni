numbers = input().split()

sorted_numbers = sorted([int(x) for x in numbers if x.isdigit()])

print(' '.join([str(x) for x in sorted_numbers if x > len(numbers)]))
