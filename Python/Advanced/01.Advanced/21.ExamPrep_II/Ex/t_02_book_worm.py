def out_of_borders(row, col, size):
    return row < 0 or row >= size or col < 0 or col >= size


result_string = input()

matrix_size = int(input())
matrix = []

player_row = 0
player_col = 0

for i in range(matrix_size):
    tokens = list(input())
    matrix.append(tokens)

    if 'P' in matrix[i]:
        player_row = i
        player_col = matrix[i].index('P')

moves_count = int(input())

for _ in range(moves_count):
    move = input()

    if move == 'up':
        if out_of_borders(player_row - 1, player_col, matrix_size) and result_string:
            result_string = result_string[:-1]
            continue
        matrix[player_row][player_col] = '-'
        player_row -= 1
    elif move == 'down':
        if out_of_borders(player_row + 1, player_col, matrix_size) and result_string:
            result_string = result_string[:-1]
            continue

        matrix[player_row][player_col] = '-'
        player_row += 1
    elif move == 'right':
        if out_of_borders(player_row, player_col + 1, matrix_size) and result_string:
            result_string = result_string[:-1]
            continue
        matrix[player_row][player_col] = '-'
        player_col += 1
    elif move == 'left':
        if out_of_borders(player_row, player_col - 1, matrix_size) and result_string:
            result_string = result_string[:-1]
            continue
        matrix[player_row][player_col] = '-'
        player_col -= 1

    element = matrix[player_row][player_col]

    if element != '-':
        result_string += element
    matrix[player_row][player_col] = 'P'

print(result_string)

for row in range(matrix_size):
    print("".join(matrix[row]))
