class IntegerList:
    def __init__(self, *args):
        self.__data = []
        for x in args:
            if type(x) == int:
                self.__data.append(x)

    def get_data(self):
        return self.__data

    def add(self, element):
        if not type(element) == int:
            raise ValueError("Element is not Integer")
        self.get_data().append(element)
        return self.get_data()

    def remove_index(self, index):
        if index >= len(self.get_data()):
            raise IndexError("Index is out of range")
        a = self.get_data()[index]
        del self.get_data()[index]
        return a

    def get(self, index):
        if index >= len(self.get_data()):
            raise IndexError("Index is out of range")
        return self.get_data()[index]

    def insert(self, index, el):
        if index >= len(self.get_data()):
            raise IndexError("Index is out of range")
        elif not type(el) == int:
            raise ValueError("Element is not Integer")

        self.get_data().insert(index, el)

    def get_biggest(self):
        a = sorted(self.get_data(), reverse=True)
        return a[0]

    def get_index(self, el):
        return self.get_data().index(el)


import unittest


class IntegerListTests(unittest.TestCase):
    def test_inserts_correctly(self):
        my_list = IntegerList(1)
        my_list.insert(0, 5)

        self.assertEqual([5, 1], my_list.get_data())

    def test_inserts_non_existing_index_throws_exception(self):
        my_list = IntegerList()

        self.assertRaises(IndexError, lambda: my_list.insert(2, 5))

    def test_inserts_non_int_throws_exception(self):
        my_list = IntegerList(1)

        self.assertRaises(ValueError, lambda: my_list.insert(1, "5"))

    def test_get_biggest_should_work_correctly(self):
        my_list = IntegerList(1, 2, 3, 800)

        self.assertEqual(my_list.get_biggest(), 800)

    def test_get_element_on_index_should_work_correctly(self):
        my_list = IntegerList(1, 2, 3, 5, 8)

        self.assertEqual(my_list.get_index(5), 3)


def main():
    unittest.main()


if __name__ == "__main__":
    main()
