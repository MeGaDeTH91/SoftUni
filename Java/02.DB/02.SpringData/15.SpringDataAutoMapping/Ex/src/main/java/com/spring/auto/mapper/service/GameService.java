package com.spring.auto.mapper.service;

import com.spring.auto.mapper.model.dto.games.GameAddDTO;
import com.spring.auto.mapper.model.dto.games.GameEditDTO;
import com.spring.auto.mapper.model.entity.Game;

import java.util.List;

public interface GameService {

    void addGame(GameAddDTO gameAddDTO);

    void editGame(long id, GameEditDTO gameEditDTO);

    void removeGameById(long id);

    List<String> getAllGames();

    Game getGameById(long id);

    Game getGameByTitle(String title);
}
