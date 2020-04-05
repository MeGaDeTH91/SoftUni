class Hero:
    def __init__(self, username, level):
        self.username = username
        self.level = level

    def __repr__(self):
        return f'{self.username} of type {type(self).__name__} has level {self.level}'


class Elf(Hero):
    pass


class MuseElf(Elf):
    pass


class Wizard(Hero):
    pass


class DarkWizard(Wizard):
    pass


class SoulMaster(DarkWizard):
    pass


class Knight(Hero):
    pass


class DarkKnight(Knight):
    pass


class BladeKnight(DarkKnight):
    pass
