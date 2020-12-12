package onlineShop.models.products.peripherals;

import onlineShop.models.products.BaseProduct;

public abstract class BasePeripheral extends BaseProduct implements Peripheral {

    private String connectionType;

    protected BasePeripheral(int id, String manufacturer, String model, double price, double overallPerformance, String connectionType) {
        super(id, manufacturer, model, price, overallPerformance);
        this.setConnectionType(connectionType);
    }

    @Override
    public String getConnectionType() {
        return connectionType;
    }

    private void setConnectionType(String connectionType) {
        if (connectionType == null || connectionType.trim().isEmpty()) {
            throw new IllegalArgumentException("Connection type can not be empty.");
        }

        this.connectionType = connectionType;
    }

    @Override
    public String toString() {
        return super.toString() + String.format(" Connection Type: %s", getConnectionType());
    }
}
