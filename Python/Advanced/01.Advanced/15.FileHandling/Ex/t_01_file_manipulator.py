import os
from os.path import join


def create_joined_path(file_name):
    return join('files', file_name)


def print_invalid_message(message):
    print(message)


def execute_file_operation(*args):
    command = args[0]
    file_name = args[1]

    if command == 'Create':
        with open(create_joined_path(file_name), 'w') as file:
            file.write('')
    elif command == 'Add' and len(args) == 3:
        try:
            with open(create_joined_path(file_name), 'a') as file:
                file.write(f'{args[2]}\n')
        except FileNotFoundError:
            with open(create_joined_path(file_name), 'w') as file:
                file.write(f'{args[2]}\n')
    elif command == 'Replace' and len(args) == 4:
        old_string = args[2]
        new_string = args[3]

        result = ''
        try:
            with open(create_joined_path(file_name), 'r') as file:
                for line in file:
                    if old_string in line:
                        result += line.replace(old_string, new_string)
                    else:
                        result += line
            with open(create_joined_path(file_name), 'w') as file:
                file.write(result)
        except FileNotFoundError:
            print_invalid_message('An error occurred')
    elif command == 'Delete':
        try:
            os.remove(create_joined_path(file_name))
        except FileNotFoundError:
            print_invalid_message('An error occurred')
    else:
        print_invalid_message('Invalid command!')


input_line = input()
while input_line != 'End':
    tokens = input_line.split('-')

    if len(tokens) < 2:
        print_invalid_message('Invalid command!')
    else:
        execute_file_operation(*tokens)

    input_line = input()
