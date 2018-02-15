USE Minions

CREATE TABLE People(
Id INT IDENTITY PRIMARY KEY NOT NULL,
Name NVARCHAR(200) NOT NULL,
Picture VARBINARY CHECK (DATALENGTH(Picture) < 900*1024),
Height DECIMAL(10, 2),
[Weight] DECIMAL(10, 2),
Gender CHAR(1) NOT NULL CHECK(Gender = 'm' OR Gender = 'f'),
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People(Name,Gender, Birthdate)
VALUES('Goshko', 'm', '1991-04-02')

INSERT INTO People(Name,Gender, Birthdate)
VALUES('Petra', 'f', '1991-04-02')

INSERT INTO People(Name,Gender, Birthdate)
VALUES('Misho', 'm', '1991-04-02')

INSERT INTO People(Name,Gender, Birthdate)
VALUES('Ali', 'm', '1991-04-02')

INSERT INTO People(Name,Gender, Birthdate)
VALUES('Eliena', 'f', '1991-04-02')