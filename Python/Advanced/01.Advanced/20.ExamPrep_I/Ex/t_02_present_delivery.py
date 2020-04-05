def print_matrix(matrix, size):
    for row in range(size):
        print(" ".join(matrix[row]))


def check_for_children(current_row, current_col, neighbourhood):
    bad_kids = 0
    good_kids = 0

    if neighbourhood[current_row - 1][current_col] == 'X':
        bad_kids += 1
        neighbourhood[current_row - 1][current_col] = '-'
    elif neighbourhood[current_row - 1][current_col] == 'V':
        good_kids += 1
        neighbourhood[current_row - 1][current_col] = '-'
    if neighbourhood[current_row][current_col - 1] == 'X':
        bad_kids += 1
        neighbourhood[current_row][current_col - 1] = '-'
    elif neighbourhood[current_row][current_col - 1] == 'V':
        good_kids += 1
        neighbourhood[current_row][current_col - 1] = '-'
    if neighbourhood[current_row][current_col + 1] == 'X':
        bad_kids += 1
        neighbourhood[current_row][current_col + 1] = '-'
    elif neighbourhood[current_row][current_col + 1] == 'V':
        good_kids += 1
        neighbourhood[current_row][current_col + 1] = '-'
    if neighbourhood[current_row + 1][current_col] == 'X':
        bad_kids += 1
        neighbourhood[current_row + 1][current_col] = '-'
    elif neighbourhood[current_row + 1][current_col] == 'V':
        good_kids += 1
        neighbourhood[current_row + 1][current_col] = '-'

    return good_kids, bad_kids


presents_count = int(input())
neighbourhood_size = int(input())

neighbourhood = []

nice_kids = 0
seek_start = True

current_row = 0
current_col = 0

for row in range(neighbourhood_size):
    tokens = input().split()
    nice_kids += tokens.count('V')
    neighbourhood.append(tokens)

    if seek_start:
        if 'S' in tokens:
            index = tokens.index('S')
            current_row = row
            current_col = index
            seek_start = False

nice_kids_initial = nice_kids

command = ''
while command != 'Christmas morning' and presents_count:
    command = input()

    neighbourhood[current_row][current_col] = '-'

    if command == 'up':
        current_row -= 1
    elif command == 'right':
        current_col += 1
    elif command == 'down':
        current_row += 1
    elif command == 'left':
        current_col -= 1

    element = neighbourhood[current_row][current_col]
    neighbourhood[current_row][current_col] = 'S'
    if element == 'V':
        nice_kids -= 1
        presents_count -= 1
    elif element == 'C':
        good_children, bad_children = check_for_children(current_row, current_col, neighbourhood)
        nice_kids -= good_children
        presents_count -= good_children + bad_children

        if presents_count < 0:
            presents_count = 0

santa_run_out = nice_kids > 0 >= presents_count
if santa_run_out:
    print('Santa ran out of presents!')

print_matrix(neighbourhood, neighbourhood_size)

if not santa_run_out and nice_kids == 0:
    print(f'Good job, Santa! {nice_kids_initial - nice_kids} happy nice kid/s.')
else:
    print(f'No presents for {nice_kids} nice kid/s.')
