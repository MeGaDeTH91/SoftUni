package parking;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class Parking {
    private List<Car> data;
    private String type;
    private int capacity;

    public Parking(String type, int capacity) {
        data = new ArrayList<>();
        this.type = type;
        this.capacity = capacity;
    }

    public void add(Car car) {
        if (data.size() < capacity) {
            data.add(car);
        }
    }

    public boolean remove(String manufacturer, String model) {
        return data.removeIf(x -> x.getManufacturer().equals(manufacturer) && x.getModel().equals(model));
    }

    public Car getLatestCar() {
        /*Car car = null;
        int maxYear = Integer.MIN_VALUE;

        for (Car currentCar: data) {
            if (currentCar.getYear() > maxYear) {
                car = currentCar;
                maxYear = currentCar.getYear();
            }
        }

        return car;*/
        if (data.isEmpty()) {
            return null;
        }

        return Collections.max(data, Comparator.comparing(Car::getYear));
    }

    public Car getCar(String manufacturer, String model) {
        /*Car car = null;

        for (Car currentCar: data) {
            if (currentCar.getManufacturer().equals(manufacturer) && currentCar.getModel().equals(model)) {
                car = currentCar;
            }
        }
        return car;*/
        return data.stream()
                .filter(x -> x.getManufacturer().equals(manufacturer) && x.getModel().equals(model))
                .findFirst()
                .orElse(null);
    }

    public int getCount() {
        return data.size();
    }

    public String getStatistics() {
        StringBuilder sb = new StringBuilder();

        sb.append("The cars are parked in ").append(type).append(':').append(System.lineSeparator());

        for (Car car: data) {
            sb.append(car.toString()).append(System.lineSeparator());
        }

        return sb.toString().trim();
    }
}
