package t_03_wild_farm;

import t_03_wild_farm.animals.Animal;
import t_03_wild_farm.factories.AnimalFactory;
import t_03_wild_farm.factories.FoodFactory;
import t_03_wild_farm.foods.Food;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        List<Animal> animals = new ArrayList<>(17);

        String line;
        String[] animalTokens;
        Animal currentAnimal;
        Food currentFood;
        while(!(line = reader.readLine()).equals("End")) {
            animalTokens = line.split("\\s+");
            currentAnimal = AnimalFactory.createAnimal(animalTokens);
            currentFood = FoodFactory.createFood(reader.readLine().split("\\s+"));

            currentAnimal.makeSound();
            currentAnimal.eat(currentFood);

            animals.add(currentAnimal);
        }

        animals.forEach(System.out::println);
    }
}
