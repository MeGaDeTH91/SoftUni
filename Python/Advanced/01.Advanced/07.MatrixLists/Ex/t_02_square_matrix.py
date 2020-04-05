tokens = [int(x) for x in input().split()]

row_count = tokens[0]
col_count = tokens[1]

matrix = []
matrices_count = 0

for _ in range(row_count):
    matrix.append(list(input().split()))

for row in range(row_count - 1):
    for col in range(col_count - 1):
        current = matrix[row][col]
        right = matrix[row][col + 1]
        bottom = matrix[row + 1][col]
        bottom_right = matrix[row + 1][col + 1]

        if current != right or right != bottom or bottom != bottom_right:
            continue
        matrices_count += 1

print(matrices_count)
