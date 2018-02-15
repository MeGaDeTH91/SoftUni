USE Minions

CREATE TABLE Users(
Id BIGINT IDENTITY NOT NULL,
Username VARCHAR(30) UNIQUE NOT NULL,
Password VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted BIT 
CONSTRAINT PK_Users PRIMARY KEY(Id)
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Marto', '123456', NULL, NULL, 1)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Mar1', '21443', NULL, NULL, 1)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Marto2', '3123456', NULL, NULL, 1)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Marto3', '4123456', NULL, NULL, 1)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Marto4', '5123456', NULL, NULL, 1)

INSERT INTO Users(Username, Password, IsDeleted)
VALUES
('Martoss', '5123456', 1)
