CREATE TABLE NotificationEmails(
Id INT IDENTITY(1, 1),
Recipient INT NOT NULL,
[Subject] VARCHAR(MAX)NOT NULL,
Body VARCHAR(MAX) NOT NULL,
CONSTRAINT PK_NotificationEmails PRIMARY KEY(Id)
)
GO
CREATE TRIGGER tr_Notifications ON Logs AFTER INSERT
AS
BEGIN
DECLARE @recipient INT = (SELECT Logs.AccountId FROM Logs)
DECLARE @old MONEY = (SELECT Logs.OldSum FROM Logs)
DECLARE @new MONEY = (SELECT Logs.NewSum FROM Logs)
DECLARE @subject VARCHAR(MAX) = CONCAT('Balance change for account: ', @recipient)
DECLARE @body VARCHAR(MAX) = CONCAT('On ', GETDATE(), 'your balance was changed from ', @old, ' to ', @new)

INSERT INTO NotificationEmails(Recipient, [Subject], Body)VALUES
 (@recipient, @subject, @body)
END