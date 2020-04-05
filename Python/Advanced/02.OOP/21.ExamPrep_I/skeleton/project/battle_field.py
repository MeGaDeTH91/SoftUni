from project.player.player import Player


class BattleField:
    def fight(self, attacker: Player, enemy: Player):
        if attacker.is_dead or enemy.is_dead:
            raise ValueError("Player is dead!")

        if attacker.__class__.__name__ == "Beginner":
            attacker.health += 40

            for card in attacker.card_repository.cards:
                card.damage_points += 30

        if enemy.__class__.__name__ == "Beginner":
            enemy.health += 40

            for card in enemy.card_repository.cards:
                card.damage_points += 30

        attacker.health += sum([x.health_points for x in attacker.card_repository.cards])
        enemy.health += sum([x.health_points for x in enemy.card_repository.cards])

        for attacking_card in attacker.card_repository.cards:
            enemy.take_damage(attacking_card.damage_points)

        for enemy_card in enemy.card_repository.cards:
            attacker.take_damage(enemy_card.damage_points)
