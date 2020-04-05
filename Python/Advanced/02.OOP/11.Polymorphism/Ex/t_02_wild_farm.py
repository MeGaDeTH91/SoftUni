from abc import ABC, abstractmethod


class Food(ABC):
    def __init__(self, quantity):
        self.quantity = quantity


class Vegetable(Food):
    pass


class Fruit(Food):
    pass


class Meat(Food):
    pass


class Seed(Food):
    pass


class Animal(ABC):
    def __init__(self, name, weight):
        self.name = name
        self.weight = weight
        self.food_eaten = 0

    @abstractmethod
    def make_sound(self):
        pass

    @abstractmethod
    def feed(self, food):
        pass


class Bird(Animal, ABC):
    def __init__(self, name, weight, wing_size):
        Animal.__init__(self, name, weight)
        self.wing_size = wing_size

    def __repr__(self):
        return f'{type(self).__name__} [{self.name}, {self.wing_size}, {self.weight}, {self.food_eaten}]'


class Owl(Bird):
    def make_sound(self):
        return 'Hoot Hoot'

    def feed(self, food):
        food_type = type(food).__name__

        if food_type == 'Meat':
            self.weight += food.quantity * 0.25
            self.food_eaten += food.quantity
        else:
            return f'Owl does not eat {food_type}!'


class Hen(Bird):
    def make_sound(self):
        return 'Cluck'

    def feed(self, food):
        self.weight += food.quantity * 0.35
        self.food_eaten += food.quantity


class Mammal(Animal, ABC):
    def __init__(self, name, weight, living_region):
        Animal.__init__(self, name, weight)
        self.living_region = living_region

    def __repr__(self):
        return f'{type(self).__name__} [{self.name}, {self.weight}, {self.living_region}, {self.food_eaten}]'


class Mouse(Mammal):
    def make_sound(self):
        return 'Squeak'

    def feed(self, food):
        food_type = type(food).__name__

        if food_type == 'Vegetable' or food_type == 'Fruit':
            self.weight += food.quantity * 0.10
            self.food_eaten += food.quantity
        else:
            return f'Mouse does not eat {food_type}!'


class Dog(Mammal):
    def make_sound(self):
        return 'Woof!'

    def feed(self, food):
        food_type = type(food).__name__

        if food_type == 'Meat':
            self.weight += food.quantity * 0.40
            self.food_eaten += food.quantity
        else:
            return f'Dog does not eat {food_type}!'


class Cat(Mammal):
    def make_sound(self):
        return 'Meow'

    def feed(self, food):
        food_type = type(food).__name__

        if food_type == 'Meat' or food_type == 'Vegetable':
            self.weight += food.quantity * 0.30
            self.food_eaten += food.quantity
        else:
            return f'Cat does not eat {food_type}!'


class Tiger(Mammal):
    def make_sound(self):
        return 'ROAR!!!'

    def feed(self, food):
        food_type = type(food).__name__

        if food_type == 'Meat':
            self.weight += food.quantity * 1.00
            self.food_eaten += food.quantity
        else:
            return f'Tiger does not eat {food_type}!'
