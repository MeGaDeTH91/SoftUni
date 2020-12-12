package t_07_google;

import java.util.ArrayList;
import java.util.List;

public class Person {
    private final String name;
    private Company company;
    private Car car;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;

    public Person(String name) {
        this.name = name;
        this.pokemons = new ArrayList<>();
        this.parents = new ArrayList<>();
        this.children = new ArrayList<>();
    }

    public void setCompany(Company company) {
        this.company = company;
    }

    public void setCar(Car car) {
        this.car = car;
    }

    public void addPokemon(Pokemon pokemon) {
        pokemons.add(pokemon);
    }

    public void addParent(Parent parent) {
        parents.add(parent);
    }

    public void addChild(Child child) {
        children.add(child);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder(53);

        sb.append(name).append("\n");
        sb.append("Company:\n");
        if (company != null) {
            sb.append(company.toString());
        }

        sb.append("Car:\n");
        if (car != null) {
            sb.append(car.toString());
        }

        sb.append("Pokemon:\n");
        for (Pokemon currPokemon: pokemons) {
            sb.append(currPokemon.toString());
        }

        sb.append("Parents:\n");
        for (Parent currParent: parents) {
            sb.append(currParent.toString());
        }

        sb.append("Children:\n");
        for (Child currChild: children) {
            sb.append(currChild.toString());
        }

        return sb.toString();
    }
}
