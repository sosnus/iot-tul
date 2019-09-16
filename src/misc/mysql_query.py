import mysql.connector
import time

mydb = mysql.connector.connect(
  host="www.db4free.net",
  user="mysqltulvision1",
  passwd="mMpRakr7rMq@gVW",
  database="mysqltulvision1"
)

print(mydb)


mycursor = mydb.cursor()


#a
i = 1
while 1:
    i = i + 1
    x = "INSERT INTO eventCam(idAboutCam,peopleCnt,timestampMsg,warning,description) VALUES ("+str(i%3)+",RAND(20),FROM_UNIXTIME(UNIX_TIMESTAMP()),FALSE,'nothing')"
    mycursor.execute(x)
    mydb.commit()
    print(x)
    print(mycursor.rowcount, "record inserted.")
    time.sleep( 5 )
