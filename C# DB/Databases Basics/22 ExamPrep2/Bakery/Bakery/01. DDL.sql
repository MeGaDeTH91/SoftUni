CREATE TABLE Products(
Id INT IDENTITY(1, 1),
[Name] NVARCHAR(25) UNIQUE,
[Description] NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price MONEY CHECK(Price >= 0),
CONSTRAINT PK_Products PRIMARY KEY(Id)
)

CREATE TABLE Countries(
Id INT IDENTITY(1, 1),
[Name] NVARCHAR(50) UNIQUE,
CONSTRAINT PK_Countries PRIMARY KEY(Id)
)

CREATE TABLE Customers(
Id INT IDENTITY(1, 1),
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1) CHECK(Gender IN('M', 'F')),
Age INT,
PhoneNumber CHAR(10),
CountryId INT,
CONSTRAINT PK_Customers PRIMARY KEY(Id),
CONSTRAINT FK_Customers FOREIGN KEY(CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Feedbacks(
Id INT IDENTITY(1, 1),
[Description] NVARCHAR(255),
Rate DECIMAL(15, 2) CHECK(Rate BETWEEN 0 AND 10),
ProductId INT,
CustomerId INT,
CONSTRAINT PK_Feedbacks PRIMARY KEY(Id),
CONSTRAINT FK_FeedProducts FOREIGN KEY(ProductId) REFERENCES Products(Id),
CONSTRAINT FK_FeedCust FOREIGN KEY(CustomerId) REFERENCES Customers(Id)
)

CREATE TABLE Distributors(
Id INT IDENTITY(1, 1),
[Name] NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT,
CONSTRAINT PK_Distributors PRIMARY KEY(Id),
CONSTRAINT FK_Distributors FOREIGN KEY(CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Ingredients(
Id INT IDENTITY(1, 1),
[Name] NVARCHAR(30),
[Description] NVARCHAR(200),
OriginCountryId INT,
DistributorId INT,
CONSTRAINT PK_Ingredients PRIMARY KEY(Id),
CONSTRAINT FK_OriginCountry FOREIGN KEY(OriginCountryId) REFERENCES Countries(Id),
CONSTRAINT FK_IngrDistrs FOREIGN KEY(DistributorId) REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients(
ProductId INT,
IngredientId INT,
CONSTRAINT PK_PrdIngredients PRIMARY KEY(ProductId, IngredientId),
CONSTRAINT FK_Prods FOREIGN KEY(ProductId) REFERENCES Products(Id),
CONSTRAINT FK_Ings FOREIGN KEY(IngredientId) REFERENCES Ingredients(Id)
)