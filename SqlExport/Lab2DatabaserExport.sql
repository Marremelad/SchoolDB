USE [master]
GO
/****** Object:  Database [SchoolDB]    Script Date: 2024-12-08 10:05:07 ******/
CREATE DATABASE [SchoolDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolDB', FILENAME = N'C:\Users\Corte\SchoolDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchoolDB_log', FILENAME = N'C:\Users\Corte\SchoolDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SchoolDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SchoolDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SchoolDB] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SchoolDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchoolDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SchoolDB] SET QUERY_STORE = OFF
GO
USE [SchoolDB]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](35) NOT NULL,
	[AdminID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseAssignments]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignments](
	[AssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID_FK] [int] NOT NULL,
	[CourseID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseEnrolments]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseEnrolments](
	[EnrolmentsID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID_FK] [int] NOT NULL,
	[CourseID_FK] [int] NOT NULL,
	[Grade] [char](1) NULL,
	[GradeSetter_FK] [int] NULL,
	[GradingDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[EnrolmentsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRoles]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRoles](
	[EmployeeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID_FK] [int] NOT NULL,
	[RoleID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeFirstName] [nvarchar](35) NOT NULL,
	[EmployeeLastName] [nvarchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentFirstName] [nvarchar](35) NOT NULL,
	[StudentLastName] [nvarchar](35) NOT NULL,
	[StudentSSN] [varchar](13) NULL,
	[ClassID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 2024-12-08 10:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID_FK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([AdminID], [EmployeeID_FK]) VALUES (1, 5)
INSERT [dbo].[Admins] ([AdminID], [EmployeeID_FK]) VALUES (2, 6)
INSERT [dbo].[Admins] ([AdminID], [EmployeeID_FK]) VALUES (3, 7)
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassID], [ClassName], [AdminID_FK]) VALUES (1, N'SoftwareEngineering2024', 1)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [AdminID_FK]) VALUES (2, N'DataScience2024', 2)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [AdminID_FK]) VALUES (3, N'AIandMachineLearning2024', 3)
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseAssignments] ON 

INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (1, 1, 1)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (2, 1, 2)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (3, 2, 3)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (4, 2, 4)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (5, 3, 5)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (6, 3, 6)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (7, 4, 7)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (8, 5, 8)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (9, 6, 9)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (10, 4, 2)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (11, 5, 3)
INSERT [dbo].[CourseAssignments] ([AssignmentID], [TeacherID_FK], [CourseID_FK]) VALUES (12, 6, 5)
SET IDENTITY_INSERT [dbo].[CourseAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseEnrolments] ON 

INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (1, 1, 7, N'C', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (2, 2, 7, N'F', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (3, 3, 7, N'A', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (4, 4, 7, N'A', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (5, 5, 7, N'A', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (6, 6, 7, N'F', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (7, 7, 7, N'C', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (8, 8, 7, N'A', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (9, 9, 7, N'B', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (10, 10, 7, N'B', 4, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (11, 11, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (12, 12, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (13, 13, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (14, 14, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (15, 15, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (16, 16, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (17, 17, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (18, 18, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (19, 19, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (20, 20, 10, NULL, NULL, NULL)
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (21, 21, 9, N'F', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (22, 22, 9, N'E', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (23, 23, 9, N'A', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (24, 24, 9, N'B', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (25, 25, 9, N'E', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (26, 26, 9, N'B', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (27, 27, 9, N'B', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (28, 28, 9, N'F', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (29, 29, 9, N'F', 6, CAST(N'2024-12-07' AS Date))
INSERT [dbo].[CourseEnrolments] ([EnrolmentsID], [StudentID_FK], [CourseID_FK], [Grade], [GradeSetter_FK], [GradingDate]) VALUES (30, 30, 9, N'F', 6, CAST(N'2024-12-07' AS Date))
SET IDENTITY_INSERT [dbo].[CourseEnrolments] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (1, N'Introduction to Programming')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (2, N'Database Management Systems')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (3, N'Web Development Fundamentals')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (4, N'Computer Networks')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (5, N'Data Structures and Algorithms')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (6, N'Operating Systems')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (7, N'Software Engineering')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (8, N'Machine Learning Basics')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (9, N'Artificial Intelligence')
INSERT [dbo].[Courses] ([CourseID], [CourseName]) VALUES (10, N'Data Science')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeRoles] ON 

INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (1, 1, 1)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (2, 5, 2)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (3, 6, 2)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (4, 7, 2)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (5, 5, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (6, 6, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (7, 7, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (8, 2, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (9, 3, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (10, 4, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (11, 8, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (12, 9, 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeRoleID], [EmployeeID_FK], [RoleID_FK]) VALUES (13, 10, 3)
SET IDENTITY_INSERT [dbo].[EmployeeRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (1, N'John', N'Doe')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (2, N'Jane', N'Smith')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (3, N'Alice', N'Johnson')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (4, N'Bob', N'Brown')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (5, N'Charlie', N'Davis')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (6, N'David', N'Miller')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (7, N'Eva', N'Wilson')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (8, N'Frank', N'Moore')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (9, N'Grace', N'Taylor')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeFirstName], [EmployeeLastName]) VALUES (10, N'Hank', N'Anderson')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Principal')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Teacher')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (1, N'Oliver', N'Smith', N'20050101-1234', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (2, N'Liam', N'Johnson', N'20050202-2345', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (3, N'Mia', N'Williams', N'20050303-3456', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (4, N'Ethan', N'Brown', N'20050404-4567', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (5, N'Emma', N'Jones', N'20050505-5678', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (6, N'Lucas', N'Garcia', N'20050606-6789', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (7, N'Amelia', N'Martinez', N'20050707-7890', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (8, N'Benjamin', N'Rodriguez', N'20050808-8901', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (9, N'Charlotte', N'Hernandez', N'20050909-9012', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (10, N'James', N'Lopez', N'20051010-0123', 1)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (11, N'Sophia', N'Gonzalez', N'20051111-1234', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (12, N'Mason', N'Wilson', N'20051212-2345', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (13, N'Isabella', N'Anderson', N'20051313-3456', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (14, N'Logan', N'Thomas', N'20051414-4567', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (15, N'Zoe', N'Taylor', N'20051515-5678', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (16, N'Jack', N'Moore', N'20051616-6789', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (17, N'Avery', N'Jackson', N'20051717-7890', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (18, N'Henry', N'Martin', N'20051818-8901', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (19, N'Harper', N'Lee', N'20051919-9012', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (20, N'Sebastian', N'Perez', N'20052020-0123', 2)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (21, N'Olivia', N'Khan', N'20052121-1234', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (22, N'Alexander', N'Nguyen', N'20052222-2345', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (23, N'Amira', N'Patel', N'20052323-3456', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (24, N'Lucas', N'Kim', N'20052424-4567', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (25, N'Elena', N'Wang', N'20052525-5678', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (26, N'Theo', N'Zhang', N'20052626-6789', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (27, N'Daniela', N'Sanchez', N'20052727-7890', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (28, N'Max', N'Singh', N'20052828-8901', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (29, N'Maya', N'Tan', N'20052929-9012', 3)
INSERT [dbo].[Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentSSN], [ClassID_FK]) VALUES (30, N'Carlos', N'Martinez', N'20053030-0123', 3)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (1, 5)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (2, 6)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (3, 7)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (4, 2)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (5, 3)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (6, 4)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (7, 8)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (8, 9)
INSERT [dbo].[Teachers] ([TeacherID], [EmployeeID_FK]) VALUES (9, 10)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD FOREIGN KEY([EmployeeID_FK])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD FOREIGN KEY([AdminID_FK])
REFERENCES [dbo].[Admins] ([AdminID])
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD FOREIGN KEY([CourseID_FK])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD FOREIGN KEY([TeacherID_FK])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD FOREIGN KEY([CourseID_FK])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD FOREIGN KEY([GradeSetter_FK])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD FOREIGN KEY([StudentID_FK])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD FOREIGN KEY([EmployeeID_FK])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD FOREIGN KEY([RoleID_FK])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([ClassID_FK])
REFERENCES [dbo].[Classes] ([ClassID])
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD FOREIGN KEY([EmployeeID_FK])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD CHECK  (([Grade]='F' OR [Grade]='E' OR [Grade]='D' OR [Grade]='C' OR [Grade]='B' OR [Grade]='A'))
GO
USE [master]
GO
ALTER DATABASE [SchoolDB] SET  READ_WRITE 
GO
