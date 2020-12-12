package t_06_animals.animals;

public abstract class Animal {
    private final String name;
    private final int age;
    private final String gender;

    protected Animal(String name, int age, String gender) {
        this.name = name;
        this.age = age;
        this.gender = gender;
    }

    protected abstract String produceSound();

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    public String getGender() {
        return gender;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder(26);

        sb.append(this.getClass().getSimpleName());
        sb.append("\r");
        sb.append("\n");

        sb.append(name);
        sb.append(' ');
        sb.append(age);
        sb.append(' ');
        sb.append(gender);
        sb.append("\r");
        sb.append("\n");

        sb.append(this.produceSound());

        return sb.toString();
    }
}
