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
    ('��������', ''),
    ('���������', ''),
    ('�����������', '')
go

insert into Patient(OMS, Surname, FirstName, Patronymic, BirthDay, AddressPatient, LivingAddress, Phone, Email, Nickname)
values
    (1,'����������','�������','���������','09.05.2006',' ����� ������ ����� �������� ��� 52 ��.34','����� ������ ����� �������� ��� 52 ��.34','+79233245784','povar1234@gmail.com','Nekto228'),
    (2,'������','�������','�����������','21.03.2006','����� ������ ����� ���������� ��� 12 ��.120','����� ������ ����� ���������� ��� 12 ��.120','+71023247459','NekitNeLox228@gmail.com','RaspikYaukami412'),
    (3,'�������','�������','���������','07.11.2007','����� ��������� ���� ������ ��� 3','����� ��������� ���� ������ ��� 3','+79234627580','IlikeHairyMen@gmail.com','SyperSys_129')
go

insert into Admin_(SurnameAdmin, FirstName, Patronymic, EnterPassword)
values
    ('��������','���������','����������','13579'),
    ('������������','�����','����������','97531'),
    ('������','������','����������','32546')
go

insert into Directions(Speciality_ID, OMS)
values
    (1,1),
    (2,2),
    (3,3)
go

insert into Status(NameStatus)
values
    ('�� ������������'),
    ('�������'),
    ('������� �����')
go

insert into Doctor(Surname, FirstName_, Patronymic, Speciality_ID, EnterPassword, WorkAddress)
values
    ('������', '�����', '��������', 1, '123456', '����� ������ ����� ������������ ��� 10'),
    ('�����', '���������', '������������', 2,'654321', '����� ������ ����� ��������������� ��� 25'),
    ('����������', '������', '��������', 3,'09876', '����� ��������� ����� �������� ��� 7')
go

insert into Appointments(AppointmentDate,AppointmentTime, Doctor_ID, OMS, Status_ID)
values
    ('20.06.2024','12:00',1,1,1),
    ('15.06.2024','18:00',4,2,2),
    ('10.05.2023','9:00',7,3,3)
go

insert into AppointmentDocument(Rtf)
values
    ('������'),
    ('�� ������'),
    ('�������')
go

insert into AnalysDocument(Rtf)
values
    ('���� �� �����'),
    ('��� ������ ����� 10 �������'),
    ('������')
go

insert into ResearchDocument(Rtf)
values
    ('���� �����'),
    ('�������� ����� �����'),
    ('����� �����')
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
