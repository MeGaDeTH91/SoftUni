SELECT `country_name`, `country_code`, IF(`currency_code` = 'EUR', 'Euro', 'Not Euro ') AS 'currency'
FROM `countries`
WHERE `continent_code` = 'EU'
ORDER BY `country_name` ASC;