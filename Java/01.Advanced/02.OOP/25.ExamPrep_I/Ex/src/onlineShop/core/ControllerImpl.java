package onlineShop.core;

import onlineShop.core.factories.ComponentFactory;
import onlineShop.core.factories.ComputerFactory;
import onlineShop.core.factories.PeripheralFactory;
import onlineShop.core.interfaces.Controller;
import onlineShop.models.products.components.Component;
import onlineShop.models.products.computers.Computer;
import onlineShop.models.products.peripherals.Peripheral;

import java.util.*;
import java.util.stream.Collectors;

public class ControllerImpl implements Controller {

    Map<Integer, Computer> computers;
    Map<Integer, Component> components;
    Map<Integer, Peripheral> peripherals;

    public ControllerImpl() {
        computers = new LinkedHashMap<>();
        components = new LinkedHashMap<>();
        peripherals = new LinkedHashMap<>();
    }

    @Override
    public String addComputer(String computerType, int id, String manufacturer, String model, double price) {
        if (computers.containsKey(id)) {
            throw new IllegalArgumentException("Computer with this id already exists.");
        }

        Computer computer = ComputerFactory.createComputer(computerType, id, manufacturer, model, price);
        computers.put(id, computer);

        return String.format("Computer with id %d added successfully.", id);
    }

    @Override
    public String addPeripheral(int computerId, int id, String peripheralType, String manufacturer, String model, double price, double overallPerformance, String connectionType) {
        Computer computer = computers.get(computerId);
        if (computer == null) {
            throw new IllegalArgumentException("Computer with this id does not exist.");
        }

        if (peripherals.containsKey(id)) {
            throw new IllegalArgumentException("Peripheral with this id already exists.");
        }

        Peripheral peripheral = PeripheralFactory.createPeripheral(peripheralType, id, manufacturer, model, price, overallPerformance, connectionType);
        computer.addPeripheral(peripheral);
        peripherals.put(id, peripheral);

        return String.format("Peripheral %s with id %d added successfully in computer with id %d.",
                peripheralType, id, computerId);
    }

    @Override
    public String removePeripheral(String peripheralType, int computerId) {
        Computer computer = computers.get(computerId);
        if (computer == null) {
            throw new IllegalArgumentException("Computer with this id does not exist.");
        }

        Peripheral peripheral = computer.removePeripheral(peripheralType);
        peripherals.remove(peripheral.getId());

        return String.format("Successfully removed %s with id %d.", peripheralType, peripheral.getId());
    }

    @Override
    public String addComponent(int computerId, int id, String componentType, String manufacturer, String model, double price, double overallPerformance, int generation) {
        Computer computer = computers.get(computerId);
        if (computer == null) {
            throw new IllegalArgumentException("Computer with this id does not exist.");
        }

        if (components.containsKey(id)) {
            throw new IllegalArgumentException("Component with this id already exists.");
        }

        Component component = ComponentFactory.createComponent(componentType, id, manufacturer, model, price, overallPerformance, generation);
        computer.addComponent(component);
        components.put(id, component);

        return String.format("Component %s with id %d added successfully in computer with id %d.",
                componentType, id, computerId);
    }

    @Override
    public String removeComponent(String componentType, int computerId) {
        Computer computer = computers.get(computerId);
        if (computer == null) {
            throw new IllegalArgumentException("Computer with this id does not exist.");
        }

        Component component = computer.removeComponent(componentType);
        components.remove(component.getId());

        return String.format("Successfully removed %s with id %d.", componentType, component.getId());
    }

    @Override
    public String buyComputer(int id) {
        Computer computer = computers.get(id);
        if (computer == null) {
            throw new IllegalArgumentException("Computer with this id does not exist.");
        }

        computers.remove(id);

        return computer.toString();
    }

    @Override
    public String BuyBestComputer(double budget) {
        List<Computer> filteredComputers = computers.values()
                .stream()
                .filter(x -> x.getPrice() <= budget)
                .collect(Collectors.toList());

        if (filteredComputers.isEmpty()) {
            throw new IllegalArgumentException(String.format("Can't buy a computer with a budget of ${%.2f}.", budget));
        }

        Computer chosenPC = Collections.max(filteredComputers, Comparator.comparing(Computer::getOverallPerformance));
        computers.remove(chosenPC.getId());

        return chosenPC.toString();
    }

    @Override
    public String getComputerData(int id) {
        Computer computer = computers.get(id);
        if (computer == null) {
            throw new IllegalArgumentException("Computer with this id does not exist.");
        }

        return computer.toString();
    }
}
