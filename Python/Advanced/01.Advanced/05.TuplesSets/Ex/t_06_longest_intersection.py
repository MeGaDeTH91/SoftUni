n = int(input())

left = set()
right = set()

current_intersection = set()
max_intersection = set()

for _ in range(n):
    tokens = input().split('-')

    left_tokens = tokens[0].split(',')
    right_tokens = tokens[1].split(',')

    left_start = int(left_tokens[0])
    left_end = int(left_tokens[1]) + 1

    right_start = int(right_tokens[0])
    right_end = int(right_tokens[1]) + 1

    current_left = set(range(left_start, left_end))
    current_right = set(range(right_start, right_end))

    current_intersection = current_left.intersection(current_right)

    if len(current_intersection) > len(max_intersection):
        max_intersection = list(current_intersection)


print(f'Longest intersection is {max_intersection} with length {len(max_intersection)}')
