def damage_cell(row, col, bomb_value, minefield, minefield_size):
    if row < 0 or row >= minefield_size or col < 0 or col >= minefield_size:
        return

    element = minefield[row][col]

    if element > 0:
        minefield[row][col] -= bomb_value


def explode(bomb_row, bomb_col, minefield, minefield_size):
    bomb_value = minefield[bomb_row][bomb_col]

    if bomb_value > 0:
        minefield[bomb_row][bomb_col] = 0
        damage_cell(bomb_row - 1, bomb_col -1, bomb_value, minefield, minefield_size)
        damage_cell(bomb_row - 1, bomb_col, bomb_value, minefield, minefield_size)
        damage_cell(bomb_row - 1, bomb_col + 1, bomb_value, minefield, minefield_size)
        damage_cell(bomb_row, bomb_col - 1, bomb_value, minefield, minefield_size)
        damage_cell(bomb_row, bomb_col + 1, bomb_value, minefield, minefield_size)
        damage_cell(bomb_row + 1, bomb_col - 1, bomb_value, minefield, minefield_size)
        damage_cell(bomb_row + 1, bomb_col, bomb_value, minefield, minefield_size)
        damage_cell(bomb_row + 1, bomb_col + 1, bomb_value, minefield, minefield_size)


minefield_size = int(input())

minefield = []

for row in range(minefield_size):
    minefield.append([int(x) for x in input().split()])

bombs = input().split()

for bomb in bombs:
    tokens = bomb.split(',')

    bomb_row = int(tokens[0])
    bomb_col = int(tokens[1])

    explode(bomb_row, bomb_col, minefield, minefield_size)

alive_cells_count = 0
alive_cells_sum = 0

for row in minefield:
    for element in row:
        if element > 0:
            alive_cells_count += 1
            alive_cells_sum += element

print(f'Alive cells: {alive_cells_count}')
print(f'Sum: {alive_cells_sum}')

for row in minefield:
    print(*row)
