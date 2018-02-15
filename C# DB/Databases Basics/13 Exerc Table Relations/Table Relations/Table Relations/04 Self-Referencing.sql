CREATE TABLE Teachers(
TeacherID INT IDENTITY(101, 1),
[Name] VARCHAR(50) NOT NULL,
ManagerID INT,
CONSTRAINT PK_Teachers PRIMARY KEY(TeacherID),
CONSTRAINT FK_Teachers FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 106),
('Greta', 106)