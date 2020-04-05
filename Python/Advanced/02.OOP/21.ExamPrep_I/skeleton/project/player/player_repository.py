from project.player.player import Player


class PlayerRepository:
    def __init__(self):
        self.count = 0
        self.players = []

    def add(self, player: Player):
        if player.username in [x.username for x in self.players]:
            raise ValueError(f"Player {player.username} already exists!")

        self.players.append(player)
        self.count += 1

    def remove(self, player: str):
        if not player:
            raise ValueError("Player cannot be an empty string!")

        self.players = [x for x in self.players if x.username != player]
        self.count -= 1

    def find(self, username: str):
        return [x for x in self.players if x.username == username][0]
