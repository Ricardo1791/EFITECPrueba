use master
go

create database RicardoAlvarez
go

use RicardoAlvarez
go

create table AP_Alvarez_Ricardo_Alumno(
id int identity(1,1) primary key not null,
apellidos varchar(100),
nombres varchar(100),
fecha_nacimiento datetime,
sexo varchar(1),
estado bit default 1
)
go

create table AP_Alvarez_Ricardo_Curso(
id int identity(1,1) primary key not null,
nombre varchar(100),
descripcion varchar(200),
obligatorio  bit,
estado bit default 1
)
go

create table AP_Alvarez_Ricardo_Nota(
id int identity(1,1) primary key not null,
idalumno int not null,
idcurso int not null,
practica1 numeric(3,1),
practica2 numeric(3,1),
practica3 numeric(3,1),
parcial numeric(3,1),
final numeric(3,1),
estado bit default 1
)
go

alter table AP_Alvarez_Ricardo_Nota
add constraint fk_nota_alumno foreign key(idalumno) references AP_Alvarez_Ricardo_Alumno(id)
go

alter table AP_Alvarez_Ricardo_Nota
add constraint fk_nota_curso foreign key(idcurso) references AP_Alvarez_Ricardo_Curso(id)
go


insert into [dbo].[AP_Alvarez_Ricardo_Curso] (nombre, descripcion, obligatorio, estado) values ('Literatura', 'Curso de literatura universal', 1,1 )
go

insert into [dbo].[AP_Alvarez_Ricardo_Curso] (nombre, descripcion, obligatorio, estado) values ('Aritmetica', 'Curso de Matematicas', 1,1 )
go

insert into [dbo].[AP_Alvarez_Ricardo_Curso] (nombre, descripcion, obligatorio, estado) values ('Historia del Perú', 'Curso de historia del Perú', 1,1 )
go

