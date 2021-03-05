create Database Alkemy_School
 
go

use Alkemy_School

go

create table Person(
Names varchar(200) not null,
Surname varchar(100) not null,
DNI int primary key,
)

go

create table Username(
Docket int primary key,
Access tinyint not null,
Active bit not null,
DNI int not null,
constraint FK_Username_DNI  foreign key (DNI) references Person (DNI)
)

go

Create table Teacher(
DNI int not null,
IDT smallint not null primary key,
Active bit not null
constraint FK_Teacher_DNI foreign key (DNI) references Person (DNI)
)

go

Create table Course(
ID smallint primary key,
Course_Name varchar (150) not null,
Capacity tinyint not null
)

go 

Create table Timetable(
ID smallint primary key,
ID_Course smallint not null,
Day varchar(50) not null,
Start_Hour Time not null,
End_Hour Time not null
constraint FK_Course_Time foreign key (ID_Course) references Course (ID)
)

go

create Table Inscription_by_Student(
DNI_Person int not null,
ID_Course smallint not null,
Date_Inscr date not null,
primary key(DNI_Person,ID_Course)
)

go 

alter table Inscription_by_Student
ADD Constraint FK_Course_Insc foreign key(ID_Course) references Course(ID)

go

alter table Inscription_by_Student
ADD Constraint FK_Person_Insc foreign key (DNI_Person) references Person(DNI)

go

create table Teacher_by_Course(
ID_Teacher smallint not null, 
ID_Course smallint not null,
primary key (ID_Teacher, ID_Course)

)

go

alter table  Teacher_by_Course
ADD Constraint FK_Person_Teacher foreign key (ID_Teacher) references Teacher(IDT)

go 
alter table Teacher_by_Course
ADD Constraint FK_ID_Course foreign key (ID_Course) references Course(ID)