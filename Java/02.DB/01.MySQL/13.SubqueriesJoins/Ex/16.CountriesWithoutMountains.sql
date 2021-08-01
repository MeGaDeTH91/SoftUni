SELECT COUNT(`c`.`continent_code`) AS `country_count`
FROM `countries` AS `c`
LEFT JOIN `mountains_countries` AS `mc` ON `mc`.`country_code` = `c`.`country_code`
WHERE `mc`.`mountain_id` IS NULL;