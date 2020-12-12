package t_02_vehicles_extend;

public abstract class Vehicle {
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;

    private double addedFuelConsumption;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity) {
        this.setTankCapacity(tankCapacity);
        this.setFuelQuantity(fuelQuantity);
        this.setFuelConsumption(fuelConsumption);
    }

    public boolean drive(double distance, boolean airConditionerOn) {
        double currentFuelConsumption = fuelConsumption;

        if (airConditionerOn) {
            currentFuelConsumption += addedFuelConsumption;
        }

        if ((currentFuelConsumption * distance) <= fuelQuantity) {
            this.setFuelQuantity(fuelQuantity - (currentFuelConsumption * distance));
            return true;
        }

        return false;
    }

    public void refuel(double fuel) {
        if (fuel <= 0) {
            throw new IllegalArgumentException("Fuel must be a positive number");
        }
        this.setFuelQuantity(fuelQuantity + fuel);
    }

    protected void setAddedFuelConsumption(double addedFuelConsumption) {
        this.addedFuelConsumption = addedFuelConsumption;
    }

    public void setFuelQuantity(double fuelQuantity) {
        if (fuelQuantity < 0) {
            throw new IllegalArgumentException("Fuel must be a positive number");
        }
        if (fuelQuantity > tankCapacity) {
            throw new IllegalArgumentException("Cannot fit fuel in tank");
        }
        this.fuelQuantity = fuelQuantity;
    }

    protected void setFuelConsumption(double fuelConsumption) {
        this.fuelConsumption = fuelConsumption;
    }

    protected void setTankCapacity(double tankCapacity) {
        this.tankCapacity = tankCapacity;
    }

    @Override
    public String toString() {
        return String.format("%s: %.2f", this.getClass().getSimpleName(), this.fuelQuantity);
    }
}
