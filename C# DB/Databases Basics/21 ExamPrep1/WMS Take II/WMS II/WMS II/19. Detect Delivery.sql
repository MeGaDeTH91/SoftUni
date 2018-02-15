CREATE TRIGGER tk_StatusChange ON Orders AFTER UPDATE
AS
	BEGIN
		DECLARE @deletedStatus BIT = (SELECT Delivered FROM deleted)
		DECLARE @insertedStatus BIT = (SELECT Delivered FROM inserted)

		IF(@deletedStatus = 0 AND @insertedStatus = 1)
			BEGIN
				UPDATE Parts
				SET StockQty += op.Quantity
				FROM Parts AS p
				JOIN OrderParts AS op ON op.PartId = p.PartId
				JOIN Orders AS o ON o.OrderId = op.OrderId
				JOIN inserted AS i ON i.OrderId = o.OrderId
				JOIN deleted AS d ON d.OrderId = i.OrderId
				WHERE d.Delivered = 0 AND i.Delivered = 1
			END
	END