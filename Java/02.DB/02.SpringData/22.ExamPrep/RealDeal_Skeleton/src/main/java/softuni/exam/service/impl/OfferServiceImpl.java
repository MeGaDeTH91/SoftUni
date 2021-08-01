package softuni.exam.service.impl;

import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;
import softuni.exam.models.dto.xml.OfferSeedRootDTO;
import softuni.exam.models.entity.Car;
import softuni.exam.models.entity.Offer;
import softuni.exam.repository.OfferRepository;
import softuni.exam.service.CarService;
import softuni.exam.service.OfferService;
import softuni.exam.service.SellerService;
import softuni.exam.util.ValidationUtil;
import softuni.exam.util.XmlParser;

import javax.xml.bind.JAXBException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

@Service
public class OfferServiceImpl implements OfferService {
    private static final String OFFERS_FILE_PATH = "src/main/resources/files/xml/offers.xml";

    private final OfferRepository offerRepository;
    private final CarService carService;
    private final SellerService sellerService;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final XmlParser xmlParser;

    public OfferServiceImpl(OfferRepository offerRepository, CarService carService, SellerService sellerService, ModelMapper modelMapper, ValidationUtil validationUtil, XmlParser xmlParser) {
        this.offerRepository = offerRepository;
        this.carService = carService;
        this.sellerService = sellerService;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.xmlParser = xmlParser;
    }

    @Override
    public boolean areImported() {
        return offerRepository.count() > 0;
    }

    @Override
    public String readOffersFileContent() throws IOException {
        return Files.readString(Path.of(OFFERS_FILE_PATH));
    }

    @Override
    public String importOffers() throws IOException, JAXBException {
        OfferSeedRootDTO sellers = xmlParser.readFromFile(OFFERS_FILE_PATH, OfferSeedRootDTO.class);

        StringBuilder sb = new StringBuilder(250);

        sellers.getOffers()
                .stream()
                .filter(offerDTO -> {
                    boolean offerIsValid = validationUtil.isValid(offerDTO);

                    if (offerIsValid) {
                        sb
                                .append("Successfully import offer ")
                                .append(offerDTO.getAddedOn())
                                .append(" - ")
                                .append(offerDTO.getHasGoldStatus());
                    } else {
                        sb.append("Invalid offer");
                    }
                    sb.append(System.lineSeparator());

                    return offerIsValid;
                })
                .map(offerDTO -> {
                    Offer offer = modelMapper.map(offerDTO, Offer.class);

                    Car car = carService.getCarById(offerDTO.getCar().getId());

                    offer.setCar(car);
                    offer.setPictures(car.getPictures());
                    offer.setSeller(sellerService.getSellerById(offerDTO.getSeller().getId()));

                    return offer;
                })
                .forEach(offerRepository::save);

        return sb.toString();
    }
}
