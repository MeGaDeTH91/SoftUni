package com.example.football.service;


import com.example.football.models.entity.Town;

public interface TownService {

    boolean areImported();

    String readTownsFileContent() ;
	
	String importTowns();

    Town getTownByName(String name);
}
