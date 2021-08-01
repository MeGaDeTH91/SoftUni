#1
USE minions;
CREATE TABLE minions (
id INT AUTO_INCREMENT, 
NAME VARCHAR(255),
age INT,
PRIMARY KEY(id)
);

CREATE TABLE towns (
town_id INT AUTO_INCREMENT, 
NAME VARCHAR(255),
PRIMARY KEY(town_id)
);

#2
ALTER TABLE `minions`
ADD COLUMN `town_id` INT,
ADD FOREIGN KEY fk_towns(town_id) REFERENCES towns(id) ON DELETE CASCADE;

#3
INSERT INTO `towns`(`id`, `name`)
VALUES (1, 'Sofia'), (2, 'Plovdiv'), (3, 'Varna');

INSERT INTO `minions`(`id`, `name`, `age`, `town_id`)
VALUES (1, 'Kevin', 22, 1), (2, 'Bob', 15, 3), (3, 'Steward', NULL, 2); 

#4
TRUNCATE TABLE `minions`;

#5
USE minions;
SET FOREIGN_KEY_CHECKS = 0;
drop table if exists minions;
drop table if exists towns;
SET FOREIGN_KEY_CHECKS = 1;
#5.1
DROP TABLE minions;
DROP TABLE towns;

#6
CREATE TABLE `people` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`name` VARCHAR(200) NOT NULL,
`picture` BLOB(2) NULL,
`height` DECIMAL(2) NULL,
`weight` DECIMAL(2) NULL,
`gender` CHAR(1) NOT NULL,
`birthdate` DATE NOT NULL,
`biography` TEXT  NULL
);

INSERT INTO `people` (`name`, `gender`, `birthdate`) VALUES ("Peter", "m", "1991-05-05");
INSERT INTO `people` (`name`, `weight`, `gender`, `birthdate`) VALUES ("George", 65, "m", "1981-07-08");
INSERT INTO `people` (`name`, `weight`, `gender`, `birthdate`, `biography`) VALUES ("Newton", 78.1, "m", "1998-05-04", "Pesho lud");
INSERT INTO `people` (`name`, `gender`, `birthdate`) VALUES ("John", "f", "2011-02-05");
INSERT INTO `people` (`name`, `gender`, `height`, `birthdate`) VALUES ("Riki", "m", 3.85, "2004-08-09");

#7
USE minions;
CREATE TABLE `users` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`username` VARCHAR(30) UNIQUE NOT NULL,
`password` VARCHAR(26) NOT NULL,
`profile_picture` BLOB NULL,
`last_login_time` DATE NULL,
`is_deleted` BOOLEAN NULL
);

INSERT INTO `users`(`username`, `password`, `profile_picture`, `last_login_time`, `is_deleted`)
VALUES
('Marto', '123456', NULL, NULL, 1);

INSERT INTO `users`(`username`, `password`, `profile_picture`, `last_login_time`, `is_deleted`)
VALUES
('Mar1', '21443', NULL, NULL, 1);

INSERT INTO `users`(`username`, `password`, `profile_picture`, `last_login_time`, `is_deleted`)
VALUES
('Marto2', '3123456', NULL, NULL, 1);

INSERT INTO `users`(`username`, `password`, `profile_picture`, `last_login_time`, `is_deleted`)
VALUES
('Marto3', '4123456', NULL, NULL, 1);

INSERT INTO `users`(`username`, `password`, `profile_picture`, `last_login_time`, `is_deleted`)
VALUES
('Marto4', '5123456', NULL, NULL, 1);

#8
ALTER TABLE `users`
DROP PRIMARY KEY,
ADD CONSTRAINT pk_users PRIMARY KEY (`id`, `username`);

#9
ALTER TABLE `users`
MODIFY COLUMN `last_login_time` TIMESTAMP DEFAULT CURRENT_TIMESTAMP;

#10
ALTER TABLE `users`
DROP PRIMARY KEY,
ADD CONSTRAINT pk_users PRIMARY KEY (`id`),
ADD CONSTRAINT `username_unique` UNIQUE (`username`);

#11
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

#12
CREATE DATABASE `car_rental`;
USE `car_rental`;
CREATE TABLE `categories` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`category` VARCHAR(50) NOT NULL,
`daily_rate` DECIMAL,
`weekly_rate` DECIMAL,
`monthly_rate` DECIMAL,
`weekend_rate` DECIMAL
);
CREATE TABLE `cars` (
`id` INT AUTO_INCREMENT PRIMARY KEY, 
`plate_number` VARCHAR(50) UNIQUE NOT NULL,
`make` VARCHAR(50),
`model` VARCHAR(50),
`car_year` INT,
`category_id` INT NOT NULL,
`doors` INT,
`picture` BLOB,
`car_condition`VARCHAR(50),
`available` BOOLEAN NOT NULL
);
CREATE TABLE `employees`(
`id` INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
`first_name` VARCHAR(50) NOT NULL,
`last_name` VARCHAR (50) NOT NULL,
`title` VARCHAR(50) NOT NULL,
`notes` TEXT
);

