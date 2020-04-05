class Lion:
    def __init__(self, name, gender, age):
        self.name = name
        self.gender = gender
        self.age = age

    def get_needs(self):
        return 50

    def __repr__(self):
        return f'Name: {self.name}, Age: {self.age}, Gender: {self.gender}'


class Tiger:
    def __init__(self, name, gender, age):
        self.name = name
        self.gender = gender
        self.age = age

    def get_needs(self):
        return 45

    def __repr__(self):
        return f'Name: {self.name}, Age: {self.age}, Gender: {self.gender}'


class Cheetah:
    def __init__(self, name, gender, age):
        self.name = name
        self.gender = gender
        self.age = age

    def get_needs(self):
        return 60

    def __repr__(self):
        return f'Name: {self.name}, Age: {self.age}, Gender: {self.gender}'


class Keeper:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def __repr__(self):
        return f'Name: {self.name}, Age: {self.age}, Salary: {self.salary}'


class Caretaker:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def __repr__(self):
        return f'Name: {self.name}, Age: {self.age}, Salary: {self.salary}'


class Vet:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def __repr__(self):
        return f'Name: {self.name}, Age: {self.age}, Salary: {self.salary}'


class Zoo:
    def __init__(self, name, budget, animal_capacity, workers_capacity):
        self.name = name
        self.animals = []
        self.workers = []
        self.__budget = budget
        self.__animal_capacity = animal_capacity
        self.__workers_capacity = workers_capacity

    def add_animal(self, animal, price):
        there_is_enough_capacity = len(self.animals) < self.__animal_capacity

        if there_is_enough_capacity and self.__budget >= price:
            self.animals.append(animal)
            self.__budget -= price
            return f'{animal.name} the {type(animal).__name__} added to the zoo'
        elif there_is_enough_capacity:
            return 'Not enough budget'
        else:
            return 'Not enough space for animal'

    def hire_worker(self, worker):
        if len(self.workers) < self.__workers_capacity:
            self.workers.append(worker)
            return f'{worker.name} the {type(worker).__name__} hired successfully'
        else:
            return 'Not enough space for worker'

    def fire_worker(self, worker_name):
        if worker_name in [x.name for x in self.workers]:
            self.workers = [x for x in self.workers if x.name != worker_name]
            return f'{worker_name} fired successfully'
        else:
            return f'There is no {worker_name} in the zoo'

    def pay_workers(self):
        total_sum = sum([x.salary for x in self.workers])

        if total_sum <= self.__budget:
            self.__budget -= total_sum
            return f'You payed your workers. They are happy. Budget left: {self.__budget}'
        else:
            return 'You have no budget to pay your workers. They are unhappy.'

    def tend_animals(self):
        total_sum = sum([x.get_needs() for x in self.animals])

        if total_sum <= self.__budget:
            self.__budget -= total_sum
            return f'You tended all the animals. They are happy. Budget left: {self.__budget}'
        else:
            return 'You have no budget to tend the animals. They are unhappy.'

    def profit(self, amount):
        if amount > 0:
            self.__budget += amount

    def animals_status(self):
        lions = list(filter(lambda x: type(x).__name__ == 'Lion', self.animals))
        tigers = list(filter(lambda x: type(x).__name__ == 'Tiger', self.animals))
        cheetahs = list(filter(lambda x: type(x).__name__ == 'Cheetah', self.animals))

        result = f'You have {len(self.animals)} animals\n'

        result += f'----- {len(lions)} Lions:\n'
        for lion in lions:
            result += lion.__repr__() + '\n'

        result += f'----- {len(tigers)} Tigers:\n'
        for tiger in tigers:
            result += tiger.__repr__() + '\n'

        result += f'----- {len(cheetahs)} Cheetahs:\n'
        for cheetah in cheetahs:
            result += cheetah.__repr__() + '\n'

        return result

    def workers_status(self):
        keepers = list(filter(lambda x: type(x).__name__ == 'Keeper', self.workers))
        caretakers = list(filter(lambda x: type(x).__name__ == 'Caretaker', self.workers))
        vets = list(filter(lambda x: type(x).__name__ == 'Vet', self.workers))

        result = f'You have {len(self.workers)} workers\n'

        result += f'----- {len(keepers)} Keepers:\n'
        for keeper in keepers:
            result += keeper.__repr__() + '\n'

        result += f'----- {len(caretakers)} Caretakers:\n'
        for caretaker in caretakers:
            result += caretaker.__repr__() + '\n'

        result += f'----- {len(vets)} Vets:\n'
        for vet in vets:
            result += vet.__repr__() + '\n'

        return result
