import math


class Circle:
    pi = 3.14

    def __init__(self, radius):
        self.radius = radius

    def set_radius(self, new_radius):
        self.radius = new_radius

    def get_area(self):
        return self.pi * math.pow(self.radius, 2)

    def get_circumference(self):
        return 2 * self.pi * self.radius
