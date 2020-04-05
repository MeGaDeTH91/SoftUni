class dictionary_iter:
    def __init__(self, dictionary):
        self.dictionary = list(dictionary.items())
        self.index = 0
        self.size = len(self.dictionary)

    def __iter__(self):
        return self

    def __next__(self):
        if self.index < self.size:
            current = self.dictionary[self.index]
            self.index += 1

            return current
        else:
            raise StopIteration


diction = dictionary_iter({1: "1", 2: "2"})
for x in diction:
    print(x)
