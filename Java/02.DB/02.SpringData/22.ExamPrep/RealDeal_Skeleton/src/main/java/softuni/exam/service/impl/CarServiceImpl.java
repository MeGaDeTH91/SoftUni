package softuni.exam.service.impl;

import com.google.gson.Gson;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;
import softuni.exam.models.dto.json.CarSeedDTO;
import softuni.exam.models.entity.Car;
import softuni.exam.repository.CarRepository;
import softuni.exam.service.CarService;
import softuni.exam.util.ValidationUtil;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;

@Service
public class CarServiceImpl implements CarService {
    private static final String CARS_FILE_PATH = "src/main/resources/files/json/cars.json";

    private final CarRepository carRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final Gson gson;

    public CarServiceImpl(CarRepository carRepository, ModelMapper modelMapper, ValidationUtil validationUtil, Gson gson) {
        this.carRepository = carRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.gson = gson;
    }

    @Override
    public boolean areImported() {
        return carRepository.count() > 0;
    }

    @Override
    public String readCarsFileContent() throws IOException {
        return Files.readString(Path.of(CARS_FILE_PATH));
    }

    @Override
    public String importCars() throws IOException {
        var carDTOs = gson
                .fromJson(readCarsFileContent(),
                        CarSeedDTO[].class);

        StringBuilder sb = new StringBuilder(250);

        Arrays.stream(carDTOs)
                .filter(carDto -> {
                    boolean carIsValid = validationUtil.isValid(carDto);

                    if(carIsValid) {
                        sb
                                .append("Successfully imported car - ")
                                .append(carDto.getMake())
                                .append(" - ")
                                .append(carDto.getModel());
                    } else {
                        sb.append("Invalid car");
                    }
                    sb.append(System.lineSeparator());

                    return carIsValid;
                })
                .map(carDto -> modelMapper.map(carDto, Car.class))
                .forEach(carRepository::save);

        return sb.toString();
    }

    @Override
    public String getCarsOrderByPicturesCountThenByMake() {
        StringBuilder sb = new StringBuilder(200);

        carRepository.findAllCarsByPicturesCountDescThenByMakeAsc()
        .forEach(car -> {
            sb.append("Car make - ")
                    .append(car.getMake())
                    .append(", model - ")
                    .append(car.getModel())
                    .append(System.lineSeparator());

            sb.append("\tKilometers - ").append(car.getKilometers()).append(System.lineSeparator());
            sb.append("\tRegistered on - ").append(car.getRegisteredOn()).append(System.lineSeparator());
            sb.append("\tNumber of pictures - ").append(car.getPictures().size()).append(System.lineSeparator());
        });

        return sb.toString();
    }

    @Override
    public Car getCarById(long id) {
        return carRepository
                .findById(id)
                .orElse(null);
    }
}
