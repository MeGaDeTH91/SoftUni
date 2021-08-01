package softuni.exam.service.impl;

import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;
import softuni.exam.models.dto.xml.SellerSeedRootDTO;
import softuni.exam.models.entity.Seller;
import softuni.exam.repository.SellerRepository;
import softuni.exam.service.SellerService;
import softuni.exam.util.ValidationUtil;
import softuni.exam.util.XmlParser;

import javax.xml.bind.JAXBException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

@Service
public class SellerServiceImpl implements SellerService {
    private static final String SELLERS_FILE_PATH = "src/main/resources/files/xml/sellers.xml";

    private final SellerRepository sellerRepository;
    private final ModelMapper modelMapper;
    private final ValidationUtil validationUtil;
    private final XmlParser xmlParser;

    public SellerServiceImpl(SellerRepository sellerRepository, ModelMapper modelMapper, ValidationUtil validationUtil, XmlParser xmlParser) {
        this.sellerRepository = sellerRepository;
        this.modelMapper = modelMapper;
        this.validationUtil = validationUtil;
        this.xmlParser = xmlParser;
    }

    @Override
    public boolean areImported() {
        return sellerRepository.count() > 0;
    }

    @Override
    public String readSellersFromFile() throws IOException {
        return Files.readString(Path.of(SELLERS_FILE_PATH));
    }

    @Override
    public String importSellers() throws IOException, JAXBException {
        SellerSeedRootDTO sellers = xmlParser.readFromFile(SELLERS_FILE_PATH, SellerSeedRootDTO.class);

        StringBuilder sb = new StringBuilder(250);

        sellers.getSellers()
                .stream()
                .filter(sellerDto -> {
                    boolean sellerIsValid = validationUtil.isValid(sellerDto);

                    if(sellerIsValid) {
                        sb
                                .append("Successfully import seller ")
                                .append(sellerDto.getLastName())
                                .append(" - ")
                                .append(sellerDto.getEmail());
                    } else {
                        sb.append("Invalid seller");
                    }
                    sb.append(System.lineSeparator());

                    return sellerIsValid;
                })
                .map(sellerDTO -> modelMapper.map(sellerDTO, Seller.class))
                .forEach(sellerRepository::save);

        return sb.toString();
    }

    @Override
    public Seller getSellerById(long id) {
        return sellerRepository
                .findById(id)
                .orElse(null);
    }
}
