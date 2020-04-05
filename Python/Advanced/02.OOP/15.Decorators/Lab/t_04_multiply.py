def multiply(times):
    def decorator(function):
        def wrapper(number):
            increased_number = function(number)

            return increased_number * times

        return wrapper
    return decorator


@multiply(3)
def add_ten(number):
    return number + 10


print(add_ten(3))
