package com.example.football.service.impl;

import com.example.football.models.dto.xml.StatSeedRootDTO;
import com.example.football.models.entity.Stat;
import com.example.football.repository.StatRepository;
import com.example.football.service.StatService;
import com.example.football.util.ValidationUtil;
import com.example.football.util.XmlParser;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.nio.file.Files;
import java.nio.file.Path;

@Service
public class StatServiceImpl implements StatService {
    private static final String STATS_FILE_PATH = "src/main/resources/files/xml/stats.xml";

    private final StatRepository statRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final XmlParser xmlParser;

    public StatServiceImpl(StatRepository statRepository, ModelMapper modelMapper, ValidationUtil validationUtil, XmlParser xmlParser) {
        this.statRepository = statRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.xmlParser = xmlParser;
    }

    @Override
    public boolean areImported() {
        return statRepository.count() > 0;
    }

    @Override
    public String readStatsFileContent()  {
        String statsContent = null;

        try {
            statsContent = Files.readString(Path.of(STATS_FILE_PATH));
        } catch (Exception e) {
            System.out.println("There was problem reading stats.xml file");
        }
        return statsContent;
    }

    @Override
    public String importStats() {
        StatSeedRootDTO seedRootDTO = xmlParser.readFromFile(STATS_FILE_PATH, StatSeedRootDTO.class);

        StringBuilder sb = new StringBuilder(250);

        seedRootDTO.getStats()
                .stream()
                .filter(statDTO -> {
                    boolean statDataIsValid = validationUtil.isValid(statDTO);
                    boolean statExistsInDB = statRepository.existsByPassingAndShootingAndEndurance(statDTO.getPassing(),
                            statDTO.getShooting(), statDTO.getEndurance());
                    boolean statIsValid = statDataIsValid && !statExistsInDB;

                    if(statIsValid) {
                        sb
                                .append("Successfully imported Stat ")
                                .append(String.format("%.2f - %.2f - %.2f",
                                        statDTO.getShooting(), statDTO.getPassing(), statDTO.getEndurance()));
                    } else {
                        sb.append("Invalid Stat");
                    }
                    sb.append(System.lineSeparator());

                    return statIsValid;
                })
                .map(statDTO -> modelMapper.map(statDTO, Stat.class))
                .forEach(statRepository::save);

        return sb.toString();
    }

    @Override
    public Stat getStatById(Long id) {
        return statRepository
                .findById(id)
                .orElse(null);
    }
}
