package com.example.football.service.impl;

import com.example.football.models.dto.json.TownSeedDTO;
import com.example.football.models.entity.Town;
import com.example.football.repository.TownRepository;
import com.example.football.service.TownService;
import com.example.football.util.ValidationUtil;
import com.google.gson.Gson;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;


@Service
public class TownServiceImpl implements TownService {
    private static final String TOWNS_FILE_PATH = "src/main/resources/files/json/towns.json";

    private final TownRepository townRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final Gson gson;

    public TownServiceImpl(TownRepository townRepository, ModelMapper modelMapper, ValidationUtil validationUtil, Gson gson) {
        this.townRepository = townRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.gson = gson;
    }

    @Override
    public boolean areImported() {
        return townRepository.count() > 0;
    }

    @Override
    public String readTownsFileContent() {
        String townsContent = null;

        try {
            townsContent = Files.readString(Path.of(TOWNS_FILE_PATH));
        } catch (Exception e) {
            System.out.println("There was problem reading towns.json file");
        }
        return townsContent;
    }

    @Override
    public String importTowns() {
        var townSeedDTOSDTOs = gson
                .fromJson(readTownsFileContent(),
                        TownSeedDTO[].class);

        StringBuilder sb = new StringBuilder(250);

        Arrays.stream(townSeedDTOSDTOs)
                .filter(townDto -> {
                    boolean townDataIsValid = validationUtil.isValid(townDto);
                    boolean townExistsInDB = townRepository.existsByName(townDto.getName());
                    boolean townIsValid = townDataIsValid && !townExistsInDB;

                    if (townIsValid) {
                        sb
                                .append("Successfully imported Town ")
                                .append(townDto.getName())
                                .append(" - ")
                                .append(townDto.getPopulation());
                    } else {
                        sb.append("Invalid Town");
                    }
                    sb.append(System.lineSeparator());

                    return townIsValid;
                })
                .map(townDto -> modelMapper.map(townDto, Town.class))
                .forEach(townRepository::save);

        return sb.toString();
    }

    public Town getTownByName(String name) {
        return townRepository
                .findByName(name)
                .orElse(null);
    }
}
