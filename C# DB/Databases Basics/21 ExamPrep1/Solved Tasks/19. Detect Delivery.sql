CREATE TRIGGER tr_OrderDelivered ON Orders
AFTER UPDATE
AS
BEGIN
    DECLARE @OldStatus INT = (SELECT Delivered FROM deleted)
    DECLARE @NewStatus INT = (SELECT Delivered FROM inserted)

    IF (@OldStatus = 0 AND @NewStatus = 1)
    BEGIN
        UPDATE Parts
        SET StockQty += op.Quantity
        FROM Parts AS p
        JOIN OrderParts op ON op.PartId = p.PartId
        JOIN Orders o ON o.OrderId = op.OrderId
        JOIN inserted AS i ON i.OrderId = o.OrderId
        JOIN deleted AS d ON d.OrderId = o.OrderId
        WHERE d.Delivered = 0 AND i.Delivered = 1
    END
END

BEGIN TRAN
    UPDATE Orders
    SET Delivered = 1
    WHERE OrderId = 21
ROLLBACK