CREATE TABLE `customers`(
`id` INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
`driver_licence_number` VARCHAR(100) NOT NULL,
`full_name` VARCHAR(50) NOT NULL,
`address` VARCHAR(250),
`city` VARCHAR(50),
`zip_code` VARCHAR(50),
`notes` TEXT
);

CREATE TABLE `rental_orders`(
`id` INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
`employee_id` INT NOT NULL,
`customer_id` INT NOT NULL,
`car_id` INT NOT NULL,
`tank_level` DECIMAL (10, 2) NOT NULL,
`kilometrage_start` BIGINT NOT NULL,
`kilometrage_end` BIGINT NOT NULL,
`total_kilometrage` BIGINT,
`start_date` DATE NOT NULL,
`end_date` DATE NOT NULL,
`total_days` INT,
`rate_applied` DECIMAL NOT NULL,
`tax_rate` DECIMAL NOT NULL,
`order_status` VARCHAR(50) NOT NULL,
`notes` TEXT
);
INSERT INTO `categories`(`category`)
VALUES ('Limusine'), ('Cabrio'), ('Truck');

INSERT INTO `cars`(`plate_number`, `make`, `model`, `car_year`, `category_id`, `available`)
VALUES ('Yes!', 'Toyota', 'Supra', 1991, 1, TRUE);

INSERT INTO `cars`(`plate_number`, `make`, `model`, `car_year`, `category_id`, `available`)
VALUES ('Yes!2', 'Audi', 'A8', 1991, 1, FALSE);

INSERT INTO `cars`(`plate_number`, `make`, `model`, `car_year`, `category_id`, `available`)
VALUES ('Yes!3', 'BMW', 'M7', 1991, 1, TRUE);

INSERT INTO `employees`(`first_name`, `last_name`, `title`)
VALUES ('Michael', 'Jordan', 'The Master');

INSERT INTO `employees`(`first_name`, `last_name`, `title`)
VALUES ('John', 'Wayne', 'The Shooter');

INSERT INTO `employees`(`first_name`, `last_name`, `title`)
VALUES ('Arnold', 'Schwarzenegger', 'The Terminator');

INSERT INTO `customers`(`driver_licence_number`, `full_name`, `address`, `city`, `zip_code`)
VALUES ('Echo1', 'PeterPete', 'Bulgaria', 'Sofia', '2100');

INSERT INTO `customers`(`driver_licence_number`, `full_name`, `address`, `city`, `zip_code`)
VALUES ('Echo2', 'Johny Walker', 'Bulgaria', 'Sofia', '2100');

INSERT INTO `customers`(`driver_licence_number`, `full_name`, `address`, `city`, `zip_code`)
VALUES ('Echo3', 'Bushmills', 'Bulgaria', 'Sofia', '2100');

INSERT INTO `rental_orders`(`employee_id`, `customer_id`, `car_id`, `tank_level`, `kilometrage_start`, `kilometrage_end`, `start_date`, `end_date`, `rate_applied`, `tax_rate`, `order_status`)
VALUES (1, 1, 1, 50.00, 100, 300, '1991-04-02', '1991-04-20', 20.00, 15.5, 'Ordered');

INSERT INTO `rental_orders`(`employee_id`, `customer_id`, `car_id`, `tank_level`, `kilometrage_start`, `kilometrage_end`, `start_date`, `end_date`, `rate_applied`, `tax_rate`, `order_status`)
VALUES (2, 2, 2, 60.00, 200, 400, '1992-04-02', '1992-04-20', 30.00, 25.5, 'Ordered');

INSERT INTO `rental_orders`(`employee_id`, `customer_id`, `car_id`, `tank_level`, `kilometrage_start`, `kilometrage_end`, `start_date`, `end_date`, `rate_applied`, `tax_rate`, `order_status`)
VALUES (3, 3, 3, 70.00, 300, 500, '1993-04-02', '1993-04-20', 40.00, 35.5, 'Ordered');

#13
INSERT INTO towns VALUES (1, 'Sofia'),
						 (2, 'Plovdiv'),
						 (3, 'Varna'),
						 (4, 'Burgas');                            
                            
INSERT INTO departments VALUES (1, 'Engineering'),
							   (2, 'Sales'),
							   (3, 'Marketing'),
							   (4, 'Software Development'),
							   (5, 'Quality Assurance');
                                   
INSERT INTO employees (id, first_name, middle_name, last_name, job_title, department_id, hire_date, salary)
VALUES (1, 'Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	   (2, 'Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	   (3, 'Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	   (4, 'Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	   (5, 'Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);

#14
SELECT * FROM `towns`;
SELECT * FROM `departments`;
SELECT * FROM `employees`;

#15
SELECT * FROM `towns`
ORDER BY `name` ASC;
SELECT * FROM `departments`
ORDER BY `name` ASC;
SELECT * FROM `employees`
ORDER BY `salary` DESC;

#16
SELECT `name` FROM `towns`
ORDER BY `name` ASC;
SELECT `name` FROM `departments`
ORDER BY `name` ASC;
SELECT `first_name`, `last_name`, `job_title`, `salary` FROM `employees`
ORDER BY `salary` DESC;

#17
UPDATE `employees`
SET `salary` = `salary` * 1.10;
SELECT `salary` FROM `employees`;

#18
TRUNCATE TABLE `occupancies`