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