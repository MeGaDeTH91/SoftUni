from collections import deque
from math import floor

tokens = input().split()
result = deque()

for element in tokens:
    try:
        check_int = int(element)
        result.append(check_int)
    except:
        current_result = result.popleft()
        while result:
            current_number = result.popleft()
            if element == '+':
                current_result = floor(current_result + current_number)
            elif element == '-':
                current_result = floor(current_result - current_number)
            elif element == '*':
                current_result = floor(current_result * current_number)
            elif element == '/':
                current_result = floor(current_result / current_number)

        result.append(current_result)

print(result.pop())
