import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.TreeMap;

public class t_14_dragon_army {
    private static final BufferedReader reader;
    private static final Map<String, Map<String, Dragon>> dragons;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        dragons = new LinkedHashMap<>();
    }

    public static void main(String[] args) throws IOException {
        int dragonsCount = Integer.parseInt(reader.readLine());

        String[] lineTokens;
        String dragonType;
        String dragonName;
        int dragonDamage;
        int dragonHealth;
        int dragonArmor;
        for (int i = 0; i < dragonsCount; i++) {
            lineTokens = reader.readLine().split("\\s+");

            dragonType = lineTokens[0];
            dragonName = lineTokens[1];
            dragonDamage = lineTokens[2].equals("null") ? 45 : Integer.parseInt(lineTokens[2]);
            dragonHealth = lineTokens[3].equals("null") ? 250 : Integer.parseInt(lineTokens[3]);
            dragonArmor = lineTokens[4].equals("null") ? 10 : Integer.parseInt(lineTokens[4]);

            if (!dragons.containsKey(dragonType)) {
                dragons.put(dragonType, new TreeMap<>());
            }

            Dragon dragon = new Dragon(dragonName, dragonDamage, dragonHealth, dragonArmor);
            dragons.get(dragonType).put(dragonName, dragon);
        }

        double overallDmg;
        double overallHealth;
        double overallArmor;
        double dragonTypeMembers;
        Dragon currentDragon;
        for (Map.Entry<String, Map<String, Dragon>> currDragonType: dragons.entrySet()) {
            dragonTypeMembers = currDragonType.getValue().size();
            overallDmg = currDragonType.getValue().values().stream().mapToDouble(x -> x.damage).reduce(0, Double::sum) / dragonTypeMembers;
            overallHealth = currDragonType.getValue().values().stream().mapToDouble(x -> x.health).reduce(0, Double::sum) / dragonTypeMembers;
            overallArmor = currDragonType.getValue().values().stream().mapToDouble(x -> x.armor).reduce(0, Double::sum) / dragonTypeMembers;

            System.out.printf("%s::(%.2f/%.2f/%.2f)%n", currDragonType.getKey(), overallDmg, overallHealth, overallArmor);

            for (Map.Entry<String, Dragon> currentDragonPair: currDragonType.getValue().entrySet()) {
                currentDragon = currentDragonPair.getValue();
                System.out.printf("-%s -> damage: %d, health: %d, armor: %d%n", currentDragon.name, currentDragon.damage, currentDragon.health, currentDragon.armor);
            }
        }
    }

    private static class Dragon {
        private final String name;
        private final int damage;
        private final int health;
        private final int armor;

        public Dragon(String name, int damage, int health, int armor) {
            this.name = name;
            this.damage = damage;
            this.health = health;
            this.armor = armor;
        }
    }
}
