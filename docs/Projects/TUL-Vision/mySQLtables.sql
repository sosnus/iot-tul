CREATE TABLE temperature(
id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
temp INT NOT NULL,
reg_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
)


INSERT INTO temperature(temp)
VALUES (22)


INSERT INTO table_name (column1, column2, column3,...)
VALUES (value1, value2, value3,...)

INSERT INTO temperature(temp) VALUES (10+10*RAND())


        self._id = _id
        self.name = name
        self.description = description
        self.gps = gps # Latitude, Longitude, Altitude - B, L, h (szerokość, długość, wysokość elipsoidalna) (WGS-84 system)
        self.mountAngle = mountAngle # yaw, pich, roll
        self.viewAngle = [78,42] #lens angle [horizontal,vertical]


INSERT INTO(name,description,latitude,longitude,altitude,yaw,pich,roll,viewAngleHorizontal,viewAngleVertical)
VALUES ('cam0','hall A, left corner', 51.752777, 19.454069, 15.8,  359, -20, 0,78, 42)
VALUES ('cam1','hall A, right corner',51.752807, 19.194066, 15.81, 0, -20, 0, 78, 42)

VALUES ('cam2','hall B, left corner',51.752811, 19.19454077, 15.82, 30, -20, 0, 78, 42)



{"lastMsg": 1568534439, "_id": "523c067f-24b0-4f67-ab4b-52eeae40ea39", "aboutCam": {"gps": [51.752777, 19.454069, 15.8], "mountAngle": [359, -20, 0], "_id": 0, "description": "hall A, left corner", "viewAngle": [78, 42], "name": "cam0"}, "peopleCnt": 5}


{"description": "hall B, left corner", "name": "cam2", "mountAngle": [30, -20, 0], "viewAngle": [78, 42], "_id": 2, "gps": [51.752811, 19.19454077, 15.82]}]

{"description": "hall A, right corner", "name": "cam1", "mountAngle": [0, -20, 0], "viewAngle": [78, 42], "_id": 1, "gps": [51.752807, 19.194066, 15.81]},
CREATE TABLE aboutCam(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(40),
description VARCHAR(200),
latitude FLOAT,
longitude FLOAT,
altitude FLOAT,
yaw FLOAT,
pich FLOAT,
roll FLOAT,
viewAngleHorizontal FLOAT,
viewAngleVertical FLOAT
)


INSERT INTO eventCam(idAboutCam,peopleCnt,timestampMsg,warning,description)
VALUES(0,5,FROM_UNIXTIME(1568579294),FALSE,'nothing')


CREATE TABLE eventCam(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
idAboutCam INT,
peopleCnt INT,
timestampMsg TIMESTAMP,
warning BOOLEAN,
description TEXT
)


temp INT NOT NULL,
reg_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
)


SELECT
	e.id as camID,
  UNIX_TIMESTAMP(e.timestampMsg) as time_sec,
  e.peopleCnt as value,
  a.latitude,
  a.longitude,
  a.altitude
 FROM eventCam

ORDER BY timestampMsg ASC


SELECT latitude,longitude  as value FROM aboutCam WHERE id=1
------------------------------
latitude FLOAT,
longitude FLOAT,
altitude FLOAT,

SELECT  l.customer_id, r.customer_id, l.lname, r.lname

FROM customer l INNER JOIN customer r

ON l.customer_id = r.customer_id;

---------------
SELECT
	e.id as camID,
  UNIX_TIMESTAMP(e.timestampMsg) as time_sec,
  e.peopleCnt as value,
  a.latitude,
  a.longitude,
  a.altitude
FROM eventCam e INNER JOIN aboutCam a

ON e.idAboutCam = a.id;
---------------------
ORDER BY timestampMsg ASC






CREATE TABLE aboutCam(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(40),
description VARCHAR(200),
latitude FLOAT,
longitude FLOAT,
altitude FLOAT,
yaw FLOAT,
pich FLOAT,
roll FLOAT,
viewAngleHorizontal FLOAT,
viewAngleVertical FLOAT
)


CREATE TABLE occurrencePriority(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
statusText TEXT)

CREATE TABLE occurrence(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
statusId INT,
timestampMsg TIMESTAMP,
description TEXT)


CREATE TABLE occurrencePriority(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
statusText TEXT)

INSERT statusText 



INSERT INTO occurrencePriority(statusText)
VALUES('info');

INSERT INTO occurrencePriority(statusText)
VALUES('annoucement');

INSERT INTO occurrencePriority(statusText)
VALUES('warning');

INSERT INTO occurrencePriority(statusText)
VALUES('dangerous');


INSERT INTO occurrence(
statusId ,
timestampMsg ,
description ) VALUES
(2,FROM_UNIXTIME(1568579294),'attempted unauthorized opening of the door No #3');




CREATE TABLE occurrence(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
statusId INT,
timestampMsg TIMESTAMP,
description TEXT)


CREATE TABLE occurrencePriority(
id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
statusText TEXT)



SELECT o.id, i.statusText, o.timestampMsg, o.description
FROM occurrence o OUTER JOIN occurrencePriority i
ON o.statusId = i.id;





SELECT
	e.id as eventID,
    a.name as camName,
  UNIX_TIMESTAMP(e.timestampMsg) as time_sec,
  e.peopleCnt as value,
  a.latitude,
  a.longitude,
  a.altitude
FROM eventCam e INNER JOIN aboutCam a
ON e.idAboutCam = a.id;


//
show events

SELECT o.id, i.statusText, o.timestampMsg, o.description
FROM occurrence o LEFT OUTER JOIN occurrencePriority i
ON o.statusId = i.id;





INSERT INTO occurrence(
statusId ,
timestampMsg ,
description ) VALUES
(4,FROM_UNIXTIME(1568579294),'the window was broken near camera "cam1"');




# QUERY TO ADD EVENTS
SELECT o.id, i.statusText, o.timestampMsg, o.description
FROM occurrence o LEFT OUTER JOIN occurrencePriority i
ON o.statusId = i.id;

