package t_03_birthday_celebrations;

public class Pet implements Birthable {
    private String name;
    private String birthDate;

    public Pet(String name, String birthDate) {
        this.name = name;
        this.birthDate = birthDate;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public String getBirthDate() {
        return birthDate;
    }
}
