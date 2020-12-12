package t_04_raw_data;

import java.util.List;

public class RawCar {
    private final String model;
    private final RawEngine engine;
    private final RawCargo cargo;
    private final List<RawTyre> tyres;

    public RawCar(String model, RawEngine engine, RawCargo cargo, List<RawTyre> tyres) {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tyres = tyres;
    }

    public boolean lowTyreExists () {
        return cargo.getType().equals("fragile") && tyres.stream().anyMatch(x -> x.getPressure() < 1);
    }

    public boolean highEnginePower () {
        return cargo.getType().equals("flamable") && engine.getPower() > 250;
    }

    @Override
    public String toString() {
        return model;
    }
}
