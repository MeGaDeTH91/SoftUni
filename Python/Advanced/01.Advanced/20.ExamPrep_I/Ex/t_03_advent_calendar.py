def fix_calendar(numbers):
    for i in range(len(numbers)):
        for check in range(i, len(numbers)):
            if numbers[check] < numbers[i]:
                numbers[check], numbers[i] = numbers[i], numbers[check]

    return numbers
