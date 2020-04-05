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


import unittest


class IntegerListTests(unittest.TestCase):

    def test_starting_out(self):
        self.assertEqual(1, 1)

    def test_adds_correctly(self):
        my_list = IntegerList()

        self.assertEqual(my_list.add(5), [5])

    def test_adds_non_int_throws_exception(self):
        my_list = IntegerList()

        self.assertRaises(ValueError, lambda: my_list.add("5"))

    def test_removes_element_correctly(self):
        my_list = IntegerList(1, 2, 3)

        self.assertEqual(my_list.remove_index(1), 2)

    def test_removes_non_existing_element_throws_exception(self):
        my_list = IntegerList(1, 2, 3)

        self.assertRaises(IndexError, lambda: my_list.remove_index(5))

    def test_gets_element_correctly(self):
        my_list = IntegerList(1, 2, 3)

        self.assertEqual(my_list.get(1), 2)

    def test_gets_non_existing_element_throws_exception(self):
        my_list = IntegerList(1, 2, 3)

        self.assertRaises(IndexError, lambda: my_list.get(5))

    def test_gets_data_correctly(self):
        my_list = IntegerList(5)

        self.assertEqual(my_list.get_data(), [5])


def main():
    unittest.main()


if __name__ == "__main__":
    main()
