package onlineShop.models.products;

public abstract class BaseProduct implements Product {

    private int id;
    private String manufacturer;
    private String model;
    private double price;
    private double overallPerformance;

    protected BaseProduct(int id, String manufacturer, String model, double price, double overallPerformance) {
        this.setId(id);
        this.setManufacturer(manufacturer);
        this.setModel(model);
        this.setPrice(price);
        this.setOverallPerformance(overallPerformance);
    }

    @Override
    public int getId() {
        return id;
    }

    @Override
    public String getManufacturer() {
        return manufacturer;
    }

    @Override
    public String getModel() {
        return model;
    }

    @Override
    public double getPrice() {
        return price;
    }

    @Override
    public double getOverallPerformance() {
        return overallPerformance;
    }

    private void setId(int id) {
        if (id <= 0) {
            throw new IllegalArgumentException("Id can not be less or equal than 0.");
        }
        this.id = id;
    }

    private void setManufacturer(String manufacturer) {
        if (manufacturer == null || manufacturer.trim().isEmpty()) {
            throw new IllegalArgumentException("Manufacturer can not be empty.");
        }
        this.manufacturer = manufacturer;
    }

    private void setModel(String model) {
        if (model == null || model.trim().isEmpty()) {
            throw new IllegalArgumentException("Model can not be empty.");
        }
        this.model = model;
    }

    private void setPrice(double price) {
        if (price <= 0) {
            throw new IllegalArgumentException("Price can not be less or equal than 0.");
        }
        this.price = price;
    }

    private void setOverallPerformance(double overallPerformance) {
        if (overallPerformance <= 0) {
            throw new IllegalArgumentException("Overall Performance can not be less or equal than 0.");
        }
        this.overallPerformance = overallPerformance;
    }

    @Override
    public String toString() {
        return String.format("Overall Performance: %.2f. Price: %.2f - %s: %s %s (Id: %d)",
                getOverallPerformance(), getPrice(), this.getClass().getSimpleName(), getManufacturer(), getModel(), getId());
    }
}
