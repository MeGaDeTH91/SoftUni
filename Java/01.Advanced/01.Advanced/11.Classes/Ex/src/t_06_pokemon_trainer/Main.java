package t_06_pokemon_trainer;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, Trainer> trainers = new LinkedHashMap<>();

        String command;
        String[] tokens;

        String trainerName;
        String pokemonName;
        String pokemonElement;
        int pokemonHealth;
        Pokemon pokemon;
        while (!(command = reader.readLine()).equals("Tournament")) {
            tokens = command.split("\\s+");

            trainerName = tokens[0];
            pokemonName = tokens[1];
            pokemonElement = tokens[2];
            pokemonHealth = Integer.parseInt(tokens[3]);

            if (!trainers.containsKey(trainerName)) {
                trainers.put(trainerName, new Trainer(trainerName));
            }

            pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            trainers.get(trainerName).addPokemon(pokemon);
        }

        while (!(command = reader.readLine()).equals("End")) {
            for (Map.Entry<String, Trainer> currTrainer: trainers.entrySet()) {
                currTrainer.getValue().checkElement(command);
            }
        }

        List<Trainer> result = new ArrayList<>(trainers.values());

        Collections.sort(result);

        for (Trainer currTrainer: result) {
            System.out.println(currTrainer.toString());
        }
    }
}
