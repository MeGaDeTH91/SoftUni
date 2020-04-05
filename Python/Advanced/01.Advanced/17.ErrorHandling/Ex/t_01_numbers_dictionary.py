class StringIsNumberError(Exception):
    """Raised when the string provided for key is digit"""
    pass


numbers_dictionary = {}

line = input()

while line != "Search":
    try:
        number_as_string = line

        if number_as_string.isdigit():
            raise StringIsNumberError('The provided key is number')

        number = int(input())
        numbers_dictionary[number_as_string] = number
    except StringIsNumberError as err:
        print(err)
    except ValueError:
        print('The variable number must be an integer')
    finally:
        line = input()

line = input()

while line != "Remove":
    try:
        searched = line
        print(numbers_dictionary[searched])
    except KeyError:
        print('Number does not exist in dictionary')
    finally:
        line = input()

line = input()

while line != "End":
    try:
        searched = line
        del numbers_dictionary[searched]
    except KeyError:
        print('Number does not exist in dictionary')
    finally:
        line = input()

print(numbers_dictionary)
