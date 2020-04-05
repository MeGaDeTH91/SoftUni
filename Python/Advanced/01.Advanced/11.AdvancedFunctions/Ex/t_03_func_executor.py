def func_executor(*func):
    result = []

    for function in func:
        current_function = function[0]
        current_args = function[1]
        result.append(current_function(*current_args))

    return result


def sum_numbers(num1, num2):
    return num1 + num2


def multiply_numbers(num1, num2):
    return num1 * num2


print(func_executor((sum_numbers, (1, 2)), (multiply_numbers, (2, 4))))
