from collections import deque


def out_of_borders(row, col, size):
    return row < 0 or row >= size or col < 0 or col >= size


def move(current_row, current_col, field):
    return field[current_row][current_col]


size = int(input())

directions = deque(input().split())

coal_count = 0

field = []
start_row = 0
start_col = 0

for row in range(size):
    field.append(input().split())

    if 's' in field[row]:
        start_row = row
        start_col = field[row].index('s')
    coal_count += field[row].count('c')

end_is_reached = False

current_row = start_row
current_col = start_col

while directions:
    current_direction = directions.popleft()

    result = ''

    if current_direction == 'up':
        if out_of_borders(current_row - 1, current_col, size):
            continue

        current_row = current_row - 1
    elif current_direction == 'right':
        if out_of_borders(current_row, current_col + 1, size):
            continue

        current_col = current_col + 1
    elif current_direction == 'down':
        if out_of_borders(current_row + 1, current_col, size):
            continue

        current_row = current_row + 1
    elif current_direction == 'left':
        if out_of_borders(current_row, current_col - 1, size):
            continue

        current_col = current_col - 1

    result = move(current_row, current_col, field)

    if result == 'c':
        coal_count -= 1
        field[current_row][current_col] = '*'

        if coal_count == 0:
            print(f'You collected all coals! ({current_row}, {current_col})')
            break
    elif result == 'e':
        end_is_reached = True
        break

if end_is_reached:
    print(f'Game over! ({current_row}, {current_col})')
elif not directions and coal_count > 0:
    print(f'{coal_count} coals left. ({current_row}, {current_col})')
