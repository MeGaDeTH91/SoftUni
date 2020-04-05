import unittest

from project.player.advanced import Advanced


class AdvancedTests(unittest.TestCase):

    def test_init_valid_data_should_work_correctly(self):
        player = Advanced("Dave")

        self.assertEqual([player.username, player.health], ["Dave", 250])

    def test_init_invalid_data_should_raise_error(self):
        with self.assertRaises(ValueError):
            Advanced("")

    def test_username_valid_data_should_work_correctly(self):
        player = Advanced("Dave")
        player.username = "Cool"

        self.assertEqual(player.username, "Cool")

    def test_username_invalid_data_should_raise_error(self):
        player = Advanced("Dave")

        with self.assertRaises(ValueError):
            player.username = ""

    def test_health_valid_data_should_work_correctly(self):
        player = Advanced("Dave")

        player.health = 50

        self.assertEqual(player.health, 50)

    def test_health_invalid_data_should_raise_error(self):
        player = Advanced("Dave")

        with self.assertRaises(ValueError):
            player.health = -10

    def test_is_dead_negative_valid_data_should_work_correctly(self):
        player = Advanced("Dave")

        self.assertEqual(player.is_dead, False)

    def test_is_dead_positive_valid_data_should_work_correctly(self):
        player = Advanced("Dave")

        player.take_damage(250)

        self.assertEqual(player.is_dead, True)

    def test_take_damage_valid_data_should_work_correctly(self):
        player = Advanced("Dave")

        player.take_damage(10)

        self.assertEqual(player.health, 240)

    def test_take_damage_invalid_data_should_raise_error(self):
        player = Advanced("Dave")

        with self.assertRaises(ValueError):
            player.take_damage(-10)

    def test_take_damage_to_death_valid_data_should_raise_error(self):
        player = Advanced("Dave")

        with self.assertRaises(ValueError):
            player.take_damage(500)

        self.assertEqual(player.is_dead, False)


if __name__ == "__main__":
    unittest.main()
