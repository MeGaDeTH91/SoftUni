tokens = [int(x) for x in input().split()]

row_count = tokens[0]
col_count = tokens[1]

matrix = []

for _ in range(row_count):
    matrix.append([int(x) for x in input().split()])

max_row = 0
max_col = 0
max_sum = 0

for row in range(row_count - 2):
    for col in range(col_count - 2):
        current_sum = 0

        for inner_row in range(row, row + 3):
            for inner_col in range(col, col + 3):
                current_sum += matrix[inner_row][inner_col]

        if current_sum > max_sum:
            max_sum = current_sum
            max_row = row
            max_col = col

print(f'Sum = {max_sum}')
for row in range(max_row, max_row + 3):
    for col in range(max_col, max_col + 3):
        print(f'{matrix[row][col]}', end=' ')

    print('')
