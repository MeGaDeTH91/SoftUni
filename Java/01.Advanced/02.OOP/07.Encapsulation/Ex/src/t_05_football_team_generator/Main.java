package t_05_football_team_generator;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.Map;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, Team> teams = new LinkedHashMap<>(17);

        String line;
        String[] tokens;
        String command;

        String teamName;
        Team team;

        String playerName;
        int endurance;
        int sprint;
        int dribble;
        int passing;
        int shooting;
        Player player;
        while(!(line = reader.readLine()).equals("END")) {
            tokens = line.split(";");
            try {
                command = tokens[0];
                switch (command) {
                    case "t_05_football_team_generator.Team":
                        teamName = tokens[1];
                        team = new Team(teamName);
                        teams.putIfAbsent(teamName, team);
                        break;
                    case "Add":
                        teamName = tokens[1];
                        playerName = tokens[2];
                        validateName(teamName);

                        team = teams.get(teamName);
                        if (team == null) {
                            System.out.printf("t_05_football_team_generator.Team %s does not exist.%n", teamName);
                        } else {
                            endurance = Integer.parseInt(tokens[3]);
                            sprint = Integer.parseInt(tokens[4]);
                            dribble = Integer.parseInt(tokens[5]);
                            passing = Integer.parseInt(tokens[6]);
                            shooting = Integer.parseInt(tokens[7]);

                            player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            team.addPlayer(player);
                        }
                        break;
                    case "Remove":
                        teamName = tokens[1];
                        playerName = tokens[2];
                        validateName(teamName);
                        validateName(playerName);

                        team = teams.get(teamName);
                        if (team == null) {
                            System.out.printf("t_05_football_team_generator.Team %s does not exist.%n", teamName);
                        } else {
                            team.removePlayer(playerName);
                        }
                        break;
                    case "Rating":
                        teamName = tokens[1];
                        validateName(teamName);

                        team = teams.get(teamName);
                        if (team == null) {
                            System.out.printf("t_05_football_team_generator.Team %s does not exist.%n", teamName);
                        } else {
                            System.out.printf("%s - %d", teamName, Math.round(team.getRating()));
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }
        }
    }
    private static void validateName(String name) {
        if (name == null || name.trim().isEmpty()) {
            throw new IllegalArgumentException("A name should not be empty.");
        }
    }
}
