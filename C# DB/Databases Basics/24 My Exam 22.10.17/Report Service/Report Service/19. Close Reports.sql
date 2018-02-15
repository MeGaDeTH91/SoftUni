CREATE TRIGGER tk_StatusChange ON Reports AFTER UPDATE
AS
	BEGIN
			BEGIN
				UPDATE Reports
				SET StatusId = 3
				FROM Reports AS r
				JOIN inserted AS i ON r.Id = i.Id
				JOIN deleted AS d ON d.Id = i.Id
				WHERE r.Id = i.Id AND d.Id = i.Id AND d.CloseDate IS NULL AND
				i.CloseDate IS NOT NULL
			END
	END