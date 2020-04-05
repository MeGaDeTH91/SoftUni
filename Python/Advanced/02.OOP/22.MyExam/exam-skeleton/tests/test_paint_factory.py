import unittest

from project.factory.paint_factory import PaintFactory


class PaintFactoryTests(unittest.TestCase):

    def setUp(self):
        self.paint_factory = PaintFactory("MS_Paint", 50)

    def test_init_valid_data_should_work_correctly(self):
        self.assertEqual(self.paint_factory.name, "MS_Paint")
        self.assertEqual(self.paint_factory.capacity, 50)

    def test_init_invalid_data_should_work_correctly(self):
        self.paint_factory = PaintFactory(5, "Ala")
        self.assertEqual(self.paint_factory.name, 5)
        self.assertEqual(self.paint_factory.capacity, "Ala")

    def test_add_ingredient_valid_data_should_work_correctly(self):
        self.paint_factory.add_ingredient("white", 10)

        self.assertEqual(self.paint_factory.ingredients["white"], 10)
        self.assertTrue(len(self.paint_factory.products) > 0)

    def test_add_ingredient_invalid_data_should_raise_type_error(self):
        with self.assertRaises(TypeError) as context:
            self.paint_factory.add_ingredient("invalid_color", 5)

        self.assertTrue("Ingredient of type invalid_color not allowed in PaintFactory"
                        in str(context.exception))

    def test_add_ingredient_greater_quantity_should_raise_value_error(self):
        with self.assertRaises(ValueError) as context:
            self.paint_factory.add_ingredient("white", 150)

        self.assertTrue("Not enough space in factory"
                        in str(context.exception))

    def test_remove_ingredient_valid_data_should_work_correctly(self):
        self.paint_factory.add_ingredient("white", 35)

        self.assertEqual(self.paint_factory.ingredients["white"], 35)
        self.assertTrue(len(self.paint_factory.products) > 0)

        self.paint_factory.remove_ingredient("white", 9)
        self.assertEqual(self.paint_factory.ingredients["white"], 26)

    def test_remove_non_existing_ingredient_should_raise_key_error(self):
        self.paint_factory.add_ingredient("white", 35)

        with self.assertRaises(KeyError) as context:
            self.paint_factory.remove_ingredient("yellow", 5)

        self.assertTrue("No such ingredient in the factory"
                        in str(context.exception))

    def test_remove_ingredient_greater_quantity_should_raise_value_error(self):
        self.paint_factory.add_ingredient("white", 35)

        with self.assertRaises(ValueError) as context:
            self.paint_factory.remove_ingredient("white", 80)

        self.assertTrue("Ingredient quantity cannot be less than zero"
                        in str(context.exception))


if __name__ == "__main__":
    unittest.main()
