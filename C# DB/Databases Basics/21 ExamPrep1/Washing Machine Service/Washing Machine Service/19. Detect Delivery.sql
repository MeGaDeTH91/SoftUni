CREATE TRIGGER tr_Delivered ON Orders AFTER UPDATE
AS
BEGIN
   DECLARE @oldStatus BIT = (SELECT Delivered FROM deleted)
   DECLARE @newStatus BIT = (SELECT Delivered FROM inserted)

   IF(@oldStatus = 0 AND @newStatus = 1)
   BEGIN
		UPDATE Parts
		SET StockQty += op.Quantity
		FROM Parts AS p
		JOIN OrderParts AS op ON op.PartId = p.PartId
		JOIN Orders AS o ON o.OrderId = op.OrderId
		JOIN deleted AS d ON d.OrderId = o.OrderId
		JOIN inserted AS i ON i.OrderId = o.OrderId
		WHERE d.Delivered = 0 AND i.Delivered = 1
   END

END