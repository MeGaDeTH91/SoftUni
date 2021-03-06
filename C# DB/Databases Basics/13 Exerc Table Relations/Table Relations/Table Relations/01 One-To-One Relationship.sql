CREATE TABLE Passports(
PassportID INT IDENTITY(101, 1),
PassportNumber VARCHAR(50) NOT NULL,
CONSTRAINT PK_PassID PRIMARY KEY(PassportID)
)

CREATE TABLE Persons(
PersonID INT IDENTITY,
FirstName VARCHAR(50) NOT NULL,
Salary DECIMAL(10, 2) NOT NULL,
PassportID INT UNIQUE,
CONSTRAINT PK_PersonID PRIMARY KEY(PersonID),
CONSTRAINT FK_PassID FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)
)

INSERT INTO Passports VALUES
('N34FG21B'), ('K65LO4R7'), ('ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300.00, 102), ('Tom', 56100.00, 103), ('Yana', 60200.00, 101)

DROP TABLE Passports
DROP TABLE Persons
SELECT * FROM Persons
SELECT * FROM Passports