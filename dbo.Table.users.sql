﻿
CREATE table userTbl(
    id char(9) primary key check(id like replicate('[0-9]',9)),
    firstName varchar(50) not null,
    lastName varchar(50) not null,
    dateOfBirth date,
    status int not null,
    foreign key(status) references statusTbl(numOfStatus),
    yearsInTheProgram int,
    requestStatus char(1) CHECK(requestStatus in('Y','N','?',NULL)) ,
    gender char(1) check(gender in('M','F')),
    phone varchar(10) check(phone like replicate('[0-9]',10)),
    email varchar(8000) check (email like '%_@__%.__%'),
    cityNumber int,
	foreign key(cityNumber) references cityTbl(sn),
	address text,
    numOfSiblings int,
    academicParents int check(academicParents in(0,1,2)),
    school text,
    yearFinishSchool int,
    typeOfService int not null,
    foreign key(typeOfService) REFERENCES serviceTbl(sn),
    academicInstitution text,
    studyField text,
    startYear int,
    excpectedCompletionYear int check(startYear<=excpectedCompletionYear),
    learningDisabilities varchar(3) check(learningDisabilities in('Yes','No')),
    psychometricGrade int,
    anotherScholarship varchar(3) check(anotherScholarship in('Yes','No')),
    educationFunding text,
    difficulties text,
    bankName int,
    foreign key(bankName) REFERENCES bank(sn),
    numOfBank int,
    numAccount int,
    files text,--need to change that--
    profilePicture text,
CONSTRAINT check_bank1_nullness CHECK ((bankName is null and numOfBank is null) or (bankName is not null and numOfBank is not null)),

CONSTRAINT check_bank2_nullness CHECK ((numOfBank is null and numAccount is null) or (numOfBank is not null and numAccount is not null))
    )
