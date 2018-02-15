BACKUP DATABASE SoftUni
TO DISK = 'E:\BackupDATArestore\SoftUni.bak'

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'E:\BackupDATArestore\SoftUni.bak'