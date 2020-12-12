package t_03_wild_farm.factories;


import t_03_wild_farm.animals.Animal;
import t_03_wild_farm.animals.Mouse;
import t_03_wild_farm.animals.Zebra;
import t_03_wild_farm.animals.Cat;
import t_03_wild_farm.animals.Tiger;

public class AnimalFactory {
    public static Animal createAnimal(String[] tokens) {
        String animalType = tokens[0];
        String animalName = tokens[1];
        double animalWeight = Double.parseDouble(tokens[2]);
        String animalRegion = tokens[3];

        Animal createdAnimal;

        switch (animalType) {
            case "Mouse":
                createdAnimal = new Mouse(animalName, animalType, animalWeight, animalRegion);
                break;
            case "Zebra":
                createdAnimal = new Zebra(animalName, animalType, animalWeight, animalRegion);
                break;
            case "Cat":
                createdAnimal = new Cat(animalName, animalType, animalWeight, animalRegion, tokens[4]);
                break;
            case "Tiger":
                createdAnimal = new Tiger(animalName, animalType, animalWeight, animalRegion);
                break;
            default:
                throw new IllegalArgumentException("Invalid animal type.");
        }

        return createdAnimal;
    }
}
