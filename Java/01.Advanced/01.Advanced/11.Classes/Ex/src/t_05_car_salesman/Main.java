package t_05_car_salesman;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, Engine> engines = new HashMap<>();
        List<Car> cars = new ArrayList<>();

        String[] tokens;

        int enginesCount = Integer.parseInt(reader.readLine());

        Engine engine;
        String engineModel;
        long enginePower;
        long displacement;
        String efficiency;
        for (int i = 0; i < enginesCount; i++) {
            tokens = reader.readLine().split("\\s+");

            engineModel = tokens[0];
            enginePower = Long.parseLong(tokens[1]);

            if (tokens.length == 2) {
                engine = new Engine(engineModel, enginePower);
            } else if (tokens.length == 4) {
                displacement = Long.parseLong(tokens[2]);
                efficiency = tokens[3];

                engine = new Engine(engineModel, enginePower, displacement, efficiency);
            } else {
                if (tokens[2].matches("[0-9.]+")){
                    displacement = Long.parseLong(tokens[2]);

                    engine = new Engine(engineModel, enginePower, displacement);
                } else {
                    efficiency = tokens[2];

                    engine = new Engine(engineModel, enginePower, efficiency);
                }
            }

            engines.put(engineModel, engine);
        }

        int carsCount = Integer.parseInt(reader.readLine());

        String carModel;
        long weight;
        String color;
        Car car;
        for (int i = 0; i < carsCount; i++) {
            tokens = reader.readLine().split("\\s+");

            carModel = tokens[0];
            engine = engines.get(tokens[1]);

            if (tokens.length == 2) {
                car = new Car(carModel, engine);
            } else if (tokens.length == 4) {
                weight = Long.parseLong(tokens[2]);
                color = tokens[3];

                car = new Car(carModel, engine, weight, color);
            } else {
                if (tokens[2].matches("[0-9.]+")){
                    weight = Integer.parseInt(tokens[2]);

                    car = new Car(carModel, engine, weight);
                } else {
                    color = tokens[2];

                    car = new Car(carModel, engine, color);
                }
            }

            cars.add(car);
        }

        for (Car currCar: cars) {
            System.out.println(currCar.toString());
        }
    }
}
