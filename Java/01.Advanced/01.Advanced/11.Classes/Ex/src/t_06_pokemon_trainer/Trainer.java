package t_06_pokemon_trainer;

import java.util.ArrayList;
import java.util.List;

public class Trainer implements Comparable<Trainer>{
    private final String name;
    private int badges;
    private List<Pokemon> pokemons;

    public Trainer(String name) {
        this.name = name;
        pokemons = new ArrayList<>();
    }

    public void addPokemon(Pokemon pokemon) {
        pokemons.add(pokemon);
    }

    public void checkElement(String element) {
        boolean suchElementExist = false;

        for (Pokemon pokemon: pokemons) {
            if (pokemon.getElement().equals(element)) {
                badges++;
                suchElementExist = true;
                break;
            }
        }

        if (!suchElementExist) {
            pokemons.forEach(Pokemon::decreaseHealth);
            pokemons.removeIf(x -> x.getHealth() <= 0);
        }
    }

    @Override
    public String toString() {
        return String.format("%s %d %d", name, badges, pokemons.size());
    }

    @Override
    public int compareTo(Trainer other) {
        return Integer.compare(other.badges, this.badges);
    }
}
