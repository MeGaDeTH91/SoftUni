def get_number(row, col, triangle):
    if col < 0 or col >= len(triangle[row]):
        return 0

    return triangle[row][col]


def get_magic_triangle(size):
    triangle = [[1], [1, 1]]

    for row in range(2, size):
        triangle.append([0 for x in range(row + 1)])

        for col in range(0, row + 1):
            triangle[row][col] = get_number(row - 1, col - 1, triangle) + get_number(row - 1, col, triangle)

    return triangle
