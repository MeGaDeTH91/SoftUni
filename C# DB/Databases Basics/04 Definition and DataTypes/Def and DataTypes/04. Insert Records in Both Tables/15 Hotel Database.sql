CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR (50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES ('Michael', 'Jordan', 'The Master')

INSERT INTO Employees(FirstName, LastName, Title)
VALUES ('John', 'Wayne', 'The Shooter')

INSERT INTO Employees(FirstName, LastName, Title)
VALUES ('Arnold', 'Schwarzenegger', 'The Terminator')

CREATE TABLE Customers(
AccountNumber BIGINT PRIMARY KEY NOT NULL,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(50) NOT NULL,
EmergencyName NVARCHAR(50) NOT NULL,
EmergencyNumber NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES (333, 'Peter', 'Petev', '555-1111', 'Batman1', '555-Batman1')

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES (444, 'Niki', 'Nikev', '555-2222', 'Batman2', '555-Batman2')

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES (55, 'Toto', 'Tetev', '555-3333', 'Batman3', '555-Batman3')

CREATE TABLE RoomStatus(
RoomStatus INT IDENTITY PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(Notes)
VALUES ('Free'), ('Occupied'), ('It is complex')

CREATE TABLE RoomTypes(
RoomType INT IDENTITY PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(Notes)
VALUES ('Small'), ('Middle'), ('Big f*ckin house')

CREATE TABLE BedTypes(
BedType INT IDENTITY PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(Notes)
VALUES ('Small'), ('Middle'), ('Big f*ckin bed')

CREATE TABLE Rooms(
RoomNumber INT IDENTITY PRIMARY KEY NOT NULL,
RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType INT FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(10, 2) NOT NULL,
RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus)
VALUES (1, 1, 10.00, 1), (2, 2, 20.00, 2), (3, 3, 30.00, 3)

CREATE TABLE Payments(
Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
EmployeeId BIGINT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber BIGINT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays INT,
AmountCharged DECIMAL(10, 2) NOT NULL,
TaxRate DECIMAL(10, 2) NOT NULL,
TaxAmount DECIMAL(10, 2) NOT NULL,
PaymentTotal DECIMAL(10, 2) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES(1, GETDATE(), 333, '1995-10-10', '1995-11-11', 21.00, 5.00, 11.00, 150.00)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES(2, GETDATE(), 444, '1996-10-10', '1996-11-11', 21.00, 5.00, 11.00, 150.00)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES(3, GETDATE(), 55, '1997-10-10', '1997-11-11', 21.00, 5.00, 11.00, 150.00)

CREATE TABLE Occupancies(
Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
EmployeeId BIGINT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber BIGINT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied DECIMAL(10, 2) NOT NULL,
PhoneCharge DECIMAL(10, 2) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES (1, '1995-11-11', 333, 1, 10.00, 21.00)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES (2, '1996-11-11', 444, 2, 10.00, 21.00)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES (3, '1997-11-11', 55, 3, 10.00, 21.00)

