package CounterStriker.models.field;

import CounterStriker.models.players.Player;

import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

import static CounterStriker.common.OutputMessages.COUNTER_TERRORIST_WINS;
import static CounterStriker.common.OutputMessages.TERRORIST_WINS;

public class FieldImpl implements Field {
    @Override
    public String start(Collection<Player> players) {
        List<Player> terrorists = players
                .stream()
                .filter(x -> x.getClass().getSimpleName().equals("Terrorist"))
                .collect(Collectors.toList());
        List<Player> counterTerrorists = players.stream().filter(x -> x.getClass().getSimpleName().equals("CounterTerrorist")).collect(Collectors.toList());

        while (terrorists.stream().anyMatch(Player::isAlive) && counterTerrorists.stream().anyMatch(Player::isAlive)) {
            for (Player terrorist: terrorists) {
                if (terrorist.isAlive()) {
                    counterTerrorists.stream().filter(Player::isAlive).forEach(x -> x.takeDamage(terrorist.getGun().fire()));
                }
            }

            for (Player counterTerrorist: counterTerrorists) {
                if (counterTerrorist.isAlive()) {
                    terrorists.stream().filter(Player::isAlive).forEach(x -> x.takeDamage(counterTerrorist.getGun().fire()));
                }
            }
        }

        return terrorists.stream().anyMatch(Player::isAlive)? TERRORIST_WINS : COUNTER_TERRORIST_WINS ;
    }
}
