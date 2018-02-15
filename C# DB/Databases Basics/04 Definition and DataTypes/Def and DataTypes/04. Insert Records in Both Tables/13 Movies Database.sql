CREATE DATABASE Movies
USE Movies
CREATE TABLE Directors(
Id INT IDENTITY NOT NULL,
DirectorName VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
CONSTRAINT PK_Directors PRIMARY KEY(Id)
)
CREATE TABLE Genres(
Id INT IDENTITY NOT NULL,
GenreName VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
CONSTRAINT PK_Genres PRIMARY KEY(Id)
)
CREATE TABLE Categories(
Id INT IDENTITY NOT NULL,
CategoryName VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
CONSTRAINT PK_Categories PRIMARY KEY(Id)
)
CREATE TABLE Movies(
Id INT IDENTITY NOT NULL,
Title VARCHAR(50) NOT NULL,
DirectorId INT UNIQUE NOT NULL,
CopyrightYear DATE,
Length DECIMAL(10, 2),
GenreId INT UNIQUE NOT NULL,
CategoryId INT UNIQUE NOT NULL,
Rating INT,
Notes VARCHAR(MAX)
CONSTRAINT PK_Movies PRIMARY KEY(Id)
)

INSERT INTO Directors(DirectorName, Notes)
Values('Martin', NULL)
INSERT INTO Directors(DirectorName, Notes)
Values('Veselin', 'Nearly done!')
INSERT INTO Directors(DirectorName, Notes)
Values('Maria', 'Completely done!')
INSERT INTO Directors(DirectorName, Notes)
Values('Pasteti', NULL)
INSERT INTO Directors(DirectorName, Notes)
Values('Goshko', NULL)

INSERT INTO Genres(GenreName, Notes)
Values('Horror', NULL)
INSERT INTO Genres(GenreName, Notes)
Values('Comedy', 'Completely done!')
INSERT INTO Genres(GenreName, Notes)
Values('Action', NULL)
INSERT INTO Genres(GenreName, Notes)
Values('Thriller', 'Completely done!')
INSERT INTO Genres(GenreName, Notes)
Values('Drama', 'Nearly done!')

INSERT INTO Categories(CategoryName, Notes)
Values('Pesho', 'Completely done!')
INSERT INTO Categories(CategoryName, Notes)
Values('Gosho', 'Nearly done!')
INSERT INTO Categories(CategoryName, Notes)
Values('Pesho', NULL)
INSERT INTO Categories(CategoryName, Notes)
Values('Mariika', 'Nearly done!')
INSERT INTO Categories(CategoryName, Notes)
Values('Pastefan', 'Completely done!')

INSERT INTO Movies(Title, DirectorID, CopyrightYear, Length, GenreID, CategoryID,Rating,Notes)
Values('Terminator II', 11233412, NULL, NUll, 643675, 3, 6,NULL)
INSERT INTO Movies(Title, DirectorID, CopyrightYear, Length, GenreID, CategoryID,Rating,Notes)
Values('Star Wars', 535123, NULL, NUll, 123453, 2, 4,NULL)
INSERT INTO Movies(Title, DirectorID, CopyrightYear, Length, GenreID, CategoryID,Rating,Notes)
Values('Jack Richer', 7657457, NULL, NUll, 51532, 1, 3,NULL)
INSERT INTO Movies(Title, DirectorID, CopyrightYear, Length, GenreID, CategoryID,Rating,Notes)
Values('The Godfather', 123547568, NULL, NUll, 4343, 4, 2,NULL)
INSERT INTO Movies(Title, DirectorID, CopyrightYear, Length, GenreID, CategoryID,Rating,Notes)
Values('The Matrix', 97876543, NULL, NUll, 123, 7, 5,NULL)