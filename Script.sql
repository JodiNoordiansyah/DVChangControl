USE [master]
GO
/****** Object:  Database [DaryaVaria]    Script Date: 07/10/2024 13:32:08 ******/
CREATE DATABASE [DaryaVaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DaryaVaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DaryaVaria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DaryaVaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DaryaVaria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DaryaVaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DaryaVaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DaryaVaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DaryaVaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DaryaVaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DaryaVaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [DaryaVaria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DaryaVaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DaryaVaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DaryaVaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DaryaVaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DaryaVaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DaryaVaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DaryaVaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DaryaVaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DaryaVaria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DaryaVaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DaryaVaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DaryaVaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DaryaVaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DaryaVaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DaryaVaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DaryaVaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DaryaVaria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DaryaVaria] SET  MULTI_USER 
GO
ALTER DATABASE [DaryaVaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DaryaVaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DaryaVaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DaryaVaria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DaryaVaria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DaryaVaria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DaryaVaria] SET QUERY_STORE = ON
GO
ALTER DATABASE [DaryaVaria] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DaryaVaria]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/10/2024 13:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Approval]    Script Date: 07/10/2024 13:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Approval](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DocId] [bigint] NULL,
	[DocNo] [nvarchar](max) NOT NULL,
	[Level] [int] NOT NULL,
	[ApproverUsername] [nvarchar](max) NOT NULL,
	[ApproverName] [nvarchar](max) NOT NULL,
	[ApproverEmail] [nvarchar](max) NOT NULL,
	[ApproveDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Approval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeControl]    Script Date: 07/10/2024 13:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeControl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DocumentNo] [nvarchar](max) NULL,
	[Date] [datetime2](7) NULL,
	[DepartemenCreator] [nvarchar](max) NULL,
	[Pabrik] [nvarchar](max) NULL,
	[ProductName] [nvarchar](max) NULL,
	[Deskripsi] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[Status] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChangeControl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 07/10/2024 13:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
	[ChangeControlId] [bigint] NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DepartmentId] [bigint] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07/10/2024 13:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 07/10/2024 13:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfiles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ManagerUsername] [nvarchar](max) NOT NULL,
	[ManagerName] [nvarchar](max) NOT NULL,
	[ManagerEmail] [nvarchar](max) NOT NULL,
	[DepartmentId] [bigint] NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930055503_init', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930064040_init2', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930065035_init3', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930072657_int4', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930073242_init5', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930083317_init6', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241002095959_int7', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241002100330_int8', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241002100519_int9', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241002100806_init10', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241002101351_init11', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003034833_int12', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003061529_init13', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003061715_init14', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003061814_init15', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003083111_init16', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003083502_init17', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[Approval] ON 

INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (28, 2, N'1234', 1, N'noordiansyahjodi@gmail.com', N'noordiansyah jodi', N'noordiansyahjodi@gmail.com', CAST(N'2024-10-03T17:08:56.0054963' AS DateTime2), N'Jodi', CAST(N'2024-10-03T16:51:18.9571676' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (29, 2, N'1234', 2, N'benethdesu1@gmail.com', N'Rayan', N'benethdesu1@gmail.com', CAST(N'2024-10-03T17:09:10.2253185' AS DateTime2), N'Jodi', CAST(N'2024-10-03T16:51:18.9769593' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (30, 2, N'1234', 2, N'benethdesu2@gmail.com', N'Desi', N'benethdesu2@gmail.com', CAST(N'2024-10-03T17:09:30.3021252' AS DateTime2), N'Jodi', CAST(N'2024-10-03T16:51:18.9841631' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (31, 2, N'1234', 3, N'benethdesu4@gmail.com', N'Kean', N'benethdesu4@gmail.com', NULL, N'Jodi', CAST(N'2024-10-03T16:51:18.9957407' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (32, 2, N'1234', 4, N'benethdesu5@gmail.com', N'Lutfi', N'benethdesu5@gmail.com', NULL, N'Jodi', CAST(N'2024-10-03T16:51:19.0127121' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (33, 32, N'', 1, N'noordiansyahjodi@gmail.com', N'noordiansyah jodi', N'noordiansyahjodi@gmail.com', CAST(N'2024-10-07T10:56:20.5635697' AS DateTime2), N'Jodi', CAST(N'2024-10-07T09:48:56.2197328' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (34, 32, N'', 2, N'benethdesu2@gmail.com', N'Desi', N'benethdesu2@gmail.com', CAST(N'2024-10-07T10:57:17.4442895' AS DateTime2), N'Jodi', CAST(N'2024-10-07T09:48:56.2378701' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (35, 32, N'', 3, N'benethdesu4@gmail.com', N'Kean', N'benethdesu4@gmail.com', CAST(N'2024-10-07T10:59:37.3231580' AS DateTime2), N'Jodi', CAST(N'2024-10-07T09:48:56.2499350' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (36, 32, N'', 4, N'benethdesu5@gmail.com', N'Lutfi', N'benethdesu5@gmail.com', CAST(N'2024-10-07T11:00:19.1446842' AS DateTime2), N'Jodi', CAST(N'2024-10-07T09:48:56.2584797' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (44, 37, N'', 1, N'noordiansyahjodi@gmail.com', N'noordiansyah jodi', N'noordiansyahjodi@gmail.com', NULL, N'Jodi', CAST(N'2024-10-07T13:22:29.1245628' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (45, 37, N'', 2, N'benethdesu2@gmail.com', N'Desi', N'benethdesu2@gmail.com', NULL, N'Jodi', CAST(N'2024-10-07T13:22:29.1372943' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (46, 37, N'', 3, N'benethdesu4@gmail.com', N'Kean', N'benethdesu4@gmail.com', NULL, N'Jodi', CAST(N'2024-10-07T13:22:29.1476963' AS DateTime2), NULL, NULL)
INSERT [dbo].[Approval] ([Id], [DocId], [DocNo], [Level], [ApproverUsername], [ApproverName], [ApproverEmail], [ApproveDate], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (47, 37, N'', 4, N'benethdesu5@gmail.com', N'Lutfi', N'benethdesu5@gmail.com', NULL, N'Jodi', CAST(N'2024-10-07T13:22:29.1578722' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Approval] OFF
GO
SET IDENTITY_INSERT [dbo].[ChangeControl] ON 

INSERT [dbo].[ChangeControl] ([Id], [DocumentNo], [Date], [DepartemenCreator], [Pabrik], [ProductName], [Deskripsi], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status], [Notes]) VALUES (2, N'1234', CAST(N'2024-09-30T14:33:00.0000000' AS DateTime2), N'halo', N'123', N'456', N'789', N'jodinoordiansyah@gmail.com', CAST(N'2024-09-30T14:33:32.2414838' AS DateTime2), NULL, NULL, N'Approved By Java Department', N'789')
INSERT [dbo].[ChangeControl] ([Id], [DocumentNo], [Date], [DepartemenCreator], [Pabrik], [ProductName], [Deskripsi], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status], [Notes]) VALUES (32, N'dsadasda', CAST(N'2024-10-04T13:48:00.0000000' AS DateTime2), N'dsadsadas', N'dsadsadasd', N'dsaddsadasda', N'1234901323', N'jodinoordiansyah@gmail.com', CAST(N'2024-02-09T22:48:42.0000000' AS DateTime2), N'benethdesu4@gmail.com', CAST(N'2024-10-07T10:59:18.3206673' AS DateTime2), N'Completed', N'dsadasd')
INSERT [dbo].[ChangeControl] ([Id], [DocumentNo], [Date], [DepartemenCreator], [Pabrik], [ProductName], [Deskripsi], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status], [Notes]) VALUES (33, N'', CAST(N'2024-10-07T11:19:00.0000000' AS DateTime2), N'dad', N'dsad', N'dsa', N'dsa', N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T11:19:53.1241708' AS DateTime2), N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T11:23:07.6193843' AS DateTime2), N'Rejected', N'dsada')
INSERT [dbo].[ChangeControl] ([Id], [DocumentNo], [Date], [DepartemenCreator], [Pabrik], [ProductName], [Deskripsi], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status], [Notes]) VALUES (37, N'', CAST(N'2024-10-07T00:00:00.0000000' AS DateTime2), N'dsadas', N'sdada', N'dsa', N'dsa', N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T13:17:08.1051073' AS DateTime2), N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T13:18:36.9989215' AS DateTime2), N'Submitted', NULL)
SET IDENTITY_INSERT [dbo].[ChangeControl] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (1, N'.net', 2, N'jodi', CAST(N'2024-10-03T13:18:38.5600000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (2, N'.java', 2, N'jodi', CAST(N'2024-10-03T13:18:38.5633333' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (11, N'Description 2', 32, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T09:13:12.8115745' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (12, N'Description 2', NULL, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T11:19:53.1241708' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (13, N'Description 2', 33, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T11:23:07.6193900' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (14, N'Description 2', NULL, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T13:11:57.0158472' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (15, N'Description 2', NULL, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T13:14:04.1058360' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (16, N'Description 2', NULL, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T13:16:20.0854541' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (17, N'Description 3', NULL, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T13:17:08.1051073' AS DateTime2), NULL, NULL, 3)
INSERT [dbo].[Departments] ([Id], [DepartmentName], [ChangeControlId], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [DepartmentId]) VALUES (18, N'Description 2', 37, N'jodinoordiansyah@gmail.com', CAST(N'2024-10-07T13:18:36.9991241' AS DateTime2), NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (1, N'jodinoordiansyah@gmail.com', N'12345')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (2, N'noordiansyahjodi@gmail.com', N'12345')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (3, N'benethdesu1@gmail.com', N'12345')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (4, N'benethdesu2@gmail.com', N'12345')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (5, N'benethdesu5@gmail.com', N'12345')
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (6, N'benethdesu4@gmail.com', N'12345')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] ON 

INSERT [dbo].[UserProfiles] ([Id], [Username], [Name], [Email], [ManagerUsername], [ManagerName], [ManagerEmail], [DepartmentId], [DepartmentName], [Role], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'jodinoordiansyah@gmail.com', N'Jodi Noordiansyah', N'jodinoordiansyah@gmail.com', N'noordiansyahjodi@gmail.com', N'noordiansyah jodi', N'noordiansyahjodi@gmail.com', 1, N'Dot Net Department', N'Creator', N'Jodi', CAST(N'2024-09-30T15:17:49.0233333' AS DateTime2), NULL, NULL)
INSERT [dbo].[UserProfiles] ([Id], [Username], [Name], [Email], [ManagerUsername], [ManagerName], [ManagerEmail], [DepartmentId], [DepartmentName], [Role], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'noordiansyahjodi@gmail.com', N'Noordiansyah', N'noordiansyahjodi@gmail.com', N'jodinoordiansyah@gmail.com', N'Andre', N'jodinoordiansyah@gmail.com', 1, N'Dot Net Department', N'Approver', N'Jodi', CAST(N'2024-10-01T07:14:40.8566667' AS DateTime2), NULL, NULL)
INSERT [dbo].[UserProfiles] ([Id], [Username], [Name], [Email], [ManagerUsername], [ManagerName], [ManagerEmail], [DepartmentId], [DepartmentName], [Role], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'benethdesu1@gmail.com', N'Rayan', N'benethdesu1@gmail.com', N'jodinoordiansyah@gmail.com', N'Andre', N'jodinoordiansyah@gmail.com', 1, N'Dot Net Department', N'Approver', N'Jodi', CAST(N'2024-10-01T07:14:40.8566667' AS DateTime2), NULL, NULL)
INSERT [dbo].[UserProfiles] ([Id], [Username], [Name], [Email], [ManagerUsername], [ManagerName], [ManagerEmail], [DepartmentId], [DepartmentName], [Role], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'benethdesu2@gmail.com', N'Desi', N'benethdesu2@gmail.com', N'jodinoordiansyah@gmail.com', N'Andre', N'jodinoordiansyah@gmail.com', 2, N'Java Department', N'Approver', N'Jodi', CAST(N'2024-10-01T07:14:40.8566667' AS DateTime2), NULL, NULL)
INSERT [dbo].[UserProfiles] ([Id], [Username], [Name], [Email], [ManagerUsername], [ManagerName], [ManagerEmail], [DepartmentId], [DepartmentName], [Role], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'benethdesu3@gmail.com', N'Putra', N'benethdesu3@gmail.com', N'jodinoordiansyah@gmail.com', N'Andre', N'jodinoordiansyah@gmail.com', 2, N'Java Department', N'Approver', N'Jodi', CAST(N'2024-10-01T07:14:40.8566667' AS DateTime2), NULL, NULL)
INSERT [dbo].[UserProfiles] ([Id], [Username], [Name], [Email], [ManagerUsername], [ManagerName], [ManagerEmail], [DepartmentId], [DepartmentName], [Role], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (6, N'benethdesu4@gmail.com', N'Kean', N'benethdesu4@gmail.com', N'jodinoordiansyah@gmail.com', N'Andre', N'jodinoordiansyah@gmail.com', 1, N'Dot Net Department', N'Control Center', N'Jodi', CAST(N'2024-10-01T07:14:40.8566667' AS DateTime2), NULL, NULL)
INSERT [dbo].[UserProfiles] ([Id], [Username], [Name], [Email], [ManagerUsername], [ManagerName], [ManagerEmail], [DepartmentId], [DepartmentName], [Role], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (7, N'benethdesu5@gmail.com', N'Lutfi', N'benethdesu5@gmail.com', N'jodinoordiansyah@gmail.com', N'Andre', N'jodinoordiansyah@gmail.com', 1, N'Dot Net Department', N'QA Manager', N'Jodi', CAST(N'2024-10-01T07:14:40.8566667' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF
GO
/****** Object:  Index [IX_Departments_ChangeControlId]    Script Date: 07/10/2024 13:32:08 ******/
CREATE NONCLUSTERED INDEX [IX_Departments_ChangeControlId] ON [dbo].[Departments]
(
	[ChangeControlId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_ChangeControl_ChangeControlId] FOREIGN KEY([ChangeControlId])
REFERENCES [dbo].[ChangeControl] ([Id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_ChangeControl_ChangeControlId]
GO
USE [master]
GO
ALTER DATABASE [DaryaVaria] SET  READ_WRITE 
GO
