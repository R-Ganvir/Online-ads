USE [master]
GO
/****** Object:  Database [dbemarketing]    Script Date: 14-05-2023 10.35.50 PM ******/
CREATE DATABASE [dbemarketing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbemarketing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbemarketing.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbemarketing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbemarketing_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbemarketing] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbemarketing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbemarketing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbemarketing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbemarketing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbemarketing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbemarketing] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbemarketing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbemarketing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbemarketing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbemarketing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbemarketing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbemarketing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbemarketing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbemarketing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbemarketing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbemarketing] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbemarketing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbemarketing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbemarketing] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbemarketing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbemarketing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbemarketing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbemarketing] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbemarketing] SET RECOVERY FULL 
GO
ALTER DATABASE [dbemarketing] SET  MULTI_USER 
GO
ALTER DATABASE [dbemarketing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbemarketing] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbemarketing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbemarketing] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbemarketing] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbemarketing] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbemarketing', N'ON'
GO
ALTER DATABASE [dbemarketing] SET QUERY_STORE = OFF
GO
USE [dbemarketing]
GO
/****** Object:  User [rrupesh]    Script Date: 14-05-2023 10.35.53 PM ******/
CREATE USER [rrupesh] FOR LOGIN [Rupesh] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [rrupesh]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 14-05-2023 10.35.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK_sysdiagrams] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_admin]    Script Date: 14-05-2023 10.35.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_admin](
	[ad_id] [int] IDENTITY(1,1) NOT NULL,
	[ad_username] [nvarchar](50) NOT NULL,
	[ad_password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_admin] PRIMARY KEY CLUSTERED 
(
	[ad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 14-05-2023 10.35.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_category](
	[cat_id] [int] IDENTITY(1,1) NOT NULL,
	[cat_name] [nvarchar](50) NOT NULL,
	[cat_image] [nvarchar](max) NOT NULL,
	[cat_fk_ad] [int] NULL,
	[cat_status] [int] NULL,
	[cat_subcatname] [nchar](20) NULL,
 CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_product]    Script Date: 14-05-2023 10.35.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_product](
	[pro_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_name] [nvarchar](50) NOT NULL,
	[pro_image] [nvarchar](max) NOT NULL,
	[pro_des] [nvarchar](max) NOT NULL,
	[pro_price] [int] NULL,
	[pro_fk_cat] [int] NULL,
	[pro_fk_user] [int] NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 14-05-2023 10.35.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[u_password] [nvarchar](9) NOT NULL,
	[u_name] [nvarchar](15) NOT NULL,
	[u_dateofbirth] [date] NOT NULL,
	[u_gender] [nvarchar](7) NOT NULL,
	[u_city] [nvarchar](10) NOT NULL,
	[u_state] [nvarchar](15) NOT NULL,
	[u_email] [nvarchar](30) NOT NULL,
	[u_image] [nvarchar](max) NOT NULL,
	[u_contact] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__tbl_categ__cat_f__276EDEB3]    Script Date: 14-05-2023 10.35.53 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK__tbl_categ__cat_f__276EDEB3] ON [dbo].[tbl_category]
(
	[cat_fk_ad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__tbl_produ__pro_f__2E1BDC42]    Script Date: 14-05-2023 10.35.53 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK__tbl_produ__pro_f__2E1BDC42] ON [dbo].[tbl_product]
(
	[pro_fk_cat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__tbl_produ__pro_f__2F10007B]    Script Date: 14-05-2023 10.35.53 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK__tbl_produ__pro_f__2F10007B] ON [dbo].[tbl_product]
(
	[pro_fk_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_category]  WITH CHECK ADD  CONSTRAINT [FK__tbl_categ__cat_f__276EDEB3] FOREIGN KEY([cat_fk_ad])
REFERENCES [dbo].[tbl_admin] ([ad_id])
GO
ALTER TABLE [dbo].[tbl_category] CHECK CONSTRAINT [FK__tbl_categ__cat_f__276EDEB3]
GO
ALTER TABLE [dbo].[tbl_product]  WITH CHECK ADD  CONSTRAINT [FK__tbl_produ__pro_f__2E1BDC42] FOREIGN KEY([pro_fk_cat])
REFERENCES [dbo].[tbl_category] ([cat_id])
GO
ALTER TABLE [dbo].[tbl_product] CHECK CONSTRAINT [FK__tbl_produ__pro_f__2E1BDC42]
GO
ALTER TABLE [dbo].[tbl_product]  WITH CHECK ADD  CONSTRAINT [FK__tbl_produ__pro_f__2F10007B] FOREIGN KEY([pro_fk_user])
REFERENCES [dbo].[tbl_user] ([u_id])
GO
ALTER TABLE [dbo].[tbl_product] CHECK CONSTRAINT [FK__tbl_produ__pro_f__2F10007B]
GO
USE [master]
GO
ALTER DATABASE [dbemarketing] SET  READ_WRITE 
GO
