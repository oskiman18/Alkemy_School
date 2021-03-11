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
Docket int primary key identity(1000,1),
Access tinyint not null,
Active bit not null,
DNI int not null,
constraint FK_Username_DNI  foreign key (DNI) references Person (DNI)
)

go

Create table Teacher(
DNI int not null,
IDT smallint primary key Identity (1,1),
Active bit not null
constraint FK_Teacher_DNI foreign key (DNI) references Person (DNI)
)

go

Create table Course(
ID smallint primary key identity(1,1),
Course_Name varchar (150) not null,
)

go 

Create table Timetable(
ID smallint primary key identity(1,1),
Day_Trip varchar(50) not null,
Start_Hour Time not null,
End_Hour Time not null
)


go

create Table Inscription_by_Student(
DNI_Person int ,
ID_Course smallint ,
Date_Inscr date not null,
ID_Timetable smallint,
primary key(DNI_Person,ID_Course,ID_Timetable)
)

go 

alter table Inscription_by_Student
ADD Constraint FK_Course_Insc foreign key(ID_Course) references Course(ID)

go
alter table Inscription_by_Student
ADD Constraint FK_Time_Insc foreign key(ID_Timetable) references Timetable(ID)

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

go

create table Timetable_by_Course(
ID_Course smallint,
ID_Timetable smallint,
Capacity tinyint not null,
Primary key(ID_Course, ID_Timetable)
)
go

alter table Timetable_by_Course
ADD Constraint FK_Course_Horary foreign key (ID_Course) references Course(ID)

go

alter table Timetable_by_Course
ADD Constraint FK_Timetable_Horary foreign key (ID_Timetable) references Timetable(ID)
