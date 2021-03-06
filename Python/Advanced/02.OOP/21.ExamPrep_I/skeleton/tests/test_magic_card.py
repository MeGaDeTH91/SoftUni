import unittest

from project.card.magic_card import MagicCard


class MagicCardTests(unittest.TestCase):

    def test_init_valid_data_should_work_correctly(self):
        card = MagicCard("TestCard")

        self.assertEqual([card.name, card.damage_points, card.health_points], ["TestCard", 5, 80])

    def test_init_invalid_data_should_raise_error(self):
        with self.assertRaises(ValueError):
            MagicCard("")

    def test_name_valid_data_should_work_correctly(self):
        card = MagicCard("TestCard")

        card.name = "Pesho"
        self.assertEqual(card.name, "Pesho")

    def test_name_invalid_data_should_raise_error(self):
        card = MagicCard("TestCard")

        with self.assertRaises(ValueError):
            card.name = ""

    def test_damage_points_valid_data_should_work_correctly(self):
        card = MagicCard("TestCard")
        card.damage_points = 8

        self.assertEqual(card.damage_points, 8)

    def test_damage_points_increase_valid_data_should_work_correctly(self):
        card = MagicCard("TestCard")
        card.damage_points += 8

        self.assertEqual(card.damage_points, 13)

    def test_damage_points_invalid_data_should_raise_error(self):
        card = MagicCard("TestCard")

        with self.assertRaises(ValueError):
            card.damage_points = -1

    def test_health_points_valid_data_should_work_correctly(self):
        card = MagicCard("TestCard")
        card.health_points = 8

        self.assertEqual(card.health_points, 8)

    def test_health_points_invalid_data_should_raise_error(self):
        card = MagicCard("TestCard")

        with self.assertRaises(ValueError):
            card.health_points = -1


if __name__ == "__main__":
    unittest.main()
