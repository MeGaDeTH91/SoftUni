def fibonacci():
    a, b = 0, 1

    while True:
        yield a
        result = a + b
        a = b
        b = result


generator = fibonacci()
for i in range(12):
    print(next(generator))
