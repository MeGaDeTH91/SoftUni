class Car:
    def __init__(self, make, model, fuel_consumption, fuel_capacity):
        self.make = make
        self.model = model
        self.fuel_consumption = fuel_consumption
        self.fuel_capacity = fuel_capacity
        self.fuel_amount = 0

    @property
    def make(self):
        return self.__make

    @make.setter
    def make(self, new_value):
        if not new_value:
            raise Exception("Make cannot be null or empty!")
        self.__make = new_value

    @property
    def model(self):
        return self.__model

    @model.setter
    def model(self, new_value):
        if not new_value:
            raise Exception("Model cannot be null or empty!")
        self.__model = new_value

    @property
    def fuel_consumption(self):
        return self.__fuel_consumption

    @fuel_consumption.setter
    def fuel_consumption(self, new_value):
        if new_value <= 0:
            raise Exception("Fuel consumption cannot be zero or negative!")
        self.__fuel_consumption = new_value

    @property
    def fuel_capacity(self):
        return self.__fuel_capacity

    @fuel_capacity.setter
    def fuel_capacity(self, new_value):
        if new_value <= 0:
            raise Exception("Fuel capacity cannot be zero or negative!")
        self.__fuel_capacity = new_value

    @property
    def fuel_amount(self):
        return self.__fuel_amount

    @fuel_amount.setter
    def fuel_amount(self, new_value):
        if new_value < 0:
            raise Exception("Fuel amount cannot be negative!")
        self.__fuel_amount = new_value

    def refuel(self, fuel):
        if fuel <= 0:
            raise Exception("Fuel amount cannot be zero or negative!")
        self.__fuel_amount += fuel
        if self.__fuel_amount > self.__fuel_capacity:
            self.__fuel_amount = self.__fuel_capacity

    def drive(self, distance):
        needed = (distance / 100) * self.__fuel_consumption

        if needed > self.__fuel_amount:
            raise Exception("You don't have enough fuel to drive!")

        self.__fuel_amount -= needed


import unittest


class CarTests(unittest.TestCase):

    def test_constructor_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        res = [car.make, car.model, car.fuel_consumption, car.fuel_capacity]

        self.assertEqual(res, ["Honda", "Accord", 8, 60])

    def test_car_make_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        car.make = "Honda"

        self.assertEqual(car.make, "Honda")

    def test_car_make_empty_str_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.make = ""

    def test_car_make_none_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.make = None

    def test_car_model_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        car.model = "Accord"

        self.assertEqual(car.model, "Accord")

    def test_car_model_empty_str_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.model = ""

    def test_car_model_none_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.model = None

    def test_car_fuel_consumption_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        car.fuel_consumption = 8

        self.assertEqual(car.fuel_consumption, 8)

    def test_car_fuel_consumption_zero_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.fuel_consumption = 0

    def test_car_fuel_consumption_negative_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.fuel_consumption = -5

    def test_car_fuel_capacity_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        car.fuel_capacity = 60

        self.assertEqual(car.fuel_capacity, 60)

    def test_car_fuel_capacity_zero_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.fuel_capacity = 0

    def test_car_fuel_capacity_negative_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.fuel_capacity = -5

    def test_car_fuel_amount_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        car.fuel_amount = 25

        self.assertEqual(car.fuel_amount, 25)

    def test_car_fuel_amount_negative_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.fuel_amount = -5

    def test_car_refuel_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        car.refuel(25)

        self.assertEqual(car.fuel_amount, 25)

    def test_car_refuel_negative_amount_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)

        with self.assertRaises(Exception):
            car.refuel(-25)

    def test_car_drive_should_work_correctly(self):
        car = Car("Honda", "Accord", 8, 60)

        car.refuel(60)
        car.drive(300)

        self.assertEqual(car.fuel_amount, 36)

    def test_car_drive_not_enough_fuel_amount_should_throw_exception(self):
        car = Car("Honda", "Accord", 8, 60)
        car.refuel(1)

        with self.assertRaises(Exception):
            car.drive(100)


if __name__ == "__main__":
    unittest.main()
