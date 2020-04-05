import unittest

from project.card.magic_card import MagicCard
from project.card.trap_card import TrapCard
from project.controller import Controller
from project.player.advanced import Advanced
from project.player.beginner import Beginner


class AdvancedTests(unittest.TestCase):
    def test_init_should_work_correctly(self):
        controller = Controller()

        self.assertTrue(controller.card_repository, not None)
        self.assertTrue(controller.player_repository, not None)

    def test_add_player_valid_data_should_work_correctly(self):
        controller = Controller()

        player = Advanced("Dave")

        function_result = controller.add_player("Advanced", "Dave")
        player_result = controller.player_repository.find("Dave")

        self.assertEqual(player.username, player_result.username)
        self.assertEqual(function_result, "Successfully added player of type Advanced with username: Dave")

    def test_add_second_player_valid_data_should_work_correctly(self):
        controller = Controller()

        player = Beginner("Dave")

        function_result = controller.add_player("Beginner", "Dave")
        player_result = controller.player_repository.find("Dave")

        self.assertEqual(player.username, player_result.username)
        self.assertEqual(function_result, "Successfully added player of type Beginner with username: Dave")

    def test_add_player_second_time_valid_data_should_raise_error(self):
        controller = Controller()

        controller.add_player("Beginner", "Dave")
        controller.player_repository.find("Dave")

        with self.assertRaises(ValueError):
            controller.add_player("Beginner", "Dave")

    def test_add_card_valid_data_should_work_correctly(self):
        controller = Controller()

        card = MagicCard("Card")

        function_result = controller.add_card("Magic", "Card")
        card_result = controller.card_repository.find("Card")

        self.assertEqual(card.name, card_result.name)
        self.assertEqual(function_result, "Successfully added card of type MagicCard with name: Card")

    def test_add_card_second_time_should_raise_error(self):
        controller = Controller()

        controller.add_card("Magic", "Card")
        controller.card_repository.find("Card")

        with self.assertRaises(ValueError):
            controller.add_card("Magic", "Card")

    def test_add_second_card_valid_data_should_work_correctly(self):
        controller = Controller()

        card = TrapCard("Card")

        function_result = controller.add_card("Trap", "Card")
        card_result = controller.card_repository.find("Card")

        self.assertEqual(card.name, card_result.name)
        self.assertEqual(function_result, "Successfully added card of type TrapCard with name: Card")

    def test_fight_valid_data_should_work_correctly(self):
        controller = Controller()

        controller.add_card("Magic", "Spell")
        controller.add_card("Magic", "Spell2")

        controller.add_player("Advanced", "Dave")
        controller.add_player("Advanced", "John")

        controller.add_player_card("Dave", "Spell")
        controller.add_player_card("John", "Spell2")

        result = controller.fight("Dave", "John")

        self.assertEqual(result, "Attack user health 325 - Enemy user health 325")

    def test_fight_two_valid_data_should_work_correctly(self):
        controller = Controller()

        controller.add_card("Magic", "Spell")
        controller.add_card("Trap", "Spell2")

        controller.add_player("Advanced", "Dave")
        controller.add_player("Advanced", "John")

        controller.add_player_card("Dave", "Spell")
        controller.add_player_card("John", "Spell2")

        result = controller.fight("Dave", "John")

        with self.assertRaises(Exception):
            controller.add_card("Labala", "Magic")
            controller.add_player("Labala2", "Spell")
            controller.add_player_card("Labala2", "Spell")

        self.assertEqual(result, "Attack user health 210 - Enemy user health 250")

    def test_fight_card_damage_valid_data_should_work_correctly(self):
        controller = Controller()

        add_card1 = controller.add_card("Magic", "Spell")
        add_card2 = controller.add_card("Magic", "Spell2")

        add_player1 = controller.add_player("Advanced", "Dave")
        add_player2 = controller.add_player("Beginner", "John")

        add_player_card1 = controller.add_player_card("Dave", "Spell")
        add_player_card2 = controller.add_player_card("John", "Spell2")

        controller.fight("Dave", "John")

        self.assertEqual(controller.card_repository.cards[1].damage_points, 35)
        self.assertEqual(add_card1, "Successfully added card of type MagicCard with name: Spell")
        self.assertEqual(add_card2, "Successfully added card of type MagicCard with name: Spell2")
        self.assertEqual(add_player1, "Successfully added player of type Advanced with username: Dave")
        self.assertEqual(add_player2, "Successfully added player of type Beginner with username: John")
        self.assertEqual(add_player_card1, "Successfully added card: Spell to user: Dave")
        self.assertEqual(add_player_card2, "Successfully added card: Spell2 to user: John")

    def test_report_valid_data_should_work_correctly(self):
        controller = Controller()

        controller.add_card("Magic", "Magic")
        controller.add_card("Magic", "Magic2")

        controller.add_player("Advanced", "Dave")
        controller.add_player("Advanced", "John")

        controller.add_player_card("Dave", "Magic")
        controller.add_player_card("John", "Magic2")

        self.assertEqual(controller.report(), "Username: Dave - Health: 250 - Cards 1\n### Card: Magic - Damage: 5\nUsername: John - Health: 250 - Cards 1\n### Card: Magic2 - Damage: 5\n")


if __name__ == "__main__":
    unittest.main()
