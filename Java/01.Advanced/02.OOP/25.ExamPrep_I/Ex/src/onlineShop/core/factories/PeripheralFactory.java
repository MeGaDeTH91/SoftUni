package onlineShop.core.factories;

import onlineShop.models.products.peripherals.*;

public final class PeripheralFactory {

    public static Peripheral createPeripheral(String peripheralType, int id, String manufacturer,
                                              String model, double price , double overallPerformance, String connectionType) {
        switch (peripheralType) {
            case "Headset":
                return new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            case "Keyboard":
                return new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            case "Monitor":
                return new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            case "Mouse":
                return new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            default:
                throw new IllegalArgumentException("Peripheral type is invalid.");
        }
    }
}
