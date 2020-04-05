import unittest

from project.card.magic_card import MagicCard
from project.card.card_repository import CardRepository


class PlayerRepositoryTests(unittest.TestCase):

    def test_init_valid_data_should_work_correctly(self):
        repository = CardRepository()

        self.assertEqual([repository.count, repository.cards], [0, []])

    def test_add_valid_data_should_work_correctly(self):
        repository = CardRepository()

        card = MagicCard("Dave")

        repository.add(card)

        self.assertEqual(repository.find("Dave"), card)

    def test_add_valid_data_second_time_should_raise_error(self):
        repository = CardRepository()

        card = MagicCard("Dave")

        repository.add(card)

        with self.assertRaises(ValueError):
            repository.add(card)

    def test_add_count_valid_data_should_work_correctly(self):
        repository = CardRepository()

        card = MagicCard("Dave")

        repository.add(card)

        self.assertEqual(repository.count, 1)

    def test_remove_valid_data_should_work_correctly(self):
        repository = CardRepository()

        card = MagicCard("Dave")

        repository.add(card)
        self.assertEqual(repository.count, 1)
        repository.remove("Dave")
        self.assertEqual(repository.count, 0)
        self.assertEqual(len(repository.cards), 0)

    def test_remove_valid_data_second_time_should_raise_error(self):
        repository = CardRepository()

        card = MagicCard("Dave")

        repository.add(card)

        with self.assertRaises(ValueError):
            repository.remove("")

    def test_remove_count_valid_data_should_work_correctly(self):
        repository = CardRepository()

        card = MagicCard("Dave")

        repository.add(card)
        repository.remove("Dave")

        self.assertEqual(repository.count, 0)


if __name__ == "__main__":
    unittest.main()