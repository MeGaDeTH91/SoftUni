from timeit import default_timer as timer


def exec_time(function):
    def decorator(*args):
        start = timer()
        function(*args)
        end = timer()

        return end - start

    return decorator


@exec_time
def concatenate(strings):
    result = ""
    for string in strings:
        result += string
    return result


print(concatenate(["a" for i in range(1000000)]))
