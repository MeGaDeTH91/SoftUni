command = input()

parking_lot = set()

while command != 'END':
    tokens = command.split(', ')

    direction = tokens[0]
    plate = tokens[1]

    if direction == 'IN':
        parking_lot.add(plate)
    elif plate in parking_lot:
        parking_lot.remove(plate)

    command = input()

if parking_lot:
    for x in parking_lot:
        print(x)

else:
    print('Parking Lot is Empty')
