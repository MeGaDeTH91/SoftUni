package t_01_vehicles;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.DecimalFormat;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        double fuelQuantity;
        double fuelConsumption;

        String[] carTokens = reader.readLine().split("\\s+");
        fuelQuantity = Double.parseDouble(carTokens[1]);
        fuelConsumption = Double.parseDouble(carTokens[2]);

        Vehicle car = new Car(fuelQuantity, fuelConsumption);

        String[] truckTokens = reader.readLine().split("\\s+");
        fuelQuantity = Double.parseDouble(truckTokens[1]);
        fuelConsumption = Double.parseDouble(truckTokens[2]);

        Vehicle truck = new Truck(fuelQuantity, fuelConsumption);

        int operations = Integer.parseInt(reader.readLine());
        String[] lineTokens;
        String operation;
        String vehicleType;
        Vehicle vehicle;
        for (int i = 0; i < operations; i++) {
            lineTokens = reader.readLine().split("\\s+");

            operation = lineTokens[0];
            vehicleType = lineTokens[1];

            if (vehicleType.equals("t_01_vehicles.t_02_vehicles_extend.Car")) {
                vehicle = car;
            } else {
                vehicle = truck;
            }

            executeOperation(lineTokens, operation, vehicle);
        }

        System.out.println(car.toString());
        System.out.println(truck.toString());
    }

    private static void executeOperation(String[] lineTokens, String operation, Vehicle vehicle) {
        DecimalFormat df = new DecimalFormat("0.##");

        double distance;
        double liters;
        boolean drivenSuccessfully;
        if (operation.equals("Drive")) {
            distance = Double.parseDouble(lineTokens[2]);
            drivenSuccessfully = vehicle.drive(distance);

            if (drivenSuccessfully) {
                System.out.printf("%s travelled %s km%n", lineTokens[1], df.format(distance));
            } else {
                System.out.printf("%s needs refueling%n", lineTokens[1]);
            }
        } else {
            liters = Double.parseDouble(lineTokens[2]);
            vehicle.refuel(liters);
        }
    }
}
