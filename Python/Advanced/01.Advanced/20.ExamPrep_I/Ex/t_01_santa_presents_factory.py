from collections import deque

numbers = [int(x) for x in input().split()]
magic_values = deque([int(x) for x in input().split()])

dolls = 0
wooden_trains = 0
teddy_bears = 0
bicycles = 0

while numbers and magic_values:
    current_number = numbers.pop()
    current_magic = magic_values.popleft()

    if current_number == 0 and current_magic == 0:
        continue
    elif current_number == 0:
        magic_values.appendleft(current_magic)
    elif current_magic == 0:
        numbers.append(current_number)
    else:
        result = current_number * current_magic

        if result == 150:
            dolls += 1
        elif result == 250:
            wooden_trains += 1
        elif result == 300:
            teddy_bears += 1
        elif result == 400:
            bicycles += 1
        elif result < 0:
            current_sum = current_number + current_magic
            numbers.append(current_sum)
        elif result >= 0:
            numbers.append(current_number + 15)

first_valid = dolls > 0 and wooden_trains > 0
second_valid = teddy_bears > 0 and bicycles > 0

if first_valid or second_valid:
    print('The presents are crafted! Merry Christmas!')
else:
    print('No presents this Christmas!')

if numbers:
    numbers.reverse()
    print(f'Materials left: {", ".join([str(x) for x in numbers])}')
if magic_values:
    print(f'Magic left: {", ".join([str(x) for x in magic_values])}')

if bicycles > 0:
    print(f'Bicycle: {bicycles}')

if dolls > 0:
    print(f'Doll: {dolls}')

if teddy_bears > 0:
    print(f'Teddy bear: {teddy_bears}')

if wooden_trains > 0:
    print(f'Wooden train: {wooden_trains}')
