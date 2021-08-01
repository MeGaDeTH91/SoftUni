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