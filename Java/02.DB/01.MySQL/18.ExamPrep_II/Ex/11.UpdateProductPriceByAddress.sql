DELIMITER ###

CREATE PROCEDURE udp_update_product_price(address_name VARCHAR (50))
BEGIN
	DECLARE price_increase INT;
    IF address_name LIKE '0%' THEN SET price_increase := 100;
    ELSE SET price_increase := 200;
    END IF;
    
    UPDATE  products AS p
	JOIN products_stores AS ps
	ON ps.product_id = p.id
	JOIN stores AS s
	ON s.id = ps.store_id
	JOIN addresses AS a
	ON a.id = s.address_id
    SET p.price = p.price + price_increase 
	WHERE a.`name` = address_name;
END ###

DELIMITER ;


CALL udp_update_product_price('07 Armistice Parkway');
SELECT name, price FROM products WHERE id = 15;

