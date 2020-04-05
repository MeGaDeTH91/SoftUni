from project.factory.chocolate_factory import ChocolateFactory
from project.factory.egg_factory import EggFactory
from project.factory.paint_factory import PaintFactory


class EasterShop:
    def __init__(self, name: str, chocolate_factory: ChocolateFactory,
                 egg_factory: EggFactory, paint_factory: PaintFactory):
        self.name = name
        self.chocolate_factory = chocolate_factory
        self.egg_factory = egg_factory
        self.paint_factory = paint_factory
        self.storage = {}

    def add_chocolate_ingredient(self, type: str, quantity: int):
        self.chocolate_factory.add_ingredient(type, quantity)

    def add_egg_ingredient(self, type: str, quantity: int):
        self.egg_factory.add_ingredient(type, quantity)

    def add_paint_ingredient(self, type: str, quantity: int):
        self.paint_factory.add_ingredient(type, quantity)

    def make_chocolate(self, recipe: str):
        self.chocolate_factory.make_chocolate(recipe)
        self.storage[recipe] = self.chocolate_factory.products[recipe]

    def paint_egg(self, color: str, egg_type: str):
        if color not in self.paint_factory.ingredients or self.paint_factory.ingredients[color] < 1:
            raise ValueError("Invalid commands")

        if egg_type not in self.egg_factory.ingredients or self.egg_factory.ingredients[egg_type] < 1:
            raise ValueError("Invalid commands")

        current_key = f'{color} {egg_type}'

        if current_key not in self.storage:
            self.storage[current_key] = 0

        self.storage[current_key] += 1

    def __repr__(self):
        result = ''

        result += f'Shop name: {self.name}\n'
        result += f'Shop Storage:\n'

        for key, value in self.storage.items():
            result += f'{key}: {value}\n'

        return result
