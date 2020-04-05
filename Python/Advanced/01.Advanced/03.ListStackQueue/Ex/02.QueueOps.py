from collections import deque
numbers = [int(x) for x in input().split()]
toPush, toPop, searchedNumber = numbers

elements = deque([int(x) for x in input().split()])

[elements.popleft() for _ in range(toPop)]

if searchedNumber in elements:
    print("True")
else:
    if elements:
        print(min(elements))
    else:
        print(0)