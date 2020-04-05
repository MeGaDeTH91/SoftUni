class Hero:
    name = ''
    health = 0

    def __init__(self, name, health):
        self.name = name
        self.health = health

    def heal(self, points):
        self.health += points

    def defend(self, points):
        self.health -= points

        if self.health <= 0:
            self.health = 0
            return f'{self.name} was defeated'
        else:
            return None
