phone_book = {}

command = input()
while command != 'search':
    tokens = command.split('-')
    name = tokens[0]
    number = tokens[1]

    phone_book[name] = number

    command = input()

command = input()
while command != 'stop':
    if command not in phone_book:
        print(f'Contact {command} does not exist.')
    else:
        print(f'{command} -> {phone_book[command]}')

    command = input()
