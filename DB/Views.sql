use Alkemy_School

go


create view	VM_User
as
select P.Names as Nombre,
P.Surname as Apellido,
U.DNI as Documento,
U.Docket as Legajo
from  Username as U
inner join Person as P on P.DNI = U.DNI


go

create view VM_Course
as
select top 1000 C.ID as ID_Course,
		T.ID as ID_Timetable,
C.Course_Name as Nombre,
TBC.Capacity as Capacidad,
(select TBC.Capacity - COUNT(DNI_Person) from Inscription_by_Student as IBS
	where IBS.ID_Course = C.ID) as Vacantes,
T.Day_Trip as Dia,
T.Start_Hour as Hora_Incial,
T.End_Hour as Hora_Final
from 
Course as C
inner join Timetable_by_Course as TBC on TBC.ID_Course = C.ID
inner join Timetable as T on T.ID = TBC.ID_Timetable
order by c.Course_Name

