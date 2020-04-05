def age_assignment(*args, **kwargs):
    result = {}

    for key,value in kwargs.items():
        for name in args:
            if str.startswith(name, key):
                result[name] = value

    return result


print(age_assignment("Peter", "George", G=26, P=19))