package t_02_animal_farm;

public class Chicken {
    private String name;
    private int age;

    public Chicken(String name, int age) {
        this.setName(name);
        this.setAge(age);
    }

    public double productPerDay() {
        return this.calculateProductPerDay();
    }

    private double calculateProductPerDay() {
        double eggsPerDay;

        if (age <= 5) {
            eggsPerDay = 2;
        } else if (age <= 11) {
            eggsPerDay = 1;
        } else {
            eggsPerDay = 0.75;
        }

        return eggsPerDay;
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    @Override
    public String toString() {
        return String.format("t_02_animal_farm.Chicken %s (age %d) can produce %.2f eggs per day.", name, age, productPerDay());
    }

    private void setName(String name) {
        if (name == null || name.isEmpty()) {
            throw new IllegalArgumentException("Name cannot be empty.");
        }

        this.name = name;
    }

    private void setAge(int age) {
        if (age < 0 || age > 15) {
            throw new IllegalArgumentException("Age should be between 0 and 15.");
        }

        this.age = age;
    }
}
