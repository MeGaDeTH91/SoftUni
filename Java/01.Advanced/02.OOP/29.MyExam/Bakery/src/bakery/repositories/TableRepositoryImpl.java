package bakery.repositories;

import bakery.entities.tables.interfaces.Table;
import bakery.repositories.interfaces.TableRepository;

import java.util.Collection;
import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;

public class TableRepositoryImpl implements TableRepository<Table> {

    private final Map<Integer, Table> models;

    public TableRepositoryImpl() {
        this.models = new LinkedHashMap<>();
    }

    @Override
    public Table getByNumber(int number) {
        return models.get(number);
    }

    @Override
    public Collection<Table> getAll() {
        return Collections.unmodifiableCollection(models.values());
    }

    @Override
    public void add(Table table) {
        models.put(table.getTableNumber(), table);
    }
}
