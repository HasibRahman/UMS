USE [master]
GO
/****** Object:  Database [UniversityManagementSystemDB]    Script Date: 12/7/2015 12:36:21 PM ******/
CREATE DATABASE [UniversityManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityManagementSystemDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagementSystemDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManagementSystemDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagementSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManagementSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityManagementSystemDB]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/7/2015 12:36:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Address] [varchar](250) NULL,
	[RegNo] [varchar](50) NULL,
	[PhoneNumber] [varchar](11) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [UniversityManagementSystemDB] SET  READ_WRITE 
GO
