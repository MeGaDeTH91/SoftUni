import unittest

from project.player.advanced import Advanced
from project.player.beginner import Beginner
from project.player.player_repository import PlayerRepository


class PlayerRepositoryTests(unittest.TestCase):
    def test_init_valid_data_should_work_correctly(self):
        repository = PlayerRepository()

        self.assertEqual([repository.count, repository.players], [0, []])

    def test_add_valid_data_should_work_correctly(self):
        repository = PlayerRepository()

        player = Beginner("Dave")

        repository.add(player)

        self.assertEqual(repository.find("Dave"), player)

    def test_add_valid_data_second_time_should_raise_error(self):
        repository = PlayerRepository()

        player = Beginner("Dave")

        repository.add(player)

        with self.assertRaises(ValueError):
            repository.add(player)

    def test_add_count_valid_data_should_work_correctly(self):
        repository = PlayerRepository()

        player = Beginner("Dave")

        repository.add(player)

        self.assertEqual(repository.count, 1)

    def test_remove_valid_data_should_work_correctly(self):
        repository = PlayerRepository()

        player = Advanced("Dave")

        repository.add(player)
        self.assertEqual(repository.count, 1)
        repository.remove("Dave")
        self.assertEqual(repository.count, 0)
        self.assertEqual(len(repository.players), 0)

    def test_remove_valid_data_second_time_should_raise_error(self):
        repository = PlayerRepository()

        player = Beginner("Dave")

        repository.add(player)

        with self.assertRaises(ValueError):
            repository.remove("")

    def test_remove_non_existing_should_raise_error(self):
        repository = PlayerRepository()

        player = Beginner("Dave")

        repository.add(player)

        repository.remove("Gosho")

    def test_remove_count_valid_data_should_work_correctly(self):
        repository = PlayerRepository()

        player = Beginner("Dave")

        repository.add(player)
        repository.remove("Dave")

        self.assertEqual(repository.count, 0)


if __name__ == "__main__":
    unittest.main()
