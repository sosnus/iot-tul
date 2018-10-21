-- create table: latest

CREATE TABLE measurementsLogLatest(

idMeas INT NOT NULL PRIMARY KEY IDENTITY(1,1) ,

idSensor INT,

dateMeas DATETIME NOT NULL,

sensorType VARCHAR(10),

valueMeas REAL);


-- create table: history
CREATE TABLE measurementsLogHistory(

idMeasHistory INT NOT NULL PRIMARY KEY IDENTITY(1,1),

idMeas INT NOT NULL,

idSensor INT,

dateMeas DATETIME NOT NULL,

sensorType VARCHAR(10),

valueMeas REAL);



-- SELECT DATA from doth table

SELECT * FROM measurementsLogLatest;

SELECT * FROM measurementsLogHistory;





-- SELECT ALL NAME of sensors (idSensor)

SELECT DISTINCT idSensor FROM measurementsLogLatest;



-- SELECT ALL NAME of sensors type (sensorType)

SELECT DISTINCT sensorType FROM measurementsLogLatest;



-- copy all data (older than: ONE DAY) from measurementsLogLatest to measurementsLogHistory and removed copied data from measurementsLogLatest

INSERT INTO measurementsLogHistory 
SELECT * FROM measurementsLogLatest m WHERE  m.dateMeas < GETDATE()-1
DELETE FROM measurementsLogLatest WHERE dateMeas < GETDATE()-1



--generator @cnt new records for Latest table:

DECLARE @cnt INT = 0;

WHILE @cnt < 20

BEGIN

INSERT INTO dbo.measurementsLog (idSensor, dateMeas,valueMeas)

VALUES (RAND()*5,GETDATE(),RAND()*(25-10+1)+10);

   SET @cnt = @cnt + 1;

END;



SELECT * FROM measurementsLog;