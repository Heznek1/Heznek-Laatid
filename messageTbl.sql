create table messages(
sn int identity(1,1), 
idSender char(9), 
FOREIGN KEY(idSender) REFERENCES userTbl(id),
idReciever char(9),
FOREIGN KEY(idReciever) REFERENCES userTbl(id),
subject text,
content text,
hour time,
dateOfMessage date,
PRIMARY KEY(sn,idSender,idReciever)
)

