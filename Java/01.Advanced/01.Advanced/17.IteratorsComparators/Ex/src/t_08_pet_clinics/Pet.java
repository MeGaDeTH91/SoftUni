package t_08_pet_clinics;

public class Pet implements Comparable<Pet>{
    private final String name;

    private final int age;

    private final String kind;

    public Pet(String name, int age, String kind)
    {
        this.name = name;
        this.age = age;
        this.kind = kind;
    }

    @Override
    public String toString()
    {
        return String.format("%s %d %s", name, age, kind);
    }

    public int compareTo(Pet other) {
        int result = this.name.compareTo(other.name);

        if (result == 0)
        {
            return Integer.compare(this.age, other.age);
        }

        return result;
    }
}
