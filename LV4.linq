<Query Kind="SQL">
  <Connection>
    <ID>f32d6385-d5a0-48e9-9b87-ab9efe6fafdd</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>stuslu</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


--zad1
CREATE FUNCTION palindrome(@rijec VARCHAR(100)) RETURNS VARCHAR(100)
BEGIN

	DECLARE @reversed VARCHAR(100);
	IF LEN(@rijec) > 30
	BEGIN
		SET @reversed = 'Ulazna riječ je predugačka, maksimalan broj znakova je 30'
		RETURN @reversed
	END
	ELSE
	BEGIN
		SET @reversed = REVERSE(@rijec);
		IF @reversed = @rijec
			SET @reversed = 'palindrom'
	END
	RETURN @reversed
END

SELECT dbo.palindrome('davad') AS 'palindrom';



--OVO
CREATE FUNCTION palindrome(@rijec VARCHAR(100)) RETURNS VARCHAR(100)
BEGIN

	DECLARE @reversed VARCHAR(100) = '';
	DECLARE @kopija VARCHAR(100) = @rijec;
	IF LEN(@rijec) > 30
	BEGIN
		SET @reversed = 'Ulazna riječ je predugačka, maksimalan broj znakova je 30'
		RETURN @reversed
	END
	ELSE
	BEGIN
		WHILE LEN(@kopija) > 0
		BEGIN
			SET @reversed = @reversed + SUBSTRING(@kopija, LEN(@kopija), LEN(@kopija));
			SET @kopija = SUBSTRING(@kopija, 1, LEN(@kopija)-1);
		END
		IF @reversed = @rijec
			RETURN 'palindrom'
	END
	RETURN @reversed
END

--zad2
CREATE PROCEDURE procedura(@rijec VARCHAR(100)) AS

DECLARE @reversed VARCHAR(100);
SET @reversed = REVERSE(@rijec);
IF @reversed = @rijec
BEGIN
	SET @reversed = 'palindrom'
END
IF LEN(@rijec) > 30
	SET @reversed = 'Ulazna riječ je predugačka, maksimalan broj znakova je 30'
PRINT @reversed

exec procedura 'DAVID'

--zad3
CREATE TRIGGER okidac ON racuni FOR insert 
AS
DECLARE @reversedIme CHAR(30); SELECT @reversedIme = ime FROM inserted
DECLARE @OIB CHAR(11); SELECT @OIB = oib FROM inserted
SET @reversedIme = REVERSE(@reversedIme)
UPDATE racuni
SET ime = @reversedIme WHERE oib = @OIB

CREATE TABLE racuni(
	ime CHAR(30),
	OIB char(11) PRIMARY KEY,
	drzava CHAR(20)
	);
	

INSERT INTO racuni VALUES('DAVID', '12345678901', 'HRVATSKA')

SELECT * FROM racuni


--zad +

ALTER PROCEDURE horoskop(@datum DATETIME) AS
DECLARE @znak CHAR(15);
SELECT
CASE 
WHEN (MONTH(@datum) = 3 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 4 AND DAY(@datum) <= 20) THEN 'Ovan' 
WHEN (MONTH(@datum) = 4 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 5 AND DAY(@datum) <= 20) THEN 'Bik'
WHEN (MONTH(@datum) = 5 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 6 AND DAY(@datum) <= 20) THEN 'Blizanac'
WHEN (MONTH(@datum) = 6 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 7 AND DAY(@datum) <= 20) THEN 'Rak'
WHEN (MONTH(@datum) = 7 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 8 AND DAY(@datum) <= 20) THEN 'Lav'
WHEN (MONTH(@datum) = 8 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 9 AND DAY(@datum) <= 20) THEN 'Djevica'
WHEN (MONTH(@datum) = 9 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 10 AND DAY(@datum) <= 20) THEN 'Vaga'
WHEN (MONTH(@datum) = 10 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 11 AND DAY(@datum) <= 20) THEN 'Škorpion'
WHEN (MONTH(@datum) = 11 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 12 AND DAY(@datum) <= 20) THEN 'Strijelac'
WHEN (MONTH(@datum) = 12 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 1 AND DAY(@datum) <= 20) THEN 'Jarac'
WHEN (MONTH(@datum) = 1 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 2 AND DAY(@datum) <= 20) THEN 'Vodenjak'
WHEN (MONTH(@datum) = 2 AND DAY(@datum) >= 21) OR (MONTH(@datum) = 3 AND DAY(@datum) <= 20) THEN 'Riba'
ELSE 'Wrong date'
END
PRINT @znak


exec horoskop '06/19/2000'







