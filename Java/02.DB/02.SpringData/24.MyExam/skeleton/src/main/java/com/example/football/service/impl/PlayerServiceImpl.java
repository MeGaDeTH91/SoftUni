package com.example.football.service.impl;

import com.example.football.models.dto.xml.PlayerSeedRootDTO;
import com.example.football.models.entity.Player;
import com.example.football.models.entity.Stat;
import com.example.football.models.entity.Team;
import com.example.football.models.entity.Town;
import com.example.football.repository.PlayerRepository;
import com.example.football.service.PlayerService;
import com.example.football.service.StatService;
import com.example.football.service.TeamService;
import com.example.football.service.TownService;
import com.example.football.util.ValidationUtil;
import com.example.football.util.XmlParser;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.nio.file.Files;
import java.nio.file.Path;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

@Service
public class PlayerServiceImpl implements PlayerService {
    private static final String PLAYERS_FILE_PATH = "src/main/resources/files/xml/players.xml";

    private final PlayerRepository playerRepository;
    private final TownService townService;
    private final TeamService teamService;
    private final StatService statService;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final XmlParser xmlParser;

    public PlayerServiceImpl(PlayerRepository playerRepository, TownService townService,
                             TeamService teamService, StatService statService, ModelMapper modelMapper, ValidationUtil validationUtil, XmlParser xmlParser) {
        this.playerRepository = playerRepository;
        this.townService = townService;
        this.teamService = teamService;
        this.statService = statService;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.xmlParser = xmlParser;
    }

    @Override
    public boolean areImported() {
        return playerRepository.count() > 0;
    }

    @Override
    public String readPlayersFileContent() {
        String playersContent = null;

        try {
            playersContent = Files.readString(Path.of(PLAYERS_FILE_PATH));
        } catch (Exception e) {
            System.out.println("There was problem reading players.xml file");
        }
        return playersContent;
    }

    @Override
    public String importPlayers() {
        PlayerSeedRootDTO seedRootDTO = xmlParser.readFromFile(PLAYERS_FILE_PATH, PlayerSeedRootDTO.class);

        StringBuilder sb = new StringBuilder(250);

        seedRootDTO.getPlayers()
                .stream()
                .filter(playerDTO -> {
                    boolean playerDataIsValid = validationUtil.isValid(playerDTO) &&
                            validationUtil.isValid(playerDTO.getTown()) &&
                            validationUtil.isValid(playerDTO.getTeam()) &&
                            validationUtil.isValid(playerDTO.getStat());
                    boolean playerExistsInDB = playerRepository.existsByEmail(playerDTO.getEmail());
                    boolean playerIsValid = playerDataIsValid && !playerExistsInDB;

                    if(playerIsValid) {
                        sb
                                .append("Successfully imported Player ")
                                .append(String.format("%s - %s - %s",
                                        playerDTO.getFirstName(), playerDTO.getLastName(), playerDTO.getPosition()));
                    } else {
                        sb.append("Invalid Player");
                    }
                    sb.append(System.lineSeparator());

                    return playerIsValid;
                })
                .map(playerDTO -> {
                    Player player = modelMapper.map(playerDTO, Player.class);
                    Town playerTown = townService.getTownByName(playerDTO.getTown().getName());
                    Team playerTeam = teamService.getTeamByName(playerDTO.getTeam().getName());
                    Stat playerStat = statService.getStatById(playerDTO.getStat().getId());

                    player.setTown(playerTown);
                    player.setTeam(playerTeam);
                    player.setStat(playerStat);

                    return player;
                })
                .forEach(playerRepository::save);

        return sb.toString();
    }

    @Override
    public String exportBestPlayers() {
        StringBuilder sb = new StringBuilder(200);
        LocalDate startDate = LocalDate.parse("01-01-1995", DateTimeFormatter.ofPattern("dd-MM-yyyy"));
        LocalDate endDate = LocalDate.parse("01-01-2003", DateTimeFormatter.ofPattern("dd-MM-yyyy"));

        playerRepository.findBestPlayersOrderedByStatsDescAndLastNameAsc(startDate, endDate)
                .forEach(player -> {
                    sb.append("Player - ")
                            .append(player.getFirstName())
                            .append(" ")
                            .append(player.getLastName())
                            .append(System.lineSeparator());

                    sb.append("\tPosition - ").append(player.getPosition().toString()).append(System.lineSeparator());
                    sb.append("\tTeam - ").append(player.getTeam().getName()).append(System.lineSeparator());
                    sb.append("\tStadium - ").append(player.getTeam().getStadiumName()).append(System.lineSeparator());
                });

        return sb.toString();
    }
}
