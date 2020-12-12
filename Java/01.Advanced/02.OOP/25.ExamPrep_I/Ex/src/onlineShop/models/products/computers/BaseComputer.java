package onlineShop.models.products.computers;

import onlineShop.models.products.BaseProduct;
import onlineShop.models.products.Product;
import onlineShop.models.products.components.Component;
import onlineShop.models.products.peripherals.Peripheral;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public abstract class BaseComputer extends BaseProduct implements Computer {

    private final List<Component> components;
    private final List<Peripheral> peripherals;

    protected BaseComputer(int id, String manufacturer, String model, double price, double overallPerformance) {
        super(id, manufacturer, model, price, overallPerformance);
        this.components = new ArrayList<>();
        this.peripherals = new ArrayList<>();
    }

    @Override
    public double getOverallPerformance() {
        if (components.isEmpty()) {
            return super.getOverallPerformance();
        }

        double componentsSum = components
                .stream()
                .mapToDouble(Product::getOverallPerformance)
                .average()
                .orElse(0.0);

        return super.getOverallPerformance() + componentsSum;
    }

    @Override
    public double getPrice() {
        double componentsSum = components
                .stream()
                .mapToDouble(Component::getPrice)
                .sum();

        double peripheralSum = peripherals
                .stream()
                .mapToDouble(Peripheral::getPrice)
                .sum();

        return super.getPrice() + componentsSum + peripheralSum;
    }

    @Override
    public List<Component> getComponents() {
        return Collections.unmodifiableList(components);
    }

    @Override
    public List<Peripheral> getPeripherals() {
        return Collections.unmodifiableList(peripherals);
    }

    @Override
    public void addComponent(Component component) {
        if (components.stream().anyMatch(x -> x.getClass().getSimpleName().equals(component.getClass().getSimpleName()))) {
            throw new IllegalArgumentException(
                    String.format("Component %s already exists in %s with Id %d.",
                            component.getClass().getSimpleName(), this.getClass().getSimpleName(), this.getId()));
        }
        components.add(component);
    }

    @Override
    public Component removeComponent(String componentType) {
        Component resultComponent = components
                .stream()
                .filter(x -> x.getClass().getSimpleName().equals(componentType))
                .findFirst().orElse(null);

        if (resultComponent == null) {
            throw new IllegalArgumentException(
                    String.format("Component %s does not exist in %s with Id %d.",
                            componentType, this.getClass().getSimpleName(), this.getId()));
        }
        components.remove(resultComponent);

        return resultComponent;
    }

    @Override
    public void addPeripheral(Peripheral peripheral) {
        if (peripherals.stream().anyMatch(x -> x.getClass().getSimpleName().equals(peripheral.getClass().getSimpleName()))) {
            throw new IllegalArgumentException(
                    String.format("Peripheral %s already exists in %s with Id %d.",
                            peripheral.getClass().getSimpleName(), this.getClass().getSimpleName(), this.getId()));
        }
        peripherals.add(peripheral);
    }

    @Override
    public Peripheral removePeripheral(String peripheralType) {
        Peripheral resultPeripheral = peripherals
                .stream()
                .filter(x -> x.getClass().getSimpleName().equals(peripheralType))
                .findFirst().orElse(null);

        if (resultPeripheral == null) {
            throw new IllegalArgumentException(
                    String.format("Peripheral %s does not exist in %s with Id %d.",
                            peripheralType, this.getClass().getSimpleName(), this.getId()));
        }
        peripherals.remove(resultPeripheral);

        return resultPeripheral;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder(super.toString());

        sb.append(System.lineSeparator());

        sb.append(" Components (").append(components.size()).append("):").append(System.lineSeparator());

        for (Component currComponent : getComponents()) {
            sb.append("  ").append(currComponent.toString()).append(System.lineSeparator());
        }

        double averageOverallPerformance = peripherals
                .stream()
                .mapToDouble(Peripheral::getOverallPerformance)
                .average()
                .orElse(0.0);

        sb.append(" Peripherals (")
                .append(peripherals.size())
                .append("); Average Overall Performance (")
                .append(String.format("%.2f", averageOverallPerformance))
                .append("):")
                .append(System.lineSeparator());

        for (Peripheral currPeripheral : getPeripherals()) {
            sb.append("  ").append(currPeripheral.toString()).append(System.lineSeparator());
        }

        return sb.toString().trim();
    }
}
