def vowel_filter(function):
    def wrapper():
        vowels = ['a', 'e', 'i', 'o', 'u']

        arr = function()

        result = []

        for letter in arr:
            if letter in vowels:
                result.append(letter)

        return result
    return wrapper

@vowel_filter
def get_letters():
    return ["a", "b", "c", "d", "e"]


print(get_letters())
