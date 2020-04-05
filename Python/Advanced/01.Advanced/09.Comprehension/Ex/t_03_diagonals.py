n = int(input())

matrix = [[int(x) for x in input().split(', ')] for _ in range(n)]

first_diagonal = [matrix[x][x] for x in range(n)]
second_diagonal = [matrix[x][n - x - 1] for x in range(n)]

print(f'First diagonal: {", ".join([str(x) for x in first_diagonal])}. Sum: {sum(first_diagonal)}')
print(f'Second diagonal: {", ".join([str(x) for x in second_diagonal])}. Sum: {sum(second_diagonal)}')
