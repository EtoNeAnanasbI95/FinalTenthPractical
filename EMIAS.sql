CREATE DATABASE EMIAS;
GO

USE EMIAS;
GO

CREATE TABLE Specialities(
	IdSpeciality INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
);
GO


insert into Specialities(Name)
values
('Педиатор'),
('Гинеколог'),
('Травматолог')
go


CREATE TABLE Patient(
	OMS BIGINT PRIMARY KEY not null,
	Surname NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	BirthDay DATE NOT NULL,
	Address NVARCHAR(255) NOT NULL,
	LivingAddress NVARCHAR(255) NULL,
	Phone NVARCHAR(18) NULL,
	Email NVARCHAR(50) NULL,
	Nickname NVARCHAR(50) NULL,
);
GO

insert into Patient(OMS,Surname,Name,Patronymic,BirthDay,Address,LivingAddress,Phone,Email,Nickname)
values
(1,'Проваренов','Алексей','Андреевич÷','09.05.2006',' город Москва улица Отрадное дом 52 кв.34','город Москва улица Отрадное дом 52 кв.34','+79233245784','povar1234@gmail.com','Nekto228'),
(2,'Никита','Васюков','Обезьянович','21.03.2006','город Москва улица Мухосранск дом 12 кв.120','город Москва улица Мухосранск дом 12 кв.120','+71023247459','NekitNeLox228@gmail.com','RaspikYaukami412'),
(3,'Дмитрий','Кирилов','Сергеевич','07.11.2007','Город Хабаровск село Зелёное дом 3','Город Хабаровск село Зелёное дом 3','+79234627580','IlikeHairyMen@gmail.com','SyperSys_129')
go
drop table Admin

CREATE TABLE Admin(
	IdAdmin INT PRIMARY KEY IDENTITY(1,1),
	Surname NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	EnterPassword NVARCHAR(50) NOT NULL,

);
GO

insert into Admin(Surname,Name,Patronymic,EnterPassword)
values
('Синицына','Елизовета','Дмитриевна','13579'),
('Скорогудаева','София','Алексеевна','97531'),
('Лавром','Максим','Дмитриевич','32546')
go

CREATE TABLE Directions(
	IdDirection CHAR(18) PRIMARY KEY not null,
	IdSpeciality int not null foreign key (IdSpeciality) references Specialities(IdSpeciality),
	OMS BIGINT not null foreign key (OMS) references Patient(OMS),

);
GO

insert into Directions(IdDirection,IdSpeciality,OMS)
values
(1,1,1),
(2,2,2),
(3,3,3)
go

CREATE TABLE Status(
	IdStatus INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
);
GO

insert into Status_(Name_)
values
('на рассмотрении'),
('принято'),
('ожидает приёма')
go

drop table Doctor
CREATE TABLE Doctor(
	IdDoctor INT PRIMARY KEY IDENTITY(1,1),
	Surname NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	EnterPassword NVARCHAR(50) NOT NULL,
	WorkAddress NVARCHAR(50) NOT NULL,
	IdSpeciality int not null foreign key references Specialities(IdSpeciality)
);
GO

insert into Doctor(Surname,Name,Patronymic,EnterPassword,WorkAddress,IdSpeciality)
values
('Морарь','Роман','Олегович','123456','Город Москва улица Чертановская дом 10',1),
('Мария','Гаврикова','Владимировна','654321','Город Москва улица Севастопольская дом 25',2),
('Биктимиров','Руслан','Олегович','09876','Город Астрахань улица Черемных дом 7',3)
go



CREATE TABLE Appointments(
	IdAppointment INT PRIMARY KEY IDENTITY(1,1),
	AppointmentDate DATE NOT NULL,
	AppointmentTime TIME NOT NULL,
	IdDoctor int not null FOREIGN KEY (IdDoctor) REFERENCES Doctor(IdDoctor),
	OMS BIGINT not null foreign key (OMS) references Patient(OMS),
	IdStatus int not null FOREIGN KEY (IdStatus) REFERENCES Status(IdStatus),
	
);
GO

insert into Appointments(AppointmentDate,AppointmentTime,IdDoctor,OMS,IdStatus)
values
('20.06.2024','12:00',1,1,1),
('15.06.2024','18:00',4,2,2),
('10.05.2023','9:00',7,3,3)
go



CREATE TABLE AppointmentDocument_(
IdAppointment int not null foreign key (IdAppointment) references Appointments(IdAppointment),
	Rtf NVARCHAR(MAX) NOT NULL,
);
GO

insert into AppointmentDocument(IdAppointment,Rtf)
values
(1,'явился'),
(2,'не явился'),
(3,'опоздал')
go

CREATE TABLE AnalysDocument(
IdAppointment int not null foreign key (IdAppointment) references Appointments(IdAppointment),

	Rtf NVARCHAR(MAX) NOT NULL,

);
GO

insert into AnalysDocument(IdAppointment,Rtf)
values
(1,'умрёт от спида'),
(2,'рак левого яичка 10 степени'),
(3,'здоров')
go

CREATE TABLE ResearchDocument(
IdAppointment int not null foreign key (IdAppointment) references Appointments(IdAppointment),
	Rtf NVARCHAR(MAX) NOT NULL,
	Attachment BINARY NULL,
);
GO

insert into ResearchDocument(IdAppointment,Rtf)
values
(1,'взят мазок'),
(2,'отрезали левое яичко'),
(3,'взята кровь')
go


select * from Specialities
select * from Patient
select * from Admin
select * from Directions
select * from Status
select * from Patient
select * from Doctor
select * from Appointments
select * from AppointmentDocument
select * from AnalysDocument
select * from ResearchDocument


