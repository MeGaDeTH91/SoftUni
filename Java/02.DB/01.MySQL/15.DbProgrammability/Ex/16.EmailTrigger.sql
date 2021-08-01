CREATE TABLE `logs`(
log_id INT PRIMARY KEY AUTO_INCREMENT,
account_id INT NOT NULL,
old_sum DECIMAL(21,4) NOT NULL,
new_sum DECIMAL(21,4) NOT NULL
);
CREATE TABLE notification_emails(
id INT PRIMARY KEY AUTO_INCREMENT,
recipient INT NOT NULL,
`subject` VARCHAR(255) NOT NULL,
body VARCHAR(255) NOT NULL
);

DELIMITER ###
CREATE TRIGGER trigger_accounts
AFTER UPDATE
ON accounts
FOR EACH ROW
BEGIN
INSERT INTO `logs`(account_id, old_sum, new_sum)
VALUES(OLD.id, OLD.balance, NEW.balance);
END ###

CREATE TRIGGER trigger_emails
AFTER INSERT
ON `logs`
FOR EACH ROW
BEGIN
INSERT INTO notification_emails(recipient, `subject`, body)
VALUES(
NEW.account_id,
CONCAT('Balance change for account: ', NEW.account_id),
CONCAT('On ', DATE_FORMAT(NOW(), '%b %d %Y at %h:%i:%s %p'), ' your balance was changed from ', NEW.old_sum, ' to ', NEW.new_sum, '.'));
END ###

DELIMITER ;