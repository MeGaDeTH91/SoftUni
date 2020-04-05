from collections import deque

tokens = [int(x) for x in input().split()]
snake = deque(input())

row_count = tokens[0]
col_count = tokens[1]

matrix = []

for row in range(row_count):
    matrix.append([])
    [matrix[row].append('') for x in range(col_count)]
    element = ''
    start_index = 0
    end_index = 0
    step = 1

    if row % 2 == 0:
        start_index = 0
        end_index = col_count
        step = 1
    else:
        start_index = col_count - 1
        end_index = -1
        step = -1

    for col in range(start_index, end_index, step):
        element = snake.popleft()
        matrix[row][col] = element
        snake.append(element)


for row in matrix:
    print(''.join(row))
