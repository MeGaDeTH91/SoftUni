package CounterStriker.repositories;

import CounterStriker.models.guns.Gun;
import CounterStriker.models.players.Player;

import java.util.Collection;
import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;

import static CounterStriker.common.ExceptionMessages.INVALID_PLAYER_REPOSITORY;

public class PlayerRepository implements Repository<Player> {

    Map<String, Player> models;

    public PlayerRepository() {
        models = new LinkedHashMap<>();
    }

    @Override
    public Collection<Player> getModels() {
        return Collections.unmodifiableCollection(models.values());
    }

    @Override
    public void add(Player model) {
        if (model == null) {
            throw new NullPointerException(INVALID_PLAYER_REPOSITORY);
        }
        models.put(model.getUsername(), model);
    }

    @Override
    public boolean remove(Player model) {
        Player removed = models.remove(model.getUsername());

        return removed != null;
    }

    @Override
    public Player findByName(String name) {
        return models.get(name);
    }
}
