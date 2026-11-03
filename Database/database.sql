/* =====================================================
   MyDVLD database script
   Requires SQL Server 2017 or newer (uses CONCAT_WS)
   Run on a SERVER where the database MyDVLD does not exist yet.
   Demo login: admin / admin123  (fake data, for testing only)
   ===================================================== */

USE [master]
GO
IF DB_ID(N'MyDVLD') IS NULL
    CREATE DATABASE [MyDVLD]
GO
USE [MyDVLD]
GO

/* ===================== TABLES ===================== */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([CountryID] ASC)
)
GO

CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[NationalNo] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[SecondName] [nvarchar](20) NOT NULL,
	[ThirdName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Gender] [smallint] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[CountryID] [int] NOT NULL,
	[ImagePath] [nvarchar](250) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([PersonID] ASC)
)
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
)
GO

CREATE TABLE [dbo].[ApplicationTypes](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeTitle] [nvarchar](200) NOT NULL,
	[TypeFees] [money] NOT NULL,
 CONSTRAINT [PK_ApplicationTypes] PRIMARY KEY CLUSTERED ([TypeID] ASC)
)
GO

CREATE TABLE [dbo].[LicenseClass](
	[LicenseClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[ClassDescription] [nvarchar](500) NOT NULL,
	[MinimumAllowedAge] [tinyint] NOT NULL,
	[DefaultValidityLength] [tinyint] NOT NULL,
	[ClassFees] [money] NOT NULL,
 CONSTRAINT [PK_LicenseClass] PRIMARY KEY CLUSTERED ([LicenseClassID] ASC)
)
GO

CREATE TABLE [dbo].[TestType](
	[TestTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TestTypeTitle] [nvarchar](100) NOT NULL,
	[TestTypeDescraption] [nvarchar](500) NOT NULL,
	[TestTypeFees] [money] NOT NULL,
 CONSTRAINT [PK_TestType] PRIMARY KEY CLUSTERED ([TestTypeID] ASC)
)
GO

CREATE TABLE [dbo].[Applications](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantPersonID] [int] NOT NULL,
	[ApplicationDate] [datetime] NOT NULL,
	[ApplicationTypeID] [int] NOT NULL,
	[ApplicationStatus] [tinyint] NOT NULL,
	[LastStatusDate] [datetime] NOT NULL,
	[PaidFees] [money] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
 CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED ([ApplicationID] ASC)
)
GO

