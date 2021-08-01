package com.example.football.service;

import com.example.football.models.entity.Stat;

public interface StatService {
    boolean areImported();

    String readStatsFileContent() ;

    String importStats() ;

    Stat getStatById(Long id);
}
