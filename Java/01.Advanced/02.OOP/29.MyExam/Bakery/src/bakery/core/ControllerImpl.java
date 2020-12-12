package bakery.core;

import bakery.core.interfaces.Controller;
import bakery.entities.bakedFoods.Bread;
import bakery.entities.bakedFoods.Cake;
import bakery.entities.bakedFoods.interfaces.BakedFood;
import bakery.entities.drinks.Tea;
import bakery.entities.drinks.Water;
import bakery.entities.drinks.interfaces.Drink;
import bakery.entities.tables.InsideTable;
import bakery.entities.tables.OutsideTable;
import bakery.entities.tables.interfaces.Table;
import bakery.repositories.interfaces.DrinkRepository;
import bakery.repositories.interfaces.FoodRepository;
import bakery.repositories.interfaces.TableRepository;

import java.util.Collection;
import java.util.stream.Collectors;

import static bakery.common.ExceptionMessages.FOOD_OR_DRINK_EXIST;
import static bakery.common.ExceptionMessages.TABLE_EXIST;
import static bakery.common.OutputMessages.BILL;
import static bakery.common.OutputMessages.DRINK_ADDED;
import static bakery.common.OutputMessages.DRINK_ORDER_SUCCESSFUL;
import static bakery.common.OutputMessages.FOOD_ADDED;
import static bakery.common.OutputMessages.FOOD_ORDER_SUCCESSFUL;
import static bakery.common.OutputMessages.NONE_EXISTENT_FOOD;
import static bakery.common.OutputMessages.NON_EXISTENT_DRINK;
import static bakery.common.OutputMessages.RESERVATION_NOT_POSSIBLE;
import static bakery.common.OutputMessages.TABLE_ADDED;
import static bakery.common.OutputMessages.TABLE_RESERVED;
import static bakery.common.OutputMessages.TOTAL_INCOME;
import static bakery.common.OutputMessages.WRONG_TABLE_NUMBER;

public class ControllerImpl implements Controller {

    private final FoodRepository<BakedFood> foodRepository;
    private final DrinkRepository<Drink> drinkRepository;
    private final TableRepository<Table> tableRepository;
    private double totalIncome;

    public ControllerImpl(FoodRepository<BakedFood> foodRepository, DrinkRepository<Drink> drinkRepository, TableRepository<Table> tableRepository) {
        this.foodRepository = foodRepository;
        this.drinkRepository = drinkRepository;
        this.tableRepository = tableRepository;
        totalIncome = 0;
    }


    @Override
    public String addFood(String type, String name, double price) {
        if (foodRepository.getByName(name) != null) {
            throw new IllegalArgumentException(String.format(FOOD_OR_DRINK_EXIST, type, name));
        }

        BakedFood food = createFood(type, name, price);

        foodRepository.add(food);

        return String.format(FOOD_ADDED, name, type);
    }

    @Override
    public String addDrink(String type, String name, int portion, String brand) {
        if (drinkRepository.getByNameAndBrand(name, brand) != null) {
            throw new IllegalArgumentException(String.format(FOOD_OR_DRINK_EXIST, type, name));
        }

        Drink drink = createDrink(type, name, portion, brand);

        drinkRepository.add(drink);

        return String.format(DRINK_ADDED, name, brand);
    }

    @Override
    public String addTable(String type, int tableNumber, int capacity) {
        if (tableRepository.getByNumber(tableNumber) != null) {
            throw new IllegalArgumentException(String.format(TABLE_EXIST, tableNumber));
        }

        Table table = createTable(type, tableNumber, capacity);

        tableRepository.add(table);

        return String.format(TABLE_ADDED, tableNumber);
    }

    @Override
    public String reserveTable(int numberOfPeople) {
        Collection<Table> tables = tableRepository.getAll();

        Table table = null;

        for (Table currTable: tables) {
            if (!currTable.isReserved() && currTable.getCapacity() >= numberOfPeople) {
                currTable.reserve(numberOfPeople);
                table = currTable;
                break;
            }
        }

        if (table == null) {
            return String.format(RESERVATION_NOT_POSSIBLE, numberOfPeople);
        }

        return String.format(TABLE_RESERVED, table.getTableNumber(), numberOfPeople);
    }

    @Override
    public String orderFood(int tableNumber, String foodName) {
        Table table = tableRepository.getByNumber(tableNumber);
        BakedFood food = foodRepository.getByName(foodName);

        if (table == null || !table.isReserved()) {
            return String.format(WRONG_TABLE_NUMBER, tableNumber);
        }

        if (food == null) {
            return String.format(NONE_EXISTENT_FOOD, foodName);
        }

        table.orderFood(food);

        return String.format(FOOD_ORDER_SUCCESSFUL, tableNumber, foodName);
    }

    @Override
    public String orderDrink(int tableNumber, String drinkName, String drinkBrand) {
        Table table = tableRepository.getByNumber(tableNumber);
        Drink drink = drinkRepository.getByNameAndBrand(drinkName, drinkBrand);

        if (table == null || !table.isReserved()) {
            return String.format(WRONG_TABLE_NUMBER, tableNumber);
        }

        if (drink == null) {
            return String.format(NON_EXISTENT_DRINK, drinkName, drinkBrand);
        }

        table.orderDrink(drink);

        return String.format(DRINK_ORDER_SUCCESSFUL, tableNumber, drinkName, drinkBrand);

    }

    @Override
    public String leaveTable(int tableNumber) {
        Table table = tableRepository.getByNumber(tableNumber);

        if (table == null) {
            return String.format(WRONG_TABLE_NUMBER, tableNumber);
        }

        double bill = table.getBill();
        totalIncome += bill;
        table.clear();

        return String.format(BILL, tableNumber, bill);
    }

    @Override
    public String getFreeTablesInfo() {
        StringBuilder sb = new StringBuilder();

        Collection<Table> freeTables = tableRepository.getAll().stream().filter(x -> !x.isReserved()).collect(Collectors.toList());

        for (Table currTable: freeTables) {
            sb.append(currTable.getFreeTableInfo()).append(System.lineSeparator());
        }

        return sb.toString().trim();
    }

    @Override
    public String getTotalIncome() {
        return String.format(TOTAL_INCOME, totalIncome);
    }

    private BakedFood createFood(String type, String name, double price) {
        switch (type){
            case "Bread":
                return new Bread(name, price);
            case "Cake":
                return new Cake(name, price);
            default:
                throw new IllegalArgumentException("Invalid food type!");
        }
    }

    private Drink createDrink(String type, String name, int portion, String brand) {
        switch (type){
            case "Tea":
                return new Tea(name, portion, brand);
            case "Water":
                return new Water(name, portion, brand);
            default:
                throw new IllegalArgumentException("Invalid drink type!");
        }
    }

    private Table createTable(String type, int tableNumber, int capacity) {
        switch (type){
            case "InsideTable":
                return new InsideTable(tableNumber, capacity);
            case "OutsideTable":
                return new OutsideTable(tableNumber, capacity);
            default:
                throw new IllegalArgumentException("Invalid table type!");
        }
    }
}
