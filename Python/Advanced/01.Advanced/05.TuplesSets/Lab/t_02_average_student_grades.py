n = int(input())

students = {}

for _ in range(n):
    tokens = input().split()
    name = tokens[0]
    grade = float(tokens[1])

    if name not in students:
        students[name] = []

    students[name].append(grade)


for key, value in students.items():
    grades = " ".join(str('%.2f' % x) for x in value)
    calculated_avg = sum(value) / len(value)
    average = round(calculated_avg, 2)
    print(f'{key} -> {grades} (avg: %.2f)' % average)

