def palindrome(word, index, *args):
    word_length = len(word)

    if index >= word_length:
        if word == args[0]:
            return f'{word} is a palindrome'
        else:
            return f'{word} is not a palindrome'

    if args:
        current = args[0] + word[word_length - 1 - index]
        return palindrome(word, index + 1, current)

    return palindrome(word, index + 1, word[-1])
