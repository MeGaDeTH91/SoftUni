package CounterStriker.repositories;

import CounterStriker.models.guns.Gun;

import java.util.Collection;
import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;

import static CounterStriker.common.ExceptionMessages.INVALID_GUN_REPOSITORY;

public class GunRepository implements Repository<Gun> {
    Map<String, Gun> models;

    public GunRepository() {
        models = new LinkedHashMap<>();
    }

    @Override
    public Collection<Gun> getModels() {
        return Collections.unmodifiableCollection(models.values());
    }

    @Override
    public void add(Gun model) {
        if (model == null) {
            throw new NullPointerException(INVALID_GUN_REPOSITORY);
        }
        models.put(model.getName(), model);
    }

    @Override
    public boolean remove(Gun model) {
        Gun removed = models.remove(model.getName());

        return removed != null;
    }

    @Override
    public Gun findByName(String name) {
        return models.get(name);
    }
}
