package vetClinic;

import java.util.*;

public class Clinic {
    private List<Pet> data;
    private int capacity;

    public Clinic(int capacity) {
        this.capacity = capacity;
        data = new ArrayList<>();
    }

    public void add(Pet pet) {
        if (data.size() + 1 <= capacity) {
            data.add(pet);
        }
    }

    public boolean remove(String name) {
        Pet pet = data.stream().filter(x -> x.getName().equals(name)).findFirst().orElse(null);

        return data.remove(pet);
    }

    public Pet getPet(String name, String owner) {
        return data.stream()
                .filter(x -> x.getName().equals(name) && x.getOwner().equals(owner))
                .findFirst().orElse(null);
    }

    public Pet getOldestPet() {
        return Collections.max(data, Comparator.comparing(Pet::getAge));
    }

    public int getCount() {
        return data.size();
    }

    public String getStatistics() {
        StringBuilder sb = new StringBuilder(44);

        sb.append("The clinic has the following patients:").append(System.lineSeparator());

        for (Pet pet: data) {
            sb.append(pet.getName()).append(' ').append(pet.getOwner()).append(System.lineSeparator());
        }

        return sb.toString().trim();
    }
}
