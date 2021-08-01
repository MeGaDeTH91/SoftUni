ALTER TABLE `minions`
ADD COLUMN `town_id` INT,
ADD FOREIGN KEY fk_towns(town_id) REFERENCES towns(id) ON DELETE CASCADE;