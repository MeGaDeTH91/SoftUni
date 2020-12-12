package t_07_google;

public class Parent {
    private final String name;
    private final String birthDate;

    public Parent(String name, String birthDate) {
        this.name = name;
        this.birthDate = birthDate;
    }

    @Override
    public String toString() {
        return String.format("%s %s%n", name, birthDate);
    }
}
