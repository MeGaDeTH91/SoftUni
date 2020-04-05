lengths = input().split()
first_len = int(lengths[0])
second_len = int(lengths[1])

a = set()
b = set()

for _ in range(first_len):
    a.add(int(input()))

for _ in range(second_len):
    b.add(int(input()))

result = a.intersection(b)

for el in result:
    print(el)
