USE [master]
GO
/****** Object:  Database [Specifications]    Script Date: 23/07/2019 01:16:25 ******/
CREATE DATABASE [Specifications]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Specifications', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Specifications.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Specifications_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Specifications_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Specifications] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Specifications].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Specifications] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Specifications] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Specifications] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Specifications] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Specifications] SET ARITHABORT OFF 
GO
ALTER DATABASE [Specifications] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Specifications] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Specifications] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Specifications] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Specifications] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Specifications] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Specifications] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Specifications] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Specifications] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Specifications] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Specifications] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Specifications] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Specifications] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Specifications] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Specifications] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Specifications] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Specifications] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Specifications] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Specifications] SET  MULTI_USER 
GO
ALTER DATABASE [Specifications] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Specifications] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Specifications] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Specifications] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Specifications] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Specifications] SET QUERY_STORE = OFF
GO
USE [Specifications]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Specifications]
GO
/****** Object:  Table [dbo].[Aircraft]    Script Date: 23/07/2019 01:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aircraft](
	[AircraftID] [int] IDENTITY(1,1) NOT NULL,
	[AircraftName] [varchar](30) NOT NULL,
	[Series] [varchar](30) NOT NULL,
	[Speed(km/h)] [int] NULL,
	[Weight(kg)] [int] NULL,
	[MaxTakeoffWeight(kg)] [int] NULL,
	[FuelCapacity(l)] [int] NULL,
	[FuelConsumption(km/l)] [varchar](10) NULL,
	[FKInventoryID] [int] NOT NULL,
 CONSTRAINT [PK_Aircraft] PRIMARY KEY CLUSTERED 
(
	[AircraftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 23/07/2019 01:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[InventoryID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](20) NOT NULL,
	[Quantity] [int] NULL,
	[Weight(kg)] [int] NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[InventoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aircraft] ON 

INSERT [dbo].[Aircraft] ([AircraftID], [AircraftName], [Series], [Speed(km/h)], [Weight(kg)], [MaxTakeoffWeight(kg)], [FuelCapacity(l)], [FuelConsumption(km/l)], [FKInventoryID]) VALUES (1, N'Lockheed Martin', N'F-35C Lightning II', 1976, 22426, 31800, 10448, N'0.460', 4)
INSERT [dbo].[Aircraft] ([AircraftID], [AircraftName], [Series], [Speed(km/h)], [Weight(kg)], [MaxTakeoffWeight(kg)], [FuelCapacity(l)], [FuelConsumption(km/l)], [FKInventoryID]) VALUES (2, N'Fairchild Republic', N'A-10 Thunderbolt II', 706, 13782, 22700, 6057, N'0.685', 1)
INSERT [dbo].[Aircraft] ([AircraftID], [AircraftName], [Series], [Speed(km/h)], [Weight(kg)], [MaxTakeoffWeight(kg)], [FuelCapacity(l)], [FuelConsumption(km/l)], [FKInventoryID]) VALUES (3, N'Boeing', N'AH-64 Apache', 293, 8000, 10433, 1420, N'1.590', 2)
INSERT [dbo].[Aircraft] ([AircraftID], [AircraftName], [Series], [Speed(km/h)], [Weight(kg)], [MaxTakeoffWeight(kg)], [FuelCapacity(l)], [FuelConsumption(km/l)], [FKInventoryID]) VALUES (4, N'MD Helicopters', N'MH-6 Little Bird', 282, 905, 1406, 242, N'2.050', 2)
INSERT [dbo].[Aircraft] ([AircraftID], [AircraftName], [Series], [Speed(km/h)], [Weight(kg)], [MaxTakeoffWeight(kg)], [FuelCapacity(l)], [FuelConsumption(km/l)], [FKInventoryID]) VALUES (5, N'Northrop Grumman', N'B-2 Spirit', 1014, 152634, 170551, 94351, N'0.117', 3)
SET IDENTITY_INSERT [dbo].[Aircraft] OFF
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([InventoryID], [Type], [Quantity], [Weight(kg)]) VALUES (1, N'Ammunition', 0, 250)
INSERT [dbo].[Inventory] ([InventoryID], [Type], [Quantity], [Weight(kg)]) VALUES (2, N'Supplies', 0, 28)
INSERT [dbo].[Inventory] ([InventoryID], [Type], [Quantity], [Weight(kg)]) VALUES (3, N'Bombs', 0, 850)
INSERT [dbo].[Inventory] ([InventoryID], [Type], [Quantity], [Weight(kg)]) VALUES (4, N'Additional Equipment', 0, 90)
SET IDENTITY_INSERT [dbo].[Inventory] OFF
ALTER TABLE [dbo].[Aircraft]  WITH CHECK ADD  CONSTRAINT [FK_Aircraft_Inventory] FOREIGN KEY([FKInventoryID])
REFERENCES [dbo].[Inventory] ([InventoryID])
GO
ALTER TABLE [dbo].[Aircraft] CHECK CONSTRAINT [FK_Aircraft_Inventory]
GO
USE [master]
GO
ALTER DATABASE [Specifications] SET  READ_WRITE 
GO
