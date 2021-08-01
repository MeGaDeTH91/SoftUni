package com.example.football.service.impl;

import com.example.football.models.dto.json.TeamSeedDTO;
import com.example.football.models.entity.Team;
import com.example.football.models.entity.Town;
import com.example.football.repository.TeamRepository;
import com.example.football.service.TeamService;
import com.example.football.service.TownService;
import com.example.football.util.ValidationUtil;
import com.google.gson.Gson;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;

@Service
public class TeamServiceImpl implements TeamService {
    private static final String TEAMS_FILE_PATH = "src/main/resources/files/json/teams.json";

    private final TeamRepository teamRepository;
    private final TownService townService;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final Gson gson;

    public TeamServiceImpl(TeamRepository teamRepository, TownService townService, ModelMapper modelMapper, ValidationUtil validationUtil, Gson gson) {
        this.teamRepository = teamRepository;
        this.townService = townService;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.gson = gson;
    }

    @Override
    public boolean areImported() {
        return teamRepository.count() > 0;
    }

    @Override
    public String readTeamsFileContent() {
        String teamsContent = null;

        try {
            teamsContent = Files.readString(Path.of(TEAMS_FILE_PATH));
        } catch (Exception e) {
            System.out.println("There was problem reading teams.json file");
        }
        return teamsContent;
    }

    @Override
    public String importTeams() {
        var teamSeedDTOSDTOs = gson
                .fromJson(readTeamsFileContent(),
                        TeamSeedDTO[].class);

        StringBuilder sb = new StringBuilder(250);

        Arrays.stream(teamSeedDTOSDTOs)
                .filter(teamDTO -> {
                    boolean teamDataIsValid = validationUtil.isValid(teamDTO);
                    boolean teamExistsInDB = teamRepository.existsByName(teamDTO.getName());
                    boolean teamIsValid = teamDataIsValid && !teamExistsInDB;

                    if(teamIsValid) {
                        sb
                                .append("Successfully imported Team ")
                                .append(teamDTO.getName())
                                .append(" - ")
                                .append(teamDTO.getFanBase());
                    } else {
                        sb.append("Invalid Team");
                    }
                    sb.append(System.lineSeparator());

                    return teamIsValid;
                })
                .map(teamDto -> {
                    Town town = townService.getTownByName(teamDto.getTownName());

                    Team team = modelMapper.map(teamDto, Team.class);
                    team.setTown(town);

                    return team;
                })
                .forEach(teamRepository::save);

        return sb.toString();
    }

    @Override
    public Team getTeamByName(String name) {
        return teamRepository
                .findByName(name)
                .orElse(null);
    }
}
