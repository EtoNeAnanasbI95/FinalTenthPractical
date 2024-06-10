DROP DATABASE EMIAS;
GO

CREATE DATABASE EMIAS;
GO

USE EMIAS;
GO

CREATE TABLE Specialities
(
    ID_Speciality    INT PRIMARY KEY IDENTITY(1,1),
    NameSpecialities NVARCHAR(50) NOT NULL,
    PathImage        NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Patient
(
    OMS            BIGINT PRIMARY KEY,
    Surname        NVARCHAR(50) NOT NULL,
    FirstName      NVARCHAR(50) NOT NULL,
    Patronymic     NVARCHAR(50) NOT NULL,
    BirthDay       DATE NOT NULL,
    AddressPatient NVARCHAR(255) NOT NULL,
    LivingAddress  NVARCHAR(255) NULL,
    Phone          NVARCHAR(18) NULL,
    Email          NVARCHAR(50) NULL,
    Nickname       NVARCHAR(50) NULL
);
GO

CREATE TABLE Admin_
(
    ID_Admin      INT PRIMARY KEY IDENTITY(1,1),
    SurnameAdmin  NVARCHAR(50) NOT NULL,
    FirstName     NVARCHAR(50) NOT NULL,
    Patronymic    NVARCHAR(50) NOT NULL,
    EnterPassword NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Directions
(
    ID_Direction  INT PRIMARY KEY IDENTITY(1,1),
    Speciality_ID INT    NOT NULL,
    FOREIGN KEY (Speciality_ID) REFERENCES Specialities (ID_Speciality),
    OMS           BIGINT NOT NULL,
    FOREIGN KEY (OMS) REFERENCES Patient (OMS)
);
GO

CREATE TABLE Status
(
    ID_Status  INT PRIMARY KEY IDENTITY(1,1),
    NameStatus NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Doctor
(
    ID_Doctor     INT PRIMARY KEY IDENTITY(1,3),
    Surname       NVARCHAR(50) NOT NULL,
    FirstName_    NVARCHAR(50) NOT NULL,
    Patronymic    NVARCHAR(50) NOT NULL,
    Speciality_ID int not null,
    FOREIGN KEY (Speciality_ID) REFERENCES Specialities (ID_Speciality),
    EnterPassword NVARCHAR(50) NOT NULL,
    WorkAddress   NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Appointments
(
    ID_Appointment  INT PRIMARY KEY IDENTITY(1,1),
    AppointmentDate DATE   NOT NULL,
    AppointmentTime TIME   NOT NULL,
    Doctor_ID       INT    NOT NULL,
    FOREIGN KEY (Doctor_ID) REFERENCES Doctor (ID_Doctor),
    OMS             BIGINT NOT NULL,
    FOREIGN KEY (OMS) REFERENCES Patient (OMS),
    Status_ID       INT    NOT NULL,
    FOREIGN KEY (Status_ID) REFERENCES Status (ID_Status)
);
GO

CREATE TABLE AppointmentDocument
(
    ID_Appointment INT PRIMARY KEY IDENTITY (1,1),
    FOREIGN KEY (ID_Appointment) REFERENCES Appointments (ID_Appointment),
    Rtf            NVARCHAR(MAX) NOT NULL,
);
GO

CREATE TABLE AnalysDocument
(
    ID_Appointment INT PRIMARY KEY IDENTITY (1,1),
    FOREIGN KEY (ID_Appointment) REFERENCES Appointments (ID_Appointment),
    Rtf            NVARCHAR(MAX) NOT NULL,
);
GO

CREATE TABLE ResearchDocument
(
    ID_Appointment INT PRIMARY KEY IDENTITY (1,1),
    FOREIGN KEY (ID_Appointment) REFERENCES Appointments (ID_Appointment),
    Rtf            NVARCHAR(MAX) NOT NULL,
    Attachment     VARBINARY NULL
);
GO

insert into Specialities(NameSpecialities, PathImage)
values
    ('Педиатор', ''),
    ('Гинеколог', ''),
    ('Травматолог', '')
go

insert into Patient(OMS, Surname, FirstName, Patronymic, BirthDay, AddressPatient, LivingAddress, Phone, Email, Nickname)
values
    (1,'Проваренов','Алексей','Андреевич','09.05.2006',' город Москва улица Отрадное дом 52 кв.34','город Москва улица Отрадное дом 52 кв.34','+79233245784','povar1234@gmail.com','Nekto228'),
    (2,'Никита','Васюков','Обезьянович','21.03.2006','город Москва улица Мухосранск дом 12 кв.120','город Москва улица Мухосранск дом 12 кв.120','+71023247459','NekitNeLox228@gmail.com','RaspikYaukami412'),
    (3,'Дмитрий','Кирилов','Сергеевич','07.11.2007','Город Хабаровск село Зелёное дом 3','Город Хабаровск село Зелёное дом 3','+79234627580','IlikeHairyMen@gmail.com','SyperSys_129')
go

insert into Admin_(SurnameAdmin, FirstName, Patronymic, EnterPassword)
values
    ('Синицына','Елизовета','Дмитриевна','13579'),
    ('Скорогудаева','София','Алексеевна','97531'),
    ('Лавром','Максим','Дмитриевич','32546')
go

insert into Directions(Speciality_ID, OMS)
values
    (1,1),
    (2,2),
    (3,3)
go

insert into Status(NameStatus)
values
    ('на рассмотрении'),
    ('принято'),
    ('ожидпет приёма')
go

insert into Doctor(Surname, FirstName_, Patronymic, Speciality_ID, EnterPassword, WorkAddress)
values
    ('Морарь', 'Роман', 'Олегович', 1, '123456', 'Город Москва улица Чертановская дом 10'),
    ('Мария', 'Гаврикова', 'Владимировна', 2,'654321', 'Город Москва улица Севастопольская дом 25'),
    ('Биктимиров', 'Руслан', 'Олегович', 3,'09876', 'Город Астрахань улица Черемных дом 7')
go

insert into Appointments(AppointmentDate,AppointmentTime, Doctor_ID, OMS, Status_ID)
values
    ('20.06.2024','12:00',1,1,1),
    ('15.06.2024','18:00',4,2,2),
    ('10.05.2023','9:00',7,3,3)
go

insert into AppointmentDocument(Rtf)
values
    ('явился'),
    ('не явился'),
    ('опоздал')
go

insert into AnalysDocument(Rtf)
values
    ('умрёт от спида'),
    ('рак левого яичка 10 степени'),
    ('здоров')
go

insert into ResearchDocument(Rtf)
values
    ('взят мазок'),
    ('отрезали левое яичко'),
    ('взята кровь')
go

select * from Specialities
select * from Patient
select * from Admin_
select * from Directions
select * from Status
select * from Patient
select * from Doctor
select * from Appointments
select * from AppointmentDocument
select * from AnalysDocument
select * from ResearchDocument
