def type_check(type_value):
    def decorator(func):
        def wrapper(param):
            param_type = param.__class__.__name__
            valid_type = type_value.__name__

            if param_type == valid_type:
                return func(param)

            return 'Bad Type'
        return wrapper

    return decorator


@type_check(int)
def times2(num):
    return num * 2


print(times2(2))
print(times2('Not A Number'))
