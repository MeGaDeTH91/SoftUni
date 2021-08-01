ALTER TABLE `users`
DROP PRIMARY KEY,
ADD CONSTRAINT pk_users PRIMARY KEY (`id`),
ADD CONSTRAINT `username_unique` UNIQUE (`username`);