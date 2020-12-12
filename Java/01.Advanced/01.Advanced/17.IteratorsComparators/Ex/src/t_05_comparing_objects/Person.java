package t_05_comparing_objects;

public class Person implements Comparable<Person>{
    private final String name;
    private final int age;
    private final String town;

    public Person(String name, int age, String town) {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    @Override
    public int compareTo(Person other) {
        int result = this.name.compareTo(other.name);

        if (result == 0) {
            result = Integer.compare(this.age, other.age);
        }

        if (result == 0) {
            return this.town.compareTo(other.town);
        }

        return result;
    }
}
