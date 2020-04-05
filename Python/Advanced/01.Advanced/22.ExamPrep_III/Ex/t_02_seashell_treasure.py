def valid_cell(current_row, current_col, beach, rows_count):
    return 0 <= current_row < rows_count and 0 <= current_col < len(beach[current_row])


def move_vertically(current_row, current_col, beach, rows_count, step):
    global stolen_seashells_count
    global seashell_types

    for _ in range(3):
        current_row += step
        if valid_cell(current_row, current_col, beach, rows_count):
            cell_content = beach[current_row][current_col]

            if cell_content in seashell_types:
                beach[current_row][current_col] = '-'
                stolen_seashells_count += 1


def move_horizontally(current_row, current_col, beach, rows_count, step):
    global stolen_seashells_count
    global seashell_types

    for _ in range(3):
        current_col += step
        if valid_cell(current_row, current_col, beach, rows_count):
            cell_content = beach[current_row][current_col]

            if cell_content in seashell_types:
                beach[current_row][current_col] = '-'
                stolen_seashells_count += 1


rows_count = int(input())

beach = []
seashell_types = ['C', 'N', 'M']
collected_seashells = []
stolen_seashells_count = 0

for _ in range(rows_count):
    beach.append(input().split())

line = input()
while line != 'Sunset':
    tokens = line.split()
    command = tokens[0]
    current_row = int(tokens[1])
    current_col = int(tokens[2])

    if command == 'Collect':
        if valid_cell(current_row, current_col, beach, rows_count):
            cell_content = beach[current_row][current_col]

            if cell_content in seashell_types:
                collected_seashells.append(cell_content)
                beach[current_row][current_col] = '-'
    elif command == 'Steal':
        direction = tokens[3]
        if valid_cell(current_row, current_col, beach, rows_count):
            cell_content = beach[current_row][current_col]

            if cell_content in seashell_types:
                stolen_seashells_count += 1
                beach[current_row][current_col] = '-'

            if direction == 'up':
                move_vertically(current_row, current_col, beach, rows_count, -1)
            if direction == 'down':
                move_vertically(current_row, current_col, beach, rows_count, +1)
            if direction == 'left':
                move_horizontally(current_row, current_col, beach, rows_count, -1)
            if direction == 'right':
                move_horizontally(current_row, current_col, beach, rows_count, +1)

    line = input()

for row in beach:
    print(" ".join(row))

if collected_seashells:
    print(f'Collected seashells: {len(collected_seashells)} -> {", ".join(collected_seashells)}')
else:
    print('Collected seashells: 0')

print(f'Stolen seashells: {stolen_seashells_count}')
