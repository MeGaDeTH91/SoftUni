SELECT `country_name`, `iso_code`
FROM `countries`
WHERE LENGTH(`country_name`) - LENGTH(REPLACE(LOWER(`country_name`), 'a', '')) >= 3
ORDER BY `iso_code`;