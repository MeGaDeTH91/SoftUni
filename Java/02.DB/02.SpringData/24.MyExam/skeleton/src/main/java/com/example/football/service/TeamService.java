package com.example.football.service;

import com.example.football.models.entity.Team;

public interface TeamService {
    boolean areImported();

    String readTeamsFileContent() ;

    String importTeams() ;

    Team getTeamByName(String name);
}
