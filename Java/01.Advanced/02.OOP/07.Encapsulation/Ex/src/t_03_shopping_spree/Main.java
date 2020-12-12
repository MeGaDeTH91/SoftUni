package t_03_shopping_spree;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) {
        Map<String, Person> people = new LinkedHashMap<>(8);
        Map<String, Product> products = new HashMap<>(8);

        try {
            String[] lineTokens = reader.readLine().split(";");
            String[] pairTokens;

            String personName;
            double personMoney;
            Person person;
            for (String currPerson: lineTokens) {
                pairTokens = currPerson.split("=");

                personName = pairTokens[0];
                personMoney = Double.parseDouble(pairTokens[1]);
                person = new Person(personName, personMoney);

                if (!people.containsKey(personName)) {
                    people.put(personName, person);
                }
            }

            lineTokens = reader.readLine().split(";");
            String productName;
            double productCost;
            Product product;
            for (String currProduct: lineTokens) {
                pairTokens = currProduct.split("=");

                productName = pairTokens[0];
                productCost = Double.parseDouble(pairTokens[1]);
                product = new Product(productName, productCost);

                if (!products.containsKey(productName)) {
                    products.put(productName, product);
                }
            }

            String command;
            while(!(command = reader.readLine()).equalsIgnoreCase("end")) {
                lineTokens = command.split("\\s+");

                personName = lineTokens[0];
                productName = lineTokens[1];

                if (people.containsKey(personName) && products.containsKey(productName)) {
                    people.get(personName).buyProduct(products.get(productName));
                }
            }

            for (Person currPerson: people.values()) {
                System.out.println(currPerson.toString());
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
