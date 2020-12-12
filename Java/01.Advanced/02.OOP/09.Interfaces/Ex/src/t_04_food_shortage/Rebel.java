package t_04_food_shortage;

public class Rebel implements Person, Buyer, Groupable{
    private String name;
    private int age;
    private int food;
    private String group;

    public Rebel(String name, int age, String group) {
        this.name = name;
        this.age = age;
        this.group = group;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public int getAge() {
        return age;
    }


    @Override
    public void buyFood() {
        food += 5;
    }

    @Override
    public int getFood() {
        return food;
    }

    @Override
    public String getGroup() {
        return group;
    }
}
