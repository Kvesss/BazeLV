<Query Kind="SQL">
  <Connection>
    <ID>f32d6385-d5a0-48e9-9b87-ab9efe6fafdd</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>stuslu</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

--Zad1

SELECT
--DISTINCT
SUBSTRING(ime, 1, 1) AS 'imeInic', SUBSTRING(prezime, 1, 1) AS 'prezimeInic', YEAR(datRod) as 'godinaRodenja'
FROM student
ORDER BY godinaRodenja ASC;

SELECT ime, prezime, datRod
FROM student
WHERE datRod=(SELECT MIN(datRod) FROM student WHERE spol='F')

--Zad2

SELECT COUNT(mbr) AS 'brojStudenata'
FROM student;

SELECT 
COUNT(DISTINCT pbrPreb) AS 'brojMjesta'
FROM student;

SELECT *
FROM student;

--Zad3

SELECT
AVG(CAST(ocjena AS DECIMAL(3,2))) AS 'prosjecnaOcjena'
FROM ispit
WHERE ocjena > 1;


--Zad4

SELECT
ime, prezime, AVG(CAST(ocjena AS DECIMAL(3,2))) AS 'prosjecnaOcjena'
FROM ispit, student
WHERE mbrStud = mbr AND ocjena > 1
GROUP BY prezime, ime
ORDER BY prosjecnaOcjena DESC;

SELECT mbrStud, AVG(CAST(ocjena AS DECIMAL(3,2)))
FROM ispit
WHERE ocjena > 1
GROUP BY mbrStud
HAVING AVG(CAST(ocjena AS DECIMAL(3,2))) > 2.5 ;


--Zad5

ALTER VIEW ispiti AS 
SELECT naziv, ocjena, datIspita, ime, prezime
FROM ispit, predmet, student
WHERE mbrStud = mbr AND sifPredmeta = sifra; -- AND ocjena > 1
