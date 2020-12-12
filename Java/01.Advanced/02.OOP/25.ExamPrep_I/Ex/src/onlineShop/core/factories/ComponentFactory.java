package onlineShop.core.factories;

import onlineShop.models.products.components.CentralProcessingUnit;
import onlineShop.models.products.components.*;

public final class ComponentFactory {

    public static Component createComponent(String componentType, int id, String manufacturer,
                                            String model, double price , double overallPerformance, int generation) {
        switch (componentType) {
            case "CentralProcessingUnit":
                return new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            case "Motherboard":
                return new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            case "PowerSupply":
                return new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            case "RandomAccessMemory":
                return new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            case "SolidStateDrive":
                return new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            case "VideoCard":
                return new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            default:
                throw new IllegalArgumentException("Component type is invalid.");
        }
    }
}
