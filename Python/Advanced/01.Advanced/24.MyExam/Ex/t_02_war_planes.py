def valid_cell(row, col, field, size):
    return 0 <= row < size and 0 <= col < len(field[row])


def available_for_move(row, col, field):
    return field[row][col] == '.'


def print_field(field, size):
    for row in range(size):
        print(' '.join(field[row]))


field_size = int(input())

field = []
plane_row = 0
plane_col = 0
initial_targets_count = 0

for row in range(field_size):
    field.append(input().split())
    initial_targets_count += field[row].count('t')
    if 'p' in field[row]:
        plane_row = row
        plane_col = field[row].index('p')

commands_count = int(input())
targets_count = initial_targets_count

for _ in range(commands_count):
    tokens = input().split()
    command = tokens[0]
    direction = tokens[1]
    steps = int(tokens[2])

    if command == 'move':
        if direction == 'right':
            if valid_cell(plane_row, plane_col + steps, field, field_size) and available_for_move(plane_row, plane_col + steps,
                                                                                              field):
                field[plane_row][plane_col] = '.'
                plane_col += steps
                field[plane_row][plane_col] = 'p'
            else:
                continue
        if direction == 'left':
            if valid_cell(plane_row, plane_col - steps, field, field_size) and available_for_move(plane_row, plane_col - steps,
                                                                                              field):
                field[plane_row][plane_col] = '.'
                plane_col -= steps
                field[plane_row][plane_col] = 'p'
            else:
                continue
        if direction == 'up':
            if valid_cell(plane_row - steps, plane_col, field, field_size) and available_for_move(plane_row - steps, plane_col,
                                                                                              field):
                field[plane_row][plane_col] = '.'
                plane_row -= steps
                field[plane_row][plane_col] = 'p'
            else:
                continue
        if direction == 'down':
            if valid_cell(plane_row + steps, plane_col, field, field_size) and available_for_move(plane_row + steps, plane_col,
                                                                                              field):
                field[plane_row][plane_col] = '.'
                plane_row += steps
                field[plane_row][plane_col] = 'p'
            else:
                continue
    elif command == 'shoot':
        if direction == 'right':
            if valid_cell(plane_row, plane_col + steps, field, field_size):
                if field[plane_row][plane_col + steps] == 't':
                    targets_count -= 1
                field[plane_row][plane_col + steps] = 'x'

        if direction == 'left':
            if valid_cell(plane_row, plane_col - steps, field, field_size):
                if field[plane_row][plane_col - steps] == 't':
                    targets_count -= 1
                field[plane_row][plane_col - steps] = 'x'

        if direction == 'up':
            if valid_cell(plane_row - steps, plane_col, field, field_size):
                if field[plane_row - steps][plane_col] == 't':
                    targets_count -= 1
                field[plane_row - steps][plane_col] = 'x'

        if direction == 'down':
            if valid_cell(plane_row + steps, plane_col, field, field_size):
                if field[plane_row + steps][plane_col] == 't':
                    targets_count -= 1
                field[plane_row + steps][plane_col] = 'x'
    if targets_count == 0:
        print(f'Mission accomplished! All {initial_targets_count} targets destroyed.')
        print_field(field, field_size)
        exit(0)

print(f'Mission failed! {targets_count} targets left.')
print_field(field, field_size)
