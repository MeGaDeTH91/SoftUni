def validate_input_line(input_line):
    tokens = input_line.split()

    if invalid_tokens_count(tokens):
        return None

    swap_str = tokens[0]
    old_row = int(tokens[1])
    old_col = int(tokens[2])
    new_row = int(tokens[3])
    new_col = int(tokens[4])

    if invalid_borders(swap_str, old_row, old_col, new_row, new_col):
        return None

    return old_row, old_col, new_row, new_col


def invalid_tokens_count(tokens):
    return len(tokens) != 5


def invalid_borders(swap_str, row_old, col_old, row_new, col_new):
    return swap_str != 'swap' or \
           row_old < 0 or row_old >= row_count or row_new < 0 or row_new >= row_count or \
           col_old < 0 or col_old >= col_count or col_new < 0 or col_new >= col_count


size_tokens = input().split()

row_count = int(size_tokens[0])
col_count = int(size_tokens[1])

matrix = []

for _ in range(row_count):
    matrix.append(input().split())

command = input()

while command != 'END':
    current_result = validate_input_line(command)

    if current_result:
        row_old, col_old, row_new, col_new = current_result

        old_element = matrix[row_old][col_old]
        matrix[row_old][col_old] = matrix[row_new][col_new]
        matrix[row_new][col_new] = old_element

        for x in matrix:
            print(" ".join(x))
    else:
        print('Invalid input!')

    command = input()
