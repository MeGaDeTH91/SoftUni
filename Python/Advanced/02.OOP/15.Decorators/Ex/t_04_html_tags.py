def tags(tag):
    def decorator(function):
        def wrapper(*args):
            func_result = function(*args)

            return f'<{tag}>{func_result}</{tag}>'
        return wrapper
    return decorator


@tags('p')
def join_strings(*args):
    return "".join(args)


print(join_strings("Hello", " you!"))
