package t_03_wild_farm.animals;

import java.text.DecimalFormat;

public abstract class Mammal extends Animal {
    private final String livingRegion;

    public Mammal(String animalName, String animalType, double animalWeight, String livingRegion) {
        super(animalName, animalType, animalWeight);
        this.livingRegion = livingRegion;
    }

    protected String getLivingRegion() {
        return livingRegion;
    }

    @Override
    public String toString() {
        DecimalFormat df = new DecimalFormat("0.##");

        return String.format("%s[%s, %s, %s, %d]", this.getAnimalType(), this.getAnimalName(),
                df.format(this.getAnimalWeight()), this.livingRegion, this.getFoodEaten());
    }
}
