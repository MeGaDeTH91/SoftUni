def logged(function):
    def decorator(*args):
        function_name = function.__name__
        func_result = function(*args)

        result = f'you called {function_name}{args}\n'
        result += f'it returned {func_result}'

        return result
    return decorator


@logged
def func(*args):
    return 3 + len(args)


print(func(4, 4, 4))
