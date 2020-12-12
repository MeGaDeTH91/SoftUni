package onlineShop.core.factories;

import onlineShop.models.products.computers.Computer;
import onlineShop.models.products.computers.DesktopComputer;
import onlineShop.models.products.computers.Laptop;

public final class ComputerFactory {
    public static Computer createComputer(String computerType, int id, String manufacturer, String model, double price) {
        switch (computerType) {
            case "Laptop":
                return new Laptop(id, manufacturer, model, price);
            case "DesktopComputer":
                return new DesktopComputer(id, manufacturer, model, price);
            default:
                throw new IllegalArgumentException("Computer type is invalid.");
        }
    }
}
