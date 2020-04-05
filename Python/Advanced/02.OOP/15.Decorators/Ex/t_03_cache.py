def cache(func):
    log = {}

    def decorator(num):
        if num in log:
            return log[num]
        else:
            value = func(num)
            log[num] = value
            return value

    decorator.log = log
    return decorator


@cache
def fibonacci(n):
    if n < 2:
        return n
    else:
        return fibonacci(n-1) + fibonacci(n-2)


fibonacci(3)
print(fibonacci.log)
