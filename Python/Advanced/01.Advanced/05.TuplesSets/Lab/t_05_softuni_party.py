name = input()

all_names = set()
actual_guests = set()

while name != 'PARTY':
    all_names.add(name)

    name = input()

name = input()

while name != 'END':
    actual_guests.add(name)

    name = input()

result = sorted(all_names - actual_guests)

guest_count = len(result)

print(guest_count)

for x in result:
    print(x)
