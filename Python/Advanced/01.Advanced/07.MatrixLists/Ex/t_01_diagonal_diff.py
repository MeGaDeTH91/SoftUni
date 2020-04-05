n = int(input())

matrix = []

for _ in range(n):
    current_row = [int(x) for x in input().split()]
    matrix.append(current_row)

primary_diagonal = 0
secondary_diagonal = 0

row = 0
col = 0

while row < n:
    primary_diagonal += matrix[row][col]
    row += 1
    col += 1

row = 0
col = n - 1

while col >= 0:
    secondary_diagonal += matrix[row][col]
    col -= 1
    row += 1

difference = abs(primary_diagonal - secondary_diagonal)

print(difference)
