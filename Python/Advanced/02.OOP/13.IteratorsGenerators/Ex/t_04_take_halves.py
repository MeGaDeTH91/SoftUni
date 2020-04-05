def solution():
    def integers():
        i = 1
        while True:
            yield i
            i += 1

    def halves():
        for i in integers():
            yield float(i / 2)

    def take(n, seq):
        result = []

        for num in seq:
            if len(result) < n:
                result.append(num)
            else:
                break

        return result

    return (take, halves, integers)


take = solution()[0]
halves = solution()[1]
print(take(5, halves()))
