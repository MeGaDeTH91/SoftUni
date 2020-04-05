import unittest

from project.player.beginner import Beginner


class BeginnerTests(unittest.TestCase):

    def test_init_valid_data_should_work_correctly(self):
        player = Beginner("Dave")

        self.assertEqual([player.username, player.health], ["Dave", 50])

    def test_init_invalid_data_should_raise_error(self):
        with self.assertRaises(ValueError):
            Beginner("")

    def test_username_valid_data_should_work_correctly(self):
        player = Beginner("Dave")
        player.username = "Cool"

        self.assertEqual(player.username, "Cool")

    def test_username_invalid_data_should_raise_error(self):
        player = Beginner("Dave")

        with self.assertRaises(ValueError):
            player.username = ""

    def test_health_valid_data_should_work_correctly(self):
        player = Beginner("Dave")

        player.health = 50

        self.assertEqual(player.health, 50)

    def test_health_invalid_data_should_raise_error(self):
        player = Beginner("Dave")

        with self.assertRaises(ValueError):
            player.health = -10

    def test_is_dead_negative_valid_data_should_work_correctly(self):
        player = Beginner("Dave")

        self.assertEqual(player.is_dead, False)

    def test_is_dead_positive_valid_data_should_work_correctly(self):
        player = Beginner("Dave")

        player.take_damage(50)

        self.assertEqual(player.is_dead, True)

    def test_take_damage_valid_data_should_work_correctly(self):
        player = Beginner("Dave")

        player.take_damage(10)

        self.assertEqual(player.health, 40)

    def test_take_damage_invalid_data_should_raise_error(self):
        player = Beginner("Dave")

        with self.assertRaises(ValueError):
            player.take_damage(-10)


if __name__ == "__main__":
    unittest.main()
