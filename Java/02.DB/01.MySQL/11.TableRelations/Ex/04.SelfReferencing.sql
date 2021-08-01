CREATE TABLE `teachers` (
`teacher_id` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
`name` VARCHAR(35) NOT NULL,
`manager_id` INT NULL,
CONSTRAINT `fk_manager` FOREIGN KEY(`manager_id`) REFERENCES `teachers`(`teacher_id`)
);

INSERT INTO `teachers`(`teacher_id`, `name`, `manager_id`) 
VALUES
(101, 'John', NULL),
(105, 'Mark', 101),
(106, 'Greta', 101),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105);