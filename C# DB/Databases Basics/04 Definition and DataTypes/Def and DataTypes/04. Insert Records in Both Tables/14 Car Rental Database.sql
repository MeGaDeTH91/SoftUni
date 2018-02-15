CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY NOT NULL,
CategoryName VARCHAR(100) NOT NULL,
DailyRate DECIMAL (10, 2),
WeeklyRate DECIMAL (10, 2),
MontlyRate DECIMAL (10, 2),
WeekendRate DECIMAL (10, 2)
)

CREATE TABLE Cars(
Id INT IDENTITY PRIMARY KEY NOT NULL,
PlateNumber NVARCHAR(50) NOT NULL,
Manufacturer VARCHAR(50) NOT NULL,
Model VARCHAR(50) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT NOT NULL,
Doors INT,
Picture VARBINARY CHECK(DATALENGTH(Picture) < 900 * 1024),
Condition VARCHAR(50),
Available BIT NOT NULL
)

CREATE TABLE Employees(
Id INT IDENTITY PRIMARY KEY NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR (50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
Id INT IDENTITY PRIMARY KEY NOT NULL,
DriverLicenseNumber NVARCHAR(100) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50) NOT NULL,
City NVARCHAR(50) NOT NULL,
ZIPCode NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
Id INT IDENTITY PRIMARY KEY NOT NULL,
EmployeeId INT NOT NULL,
CustomerId INT NOT NULL,
CarId INT NOT NULL,
TankLevel DECIMAL (10, 2) NOT NULL,
KilometrageStart BIGINT NOT NULL,
KilometrageEnd BIGINT NOT NULL,
TotalKilometrage BIGINT,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays DATE,
RateApplied DECIMAL (10, 2) NOT NULL,
TaxRate DECIMAL (10, 2) NOT NULL,
OrderStatus VARCHAR(50) NOT NULL,
Notes NVARCHAR(50)
)

INSERT INTO Categories(CategoryName)
VALUES ('Limusine'), ('Cabrio'), ('Truck')

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Available)
VALUES ('Yes!', 'Toyota', 'Supra', 1991, 1, 1)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Available)
VALUES ('Yes!2', 'Audi', 'A8', 1991, 1, 2)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Available)
VALUES ('Yes!3', 'BMW', 'M7', 1991, 1, 3)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES ('Michael', 'Jordan', 'The Master')

INSERT INTO Employees(FirstName, LastName, Title)
VALUES ('John', 'Wayne', 'The Shooter')

INSERT INTO Employees(FirstName, LastName, Title)
VALUES ('Arnold', 'Schwarzenegger', 'The Terminator')

INSERT INTO Customers(DriverLicenseNumber, FullName, [Address], City, ZIPCode)
VALUES ('Echo1', 'PeterPete', 'Bulgaria', 'Sofia', '2100')

INSERT INTO Customers(DriverLicenseNumber, FullName, [Address], City, ZIPCode)
VALUES ('Echo2', 'Johny Walker', 'Bulgaria', 'Sofia', '2100')

INSERT INTO Customers(DriverLicenseNumber, FullName, [Address], City, ZIPCode)
VALUES ('Echo3', 'Bushmills', 'Bulgaria', 'Sofia', '2100')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus)
VALUES (1, 1, 1, 50.00, 100, 300, '1991-04-02', '1991-04-20', 20.00, 15.5, 'Ordered')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus)
VALUES (2, 2, 2, 60.00, 200, 400, '1992-04-02', '1992-04-20', 30.00, 25.5, 'Ordered')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus)
VALUES (3, 3, 3, 70.00, 300, 500, '1993-04-02', '1993-04-20', 40.00, 35.5, 'Ordered')