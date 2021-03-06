USE [master]
GO
/****** Object:  Database [StudentProfessor]    Script Date: 18-10-2019 12:42:28 ******/
CREATE DATABASE [StudentProfessor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentProfessor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StudentProfessor.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentProfessor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StudentProfessor_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentProfessor] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentProfessor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentProfessor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentProfessor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentProfessor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentProfessor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentProfessor] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentProfessor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentProfessor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentProfessor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentProfessor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentProfessor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentProfessor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentProfessor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentProfessor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentProfessor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentProfessor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentProfessor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentProfessor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentProfessor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentProfessor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentProfessor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentProfessor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentProfessor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentProfessor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentProfessor] SET  MULTI_USER 
GO
ALTER DATABASE [StudentProfessor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentProfessor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentProfessor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentProfessor] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudentProfessor] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StudentProfessor]
GO
/****** Object:  Table [dbo].[courseTable]    Script Date: 18-10-2019 12:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courseTable](
	[CourseId] [int] NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_courseTable] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[studentEnrolTable]    Script Date: 18-10-2019 12:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[studentEnrolTable](
	[EnrolId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_studentEnrolTable] PRIMARY KEY CLUSTERED 
(
	[EnrolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[studentTable]    Script Date: 18-10-2019 12:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[studentTable](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_studentTable] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProfessor]    Script Date: 18-10-2019 12:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProfessor](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[ProfessorName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblProfessor] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (101, N'English')
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (102, N'Mathematics')
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (103, N'Physics')
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (104, N'Chemistry')
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (105, N'Political Science')
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (106, N'History')
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (107, N'Computer Administration')
INSERT [dbo].[courseTable] ([CourseId], [CourseName]) VALUES (108, N'Geography')
SET IDENTITY_INSERT [dbo].[studentEnrolTable] ON 

INSERT [dbo].[studentEnrolTable] ([EnrolId], [CourseId], [StudentId]) VALUES (21, 102, 17)
INSERT [dbo].[studentEnrolTable] ([EnrolId], [CourseId], [StudentId]) VALUES (22, 105, 17)
INSERT [dbo].[studentEnrolTable] ([EnrolId], [CourseId], [StudentId]) VALUES (23, 107, 18)
INSERT [dbo].[studentEnrolTable] ([EnrolId], [CourseId], [StudentId]) VALUES (24, 102, 18)
SET IDENTITY_INSERT [dbo].[studentEnrolTable] OFF
SET IDENTITY_INSERT [dbo].[studentTable] ON 

INSERT [dbo].[studentTable] ([StudentId], [StudentName]) VALUES (17, N'anand')
INSERT [dbo].[studentTable] ([StudentId], [StudentName]) VALUES (18, N'rohit')
SET IDENTITY_INSERT [dbo].[studentTable] OFF
SET IDENTITY_INSERT [dbo].[tblProfessor] ON 

INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (1, 101, N'Anil')
INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (2, 106, N'Anil')
INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (3, 105, N'Anil')
INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (4, 103, N'Suresh')
INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (5, 102, N'Suresh')
INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (6, 107, N'Mohan')
INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (7, 104, N'Mohan')
INSERT [dbo].[tblProfessor] ([ProfessorId], [CourseId], [ProfessorName]) VALUES (8, 108, N'Abhay')
SET IDENTITY_INSERT [dbo].[tblProfessor] OFF
ALTER TABLE [dbo].[studentEnrolTable]  WITH CHECK ADD  CONSTRAINT [FK_studentEnrolTable_courseTable] FOREIGN KEY([CourseId])
REFERENCES [dbo].[courseTable] ([CourseId])
GO
ALTER TABLE [dbo].[studentEnrolTable] CHECK CONSTRAINT [FK_studentEnrolTable_courseTable]
GO
ALTER TABLE [dbo].[studentEnrolTable]  WITH CHECK ADD  CONSTRAINT [FK_studentEnrolTable_studentTable] FOREIGN KEY([StudentId])
REFERENCES [dbo].[studentTable] ([StudentId])
GO
ALTER TABLE [dbo].[studentEnrolTable] CHECK CONSTRAINT [FK_studentEnrolTable_studentTable]
GO
ALTER TABLE [dbo].[tblProfessor]  WITH CHECK ADD  CONSTRAINT [FK_tblProfessor_courseTable] FOREIGN KEY([CourseId])
REFERENCES [dbo].[courseTable] ([CourseId])
GO
ALTER TABLE [dbo].[tblProfessor] CHECK CONSTRAINT [FK_tblProfessor_courseTable]
GO
USE [master]
GO
ALTER DATABASE [StudentProfessor] SET  READ_WRITE 
GO
