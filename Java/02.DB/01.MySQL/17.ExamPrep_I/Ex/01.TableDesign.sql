CREATE DATABASE fsd;
USE fsd;

CREATE TABLE countries (
id INT(11) PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(45) NOT NULL
);

CREATE TABLE towns (
id INT(11) PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(45) NOT NULL,
country_id INT(11) NOT NULL,
CONSTRAINT fk_towns_countries FOREIGN KEY(country_id) REFERENCES countries(id)
);

CREATE TABLE stadiums (
id INT(11) PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(45) NOT NULL,
capacity INT(11) NOT NULL,
town_id INT(11) NOT NULL,
CONSTRAINT fk_stadiums_towns FOREIGN KEY(town_id) REFERENCES towns(id)
);

CREATE TABLE teams (
id INT(11) PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(45) NOT NULL,
established DATE NOT NULL,
fan_base BIGINT(20) DEFAULT 0 NOT NULL,
stadium_id INT(11) NOT NULL,
CONSTRAINT fk_teams_stadiums FOREIGN KEY(stadium_id) REFERENCES stadiums(id)
);

CREATE TABLE skills_data (
id INT(11) PRIMARY KEY AUTO_INCREMENT,
dribbling INT(11) DEFAULT 0 NOT NULL,
pace INT(11) DEFAULT 0 NOT NULL,
passing INT(11) DEFAULT 0 NOT NULL,
shooting INT(11) DEFAULT 0 NOT NULL,
speed INT(11) DEFAULT 0 NOT NULL,
strength INT(11) DEFAULT 0 NOT NULL
);

CREATE TABLE coaches (
id INT(11) PRIMARY KEY AUTO_INCREMENT,
first_name VARCHAR(10) NOT NULL,
last_name VARCHAR(20) NOT NULL,
salary DECIMAL(10,2) DEFAULT 0 NOT NULL,
coach_level INT(11) DEFAULT 0 NOT NULL
);

CREATE TABLE players (
id INT(11) PRIMARY KEY AUTO_INCREMENT,
first_name VARCHAR(10) NOT NULL,
last_name VARCHAR(20) NOT NULL,
age INT(11) DEFAULT 0 NOT NULL,
position CHAR(1) NOT NULL CHECK(position IN('A', 'M', 'D')),
salary DECIMAL(10,2) DEFAULT 0 NOT NULL,
hire_date DATETIME NULL,
skills_data_id INT(11) NOT NULL,
team_id INT(11) NULL,
CONSTRAINT fk_players_skills FOREIGN KEY(skills_data_id) REFERENCES skills_data(id),
CONSTRAINT fk_players_teams FOREIGN KEY(team_id) REFERENCES teams(id)
);

CREATE TABLE players_coaches (
player_id INT(11) NOT NULL,
coach_id INT(11) NOT NULL,
CONSTRAINT fk_pc_players FOREIGN KEY(player_id) REFERENCES players(id),
CONSTRAINT fk_pc_coaches FOREIGN KEY(coach_id) REFERENCES coaches(id)
);