-- create table: latest or history
CREATE TABLE measurementsLogLatest(
--CREATE TABLE measurementsLogHistory(
idMeas INT NOT NULL PRIMARY KEY IDENTITY(1,1) ,
idSensor INT,
dateMeas DATETIME,
sensorType VARCHAR(10),
valueMeas REAL);


-- SELECT DATA from doth table
SELECT * FROM measurementsLogLatest;
SELECT * FROM measurementsLogHistory;


-- SELECT ALL NAME of sensors (idSensor)
TODO

-- SELECT ALL NAME of sensors type (sensorType)
TODO

-- copy all data (older than: ONE DAY) from measurementsLogLatest to measurementsLogHistory and removed copied data from measurementsLogLatest
TODO



--generator @cnt new records for Latest table:
DECLARE @cnt INT = 0;
WHILE @cnt < 20
BEGIN
INSERT INTO dbo.measurementsLog (idSensor, dateMeas,valueMeas)
VALUES (RAND()*5,GETDATE(),RAND()*(25-10+1)+10);
   SET @cnt = @cnt + 1;
END;

SELECT * FROM measurementsLog;

