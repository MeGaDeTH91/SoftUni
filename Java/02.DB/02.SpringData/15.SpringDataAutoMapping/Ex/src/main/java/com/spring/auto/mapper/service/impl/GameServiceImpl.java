package com.spring.auto.mapper.service.impl;

import com.spring.auto.mapper.model.dto.games.GameAddDTO;
import com.spring.auto.mapper.model.dto.games.GameEditDTO;
import com.spring.auto.mapper.model.entity.Game;
import com.spring.auto.mapper.repository.GameRepository;
import com.spring.auto.mapper.service.GameService;
import com.spring.auto.mapper.service.UserService;
import com.spring.auto.mapper.util.ValidationUtil;
import org.modelmapper.ModelMapper;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.BeanWrapper;
import org.springframework.beans.BeanWrapperImpl;
import org.springframework.stereotype.Service;

import javax.validation.ConstraintViolation;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

@Service
public class GameServiceImpl implements GameService {

    private final GameRepository gameRepository;
    private final UserService userService;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;

    public GameServiceImpl(GameRepository gameRepository, UserService userService, ModelMapper modelMapper, ValidationUtil validationUtil) {
        this.gameRepository = gameRepository;
        this.userService = userService;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
    }

    @Override
    public void addGame(GameAddDTO gameAddDTO) {
        if (!userService.loggedInAdministrator()) {
            System.out.println("Login as administrator");
            return;
        }

        var violations = validationUtil.violations(gameAddDTO);
        if (!violations.isEmpty()) {
            violations
                    .stream()
                    .map(ConstraintViolation::getMessage)
                    .forEach(System.out::println);
        } else {
            var game = modelMapper.map(gameAddDTO, Game.class);

            gameRepository.save(game);
            System.out.println("Added " + game.getTitle());
        }
    }

    @Override
    public void editGame(long id, GameEditDTO gameEditDTO) {
        if (!userService.loggedInAdministrator()) {
            System.out.println("Login as administrator");
            return;
        }
        Game game = getGameById(id);

        if (game != null) {
            BeanUtils.copyProperties(gameEditDTO, game,
                    getNullPropertyNames(gameEditDTO));

            gameRepository.save(game);
            System.out.println("Edited " + game.getTitle());
        } else {
            System.out.println("Enter valid game id");
        }
    }

    @Override
    public void removeGameById(long id) {
        if (!userService.loggedInAdministrator()) {
            System.out.println("Login as administrator");
            return;
        }
        Game game = getGameById(id);

        if (game != null) {
            System.out.println("Deleted " + game.getTitle());
            gameRepository.deleteById(id);
        } else {
            System.out.println("Enter valid game id");
        }
    }

    @Override
    public List<String> getAllGames() {
        return gameRepository.findAll()
                .stream()
                .map(game -> String.format("%s %.2f", game.getTitle(), game.getPrice()))
                .collect(Collectors.toList());
    }

    @Override
    public Game getGameByTitle(String title) {
        return gameRepository.findByTitle(title).orElse(null);
    }

    @Override
    public Game getGameById(long id) {
        if (id < 1) {
            return null;
        }

        return gameRepository.findById(id).orElse(null);
    }

    public static String[] getNullPropertyNames (Object source) {
        final BeanWrapper src = new BeanWrapperImpl(source);
        java.beans.PropertyDescriptor[] pds = src.getPropertyDescriptors();

        Set<String> emptyNames = new HashSet<>();
        for(java.beans.PropertyDescriptor pd : pds) {
            Object srcValue = src.getPropertyValue(pd.getName());
            if (srcValue == null) emptyNames.add(pd.getName());
        }

        String[] result = new String[emptyNames.size()];
        return emptyNames.toArray(result);
    }
}
