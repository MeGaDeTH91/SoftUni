class take_skip:
    def __init__(self, step, count):
        self.step = step
        self.count = count
        self.count_amount = 0

    def __iter__(self):
        return self

    def __next__(self):
        if self.count_amount < self.count * self.step:
            result = self.count_amount
            self.count_amount += self.step
            return result
        else:
            raise StopIteration
