def unmark_attacker(row, col, chessboard, matrix_counts, board_size):
    if out_of_borders(row, col, board_size):
        return

    if chessboard[row][col] == 'K':
        matrix_counts[row][col] -= 1


def remove_attacked_cells(row, col, chessboard, matrix_counts, board_size):
    matrix_counts[row][col] = 0
    chessboard[row][col] = '0'

    unmark_attacker(row - 2, col - 1, chessboard, matrix_counts, board_size)  # Up-Left
    unmark_attacker(row - 2, col + 1, chessboard, matrix_counts, board_size)  # Up-Right
    unmark_attacker(row - 1, col + 2, chessboard, matrix_counts, board_size)  # Right-Up
    unmark_attacker(row + 1, col + 2, chessboard, matrix_counts, board_size)  # Right-Down
    unmark_attacker(row + 2, col + 1, chessboard, matrix_counts, board_size)  # Down-Right
    unmark_attacker(row + 2, col - 1, chessboard, matrix_counts, board_size)  # Down-Left
    unmark_attacker(row + 1, col - 2, chessboard, matrix_counts, board_size)  # Left-Down
    unmark_attacker(row - 1, col - 2, chessboard, matrix_counts, board_size)  # Left-Up


def out_of_borders(row, col, board_size):
    return row < 0 or row >= board_size or col < 0 or col >= board_size


def check_for_knight(row, col, chessboard, board_size):
    if out_of_borders(row, col, board_size):
        return 0

    if chessboard[row][col] == 'K':
        return 1
    else:
        return 0


def update_attackers(row, col, chessboard, matrix_counts, board_size):
    attackers_count = 0

    attackers_count += check_for_knight(row - 2, col - 1, chessboard, board_size)  # Up-Left
    attackers_count += check_for_knight(row - 2, col + 1, chessboard, board_size)  # Up-Right
    attackers_count += check_for_knight(row - 1, col + 2, chessboard, board_size)  # Right-Up
    attackers_count += check_for_knight(row + 1, col + 2, chessboard, board_size)  # Right-Down
    attackers_count += check_for_knight(row + 2, col + 1, chessboard, board_size)  # Down-Right
    attackers_count += check_for_knight(row + 2, col - 1, chessboard, board_size)  # Down-Left
    attackers_count += check_for_knight(row + 1, col - 2, chessboard, board_size)  # Left-Down
    attackers_count += check_for_knight(row - 1, col - 2, chessboard, board_size)  # Left-Up

    matrix_counts[row][col] = attackers_count


board_size = int(input())

chessboard = []
matrix_counts = []
[chessboard.append([]) for x in range(board_size)]
[matrix_counts.append([0 for y in range(board_size)]) for _ in range(board_size)]

for row in range(board_size):
    chessboard[row] = list(input())

for row in range(board_size):
    for col in range(board_size):
        element = chessboard[row][col]

        if element == 'K':
            update_attackers(row, col, chessboard, matrix_counts, board_size)

attacking = True
max_row = 0
max_col = 0
max_value = -1
counter = 0

while attacking:
    attacking = False
    max_value = -1

    for row in range(board_size):
        for col in range(board_size):
            current_value = matrix_counts[row][col]
            if current_value != 0:
                attacking = True
                if current_value > max_value:
                    max_value = current_value
                    max_row = row
                    max_col = col

    remove_attacked_cells(max_row, max_col, chessboard, matrix_counts, board_size)
    counter += 1

print(counter - 1)
