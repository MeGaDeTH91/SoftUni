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