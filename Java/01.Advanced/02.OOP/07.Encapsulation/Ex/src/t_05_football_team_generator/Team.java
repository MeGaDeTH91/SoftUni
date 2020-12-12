package t_05_football_team_generator;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

public class Team {
    private String name;
    private List<Player> players;
    private Map<String, Player> uniquePlayers;

    public Team(String name) {
        this.setName(name);
        players = new ArrayList<>(15);
        uniquePlayers = new LinkedHashMap<>(15);
    }

    public void addPlayer(Player player) {
        players.add(player);
        uniquePlayers.putIfAbsent(player.getName(), player);
    }

    public void removePlayer(String player) {
        if (!uniquePlayers.containsKey(player)) {
            System.out.printf("t_05_football_team_generator.Player %s is not in %s team.%n", player, name);
        }

        Player playerToRemove = uniquePlayers.get(player);
        players.remove(playerToRemove);
        uniquePlayers.remove(player);
    }

    public double getRating() {
        return !players.isEmpty() ? players.stream().mapToDouble(Player::overallSkillLevel).sum() / (double) players.size() : 0.0;
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        if (name == null || name.trim().isEmpty()) {
            throw new IllegalArgumentException("A name should not be empty.");
        }
        this.name = name;
    }
}
