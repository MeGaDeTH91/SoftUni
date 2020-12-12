package bakery.entities.tables;

import bakery.entities.bakedFoods.interfaces.BakedFood;
import bakery.entities.drinks.interfaces.Drink;
import bakery.entities.tables.interfaces.Table;

import java.util.ArrayList;
import java.util.Collection;

import static bakery.common.ExceptionMessages.INVALID_NUMBER_OF_PEOPLE;
import static bakery.common.ExceptionMessages.INVALID_TABLE_CAPACITY;

public abstract class BaseTable implements Table {

    private Collection<BakedFood> foodOrders;
    private Collection<Drink> drinkOrders;
    private int tableNumber;
    private int capacity;
    private int numberOfPeople;
    private double pricePerPerson;
    private boolean isReserved;
    private double price;

    protected BaseTable(int tableNumber, int capacity, double pricePerPerson) {
        this.setTableNumber(tableNumber);
        this.setCapacity(capacity);
        this.setPricePerPerson(pricePerPerson);
        this.setPrice(0);
        foodOrders = new ArrayList<>();
        drinkOrders = new ArrayList<>();
    }

    @Override
    public int getTableNumber() {
        return tableNumber;
    }

    @Override
    public int getCapacity() {
        return capacity;
    }

    @Override
    public int getNumberOfPeople() {
        return numberOfPeople;
    }

    @Override
    public double getPricePerPerson() {
        return pricePerPerson;
    }

    @Override
    public boolean isReserved() {
        return isReserved;
    }

    @Override
    public double getPrice() {
        return price;
    }

    public void setTableNumber(int tableNumber) {
        this.tableNumber = tableNumber;
    }

    public void setCapacity(int capacity) {
        if (capacity <= 0) {
            throw new IllegalArgumentException(INVALID_TABLE_CAPACITY);
        }
        this.capacity = capacity;
    }

    public void setPricePerPerson(double pricePerPerson) {
        this.pricePerPerson = pricePerPerson;
    }

    public void setNumberOfPeople(int numberOfPeople) {
        this.numberOfPeople = numberOfPeople;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    @Override
    public void reserve(int numberOfPeople) {
        if (numberOfPeople <= 0) {
            throw new IllegalArgumentException(INVALID_NUMBER_OF_PEOPLE);
        }

        this.setNumberOfPeople(numberOfPeople);
        this.setPrice(getNumberOfPeople() * getPricePerPerson());
        isReserved = true;
    }

    @Override
    public void orderFood(BakedFood food) {
        foodOrders.add(food);
    }

    @Override
    public void orderDrink(Drink drink) {
        drinkOrders.add(drink);
    }

    @Override
    public double getBill() {
        double foodSum = foodOrders
                .stream()
                .mapToDouble(BakedFood::getPrice)
                .sum();

        double drinksSum = drinkOrders
                .stream()
                .mapToDouble(Drink::getPrice)
                .sum();

        return foodSum + drinksSum + getPrice();
    }

    @Override
    public void clear() {
        foodOrders = new ArrayList<>();
        drinkOrders = new ArrayList<>();
        isReserved = false;
        price = 0;
        this.setNumberOfPeople(0);
        this.setPrice(0);
    }

    @Override
    public String getFreeTableInfo() {

        return "Table: " + getTableNumber() + System.lineSeparator() +
                "Type: " + this.getClass().getSimpleName() + System.lineSeparator() +
                "Capacity: " + getCapacity() + System.lineSeparator() +
                String.format("Price per Person: %.2f", getPricePerPerson());
    }
}
