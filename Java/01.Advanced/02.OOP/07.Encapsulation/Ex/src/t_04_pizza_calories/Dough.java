package t_04_pizza_calories;

public class Dough {
    private String flourType;
    private String bakingTechnique;
    private double weight;

    public Dough(String flourType, String bakingTechnique, double weight) {
        this.setFlourType(flourType);
        this.setBakingTechnique(bakingTechnique);
        this.setWeight(weight);
    }

    public double calculateCalories() {
        double totalCalories = weight * 2.0;

        if (flourType.equals("White")) {
            totalCalories *= 1.5;
        }
        if (bakingTechnique.equals("Crispy")) {
            totalCalories *= 0.9;
        }
        if (bakingTechnique.equals("Chewy")) {
            totalCalories *= 1.1;
        }

        return totalCalories;
    }

    private void setFlourType(String flourType) {
        if (flourType == null || flourType.trim().isEmpty() || (!flourType.equals("White") && !flourType.equals("Wholegrain"))) {
            throw new IllegalArgumentException("Invalid type of dough.");
        }
        this.flourType = flourType;
    }

    private void setBakingTechnique(String bakingTechnique) {
        if (bakingTechnique == null || bakingTechnique.trim().isEmpty() || (!bakingTechnique.equals("Crispy") && !bakingTechnique.equals("Chewy") && !bakingTechnique.equals("Homemade"))) {
            throw new IllegalArgumentException("Invalid type of dough.");
        }
        this.bakingTechnique = bakingTechnique;
    }

    private void setWeight(double weight) {
        if (weight < 1 || weight > 200) {
            throw new IllegalArgumentException("t_04_pizza_calories.Dough weight should be in the range [1..200].");
        }
        this.weight = weight;
    }
}
