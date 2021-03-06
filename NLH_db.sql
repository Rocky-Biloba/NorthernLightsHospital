USE [master]
GO
/****** Object:  Database [NorthernLightsHospital]    Script Date: 8/30/2020 6:56:05 PM ******/
CREATE DATABASE [NorthernLightsHospital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NorthernLightsHospital', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NorthernLightsHospital.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NorthernLightsHospital_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NorthernLightsHospital_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NorthernLightsHospital] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NorthernLightsHospital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NorthernLightsHospital] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET ARITHABORT OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NorthernLightsHospital] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NorthernLightsHospital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NorthernLightsHospital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NorthernLightsHospital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NorthernLightsHospital] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET RECOVERY FULL 
GO
ALTER DATABASE [NorthernLightsHospital] SET  MULTI_USER 
GO
ALTER DATABASE [NorthernLightsHospital] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NorthernLightsHospital] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NorthernLightsHospital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NorthernLightsHospital] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NorthernLightsHospital', N'ON'
GO
USE [NorthernLightsHospital]
GO
/****** Object:  Table [dbo].[Assurance]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assurance](
	[IDassurance] [int] NOT NULL,
	[NomCompagnie] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Assurance] PRIMARY KEY CLUSTERED 
(
	[IDassurance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblAdmission]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmission](
	[IDadmission] [int] IDENTITY(5,1) NOT NULL,
	[NAS] [int] NULL,
	[dateAdmis] [datetime2](7) NOT NULL,
	[IDmedecin] [int] NOT NULL,
	[Lit] [int] NOT NULL,
	[Chirugie] [bit] NULL,
	[dateChirugie] [datetime2](7) NULL,
	[dateConge] [datetime2](7) NULL,
	[tv] [bit] NULL,
	[telephone] [bit] NULL,
 CONSTRAINT [PK_tblAdmission] PRIMARY KEY CLUSTERED 
(
	[IDadmission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDept]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDept](
	[IDdept] [int] NOT NULL,
	[NomDept] [nchar](30) NOT NULL,
 CONSTRAINT [PK_tblDept] PRIMARY KEY CLUSTERED 
(
	[IDdept] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLit]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLit](
	[Lit] [int] NOT NULL,
	[Occupe] [bit] NOT NULL,
	[Type] [int] NOT NULL,
	[IDdept] [int] NOT NULL,
 CONSTRAINT [PK_tblLit] PRIMARY KEY CLUSTERED 
(
	[Lit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLitType]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLitType](
	[Type] [int] NOT NULL,
	[Descript] [nchar](10) NOT NULL,
 CONSTRAINT [PK_tblLitType] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMedecins]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMedecins](
	[IDmedecin] [int] IDENTITY(209,1) NOT NULL,
	[Nom] [nchar](20) NOT NULL,
	[Prenom] [nchar](20) NOT NULL,
	[Specialite] [nchar](30) NOT NULL,
 CONSTRAINT [PK_tblMedecins] PRIMARY KEY CLUSTERED 
(
	[IDmedecin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblParents]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblParents](
	[RefParent] [int] NOT NULL,
	[Nom] [nchar](20) NULL,
	[Prenom] [nchar](20) NULL,
	[Adresse] [nchar](20) NULL,
	[Ville] [nchar](20) NULL,
	[Province] [nchar](20) NULL,
	[CP] [nchar](6) NULL,
	[Tel] [nchar](10) NULL,
 CONSTRAINT [PK_tblParents] PRIMARY KEY CLUSTERED 
(
	[RefParent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPatients]    Script Date: 8/30/2020 6:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPatients](
	[NAS] [int] NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Nom] [nchar](20) NOT NULL,
	[Prenom] [nchar](20) NOT NULL,
	[Adresse] [nchar](30) NULL,
	[Ville] [nchar](20) NULL,
	[Province] [nchar](20) NULL,
	[CP] [nchar](6) NULL,
	[Tel] [nchar](10) NULL,
	[IDassurance] [int] NULL,
	[RefParent] [int] NULL,
 CONSTRAINT [PK_tblPatients] PRIMARY KEY CLUSTERED 
(
	[NAS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Assurance] ([IDassurance], [NomCompagnie]) VALUES (1, N'Hamstervie                    ')
INSERT [dbo].[Assurance] ([IDassurance], [NomCompagnie]) VALUES (2, N'Croix Rose                    ')
INSERT [dbo].[Assurance] ([IDassurance], [NomCompagnie]) VALUES (3, N'Elviva Inc.                   ')
SET IDENTITY_INSERT [dbo].[tblAdmission] ON 

INSERT [dbo].[tblAdmission] ([IDadmission], [NAS], [dateAdmis], [IDmedecin], [Lit], [Chirugie], [dateChirugie], [dateConge], [tv], [telephone]) VALUES (1, 111111111, CAST(N'2020-07-01 00:00:00.0000000' AS DateTime2), 204, 201, NULL, NULL, CAST(N'2020-08-30 00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[tblAdmission] ([IDadmission], [NAS], [dateAdmis], [IDmedecin], [Lit], [Chirugie], [dateChirugie], [dateConge], [tv], [telephone]) VALUES (2, 222222222, CAST(N'2020-07-02 00:00:00.0000000' AS DateTime2), 203, 301, 1, CAST(N'2020-07-03 00:00:00.0000000' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[tblAdmission] ([IDadmission], [NAS], [dateAdmis], [IDmedecin], [Lit], [Chirugie], [dateChirugie], [dateConge], [tv], [telephone]) VALUES (3, 333333333, CAST(N'2020-07-03 00:00:00.0000000' AS DateTime2), 202, 202, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[tblAdmission] ([IDadmission], [NAS], [dateAdmis], [IDmedecin], [Lit], [Chirugie], [dateChirugie], [dateConge], [tv], [telephone]) VALUES (23, 555555555, CAST(N'2020-08-29 00:00:00.0000000' AS DateTime2), 203, 301, 1, CAST(N'2020-08-31 00:00:00.0000000' AS DateTime2), NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[tblAdmission] OFF
INSERT [dbo].[tblDept] ([IDdept], [NomDept]) VALUES (1, N'Urgence                       ')
INSERT [dbo].[tblDept] ([IDdept], [NomDept]) VALUES (2, N'Réadaptation                  ')
INSERT [dbo].[tblDept] ([IDdept], [NomDept]) VALUES (3, N'Chirugie                      ')
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (101, 1, 1, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (102, 1, 1, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (103, 1, 1, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (104, 1, 1, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (105, 1, 1, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (106, 1, 1, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (107, 1, 2, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (108, 0, 2, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (109, 0, 2, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (110, 1, 2, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (111, 0, 3, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (112, 0, 3, 1)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (201, 0, 1, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (202, 0, 1, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (203, 1, 1, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (204, 1, 1, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (205, 1, 1, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (206, 1, 1, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (207, 1, 2, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (208, 1, 2, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (209, 0, 2, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (210, 0, 2, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (211, 1, 3, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (212, 1, 3, 2)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (301, 0, 1, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (302, 1, 1, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (303, 1, 1, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (304, 1, 1, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (305, 1, 1, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (306, 1, 1, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (307, 0, 2, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (308, 1, 2, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (309, 1, 2, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (310, 1, 2, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (311, 0, 3, 3)
INSERT [dbo].[tblLit] ([Lit], [Occupe], [Type], [IDdept]) VALUES (312, 0, 3, 3)
INSERT [dbo].[tblLitType] ([Type], [Descript]) VALUES (1, N'Standard  ')
INSERT [dbo].[tblLitType] ([Type], [Descript]) VALUES (2, N'Semi-privé')
INSERT [dbo].[tblLitType] ([Type], [Descript]) VALUES (3, N'Privé     ')
SET IDENTITY_INSERT [dbo].[tblMedecins] ON 

INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (201, N'Rabbit              ', N'Peter               ', N'Pédiatrie                     ')
INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (202, N'Terrapin            ', N'Babette             ', N'Anesthésiologie               ')
INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (203, N'Sangsue             ', N'Eloise              ', N'Interniste                    ')
INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (204, N'Coucou              ', N'Francine            ', N'Anesthésiologie               ')
INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (205, N'Papillon            ', N'Artur               ', N'Interniste                    ')
INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (206, N'Fuchs               ', N'Reynardine          ', N'Interniste                    ')
INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (207, N'LaTaupe             ', N'Bunny               ', N'Interniste                    ')
INSERT [dbo].[tblMedecins] ([IDmedecin], [Nom], [Prenom], [Specialite]) VALUES (209, N'Cobaye              ', N'Leonard             ', N'Pédiatrie                     ')
SET IDENTITY_INSERT [dbo].[tblMedecins] OFF
INSERT [dbo].[tblParents] ([RefParent], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel]) VALUES (111111111, N'Squirrel            ', N'Elmer               ', N'10 ave Bleuet       ', N'St.Hyacinthe        ', N'Québec              ', N'Q1Q1Q1', N'0         ')
INSERT [dbo].[tblParents] ([RefParent], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel]) VALUES (222222222, N'Otter               ', N'Brune               ', N'20 ave Fraise       ', N'Berthierville       ', N'Québec              ', N'R2R2R2', N'0         ')
INSERT [dbo].[tblParents] ([RefParent], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel]) VALUES (333333333, N'Truite              ', N'Clara               ', N'40 ave Physalis     ', N'Rimouski            ', N'Québec              ', N'S4S4S4', N'0         ')
INSERT [dbo].[tblParents] ([RefParent], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel]) VALUES (444444444, N'Grenouille          ', N'Grandmaman          ', N'30 ave Mûre         ', N'Chicoutimi          ', N'Québec              ', N'T3T3T3', N'4032356784')
INSERT [dbo].[tblParents] ([RefParent], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel]) VALUES (555555555, N'LaFleur             ', N'Pissenlit           ', N'50 rue Raisin       ', N'Montréal            ', N'Québec              ', N'T5T5T5', N'1112225555')
INSERT [dbo].[tblParents] ([RefParent], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel]) VALUES (666666666, N'Poisson-Chat        ', N'Grandpère           ', N'60 boul. Banane     ', N'Chicoutimi          ', N'Québec              ', N'U6U6U6', N'2345678890')
INSERT [dbo].[tblPatients] ([NAS], [DOB], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel], [IDassurance], [RefParent]) VALUES (111111111, CAST(N'1975-09-19 00:00:00.0000000' AS DateTime2), N'Squirrel            ', N'Monsieur            ', N'10 rue Bleuet                 ', N'Montréal            ', N'Québec              ', N'M1M1M1', N'0         ', 1, 111111111)
INSERT [dbo].[tblPatients] ([NAS], [DOB], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel], [IDassurance], [RefParent]) VALUES (222222222, CAST(N'1980-10-30 00:00:00.0000000' AS DateTime2), N'Otter               ', N'Miss                ', N'20 rue Fraise                 ', N'Montréal            ', N'Québec              ', N'N2N2N2', N'0         ', 2, 222222222)
INSERT [dbo].[tblPatients] ([NAS], [DOB], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel], [IDassurance], [RefParent]) VALUES (333333333, CAST(N'1937-05-31 00:00:00.0000000' AS DateTime2), N'Grenouille          ', N'Petite              ', N'30 rue Mûre                   ', N'Montréal            ', N'Québec              ', N'L3L3L3', N'0         ', 3, NULL)
INSERT [dbo].[tblPatients] ([NAS], [DOB], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel], [IDassurance], [RefParent]) VALUES (444444444, CAST(N'1956-02-18 00:00:00.0000000' AS DateTime2), N'Truite              ', N'Grande              ', N'40 rue Physalis               ', N'Montréal            ', N'Québec              ', N'P4P4P4', N'0         ', 1, 444444444)
INSERT [dbo].[tblPatients] ([NAS], [DOB], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel], [IDassurance], [RefParent]) VALUES (555555555, CAST(N'2010-04-04 00:00:00.0000000' AS DateTime2), N'LaFleur             ', N'Dandelion           ', N'50 rue Raisin                 ', N'Montréal            ', N'Québec              ', N'T5T5T5', N'1112225555', 0, 555555555)
INSERT [dbo].[tblPatients] ([NAS], [DOB], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel], [IDassurance], [RefParent]) VALUES (666666666, CAST(N'1993-10-30 00:00:00.0000000' AS DateTime2), N'Poisson-Chat        ', N'Madelle             ', N'rue Banane                    ', N'Montréal            ', N'Québec              ', N'R6R6R6', N'1111111111', 3, NULL)
INSERT [dbo].[tblPatients] ([NAS], [DOB], [Nom], [Prenom], [Adresse], [Ville], [Province], [CP], [Tel], [IDassurance], [RefParent]) VALUES (777777777, CAST(N'1978-09-17 00:00:00.0000000' AS DateTime2), N'Libellule           ', N'Aline               ', N'boul Melon d''eau              ', N'Montréal            ', N'Québec              ', N'S7S7S7', N'7777777777', 2, NULL)
ALTER TABLE [dbo].[tblAdmission]  WITH CHECK ADD  CONSTRAINT [FK_AdmissionLit] FOREIGN KEY([Lit])
REFERENCES [dbo].[tblLit] ([Lit])
GO
ALTER TABLE [dbo].[tblAdmission] CHECK CONSTRAINT [FK_AdmissionLit]
GO
ALTER TABLE [dbo].[tblAdmission]  WITH CHECK ADD  CONSTRAINT [FK_AdmissionMedecins] FOREIGN KEY([IDmedecin])
REFERENCES [dbo].[tblMedecins] ([IDmedecin])
GO
ALTER TABLE [dbo].[tblAdmission] CHECK CONSTRAINT [FK_AdmissionMedecins]
GO
ALTER TABLE [dbo].[tblAdmission]  WITH CHECK ADD  CONSTRAINT [FK_AdmissionPatients] FOREIGN KEY([NAS])
REFERENCES [dbo].[tblPatients] ([NAS])
GO
ALTER TABLE [dbo].[tblAdmission] CHECK CONSTRAINT [FK_AdmissionPatients]
GO
ALTER TABLE [dbo].[tblLit]  WITH CHECK ADD  CONSTRAINT [FK_LitDept] FOREIGN KEY([IDdept])
REFERENCES [dbo].[tblDept] ([IDdept])
GO
ALTER TABLE [dbo].[tblLit] CHECK CONSTRAINT [FK_LitDept]
GO
ALTER TABLE [dbo].[tblLit]  WITH CHECK ADD  CONSTRAINT [FK_LitLitType] FOREIGN KEY([Type])
REFERENCES [dbo].[tblLitType] ([Type])
GO
ALTER TABLE [dbo].[tblLit] CHECK CONSTRAINT [FK_LitLitType]
GO
ALTER TABLE [dbo].[tblPatients]  WITH CHECK ADD  CONSTRAINT [FK_refParents_Patients] FOREIGN KEY([RefParent])
REFERENCES [dbo].[tblParents] ([RefParent])
GO
ALTER TABLE [dbo].[tblPatients] CHECK CONSTRAINT [FK_refParents_Patients]
GO
USE [master]
GO
ALTER DATABASE [NorthernLightsHospital] SET  READ_WRITE 
GO
