package t_06_pokemon_trainer;

public class Pokemon {
    private final String name;
    private final String element;
    private int health;

    public Pokemon(String name, String element, int health) {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public void decreaseHealth() {
        health -= 10;
    }

    public String getElement() {
        return element;
    }

    public int getHealth() {
        return health;
    }
}
