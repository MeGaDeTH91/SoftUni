package t_04_raw_data;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.function.Predicate;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int carsCount = Integer.parseInt(reader.readLine());
        List<RawCar> cars = new ArrayList<>();

        String[] tokens;
        RawCar car;
        RawEngine engine;
        RawCargo cargo;
        RawTyre tyre;
        List<RawTyre> tyres;

        String model;
        int engineSpeed;
        int enginePower;
        int cargoWeight;
        String cargoType;
        double tyrePressure;
        int tyreAge;
        for (int i = 0; i < carsCount; i++) {
            tyres = new ArrayList<>();
            tokens = reader.readLine().split("\\s+");

            model = tokens[0];
            engineSpeed = Integer.parseInt(tokens[1]);
            enginePower = Integer.parseInt(tokens[2]);
            engine = new RawEngine(engineSpeed, enginePower);

            cargoWeight = Integer.parseInt(tokens[3]);
            cargoType = tokens[4];
            cargo = new RawCargo(cargoType, cargoWeight);

            for (int j = 5; j < tokens.length; j+=2) {
                tyrePressure = Double.parseDouble(tokens[j]);
                tyreAge = Integer.parseInt(tokens[j + 1]);
                tyre = new RawTyre(tyrePressure, tyreAge);
                tyres.add(tyre);
            }
            car = new RawCar(model, engine, cargo, tyres);
            cars.add(car);
        }

        String target = reader.readLine();

        Predicate<RawCar> filter = target.equals("fragile") ? fragileFilter : flammableFilter;

        for (RawCar currCar: cars) {
            if (filter.test(currCar)) {
                System.out.println(currCar.toString());
            }
        }
    }
    private static final Predicate<RawCar> fragileFilter = RawCar::lowTyreExists;
    private static final Predicate<RawCar> flammableFilter = RawCar::highEnginePower;
}
