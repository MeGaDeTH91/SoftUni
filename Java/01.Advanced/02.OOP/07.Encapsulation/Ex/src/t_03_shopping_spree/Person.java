package t_03_shopping_spree;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Person {
    private String name;
    private double money;
    private final List<Product> products;

    public Person(String name, double money) {
        this.setName(name);
        this.setMoney(money);
        products = new ArrayList<>(5);
    }

    public void buyProduct(Product product) {
        if (product.getCost() > this.money) {
            throw new IllegalArgumentException(String.format("%s can't afford %s", this.name, product.getName()));
        } else {
            money -= product.getCost();
            products.add(product);
            System.out.printf("%s bought %s%n", name, product.getName());
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder(26);

        if (products.isEmpty()) {
            sb.append(name);
            sb.append(" – Nothing bought");
        } else {
            sb.append(name);
            sb.append(" - ");
            sb.append(products.stream().map(Product::toString).collect(Collectors.joining(", ")));
        }
        return sb.toString();
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        if (name == null || name.trim().isEmpty()) {
            throw new IllegalArgumentException("Name cannot be empty");
        }
        this.name = name;
    }

    private void setMoney(double money) {
        if (money < 0) {
            throw new IllegalArgumentException("Money cannot be negative");
        }
        this.money = money;
    }
}
