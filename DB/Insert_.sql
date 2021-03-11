use Alkemy_School

go

	insert into Course(Course_Name)
	values  ('Matematica'),
			('Lengua'),
			('Filosofia')

go

	insert into Timetable(Start_Hour,End_Hour,Day_Trip)
	values  (TIMEFROMPARTS(18,0,0,0,0),TIMEFROMPARTS(22,0,0,0,0), 'Lunes' ),
			(TIMEFROMPARTS(18,0,0,0,0),TIMEFROMPARTS(22,0,0,0,0), 'Martes' ),
			(TIMEFROMPARTS(18,0,0,0,0),TIMEFROMPARTS(22,0,0,0,0), 'Miercoles' ),
			(TIMEFROMPARTS(8,0,0,0,0),TIMEFROMPARTS(12,0,0,0,0), 'Lunes' ),
			(TIMEFROMPARTS(8,0,0,0,0),TIMEFROMPARTS(12,0,0,0,0), 'Martes' ),
			(TIMEFROMPARTS(8,0,0,0,0),TIMEFROMPARTS(12,0,0,0,0), 'Miercoles' ),
			(TIMEFROMPARTS(8,0,0,0,0),TIMEFROMPARTS(12,0,0,0,0), 'Jueves' )

go

	insert into Timetable_by_Course(ID_Course,ID_Timetable,Capacity)
	values  (1,1,50),
			(1,2,60),
			(2,6,100),
			(3,7,50),
			(2,3,70)

go

	insert into Person(Names,Surname,DNI)
	values  ('Oscar Alberto','Bianchi',38427808),
			('Rogelio' , 'Buen Dia' , 10232906),
			('Francisco', 'Almiron', 31241904),
			('Esteban' , 'Quito', 37200162)

go

	insert into Username(DNI, Access, Active)
	values	(38427808, 0, 1),
			(10232906, 1, 1),
			(31241904, 0, 0),
			(37200162, 0, 1)
go

	insert into Teacher (DNI, Active)
	values (37200162,1)

go
	
	insert into Teacher_by_Course (ID_Course, ID_Teacher)
	values (2,1)

go

	insert into Inscription_by_Student(ID_Course, ID_Timetable, DNI_Person, Date_Inscr)
	values	(1,2,38427808, GETDATE()),
			(3,7,31241904, GETDATE())