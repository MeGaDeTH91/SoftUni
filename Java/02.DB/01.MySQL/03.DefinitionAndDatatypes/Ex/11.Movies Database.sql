CREATE DATABASE `movies`;
USE `movies`;
CREATE TABLE `directors` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`director_name` VARCHAR(50) NOT NULL,
`notes` TEXT
);
CREATE TABLE `genres` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`genre_name` VARCHAR(50) NOT NULL,
`notes` TEXT
);
CREATE TABLE `categories` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`category_name` VARCHAR(50) NOT NULL,
`notes` TEXT
);
CREATE TABLE `movies` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`title` VARCHAR(50) NOT NULL,
`director_id` INT NOT NULL,
`copyright_year` DATE,
`length` TIME,
`genre_id` INT NOT NULL,
`category_id` INT NOT NULL,
`rating` DECIMAL,
`notes` TEXT
);


INSERT INTO `directors`(`director_name`, `notes`)
VALUES('Martin', NULL);
INSERT INTO `directors`(`director_name`, `notes`)
VALUES('Veselin', 'Nearly done!');
INSERT INTO `directors`(`director_name`, `notes`)
VALUES('Maria', 'Completely done!');
INSERT INTO `directors`(`director_name`, `notes`)
VALUES('Pasteti', NULL);
INSERT INTO `directors`(`director_name`, `notes`)
VALUES('Goshko', NULL);

INSERT INTO `genres`(`genre_name`, `notes`)
VALUES('Horror', NULL);
INSERT INTO `genres`(`genre_name`, `notes`)
VALUES('Comedy', 'Completely done!');
INSERT INTO `genres`(`genre_name`, `notes`)
VALUES('Action', NULL);
INSERT INTO `genres`(`genre_name`, `notes`)
VALUES('Thriller', 'Completely done!');
INSERT INTO `genres`(`genre_name`, `notes`)
VALUES('Drama', 'Nearly done!');

INSERT INTO `categories`(`category_name`, `notes`)
VALUES('Pesho', 'Completely done!');
INSERT INTO `categories`(`category_name`, `notes`)
VALUES('Gosho', 'Nearly done!');
INSERT INTO `categories`(`category_name`, `notes`)
VALUES('Pesho', NULL);
INSERT INTO `categories`(`category_name`, `notes`)
VALUES('Mariika', 'Nearly done!');
INSERT INTO `categories`(`category_name`, `notes`)
VALUES('Pastefan', 'Completely done!');

INSERT INTO `movies`(`title`, `director_id`, `copyright_year`, `length`, `genre_id`, `category_id`, `rating`, `notes`)
VALUES('Terminator II', 1, NULL, NULL, 3, 3, 6,NULL);
INSERT INTO `movies`(`title`, `director_id`, `copyright_year`, `length`, `genre_id`, `category_id`, `rating`, `notes`)
VALUES('Star Wars', 3, NULL, NULL, 2, 2, 4,NULL);
INSERT INTO `movies`(`title`, `director_id`, `copyright_year`, `length`, `genre_id`, `category_id`, `rating`, `notes`)
VALUES('Jack Richer', 2, NULL, NULL, 5, 1, 3,NULL);
INSERT INTO `movies`(`title`, `director_id`, `copyright_year`, `length`, `genre_id`, `category_id`, `rating`, `notes`)
VALUES('The Godfather', 5, NULL, NULL, 1, 4, 2,NULL);
INSERT INTO `movies`(`title`, `director_id`, `copyright_year`, `length`, `genre_id`, `category_id`, `rating`, `notes`)
VALUES('The Matrix', 4, NULL, NULL, 4, 5, 5,NULL);