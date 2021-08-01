package com.example.football.models.dto.xml;

import com.example.football.models.enumerations.Position;

import javax.validation.constraints.Email;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;

@XmlAccessorType(XmlAccessType.FIELD)
public class PlayerSeedDTO {
    @XmlElement(name = "first-name")
    private String firstName;
    @XmlElement(name = "last-name")
    private String lastName;
    @XmlElement
    private String email;
    @XmlElement(name = "birth-date")
    private String birthDate;
    @XmlElement
    private Position position;
    @XmlElement
    private PlayerSeedTownDTO town;
    @XmlElement
    private PlayerSeedTeamDTO team;
    @XmlElement
    private PlayerSeedStatDTO stat;

    public PlayerSeedDTO() {
    }

    @Size(min = 3)
    @NotBlank
    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    @Size(min = 3)
    @NotBlank
    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    @Email
    @NotBlank
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @NotBlank
    public String getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(String birthDate) {
        this.birthDate = birthDate;
    }

    @NotNull
    public Position getPosition() {
        return position;
    }

    public void setPosition(Position position) {
        this.position = position;
    }

    @NotNull
    public PlayerSeedTownDTO getTown() {
        return town;
    }

    public void setTown(PlayerSeedTownDTO town) {
        this.town = town;
    }

    @NotNull
    public PlayerSeedTeamDTO getTeam() {
        return team;
    }

    public void setTeam(PlayerSeedTeamDTO team) {
        this.team = team;
    }

    @NotNull
    public PlayerSeedStatDTO getStat() {
        return stat;
    }

    public void setStat(PlayerSeedStatDTO stat) {
        this.stat = stat;
    }
}
