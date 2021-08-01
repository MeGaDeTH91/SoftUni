package com.spring.auto.mapper.model.dto.games;

import com.spring.auto.mapper.model.dto.BaseDTO;

import javax.validation.constraints.Min;
import javax.validation.constraints.Pattern;
import javax.validation.constraints.Positive;
import javax.validation.constraints.Size;
import java.math.BigDecimal;
import java.time.LocalDate;

public class GameAddDTO implements BaseDTO {
    private String title;
    private String trailer;
    private String imageURL;
    private Double size;
    private BigDecimal price;
    private String description;
    private String releaseDate;

    public GameAddDTO() {
    }

    public GameAddDTO(String title, String trailer, String imageURL, Double size,
                      BigDecimal price, String description, String releaseDate) {
        this.title = title;
        this.trailer = trailer;
        this.imageURL = imageURL;
        this.size = size;
        this.price = price;
        this.description = description;
        this.releaseDate = releaseDate;
    }

    @Pattern(regexp = "^[A-Z].{2,100}$", message = "Enter valid title")
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @Size(min = 11, max = 11, message = "Enter valid trailer")
    public String getTrailer() {
        return trailer;
    }

    public void setTrailer(String trailer) {
        this.trailer = trailer;
    }

    @Pattern(regexp = "^http(s?)://.*$")
    public String getImageURL() {
        return imageURL;
    }

    public void setImageURL(String imageURL) {
        this.imageURL = imageURL;
    }

    @Positive(message = "Enter positive size")
    public Double getSize() {
        return size;
    }

    public void setSize(Double size) {
        this.size = size;
    }

    @Positive(message = "Enter positive price")
    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    @Size(min = 20, message = "Enter valid description")
    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getReleaseDate() {
        return releaseDate;
    }

    public void setReleaseDate(String releaseDate) {
        this.releaseDate = releaseDate;
    }
}
