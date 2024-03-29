USE [master]
GO
/****** Object:  Database [CourseWork]    Script Date: 03/01/22 22:40:43 ******/
CREATE DATABASE [CourseWork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CourseWork', FILENAME = N'E:\SQL Server 2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\CourseWork.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CourseWork_log', FILENAME = N'E:\SQL Server 2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\CourseWork_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CourseWork] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseWork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseWork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CourseWork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CourseWork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CourseWork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CourseWork] SET ARITHABORT OFF 
GO
ALTER DATABASE [CourseWork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CourseWork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CourseWork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CourseWork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CourseWork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CourseWork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CourseWork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CourseWork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CourseWork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CourseWork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CourseWork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CourseWork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CourseWork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CourseWork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CourseWork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CourseWork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CourseWork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CourseWork] SET RECOVERY FULL 
GO
ALTER DATABASE [CourseWork] SET  MULTI_USER 
GO
ALTER DATABASE [CourseWork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CourseWork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CourseWork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CourseWork] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CourseWork] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CourseWork] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CourseWork', N'ON'
GO
ALTER DATABASE [CourseWork] SET QUERY_STORE = OFF
GO
/****** Object:  Login [SERGEY\zerge]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [SERGEY\zerge] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\Winmgmt]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [NT SERVICE\Winmgmt] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLTELEMETRY]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [NT SERVICE\SQLTELEMETRY] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLSERVERAGENT]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [NT SERVICE\SQLSERVERAGENT] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT Service\MSSQLSERVER]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [NT Service\MSSQLSERVER] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT AUTHORITY\СИСТЕМА]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [NT AUTHORITY\СИСТЕМА] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'y/qbAozq8nxVYKfKkkYvQrOPQS33Mshb5fBHzrpCqrA=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 03/01/22 22:40:43 ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'DZNhDxy0WEf9SK8Zfoqq0cjjtLizCIb794suQ3iUu5Y=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
ALTER AUTHORIZATION ON DATABASE::[CourseWork] TO [SERGEY\zerge]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [SERGEY\zerge]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\Winmgmt]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLWriter]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLSERVERAGENT]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT Service\MSSQLSERVER]
GO
USE [CourseWork]
GO
GRANT VIEW ANY COLUMN ENCRYPTION KEY DEFINITION TO [public] AS [dbo]
GO
GRANT VIEW ANY COLUMN MASTER KEY DEFINITION TO [public] AS [dbo]
GO
/****** Object:  Table [dbo].[Active_substance]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Active_substance](
	[Name_active_substance] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Active_substance] PRIMARY KEY CLUSTERED 
(
	[Name_active_substance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Active_substance] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Bioadditive]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bioadditive](
	[Name_bioadditive] [nchar](30) NOT NULL,
	[Weight] [nchar](50) NULL,
	[Price] [int] NOT NULL,
	[Type_of_application] [nvarchar](max) NULL,
	[Manufacturer] [nchar](20) NOT NULL,
	[Contraindication] [nvarchar](max) NOT NULL,
	[Primary_packaging] [nchar](20) NULL,
 CONSTRAINT [PK_Bioadditive] PRIMARY KEY CLUSTERED 
(
	[Name_bioadditive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Bioadditive] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Client]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[SurName] [nchar](30) NOT NULL,
	[MidName] [nchar](30) NULL,
	[Telephone] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Email] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Client] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Composition]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Composition](
	[id_composition] [int] IDENTITY(1,1) NOT NULL,
	[Count] [int] NOT NULL,
	[Name_bioadditive] [nchar](30) NOT NULL,
	[Name_active_substance] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Composition] PRIMARY KEY CLUSTERED 
(
	[id_composition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Composition] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[Name_delivery] [nchar](30) NOT NULL,
	[Type_delivery] [nchar](20) NOT NULL,
	[Time_delivery] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[Name_delivery] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Delivery] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Illness]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Illness](
	[Name_illness] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Illness] PRIMARY KEY CLUSTERED 
(
	[Name_illness] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Illness] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Preorder]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preorder](
	[id_preorder] [int] IDENTITY(1,1) NOT NULL,
	[Data] [date] NOT NULL,
	[Status] [nchar](20) NOT NULL,
	[id_cleint] [int] NOT NULL,
	[Name_delivery] [nchar](30) NOT NULL,
	[Address] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Preorder] PRIMARY KEY CLUSTERED 
(
	[id_preorder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Preorder] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[id_receipt] [int] IDENTITY(1,1) NOT NULL,
	[Count] [int] NOT NULL,
	[id_preorder] [int] NOT NULL,
	[Name_bioadditive] [nchar](30) NOT NULL,
	[Data] [date] NOT NULL,
	[Price] [int] NOT NULL,
	[Total_Sum] [int] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[id_receipt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Receipt] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Treatment]    Script Date: 03/01/22 22:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatment](
	[id_treatment] [int] IDENTITY(1,1) NOT NULL,
	[Name_bioadditive] [nchar](30) NOT NULL,
	[Name_illness] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Treatment] PRIMARY KEY CLUSTERED 
(
	[id_treatment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[Treatment] TO  SCHEMA OWNER 
GO
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Chlordiazepoxide              ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Ethinamate                    ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Galazepam                     ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Ketazolam                     ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Mesocarb                      ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Methaqualone                  ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Nitrazepam                    ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Oxazolam                      ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Phencyclidine                 ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Phendimetrazine               ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Promedol                      ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Sodium oxybutyrate            ')
INSERT [dbo].[Active_substance] ([Name_active_substance]) VALUES (N'Zolpidem                      ')
GO
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'FaibeRich                     ', N'100 g                                             ', 777, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Zadrupivka          ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'FaibeRich           ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Fine-100                      ', N'77 g                                              ', 1001, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Gdeto               ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Fine-100            ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Gamsa                         ', N'50 g                                              ', 238, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Nigeria             ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Gamsa               ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Jiaogulan                     ', N'60 capsules                                       ', 347, N'1 vegetarian capsule or as directed by a qualified healthcare professional', N'Germany             ', N'Store in a cool dry place, out of reach of children. If pregnant, nursing, or using any prescription medication consult a healthcare professional before using this product', N'Capsules            ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Juve Normavite                ', N'30 g                                              ', 84, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Uganda              ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Juve Normavite      ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Laviocard                     ', N'10 g                                              ', 1234, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Ukraine             ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Laviocard           ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Lavital-03                    ', N'23 g                                              ', 2223, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Germany             ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Lavital-03          ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Mushroom Wisdom               ', N'120 tablets                                       ', 49, N'As a dietary supplement, take 1 to 3 tablets twice daily with meals, or as directed by a healthcare practitioner', N'Egypt               ', N'Sealed for your protection. Keep out of the reach of children. If you are pregnant or breastfeeding, consult a healthcare professional before use. Do not use if seal is damaged. Store in a cool dry place', N'Pills               ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'New Chapter                   ', N'30 capsules                                       ', 731, N'One capsule per day', N'Germany             ', N'As with any dietary supplement, it is recommended that you consult a physician regarding the use of this product. Please consult your healthcare professional before using this product if you have a medical condition, are taking any medication, or are planning an operation. If you are breastfeeding, pregnant or planning to use this product, you should consult your doctor before using this product. Discontinue use and consult your doctor if you experience any side effects or an allergic reaction. Do not exceed the recommended dose. Keep out of the reach of children', N'Capsule             ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Palignin                      ', N'3 g                                               ', 999, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Italy               ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Palignin            ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Pan Cui                       ', N'7 g                                               ', 9999, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Brazil              ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Pan Cui             ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Planetary Herbals             ', N'375 mg 60 tablets                                 ', 731, N'1 tablet twice daily between meals', N'Ukraine             ', N'Store in a cool, dry place', N'Tablets             ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Psyllium Husk Powder          ', N'340 g                                             ', 211, N'Once a day, quickly stir 1 teaspoon (5 g) in 8 ounces of liquid (for children: 1/2 teaspoon in 4 ounces of liquid). Drink immediately before the liquid turns to gel', N'Japan               ', N'Take this product with a full 8 ounce glass of liquid. If you do not drink enough liquid, the product may swell in your throat, causing blockage or choking. Avoid use if you have ever had a sore throat or trouble swallowing. Get immediate medical attention if pain or swelling / difficulty breathing occurs', N'Powder              ')
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'Sage Spirit                   ', N'1 stick                                           ', 99, NULL, N'Ukraine             ', N'o not leave lighted smoking sticks unattended. Care must be taken when extinguishing glow sticks', NULL)
INSERT [dbo].[Bioadditive] ([Name_bioadditive], [Weight], [Price], [Type_of_application], [Manufacturer], [Contraindication], [Primary_packaging]) VALUES (N'UNIVIT                        ', N'10 g                                              ', 666, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'Argentina           ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'UNIVIT              ')
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([id_client], [Name], [SurName], [MidName], [Telephone], [Login], [Password], [Address], [Email]) VALUES (1025, N'Сергей              ', N'Гладкий                       ', N'Альбертович                   ', N'380666264495', N'1', N'1', N'Харьков', N'serhii.hladkyi@nure.ua        ')
INSERT [dbo].[Client] ([id_client], [Name], [SurName], [MidName], [Telephone], [Login], [Password], [Address], [Email]) VALUES (1026, N'Алексей             ', N'Косинский                     ', N'Алексеевич                    ', N'380000000000', N'2', N'2', N'Харьков', N'почта@почта.почта             ')
INSERT [dbo].[Client] ([id_client], [Name], [SurName], [MidName], [Telephone], [Login], [Password], [Address], [Email]) VALUES (1027, N'Анька               ', N'Логвиненко                    ', N'Анька                         ', N'380000000000', N'3', N'3', N'Нью-йорк (Харьков)', N'почта@почта.почта             ')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Composition] ON 

INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (2, 3, N'Mushroom Wisdom               ', N'Chlordiazepoxide              ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (6, 1, N'Sage Spirit                   ', N'Nitrazepam                    ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (7, 6, N'Sage Spirit                   ', N'Phendimetrazine               ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (8, 8, N'Psyllium Husk Powder          ', N'Ketazolam                     ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (9, 5, N'Jiaogulan                     ', N'Ketazolam                     ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (10, 2, N'New Chapter                   ', N'Zolpidem                      ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (11, 7, N'Planetary Herbals             ', N'Zolpidem                      ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (12, 3, N'Psyllium Husk Powder          ', N'Chlordiazepoxide              ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (16, 5, N'Planetary Herbals             ', N'Phendimetrazine               ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (20, 4, N'New Chapter                   ', N'Ketazolam                     ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (23, 1, N'Psyllium Husk Powder          ', N'Mesocarb                      ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (29, 4, N'New Chapter                   ', N'Chlordiazepoxide              ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1030, 1, N'Lavital-03                    ', N'Mesocarb                      ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1031, 1, N'Fine-100                      ', N'Oxazolam                      ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1032, 1, N'Psyllium Husk Powder          ', N'Galazepam                     ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1033, 3, N'Lavital-03                    ', N'Chlordiazepoxide              ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1034, 4, N'UNIVIT                        ', N'Promedol                      ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1035, 4, N'Pan Cui                       ', N'Methaqualone                  ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1036, 4, N'Sage Spirit                   ', N'Zolpidem                      ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1037, 5, N'Gamsa                         ', N'Ketazolam                     ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1038, 1, N'Palignin                      ', N'Phencyclidine                 ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1039, 1, N'Pan Cui                       ', N'Galazepam                     ')
INSERT [dbo].[Composition] ([id_composition], [Count], [Name_bioadditive], [Name_active_substance]) VALUES (1040, 3, N'FaibeRich                     ', N'Phendimetrazine               ')
SET IDENTITY_INSERT [dbo].[Composition] OFF
GO
INSERT [dbo].[Delivery] ([Name_delivery], [Type_delivery], [Time_delivery]) VALUES (N'BOLT                          ', N'Car                 ', N'3 hours             ')
INSERT [dbo].[Delivery] ([Name_delivery], [Type_delivery], [Time_delivery]) VALUES (N'Деливери                      ', N'Car                 ', N'4-5 days            ')
INSERT [dbo].[Delivery] ([Name_delivery], [Type_delivery], [Time_delivery]) VALUES (N'Новая почта                   ', N'Car                 ', N'3 days              ')
INSERT [dbo].[Delivery] ([Name_delivery], [Type_delivery], [Time_delivery]) VALUES (N'Укрпочта                      ', N'Car                 ', N'7 days              ')
GO
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Antibacterial       ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Antifungal          ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Bulbit              ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Croup               ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Dermatosis          ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Flu                 ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Hemarthrosis        ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Herpes              ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Hypovitaminosis     ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Lactostasis         ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Omphalitis          ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Selenium deficiency ')
INSERT [dbo].[Illness] ([Name_illness]) VALUES (N'Vibriosis           ')
GO
SET IDENTITY_INSERT [dbo].[Preorder] ON 

INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1034, CAST(N'2021-11-27' AS Date), N'Done                ', 1025, N'BOLT                          ', N'Харьков')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1035, CAST(N'2021-10-27' AS Date), N'Done                ', 1025, N'BOLT                          ', N'Харьков')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1036, CAST(N'2021-09-27' AS Date), N'Done                ', 1025, N'BOLT                          ', N'Харьков')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1037, CAST(N'2021-08-27' AS Date), N'Done                ', 1025, N'BOLT                          ', N'Харьков')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1038, CAST(N'2021-07-27' AS Date), N'Done                ', 1025, N'BOLT                          ', N'Харьков')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1039, CAST(N'2021-11-27' AS Date), N'Done                ', 1026, N'Деливери                      ', N'Одесса')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1040, CAST(N'2021-10-27' AS Date), N'Done                ', 1026, N'Деливери                      ', N'Одесса')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1041, CAST(N'2021-09-27' AS Date), N'Done                ', 1026, N'Деливери                      ', N'Одесса')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1042, CAST(N'2021-08-27' AS Date), N'Done                ', 1026, N'Деливери                      ', N'Одесса')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1043, CAST(N'2021-07-27' AS Date), N'Done                ', 1026, N'Деливери                      ', N'Одесса')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1044, CAST(N'2021-11-27' AS Date), N'Done                ', 1027, N'Укрпочта                      ', N'Львов')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1045, CAST(N'2021-10-27' AS Date), N'Done                ', 1027, N'Укрпочта                      ', N'Львов')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1046, CAST(N'2021-09-27' AS Date), N'Done                ', 1027, N'Укрпочта                      ', N'Львов')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1047, CAST(N'2021-08-27' AS Date), N'Done                ', 1027, N'Укрпочта                      ', N'Львов')
INSERT [dbo].[Preorder] ([id_preorder], [Data], [Status], [id_cleint], [Name_delivery], [Address]) VALUES (1048, CAST(N'2021-07-27' AS Date), N'Done                ', 1027, N'Укрпочта                      ', N'Львов')
SET IDENTITY_INSERT [dbo].[Preorder] OFF
GO
SET IDENTITY_INSERT [dbo].[Receipt] ON 

INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1016, 5, 1034, N'FaibeRich                     ', CAST(N'2021-11-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1017, 5, 1034, N'FaibeRich                     ', CAST(N'2021-11-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1018, 5, 1034, N'Fine-100                      ', CAST(N'2021-11-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1019, 5, 1034, N'Gamsa                         ', CAST(N'2021-11-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1020, 5, 1034, N'Jiaogulan                     ', CAST(N'2021-11-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1021, 4, 1034, N'Juve Normavite                ', CAST(N'2021-10-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1022, 4, 1034, N'Laviocard                     ', CAST(N'2021-10-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1023, 4, 1034, N'Lavital-03                    ', CAST(N'2021-10-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1024, 4, 1034, N'Mushroom Wisdom               ', CAST(N'2021-10-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1025, 4, 1034, N'New Chapter                   ', CAST(N'2021-10-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1026, 3, 1034, N'Palignin                      ', CAST(N'2021-09-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1027, 3, 1034, N'Pan Cui                       ', CAST(N'2021-09-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1028, 3, 1034, N'Planetary Herbals             ', CAST(N'2021-09-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1029, 3, 1034, N'Psyllium Husk Powder          ', CAST(N'2021-09-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1030, 3, 1034, N'Sage Spirit                   ', CAST(N'2021-09-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1031, 2, 1034, N'UNIVIT                        ', CAST(N'2021-08-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1032, 2, 1034, N'Fine-100                      ', CAST(N'2021-08-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1033, 2, 1034, N'Gamsa                         ', CAST(N'2021-08-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1034, 2, 1034, N'Juve Normavite                ', CAST(N'2021-08-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1035, 2, 1034, N'Laviocard                     ', CAST(N'2021-08-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1036, 2, 1034, N'Mushroom Wisdom               ', CAST(N'2021-07-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1037, 2, 1034, N'Palignin                      ', CAST(N'2021-07-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1038, 2, 1034, N'Planetary Herbals             ', CAST(N'2021-07-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1039, 2, 1034, N'UNIVIT                        ', CAST(N'2021-07-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1040, 2, 1034, N'Psyllium Husk Powder          ', CAST(N'2021-07-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1041, 5, 1035, N'FaibeRich                     ', CAST(N'2021-11-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1042, 5, 1035, N'Fine-100                      ', CAST(N'2021-11-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1043, 5, 1035, N'Gamsa                         ', CAST(N'2021-11-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1044, 5, 1035, N'Jiaogulan                     ', CAST(N'2021-11-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1045, 4, 1036, N'Juve Normavite                ', CAST(N'2021-10-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1046, 4, 1036, N'Laviocard                     ', CAST(N'2021-10-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1047, 4, 1036, N'Lavital-03                    ', CAST(N'2021-10-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1048, 4, 1036, N'Mushroom Wisdom               ', CAST(N'2021-10-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1049, 4, 1036, N'New Chapter                   ', CAST(N'2021-10-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1050, 3, 1037, N'Palignin                      ', CAST(N'2021-09-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1051, 3, 1037, N'Pan Cui                       ', CAST(N'2021-09-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1052, 3, 1037, N'Planetary Herbals             ', CAST(N'2021-09-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1053, 3, 1037, N'Psyllium Husk Powder          ', CAST(N'2021-09-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1054, 3, 1037, N'Sage Spirit                   ', CAST(N'2021-09-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1055, 2, 1038, N'UNIVIT                        ', CAST(N'2021-08-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1056, 2, 1038, N'Fine-100                      ', CAST(N'2021-08-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1057, 2, 1038, N'Gamsa                         ', CAST(N'2021-08-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1058, 2, 1038, N'Juve Normavite                ', CAST(N'2021-08-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1059, 2, 1038, N'Laviocard                     ', CAST(N'2021-08-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1060, 2, 1039, N'Mushroom Wisdom               ', CAST(N'2021-07-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1061, 2, 1039, N'Palignin                      ', CAST(N'2021-07-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1062, 2, 1039, N'Planetary Herbals             ', CAST(N'2021-07-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1063, 2, 1039, N'UNIVIT                        ', CAST(N'2021-07-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1064, 2, 1039, N'Psyllium Husk Powder          ', CAST(N'2021-07-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1065, 5, 1040, N'FaibeRich                     ', CAST(N'2021-11-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1066, 5, 1040, N'Fine-100                      ', CAST(N'2021-11-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1067, 5, 1040, N'Gamsa                         ', CAST(N'2021-11-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1068, 5, 1040, N'Jiaogulan                     ', CAST(N'2021-11-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1069, 4, 1041, N'Juve Normavite                ', CAST(N'2021-10-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1070, 4, 1041, N'Laviocard                     ', CAST(N'2021-10-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1071, 4, 1041, N'Lavital-03                    ', CAST(N'2021-10-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1072, 4, 1041, N'Mushroom Wisdom               ', CAST(N'2021-10-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1073, 4, 1041, N'New Chapter                   ', CAST(N'2021-10-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1074, 3, 1042, N'Palignin                      ', CAST(N'2021-09-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1075, 3, 1042, N'Pan Cui                       ', CAST(N'2021-09-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1076, 3, 1042, N'Planetary Herbals             ', CAST(N'2021-09-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1077, 3, 1042, N'Psyllium Husk Powder          ', CAST(N'2021-09-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1078, 3, 1042, N'Sage Spirit                   ', CAST(N'2021-09-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1079, 2, 1043, N'UNIVIT                        ', CAST(N'2021-08-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1080, 2, 1043, N'Fine-100                      ', CAST(N'2021-08-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1081, 2, 1043, N'Gamsa                         ', CAST(N'2021-08-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1082, 2, 1043, N'Juve Normavite                ', CAST(N'2021-08-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1083, 2, 1043, N'Laviocard                     ', CAST(N'2021-08-27' AS Date), 10, 50)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1084, 2, 1044, N'Mushroom Wisdom               ', CAST(N'2021-07-27' AS Date), 400, 2000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1085, 2, 1044, N'Palignin                      ', CAST(N'2021-07-27' AS Date), 200, 1000)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1086, 2, 1044, N'Planetary Herbals             ', CAST(N'2021-07-27' AS Date), 100, 500)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1087, 2, 1044, N'UNIVIT                        ', CAST(N'2021-07-27' AS Date), 50, 250)
INSERT [dbo].[Receipt] ([id_receipt], [Count], [id_preorder], [Name_bioadditive], [Data], [Price], [Total_Sum]) VALUES (1088, 2, 1044, N'Psyllium Husk Powder          ', CAST(N'2021-07-27' AS Date), 10, 50)
SET IDENTITY_INSERT [dbo].[Receipt] OFF
GO
SET IDENTITY_INSERT [dbo].[Treatment] ON 

INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (5, N'Sage Spirit                   ', N'Dermatosis          ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (6, N'Sage Spirit                   ', N'Vibriosis           ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (7, N'Jiaogulan                     ', N'Antibacterial       ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (8, N'Jiaogulan                     ', N'Flu                 ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (9, N'Mushroom Wisdom               ', N'Flu                 ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (10, N'Mushroom Wisdom               ', N'Herpes              ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (11, N'Mushroom Wisdom               ', N'Antifungal          ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (12, N'New Chapter                   ', N'Lactostasis         ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (13, N'New Chapter                   ', N'Vibriosis           ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (14, N'Planetary Herbals             ', N'Dermatosis          ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (15, N'Planetary Herbals             ', N'Antibacterial       ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (16, N'Planetary Herbals             ', N'Flu                 ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (17, N'Planetary Herbals             ', N'Hypovitaminosis     ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (18, N'Psyllium Husk Powder          ', N'Dermatosis          ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (25, N'Sage Spirit                   ', N'Hypovitaminosis     ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (30, N'Sage Spirit                   ', N'Herpes              ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2028, N'Jiaogulan                     ', N'Bulbit              ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2029, N'New Chapter                   ', N'Bulbit              ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2030, N'Palignin                      ', N'Herpes              ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2031, N'UNIVIT                        ', N'Croup               ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2032, N'Planetary Herbals             ', N'Croup               ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2033, N'Fine-100                      ', N'Croup               ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2034, N'FaibeRich                     ', N'Lactostasis         ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2035, N'Palignin                      ', N'Lactostasis         ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2036, N'Juve Normavite                ', N'Hemarthrosis        ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2037, N'Gamsa                         ', N'Hemarthrosis        ')
INSERT [dbo].[Treatment] ([id_treatment], [Name_bioadditive], [Name_illness]) VALUES (2038, N'Gamsa                         ', N'Antifungal          ')
SET IDENTITY_INSERT [dbo].[Treatment] OFF
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD  CONSTRAINT [FK_Composition_Active_substance1] FOREIGN KEY([Name_active_substance])
REFERENCES [dbo].[Active_substance] ([Name_active_substance])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Composition] CHECK CONSTRAINT [FK_Composition_Active_substance1]
GO
ALTER TABLE [dbo].[Composition]  WITH CHECK ADD  CONSTRAINT [FK_Composition_Bioadditive1] FOREIGN KEY([Name_bioadditive])
REFERENCES [dbo].[Bioadditive] ([Name_bioadditive])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Composition] CHECK CONSTRAINT [FK_Composition_Bioadditive1]
GO
ALTER TABLE [dbo].[Preorder]  WITH CHECK ADD  CONSTRAINT [FK_Preorder_Client] FOREIGN KEY([id_cleint])
REFERENCES [dbo].[Client] ([id_client])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Preorder] CHECK CONSTRAINT [FK_Preorder_Client]
GO
ALTER TABLE [dbo].[Preorder]  WITH CHECK ADD  CONSTRAINT [FK_Preorder_Delivery] FOREIGN KEY([Name_delivery])
REFERENCES [dbo].[Delivery] ([Name_delivery])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preorder] CHECK CONSTRAINT [FK_Preorder_Delivery]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Bioadditive] FOREIGN KEY([Name_bioadditive])
REFERENCES [dbo].[Bioadditive] ([Name_bioadditive])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Bioadditive]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Preorder1] FOREIGN KEY([id_preorder])
REFERENCES [dbo].[Preorder] ([id_preorder])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Preorder1]
GO
ALTER TABLE [dbo].[Treatment]  WITH CHECK ADD  CONSTRAINT [FK_Treatment_Bioadditive1] FOREIGN KEY([Name_bioadditive])
REFERENCES [dbo].[Bioadditive] ([Name_bioadditive])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_Bioadditive1]
GO
ALTER TABLE [dbo].[Treatment]  WITH CHECK ADD  CONSTRAINT [FK_Treatment_Illness1] FOREIGN KEY([Name_illness])
REFERENCES [dbo].[Illness] ([Name_illness])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_Illness1]
GO
USE [master]
GO
ALTER DATABASE [CourseWork] SET  READ_WRITE 
GO
