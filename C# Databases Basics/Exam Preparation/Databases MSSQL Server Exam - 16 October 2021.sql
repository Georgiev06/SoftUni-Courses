--Problem 01

CREATE DATABASE CigarShop

GO

USE CigarShop

GO

CREATE TABLE Sizes (
Id INT PRIMARY KEY IDENTITY,
Length INT NOT NULL
CHECK(Length >= 10 AND Length <= 25),
RingRange DECIMAL(4, 2) NOT NULL 
CHECK(RingRange >= 1.5 AND RingRange <= 7.5),
)

CREATE TABLE Tastes (
Id INT PRIMARY KEY IDENTITY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL,

)

CREATE TABLE Brands (
Id INT PRIMARY KEY IDENTITY,
BrandName VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars (
Id INT PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar MONEY NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY,
Town VARCHAR(30) NOT NULL,
Country VARCHAR(30) NOT NULL,
Streat VARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
)

CREATE TABLE ClientsCigars (
 ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
 CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL,
 CONSTRAINT PK_Client_Cigar PRIMARY KEY (ClientId, CigarId)
)

--Problem 02


--Problem 03

UPDATE Cigars
SET PriceForSingleCigar += 0.2 * PriceForSingleCigar 
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--Problem 04

DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses
WHERE Country LIKE 'C%')

DELETE FROM Addresses
WHERE Country LIKE 'C%'

--Problem 05

SELECT CigarName, PriceForSingleCigar, ImageURL FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

--Problem 06

SELECT c.Id, c.CigarName, c.PriceForSingleCigar, TasteType, TasteStrength FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY c.PriceForSingleCigar DESC

--Problem 07

SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS ClientName, c.Email FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE cc.CigarId IS NULL
ORDER BY ClientName ASC

--Problem 08

SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC
 
 --Problem 09

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, a.Country, a.ZIP, CONCAT('$', MAX(cg.PriceForSingleCigar)) AS CigarPrice FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS cg ON cc.CigarId = cg.Id
WHERE a.ZIP NOT LIKE '%[^0-9]%' -- *code that contains only digits
GROUP BY c.Id, c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName

 --Problem 10

SELECT c.LastName, AVG(s.Length) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange FROM Clients AS c 
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS cg ON cc.CigarId = cg.Id
JOIN Sizes AS s ON cg.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC

 --Problem 11

GO

CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(30)) 
RETURNS INT 
AS
BEGIN
	RETURN(SELECT COUNT(cg.Id) FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS cg ON cc.CigarId = cg.Id
WHERE c.FirstName = @name)
END

GO

SELECT dbo.udf_ClientWithCigars('Betty')

 --Problem 12

GO

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT c.CigarName, CONCAT('$', c.PriceForSingleCigar) AS Price, t.TasteType, b.BrandName, CONCAT(s.Length, ' ', 'cm') AS CigarLength, CONCAT(s.RingRange, ' ', 'cm') AS CigarRingRange FROM Cigars AS c
	JOIN Tastes AS t ON c.TastId = t.Id
	JOIN Brands AS b ON c.BrandId = b.Id
	JOIN Sizes AS s ON c.SizeId = s.Id
	WHERE t.TasteType = @taste
	ORDER BY CigarLength, CigarRingRange DESC
END

GO

EXEC usp_SearchByTaste 'Woody'
