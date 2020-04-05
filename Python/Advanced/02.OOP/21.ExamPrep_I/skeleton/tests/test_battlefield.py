import unittest

from project.battle_field import BattleField
from project.card.magic_card import MagicCard
from project.player.advanced import Advanced
from project.player.beginner import Beginner


class MagicCardTests(unittest.TestCase):

    def test_fight_valid_data_should_work_correctly(self):
        battlefield = BattleField()

        attacker = Advanced("Dave")
        enemy = Advanced("John")

        first_card = MagicCard("Magic")
        second_card = MagicCard("Magic")

        attacker.card_repository.cards.append(first_card)
        enemy.card_repository.cards.append(second_card)

        battlefield.fight(attacker, enemy)

        self.assertEqual(attacker.health, 325)
        self.assertEqual(enemy.health, 325)

    def test_fight_invalid_data_should_raise_error(self):
        battlefield = BattleField()

        attacker = Advanced("Dave")
        enemy = Advanced("John")

        first_card = MagicCard("Magic")
        second_card = MagicCard("Magic")

        attacker.card_repository.cards.append(first_card)
        enemy.card_repository.cards.append(second_card)

        attacker.take_damage(250)

        with self.assertRaises(ValueError):
            battlefield.fight(attacker, enemy)

    def test_fight_cards_data_should_work_correctly(self):
        battlefield = BattleField()

        attacker = Beginner("Dave")
        enemy = Advanced("John")

        first_card = MagicCard("Magic")
        second_card = MagicCard("Magic")

        attacker.card_repository.add(first_card)
        enemy.card_repository.add(second_card)

        battlefield.fight(attacker, enemy)

        attacker_card_dmg = attacker.card_repository.cards[0].damage_points
        enemy_card_dmg = enemy.card_repository.cards[0].damage_points

        self.assertEqual(attacker_card_dmg, 35)
        self.assertEqual(enemy_card_dmg, 5)

    def test_fight_one_player_dies_valid_data_should_work_correctly(self):
        battlefield = BattleField()

        attacker = Advanced("Dave")
        enemy = Beginner("John")

        common_card = MagicCard("Magic")

        attacker.card_repository.cards.append(common_card)
        enemy.card_repository.cards.append(common_card)
        enemy.take_damage(50)

        with self.assertRaises(ValueError):
            battlefield.fight(attacker, enemy)


if __name__ == "__main__":
    unittest.main()
