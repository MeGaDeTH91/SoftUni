package bakery.repositories;

import bakery.entities.bakedFoods.interfaces.BakedFood;
import bakery.repositories.interfaces.FoodRepository;

import java.util.Collection;
import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;

public class FoodRepositoryImpl implements FoodRepository<BakedFood> {
    private final Map<String, BakedFood> models;

    public FoodRepositoryImpl() {
        this.models = new LinkedHashMap<>();
    }

    @Override
    public BakedFood getByName(String name) {
        return models.get(name);
    }

    @Override
    public Collection<BakedFood> getAll() {
        return Collections.unmodifiableCollection(models.values());
    }

    @Override
    public void add(BakedFood bakedFood) {
        models.put(bakedFood.getName(), bakedFood);
    }
}