CREATE TABLE [dbo].[LocalDrivingLicenseApplication](
	[LocalDrivingLicenseApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NOT NULL,
	[LicenseClassID] [int] NOT NULL,
 CONSTRAINT [PK_LocalDrivingLicenseApplication] PRIMARY KEY CLUSTERED ([LocalDrivingLicenseApplicationID] ASC)
)
GO

CREATE TABLE [dbo].[TestAppointment](
	[TestAppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[TestTypeID] [int] NOT NULL,
	[LocalDrivingLicenseApplicationID] [int] NOT NULL,
	[AppointmentDate] [datetime] NOT NULL,
	[PaidFees] [money] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[RetakeTestApplicationID] [int] NULL,
 CONSTRAINT [PK_TestAppointment] PRIMARY KEY CLUSTERED ([TestAppointmentID] ASC)
)
GO

CREATE TABLE [dbo].[Tests](
	[TestID] [int] IDENTITY(1,1) NOT NULL,
	[TestAppointmentID] [int] NOT NULL,
	[TestResult] [bit] NOT NULL,
	[Note] [nvarchar](500) NULL,
	[CreatedByUserID] [int] NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED ([TestID] ASC)
)
GO

CREATE TABLE [dbo].[Drivers](
	[DriverID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED ([DriverID] ASC)
)
GO

CREATE TABLE [dbo].[License](
	[LicenseID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NOT NULL,
	[DriverID] [int] NOT NULL,
	[LicenseClassID] [int] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[PaidFees] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IssueReason] [tinyint] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[IsDetained] [bit] NOT NULL,
 CONSTRAINT [PK_License] PRIMARY KEY CLUSTERED ([LicenseID] ASC)
)
GO

CREATE TABLE [dbo].[DetainedLicense](
	[DetainID] [int] IDENTITY(1,1) NOT NULL,
	[LicenseID] [int] NOT NULL,
	[DetainDate] [datetime] NOT NULL,
	[FineFees] [money] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[IsRelease] [bit] NOT NULL,
	[ReleaseDate] [datetime] NULL,
	[ReleaseByUserID] [int] NULL,
	[ReleaseApplicationID] [int] NULL,
 CONSTRAINT [PK_DetainedLicense] PRIMARY KEY CLUSTERED ([DetainID] ASC)
)
GO

CREATE TABLE [dbo].[InternationalLicense](
	[InternationalLicenseID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NOT NULL,
	[DriverID] [int] NOT NULL,
	[IssuedUsingLocalLicenseID] [int] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
 CONSTRAINT [PK_InternationalLicense] PRIMARY KEY CLUSTERED ([InternationalLicenseID] ASC)
)
GO

/* ===================== DEFAULTS ===================== */

ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [DEFAULT_Applications_ApplicationStatus] DEFAULT ((1)) FOR [ApplicationStatus]
GO
ALTER TABLE [dbo].[License] ADD CONSTRAINT [DEFAULT_License_IsActive] DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[License] ADD CONSTRAINT [DEFAULT_License_IssueReason] DEFAULT ((1)) FOR [IssueReason]
GO
ALTER TABLE [dbo].[License] ADD CONSTRAINT [DEFAULT_License_IsDetained] DEFAULT ((0)) FOR [IsDetained]
GO
ALTER TABLE [dbo].[LicenseClass] ADD CONSTRAINT [DEFAULT_LicenseClass_MinimumAllowedAge] DEFAULT ((18)) FOR [MinimumAllowedAge]
GO
ALTER TABLE [dbo].[LicenseClass] ADD CONSTRAINT [DEFAULT_LicenseClass_DefaultValidityLength] DEFAULT ((1)) FOR [DefaultValidityLength]
GO
ALTER TABLE [dbo].[LicenseClass] ADD CONSTRAINT [DEFAULT_LicenseClass_ClassFees] DEFAULT ((0)) FOR [ClassFees]
GO

/* ===================== FOREIGN KEYS ===================== */

ALTER TABLE [dbo].[People] ADD CONSTRAINT [FK_People_Countries] FOREIGN KEY([CountryID]) REFERENCES [dbo].[Countries]([CountryID])
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_Users_People] FOREIGN KEY([PersonID]) REFERENCES [dbo].[People]([PersonID])
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [FK_Applications_ApplicationTypes] FOREIGN KEY([ApplicationTypeID]) REFERENCES [dbo].[ApplicationTypes]([TypeID])
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [FK_Applications_People] FOREIGN KEY([ApplicantPersonID]) REFERENCES [dbo].[People]([PersonID])
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [FK_Applications_Users] FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[Users]([UserID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenseApplication] ADD CONSTRAINT [FK_LocalDrivingLicenseApplication_Applications] FOREIGN KEY([ApplicationID]) REFERENCES [dbo].[Applications]([ApplicationID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenseApplication] ADD CONSTRAINT [FK_LocalDrivingLicenseApplication_LicenseClass] FOREIGN KEY([LicenseClassID]) REFERENCES [dbo].[LicenseClass]([LicenseClassID])
GO
ALTER TABLE [dbo].[TestAppointment] ADD CONSTRAINT [FK_TestAppointment_Applications] FOREIGN KEY([RetakeTestApplicationID]) REFERENCES [dbo].[Applications]([ApplicationID])
GO
ALTER TABLE [dbo].[TestAppointment] ADD CONSTRAINT [FK_TestAppointment_LocalDrivingLicenseApplication] FOREIGN KEY([LocalDrivingLicenseApplicationID]) REFERENCES [dbo].[LocalDrivingLicenseApplication]([LocalDrivingLicenseApplicationID])
GO
ALTER TABLE [dbo].[TestAppointment] ADD CONSTRAINT [FK_TestAppointment_TestType] FOREIGN KEY([TestTypeID]) REFERENCES [dbo].[TestType]([TestTypeID])
GO
ALTER TABLE [dbo].[TestAppointment] ADD CONSTRAINT [FK_TestAppointment_Users] FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[Users]([UserID])
GO
ALTER TABLE [dbo].[Tests] ADD CONSTRAINT [FK_Tests_TestAppointment] FOREIGN KEY([TestAppointmentID]) REFERENCES [dbo].[TestAppointment]([TestAppointmentID])
GO
ALTER TABLE [dbo].[Tests] ADD CONSTRAINT [FK_Tests_Users] FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[Users]([UserID])
GO
ALTER TABLE [dbo].[Drivers] ADD CONSTRAINT [FK_Drivers_People] FOREIGN KEY([PersonID]) REFERENCES [dbo].[People]([PersonID])
GO
ALTER TABLE [dbo].[Drivers] ADD CONSTRAINT [FK_Drivers_Users] FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[Users]([UserID])
GO
ALTER TABLE [dbo].[License] ADD CONSTRAINT [FK_License_Applications] FOREIGN KEY([ApplicationID]) REFERENCES [dbo].[Applications]([ApplicationID])
GO
ALTER TABLE [dbo].[License] ADD CONSTRAINT [FK_License_Drivers] FOREIGN KEY([DriverID]) REFERENCES [dbo].[Drivers]([DriverID])
GO
ALTER TABLE [dbo].[License] ADD CONSTRAINT [FK_License_LicenseClass] FOREIGN KEY([LicenseClassID]) REFERENCES [dbo].[LicenseClass]([LicenseClassID])
GO
ALTER TABLE [dbo].[License] ADD CONSTRAINT [FK_License_Users] FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[Users]([UserID])
GO
ALTER TABLE [dbo].[DetainedLicense] ADD CONSTRAINT [FK_DetainedLicense_Applications] FOREIGN KEY([ReleaseApplicationID]) REFERENCES [dbo].[Applications]([ApplicationID])
GO
ALTER TABLE [dbo].[DetainedLicense] ADD CONSTRAINT [FK_DetainedLicense_CreatedByUsers] FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[Users]([UserID])
GO
ALTER TABLE [dbo].[DetainedLicense] ADD CONSTRAINT [FK_DetainedLicense_License] FOREIGN KEY([LicenseID]) REFERENCES [dbo].[License]([LicenseID])
GO
ALTER TABLE [dbo].[DetainedLicense] ADD CONSTRAINT [FK_DetainedLicense_ReleaseByUsers] FOREIGN KEY([ReleaseByUserID]) REFERENCES [dbo].[Users]([UserID])
GO
ALTER TABLE [dbo].[InternationalLicense] ADD CONSTRAINT [FK_InternationalLicense_Applications] FOREIGN KEY([ApplicationID]) REFERENCES [dbo].[Applications]([ApplicationID])
GO
ALTER TABLE [dbo].[InternationalLicense] ADD CONSTRAINT [FK_InternationalLicense_Drivers] FOREIGN KEY([DriverID]) REFERENCES [dbo].[Drivers]([DriverID])
GO
ALTER TABLE [dbo].[InternationalLicense] ADD CONSTRAINT [FK_InternationalLicense_LocalDrivingLicenseApplication] FOREIGN KEY([IssuedUsingLocalLicenseID]) REFERENCES [dbo].[License]([LicenseID])
GO
ALTER TABLE [dbo].[InternationalLicense] ADD CONSTRAINT [FK_InternationalLicense_Users] FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[Users]([UserID])
GO

/* ===================== VIEWS ===================== */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[LocalDrivingLicenseApplications_View] AS
SELECT LD1.LocalDrivingLicenseApplicationID, LC1.ClassName, P1.NationalNo,
(CONCAT_WS(' ',P1.FirstName,P1.SecondName,P1.ThirdName,P1.LastName)) AS FullName,
AP1.ApplicationDate,
COUNT(CASE WHEN TA.IsLocked=1 AND T.TestResult=1 THEN 1 END) AS PassTestCount,
(CASE WHEN AP1.ApplicationStatus=1 THEN 'New'
      WHEN AP1.ApplicationStatus=2 THEN 'Cancelled'
      WHEN AP1.ApplicationStatus=3 THEN 'Completed'
      ELSE 'Unknown' END) AS Status
FROM LocalDrivingLicenseApplication AS LD1
JOIN Applications AS AP1 ON LD1.ApplicationID=AP1.ApplicationID
JOIN LicenseClass AS LC1 ON LC1.LicenseClassID=LD1.LicenseClassID
JOIN People AS P1 ON P1.PersonID=AP1.ApplicantPersonID
LEFT JOIN TestAppointment AS TA ON TA.LocalDrivingLicenseApplicationID=LD1.LocalDrivingLicenseApplicationID
LEFT JOIN Tests AS T ON T.TestAppointmentID=TA.TestAppointmentID
GROUP BY LD1.LocalDrivingLicenseApplicationID, LC1.ClassName,
P1.NationalNo, P1.FirstName, P1.SecondName, P1.ThirdName, P1.LastName, AP1.ApplicationDate, AP1.ApplicationStatus
GO

CREATE VIEW [dbo].[DetainedLicenses_View] AS
SELECT DL.DetainID AS 'D.ID', L1.LicenseID AS 'L.ID', DL.DetainDate, DL.IsRelease, DL.FineFees, DL.ReleaseDate, P1.NationalNo,
(CONCAT_WS(' ',P1.FirstName,P1.SecondName,P1.ThirdName,P1.LastName)) AS FullName, DL.ReleaseApplicationID
FROM DetainedLicense AS DL
JOIN License AS L1 ON L1.LicenseID=DL.LicenseID
JOIN Drivers AS D1 ON D1.DriverID=L1.DriverID
JOIN People AS P1 ON P1.PersonID=D1.PersonID
GO

CREATE VIEW [dbo].[Drivers_View] AS
SELECT D1.DriverID, D1.PersonID, P1.NationalNo,
(CONCAT_WS(' ',P1.FirstName,P1.SecondName,P1.ThirdName,P1.LastName)) AS FullName,
D1.CreatedDate, COUNT(CASE WHEN L1.IsActive=1 THEN 1 END) AS NumberOfActiveLicenses
FROM Drivers AS D1
JOIN People AS P1 ON P1.PersonID=D1.PersonID
LEFT JOIN License AS L1 ON L1.DriverID=D1.DriverID
GROUP BY D1.DriverID, D1.PersonID, P1.NationalNo, P1.FirstName, P1.SecondName, P1.ThirdName, P1.LastName, D1.CreatedDate
GO

/* ===================== DATA ===================== */

/* ---- Countries (original IDs preserved) ---- */
SET IDENTITY_INSERT [dbo].[Countries] ON
GO
INSERT INTO [dbo].[Countries] ([CountryID], [CountryName]) VALUES
(1,N'Afghanistan'),(2,N'Albania'),(3,N'Algeria'),(4,N'Andorra'),(5,N'Angola'),
(6,N'Antigua and Barbuda'),(7,N'Argentina'),(8,N'Armenia'),(9,N'Austria'),(10,N'Azerbaijan'),
(11,N'Bahrain'),(12,N'Bangladesh'),(13,N'Barbados'),(14,N'Belarus'),(15,N'Belgium'),
(16,N'Belize'),(17,N'Benin'),(18,N'Bhutan'),(19,N'Bolivia'),(20,N'Bosnia and Herzegovina'),
(21,N'Botswana'),(22,N'Brazil'),(23,N'Brunei'),(24,N'Bulgaria'),(25,N'Burkina Faso'),
(26,N'Burundi'),(27,N'Cabo Verde'),(28,N'Cambodia'),(29,N'Cameroon'),(30,N'Canada'),
(31,N'Central African Republic'),(32,N'Chad'),(33,N'Channel Islands'),(34,N'Chile'),(35,N'China'),
(36,N'Colombia'),(37,N'Comoros'),(38,N'Congo'),(39,N'Costa Rica'),(40,N'Côte d''Ivoire'),
(41,N'Croatia'),(42,N'Cuba'),(43,N'Cyprus'),(44,N'Czech Republic'),(45,N'Denmark'),
(46,N'Djibouti'),(47,N'Dominica'),(48,N'Dominican Republic'),(49,N'DR Congo'),(50,N'Ecuador'),
(51,N'Egypt'),(52,N'El Salvador'),(53,N'Equatorial Guinea'),(54,N'Eritrea'),(55,N'Estonia'),
(56,N'Eswatini'),(57,N'Ethiopia'),(58,N'Faeroe Islands'),(59,N'Finland'),(60,N'France'),
(61,N'French Guiana'),(62,N'Gabon'),(63,N'Gambia'),(64,N'Georgia'),(65,N'Germany'),
(66,N'Ghana'),(67,N'Gibraltar'),(68,N'Greece'),(69,N'Grenada'),(70,N'Guatemala'),
(71,N'Guinea'),(72,N'Guinea-Bissau'),(73,N'Guyana'),(74,N'Haiti'),(75,N'Holy See'),
(76,N'Honduras'),(77,N'Hong Kong'),(78,N'Hungary'),(79,N'Iceland'),(80,N'India'),
(81,N'Indonesia'),(82,N'Iran'),(83,N'Iraq'),(84,N'Ireland'),(85,N'Isle of Man'),
(86,N'Israel'),(87,N'Italy'),(88,N'Jamaica'),(89,N'Japan'),(90,N'Jordan'),
(91,N'Kazakhstan'),(92,N'Kenya'),(93,N'Kuwait'),(94,N'Kyrgyzstan'),(95,N'Laos'),
(96,N'Latvia'),(97,N'Lebanon'),(98,N'Lesotho'),(99,N'Liberia'),(100,N'Libya'),
(101,N'Liechtenstein'),(102,N'Lithuania'),(103,N'Luxembourg'),(104,N'Macao'),(105,N'Madagascar'),
(106,N'Malawi'),(107,N'Malaysia'),(108,N'Maldives'),(109,N'Mali'),(110,N'Malta'),
(111,N'Mauritania'),(112,N'Mauritius'),(113,N'Mayotte'),(114,N'Mexico'),(115,N'Moldova'),
(116,N'Monaco'),(117,N'Mongolia'),(118,N'Montenegro'),(119,N'Morocco'),(120,N'Mozambique'),
(121,N'Myanmar'),(122,N'Namibia'),(123,N'Nepal'),(124,N'Netherlands'),(125,N'Nicaragua'),
(126,N'Niger'),(127,N'Nigeria'),(128,N'North Korea'),(129,N'North Macedonia'),(130,N'Norway'),
(131,N'Oman'),(132,N'Pakistan'),(133,N'Panama'),(134,N'Paraguay'),(135,N'Peru'),
(136,N'Philippines'),(137,N'Poland'),(138,N'Portugal'),(139,N'Qatar'),(140,N'Réunion'),
(141,N'Romania'),(142,N'Russia'),(143,N'Rwanda'),(144,N'Saint Helena'),(145,N'Saint Kitts and Nevis'),
(146,N'Saint Lucia'),(147,N'Saint Vincent and the Grenadines'),(148,N'San Marino'),(149,N'Sao Tome & Principe'),(150,N'Saudi Arabia'),
(151,N'Senegal'),(152,N'Serbia'),(153,N'Seychelles'),(154,N'Sierra Leone'),(155,N'Singapore'),
(156,N'Slovakia'),(157,N'Slovenia'),(158,N'Somalia'),(159,N'South Africa'),(160,N'South Korea'),
(161,N'South Sudan'),(162,N'Spain'),(163,N'Sri Lanka'),(164,N'State of Palestine'),(165,N'Sudan'),
(166,N'Suriname'),(167,N'Sweden'),(168,N'Switzerland'),(169,N'Syria'),(170,N'Taiwan'),
(171,N'Tajikistan'),(172,N'Tanzania'),(173,N'Thailand'),(174,N'The Bahamas'),(175,N'Timor-Leste'),
(176,N'Togo'),(177,N'Trinidad and Tobago'),(178,N'Tunisia'),(179,N'Turkey'),(180,N'Turkmenistan'),
(181,N'Uganda'),(182,N'Ukraine'),(183,N'United Arab Emirates'),(184,N'United Kingdom'),(185,N'United States'),
(186,N'Uruguay'),(187,N'Uzbekistan'),(188,N'Venezuela'),(189,N'Vietnam'),(190,N'Western Sahara'),
(191,N'Yemen'),(192,N'Zambia'),(193,N'Zimbabwe')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO

/* ---- Demo person (FAKE data) ---- */
SET IDENTITY_INSERT [dbo].[People] ON
GO
INSERT INTO [dbo].[People]
([PersonID],[NationalNo],[FirstName],[SecondName],[ThirdName],[LastName],[DateOfBirth],[Gender],[Address],[Phone],[Email],[CountryID],[ImagePath])
VALUES
(1, N'N0001', N'Sami', N'Demo', N'Test', N'User', '1990-01-01', 0, N'123 Demo Street, Test City', N'0000000000', N'demo@example.com', 90, NULL)
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO

/* ---- Demo user: admin / admin123 (FAKE password) ----
   NOTE: if your app stores a HASH of the password, replace 'admin123'
   with the hash of your demo password. */
SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT INTO [dbo].[Users] ([UserID],[PersonID],[UserName],[Password],[IsActive])
VALUES (1, 1, N'admin', N'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

/* ---- Settings data: REPLACE with the rows generated from your own DB if different ---- */
SET IDENTITY_INSERT [dbo].[ApplicationTypes] ON
GO
INSERT INTO [dbo].[ApplicationTypes] ([TypeID],[TypeTitle],[TypeFees]) VALUES
(1, N'New Local Driving License Service', 15),
(2, N'Renew Driving License Service', 7),
(3, N'Replacement for a Lost Driving License', 10),
(4, N'Replacement for a Damaged Driving License', 5),
(5, N'Release Detained Driving License', 15),
(6, N'New International License', 51),
(7, N'Retake Test', 5)
GO
SET IDENTITY_INSERT [dbo].[ApplicationTypes] OFF
GO

SET IDENTITY_INSERT [dbo].[TestType] ON
GO
INSERT INTO [dbo].[TestType] ([TestTypeID],[TestTypeTitle],[TestTypeDescraption],[TestTypeFees]) VALUES
(1, N'Vision Test', N'Vision test to check eyesight', 10),
(2, N'Written (Theory) Test', N'Written theory test about traffic rules', 20),
(3, N'Practical (Street) Test', N'Practical driving test on the street', 35)
GO
SET IDENTITY_INSERT [dbo].[TestType] OFF
GO

SET IDENTITY_INSERT [dbo].[LicenseClass] ON
GO
INSERT INTO [dbo].[LicenseClass] ([LicenseClassID],[ClassName],[ClassDescription],[MinimumAllowedAge],[DefaultValidityLength],[ClassFees]) VALUES
(1, N'Class 1 - Small Motorcycle', N'Small motorcycle license', 18, 5, 15),
(2, N'Class 2 - Heavy Motorcycle', N'Heavy motorcycle license', 21, 5, 30),
(3, N'Class 3 - Ordinary Car', N'Ordinary private car license', 18, 10, 20),
(4, N'Class 4 - Commercial', N'Taxi, limousine and commercial vehicles', 21, 10, 200),
(5, N'Class 5 - Agricultural', N'Agricultural vehicles license', 21, 10, 50),
(6, N'Class 6 - Bus', N'Small and medium bus license', 21, 10, 250),
(7, N'Class 7 - Truck', N'Truck and heavy vehicle license', 21, 10, 300)
GO
SET IDENTITY_INSERT [dbo].[LicenseClass] OFF
GO
