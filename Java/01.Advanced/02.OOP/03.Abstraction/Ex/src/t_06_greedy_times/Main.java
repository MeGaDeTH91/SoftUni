
package t_06_greedy_times;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        long bagCapacity = Long.parseLong(scanner.nextLine());

        String[] safeContent = scanner.nextLine().split("\\s+");

        var bag = new LinkedHashMap<String, LinkedHashMap<String, Long>>();
        long goldAmount = 0;
        long gemAmount = 0;
        long cashAmount = 0;

        for (int i = 0; i < safeContent.length; i += 2) {
            String name = safeContent[i];
            long currentQuantity = Long.parseLong(safeContent[i + 1]);

            String currentItem;

            if (bagCapacity - currentQuantity < 0) {
                continue;
            } else if (name.length() == 3) {
                currentItem = "Cash";
            } else if (name.length() >= 4 && name.toLowerCase().endsWith("gem")) {
                currentItem = "Gem";
            } else if (name.toLowerCase().equals("gold")) {
                currentItem = "Gold";
            } else {
                continue;
            }

            switch (currentItem) {
                case "Gem":
                    if (goldAmount < gemAmount + currentQuantity) {
                        continue;
                    }
                    gemAmount += currentQuantity;

                    break;
                case "Cash":
                    if (gemAmount < cashAmount + currentQuantity) {
                        continue;
                    }
                    cashAmount += currentQuantity;

                    break;
                default:
                    goldAmount += currentQuantity;
                    break;
            }

            if (!bag.containsKey(currentItem)) {
                bag.put((currentItem), new LinkedHashMap<>());
            }

            if (!bag.get(currentItem).containsKey(name)) {
                bag.get(currentItem).put(name, 0L);
            }

            bag.get(currentItem).put(name, bag.get(currentItem).get(name) + currentQuantity);
            bagCapacity -= currentQuantity;
        }

        for (Map.Entry<String, LinkedHashMap<String, Long>> currItemType : bag.entrySet()) {
            Long sumValues = currItemType.getValue().values().stream().mapToLong(l -> l).sum();

            System.out.printf("<%s> $%s%n", currItemType.getKey(), sumValues);

            currItemType.getValue().entrySet().stream().sorted((firstItem, secondItem) -> secondItem.getKey().compareTo(firstItem.getKey())).forEach(item -> System.out.println("##" + item.getKey() + " - " + item.getValue()));
        }
    }
}