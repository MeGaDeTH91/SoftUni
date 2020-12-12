package t_03_speed_racing;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.Map;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, CarClass> cars = new LinkedHashMap<>();
        
        int carCount = Integer.parseInt(reader.readLine());

        String[] carTokens;
        String model;
        double fuel;
        double consumption;
        CarClass car;
        for (int i = 0; i < carCount; i++) {
            carTokens = reader.readLine().split("\\s+");
            model = carTokens[0];
            fuel = Double.parseDouble(carTokens[1]);
            consumption = Double.parseDouble(carTokens[2]);

            car = new CarClass(model, fuel, consumption);

            cars.put(model, car);
        }

        double distance;
        String command;
        while (!(command = reader.readLine()).equals("End")) {
            carTokens = command.split("\\s+");
            model = carTokens[1];
            distance = Double.parseDouble(carTokens[2]);

            car = cars.get(model);

            if (!car.drive(distance)) {
                System.out.println("Insufficient fuel for the drive");
            }
        }

        for (Map.Entry<String, CarClass> currCar: cars.entrySet()) {
            System.out.println(currCar.getValue().toString());
        }
    }
}
