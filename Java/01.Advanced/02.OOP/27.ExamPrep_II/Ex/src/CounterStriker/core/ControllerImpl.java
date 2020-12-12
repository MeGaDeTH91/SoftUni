package CounterStriker.core;

import CounterStriker.models.field.Field;
import CounterStriker.models.field.FieldImpl;
import CounterStriker.models.guns.Gun;
import CounterStriker.models.guns.Pistol;
import CounterStriker.models.guns.Rifle;
import CounterStriker.models.players.CounterTerrorist;
import CounterStriker.models.players.Player;
import CounterStriker.models.players.Terrorist;
import CounterStriker.repositories.GunRepository;
import CounterStriker.repositories.PlayerRepository;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import static CounterStriker.common.ExceptionMessages.GUN_CANNOT_BE_FOUND;
import static CounterStriker.common.ExceptionMessages.INVALID_GUN_TYPE;
import static CounterStriker.common.ExceptionMessages.INVALID_PLAYER_TYPE;
import static CounterStriker.common.OutputMessages.SUCCESSFULLY_ADDED_GUN;
import static CounterStriker.common.OutputMessages.SUCCESSFULLY_ADDED_PLAYER;

public class ControllerImpl implements Controller {
    private GunRepository guns;
    private PlayerRepository players;
    private Field field;

    public ControllerImpl() {
        guns = new GunRepository();
        players = new PlayerRepository();
        field = new FieldImpl();
    }

    @Override
    public String addGun(String type, String name, int bulletsCount) {
        Gun gun = createGun(type, name, bulletsCount);

        guns.add(gun);

        return String.format(SUCCESSFULLY_ADDED_GUN, gun.getName());
    }

    @Override
    public String addPlayer(String type, String username, int health, int armor, String gunName) {
        Player player = createPlayer(type, username, health, armor, gunName);

        players.add(player);

        return String.format(SUCCESSFULLY_ADDED_PLAYER, player.getUsername());
    }

    @Override
    public String startGame() {
        return field.start(players.getModels());
    }

    @Override
    public String report() {
        List<Player> resultPlayers = new ArrayList<>(players.getModels());

        resultPlayers.sort((o1, o2) -> {

            String firstPlayerType = o1.getClass().getSimpleName();
            String secondPlayerType = o2.getClass().getSimpleName();
            int typeCompare = firstPlayerType.compareTo(secondPlayerType);

            if (typeCompare != 0) {
                return typeCompare;
            }

            Integer firstPlayerHealth = o1.getHealth();
            Integer secondPlayerHealth = o2.getHealth();
            int healthCompare = secondPlayerHealth.compareTo(firstPlayerHealth);

            if (healthCompare != 0) {
                return healthCompare;
            }

            String firstPlayerUsername = o1.getUsername();
            String secondPlayerUsername = o2.getUsername();
            return firstPlayerUsername.compareTo(secondPlayerUsername);
        });

        StringBuilder sb = new StringBuilder();

        for (Player currPlayer: resultPlayers) {
            sb.append(currPlayer.toString()).append(System.lineSeparator());
        }

        return sb.toString().trim();
    }

    private Gun createGun(String type, String name, int bulletsCount) {
        switch (type) {
            case "Pistol":
                return new Pistol(name, bulletsCount);
            case "Rifle":
                return new Rifle(name, bulletsCount);
            default:
                throw new IllegalArgumentException(INVALID_GUN_TYPE);
        }
    }

    private Player createPlayer(String type, String username, int health, int armor, String gunName) {
        Gun gun = guns.findByName(gunName);

        if (gun == null) {
            throw new NullPointerException(GUN_CANNOT_BE_FOUND);
        }

        switch (type) {
            case "Terrorist":
                return new Terrorist(username, health, armor, gun);
            case "CounterTerrorist":
                return new CounterTerrorist(username, health, armor, gun);
            default:
                throw new IllegalArgumentException(INVALID_PLAYER_TYPE);
        }
    }
}
