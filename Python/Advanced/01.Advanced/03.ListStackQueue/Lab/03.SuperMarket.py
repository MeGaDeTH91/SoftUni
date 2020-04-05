from collections import deque


def some_func():
    command = input()
    queue = deque()

    while command != 'End':
        if command == 'Paid':
            while queue:
                print(queue.popleft())
        else:
            queue.append(command)

        command = input()

    print(f"{len(queue)} people remaining.")


some_func()
