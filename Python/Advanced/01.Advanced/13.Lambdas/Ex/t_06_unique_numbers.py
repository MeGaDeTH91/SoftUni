numbers = [round(float(x)) for x in input().split()]

min_number = min(numbers)
max_number = max(numbers)

ordered_numbers = sorted(set(numbers))

print(min_number)
print(max_number)
print(' '.join([str(x * 3) for x in ordered_numbers]))
