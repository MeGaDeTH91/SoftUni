package com.spring.auto.mapper;

import com.spring.auto.mapper.model.dto.games.GameAddDTO;
import com.spring.auto.mapper.model.dto.games.GameEditDTO;
import com.spring.auto.mapper.model.dto.users.UserLoginDTO;
import com.spring.auto.mapper.model.dto.users.UserRegisterDTO;
import com.spring.auto.mapper.service.GameService;
import com.spring.auto.mapper.service.UserService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.math.BigDecimal;
import java.time.format.DateTimeFormatter;

@Component
public class CommandLineRunnerImpl implements CommandLineRunner {
    private final UserService userService;
    private final GameService gameService;
    private final BufferedReader bufferedReader;

    public CommandLineRunnerImpl(UserService userService, GameService gameService) {
        this.userService = userService;
        this.gameService = gameService;
        bufferedReader = new BufferedReader(new InputStreamReader(System.in));
    }

    @Override
    public void run(String... args) throws Exception {
        String command;
        String[] commTokens;
        String currOperation;
        while(!(command = bufferedReader.readLine()).equals("end")) {
            commTokens = command.split("\\|");
            currOperation = commTokens[0].toLowerCase();

            switch (currOperation){
                case"registeruser":
                    UserRegisterDTO registerDTO = new UserRegisterDTO(commTokens[1], commTokens[2], commTokens[3],
                             commTokens[4]);

                    userService.registerUser(registerDTO);
                    break;
                case"loginuser":
                    UserLoginDTO loginDTO = new UserLoginDTO(commTokens[1], commTokens[2]);

                    userService.loginUser(loginDTO);
                    break;
                case"logout":
                    userService.logout();
                    break;
                case"addgame":
                    GameAddDTO gameAddDTO = new GameAddDTO(commTokens[1], commTokens[4], commTokens[5],
                            Double.parseDouble(commTokens[3]), new BigDecimal(commTokens[2]), commTokens[6], commTokens[7]);
                    gameService.addGame(gameAddDTO);
                    break;
                case"editgame":
                    GameEditDTO gameEditDTO = populateGameEditDTO(commTokens);
                    gameService.editGame(Long.parseLong(commTokens[1]), gameEditDTO);
                    break;
                case "deletegame":
                    gameService.removeGameById(Long.parseLong(commTokens[1]));
                    break;
                case "allgames":
                    var gamesInDb = gameService.getAllGames();
                    if (gamesInDb.isEmpty()) {
                        System.out.println("No games in database");
                    } else {
                        gamesInDb.forEach(System.out::println);
                    }
                    break;
                case "detailgame":
                    var game = gameService.getGameByTitle(commTokens[1]);
                    if (game == null) {
                        System.out.println("No such game");
                    } else {
                        String gameDetails = "Title: " + game.getTitle() + System.lineSeparator() +
                                "Price: " + String.format("%.2f", game.getPrice()) + System.lineSeparator() +
                                "Description: " + game.getDescription() + System.lineSeparator() +
                                "Release date: " +
                                game.getReleaseDate().format(DateTimeFormatter.ofPattern("dd-MM-yyyy"));
                        System.out.println(gameDetails);
                    }
                    break;
                case "buygame":
                    var gameToBuy = gameService.getGameById(Long.parseLong(commTokens[1]));

                    if (gameToBuy != null) {
                        userService.buyGame(gameToBuy);
                    } else {
                        System.out.println("Enter valid game id");
                    }
                    break;
                case "ownedgames":
                    var ownedGames = userService.getUserOwnedGames();

                    if (ownedGames == null) {
                        System.out.println("Cannot list owned games. No user was logged in.");
                    } else {
                        if (ownedGames.isEmpty()) {
                            System.out.println("User has no games");
                        } else{
                            ownedGames.forEach(System.out::println);
                        }
                    }
                    break;
                default:
                    System.out.println("Please provide valid operation");
                    break;
            }
        }
    }

    private GameEditDTO populateGameEditDTO(String[] commTokens) {
        GameEditDTO gameEditDTO = new GameEditDTO();

        String currentPair;
        String[] currentPairTokens;
        String currentFieldKey;
        String currentFieldValue;
        for (int i = 2; i < commTokens.length; i++) {
            currentPair = commTokens[i];
            currentPairTokens = currentPair.split("=");
            currentFieldKey = currentPairTokens[0];
            currentFieldValue = currentPairTokens[1];

            switch (currentFieldKey){
                case "trailer":
                    gameEditDTO.setTrailer(currentFieldValue);
                    break;
                case "thumbnailURL":
                    gameEditDTO.setImageURL(currentFieldValue);
                    break;
                case "size":
                    gameEditDTO.setSize(Double.parseDouble(currentFieldValue));
                    break;
                case "price":
                    gameEditDTO.setPrice(new BigDecimal(currentFieldValue));
                    break;
                case "description":
                    gameEditDTO.setDescription(currentFieldValue);
                    break;
                default:
                    break;
            }
        }

        return gameEditDTO;
    }
}
