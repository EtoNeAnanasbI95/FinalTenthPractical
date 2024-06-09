CREATE DATABASE EMIAS;
GO

USE EMIAS;
GO

CREATE TABLE Specialities_(
	IdSpeciality INT PRIMARY KEY IDENTITY(1,3),
	Name_ NVARCHAR(50) NOT NULL,
);
GO


insert into Specialities_(Name_)
values
('Ïåäèàòîð'),
('Ãèíåêîëîã'),
('Òðàâìàòîëîã')
go


CREATE TABLE Patient_(
	OMS BIGINT PRIMARY KEY not null,
	Surname NVARCHAR(50) NOT NULL,
	Name_ NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	BirthDay DATE NOT NULL,
	Address_ NVARCHAR(255) NOT NULL,
	LivingAddress NVARCHAR(255) NULL,
	Phone NVARCHAR(18) NULL,
	Email NVARCHAR(50) NULL,
	Nickname NVARCHAR(50) NULL,
);
GO

insert into Patient_(OMS,Surname,Name_,Patronymic,BirthDay,Address_,LivingAddress,Phone,Email,Nickname)
values
(1,'Ïðîâàðåíîâ','Àëñåé','Àíäðååâè÷','09.05.2006',' ãîðîä Ìîñêâà óëèöà Îòðàäíîå äîì 52 êâ.34','ãîðîä Ìîñêâà óëèöà Îòðàäíîå äîì 52 êâ.34','+79233245784','povar1234@gmail.com','Nekto228'),
(2,'Íèêèòà','Âàñþêîâ','Îáåçüÿíîâè÷','21.03.2006','ãîðîä Ìîñêâà óëèöà Ìóõîñðàíñê äîì 12 êâ.120','ãîðîä Ìîñêâà óëèöà Ìóõîñðàíñê äîì 12 êâ.120','+71023247459','NekitNeLox228@gmail.com','RaspikYaukami412'),
(3,'Äìèòðèé','Êèðèëîâ','Ñåðãååâè÷','07.11.2007','Ãîðîä Õàáàðîâñê ñåëî Çåë¸íîå äîì 3','Ãîðîä Õàáàðîâñê ñåëî Çåë¸íîå äîì 3','+79234627580','IlikeHairyMen@gmail.com','SyperSys_129')
go
drop table Admin_

CREATE TABLE Admin_(
	IdAdmin INT PRIMARY KEY IDENTITY(1,1),
	Surname NVARCHAR(50) NOT NULL,
	Name_ NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	EnterPassword NVARCHAR(50) NOT NULL,

);
GO

insert into Admin_(Surname,Name_,Patronymic,EnterPassword)
values
('Ñèíèöûíà','Åëèçîâåòà','Äìèòðèåâíà','13579'),
('Ñêîðîãóäàåâà','Ñîôèÿ','Àëåêñååâíà','97531'),
('Ëàâðîì','Ìàêñèì','Äìèòðèåâè÷','32546')
go

CREATE TABLE Directions_(
	IdDirection CHAR(18) PRIMARY KEY not null,
	IdSpeciality int not null foreign key (IdSpeciality) references Specialities_(IdSpeciality),
	OMS BIGINT not null foreign key (OMS) references Patient_(OMS),

);
GO

insert into Directions_(IdDirection,IdSpeciality,OMS)
values
(1,1,1),
(2,2,2),
(3,3,3)
go

CREATE TABLE Status_(
	IdStatus INT PRIMARY KEY IDENTITY(1,1),
	Name_ NVARCHAR(50) NOT NULL,
);
GO

insert into Status_(Name_)
values
('íà ðàññìîòðåíèè'),
('ïðèíÿòî'),
('îæèäïåò ïðè¸ìà')
go

drop table Doctor_
CREATE TABLE Doctor_(
	IdDoctor INT PRIMARY KEY IDENTITY(1,3),
	Surname NVARCHAR(50) NOT NULL,
	Name_ NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	EnterPassword NVARCHAR(50) NOT NULL,
	WorkAddress NVARCHAR(50) NOT NULL,
	IdSpeciality int not null foreign key references Specialities_(IdSpeciality)
);
GO

insert into Doctor_(Surname,Name_,Patronymic,EnterPassword,WorkAddress,IdSpeciality)
values
('Ìîðàðü','Ðîìàí','Îëåãîâè÷','123456','Ãîðîä Ìîñêâà óëèöà ×åðòàíîâñêàÿ äîì 10',1),
('Ìàðèÿ','Ãàâðèêîâà','Âëàäèìèðîâíà','654321','Ãîðîä Ìîñêâà óëèöà Ñåâàñòîïîëüñêàÿ äîì 25',2),
('Áèêòèìèðîâ','Ðóñëàí','Îëåãîâè÷','09876','Ãîðîä Àñòðàõàíü óëèöà ×åðåìíûõ äîì 7',3)
go



CREATE TABLE Appointments_(
	IdAppointment INT PRIMARY KEY IDENTITY(1,1),
	AppointmentDate DATE NOT NULL,
	AppointmentTime TIME NOT NULL,
	IdDoctor int not null FOREIGN KEY (IdDoctor) REFERENCES Doctor_(IdDoctor),
	OMS BIGINT not null foreign key (OMS) references Patient_(OMS),
	IdStatus int not null FOREIGN KEY (IdStatus) REFERENCES Status_(IdStatus),
	
);
GO

insert into Appointments_(AppointmentDate,AppointmentTime,IdDoctor,OMS,IdStatus)
values
('20.06.2024','12:00',1,1,1),
('15.06.2024','18:00',4,2,2),
('10.05.2023','9:00',7,3,3)
go



CREATE TABLE AppointmentDocument_(
IdAppointment int not null foreign key (IdAppointment) references Appointments_(IdAppointment),
	Rtf NVARCHAR(MAX) NOT NULL,
);
GO

insert into AppointmentDocument_(IdAppointment,Rtf)
values
(1,'ÿâèëñÿ'),
(2,'íå ÿâèëñÿ'),
(3,'îïîçäàë')
go

CREATE TABLE AnalysDocument_(
IdAppointment int not null foreign key (IdAppointment) references Appointments_(IdAppointment),

	Rtf NVARCHAR(MAX) NOT NULL,

);
GO

insert into AnalysDocument_(IdAppointment,Rtf)
values
(1,'óìð¸ò îò ñïèäà'),
(2,'ðàê ëåâîãî ÿè÷êà 10 ñòåïåíè'),
(3,'çäîðîâ	')
go

CREATE TABLE ResearchDocument_(
IdAppointment int not null foreign key (IdAppointment) references Appointments_(IdAppointment),
	Rtf NVARCHAR(MAX) NOT NULL,
	Attachment BINARY NULL,
);
GO

insert into ResearchDocument_(IdAppointment,Rtf)
values
(1,'âçÿò ìàçîê'),
(2,'îòðåçàëè ëåâîå ÿè÷êî'),
(3,'âçÿòà êðîâü')
go


select * from Specialities_
select * from Patient_
select * from Admin_
select * from Directions_
select * from Status_
select * from Patient_
select * from Doctor_
select * from Appointments_
select * from AppointmentDocument_
select * from AnalysDocument_
select * from ResearchDocument_


