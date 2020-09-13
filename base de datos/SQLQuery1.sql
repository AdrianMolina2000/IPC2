USE [master]
GO
/****** Object:  Database [Othello]    Script Date: 12/09/2020 18:32:23 ******/
CREATE DATABASE [Othello]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Othello', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Othello.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Othello_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Othello_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Othello] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Othello].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Othello] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Othello] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Othello] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Othello] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Othello] SET ARITHABORT OFF 
GO
ALTER DATABASE [Othello] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Othello] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Othello] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Othello] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Othello] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Othello] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Othello] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Othello] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Othello] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Othello] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Othello] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Othello] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Othello] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Othello] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Othello] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Othello] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Othello] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Othello] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Othello] SET  MULTI_USER 
GO
ALTER DATABASE [Othello] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Othello] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Othello] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Othello] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Othello] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Othello]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 12/09/2020 18:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[id_estado] [int] NOT NULL,
	[estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Partida]    Script Date: 12/09/2020 18:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partida](
	[id_partida] [int] NOT NULL,
	[id_tipo_partida] [int] NOT NULL,
	[id_estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Partida_Jugador]    Script Date: 12/09/2020 18:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partida_Jugador](
	[id_partida_jugador] [int] NOT NULL,
	[id_partida] [int] NOT NULL,
	[nickname] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_partida_jugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipo_Partida]    Script Date: 12/09/2020 18:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipo_Partida](
	[id_partida] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipo_Partida] PRIMARY KEY CLUSTERED 
(
	[id_partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 12/09/2020 18:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[nickname] [varchar](50) NOT NULL,
	[primer_nombre] [varchar](50) NOT NULL,
	[segundo_nombre] [varchar](50) NULL,
	[primer_apellido] [varchar](50) NOT NULL,
	[segundo_apellido] [varchar](50) NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[pais] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Estado] ([id_estado], [estado]) VALUES (1, N'Victoria')
GO
INSERT [dbo].[Estado] ([id_estado], [estado]) VALUES (2, N'Derrota')
GO
INSERT [dbo].[Tipo_Partida] ([id_partida], [nombre]) VALUES (1, N'Solitario')
GO
INSERT [dbo].[Tipo_Partida] ([id_partida], [nombre]) VALUES (2, N'Multijugador')
GO
INSERT [dbo].[Tipo_Partida] ([id_partida], [nombre]) VALUES (3, N'Torneo')
GO
INSERT [dbo].[usuarios] ([nickname], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [fecha_nacimiento], [pais], [contraseña], [email]) VALUES (N'Persona1', N'nombre1', N'nombre2', N'Apellido1', N'Apellido2', CAST(N'2000-12-20' AS Date), N'Guatemala', N'1234', N'persona1@gmail.com')
GO
ALTER TABLE [dbo].[Partida]  WITH CHECK ADD  CONSTRAINT [fk_estado] FOREIGN KEY([id_tipo_partida])
REFERENCES [dbo].[Estado] ([id_estado])
GO
ALTER TABLE [dbo].[Partida] CHECK CONSTRAINT [fk_estado]
GO
ALTER TABLE [dbo].[Partida]  WITH CHECK ADD  CONSTRAINT [fk_tipo_partida] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Tipo_Partida] ([id_partida])
GO
ALTER TABLE [dbo].[Partida] CHECK CONSTRAINT [fk_tipo_partida]
GO
ALTER TABLE [dbo].[Partida_Jugador]  WITH CHECK ADD  CONSTRAINT [fk_id_partida] FOREIGN KEY([id_partida])
REFERENCES [dbo].[Partida] ([id_partida])
GO
ALTER TABLE [dbo].[Partida_Jugador] CHECK CONSTRAINT [fk_id_partida]
GO
ALTER TABLE [dbo].[Partida_Jugador]  WITH CHECK ADD  CONSTRAINT [fk_nickname] FOREIGN KEY([nickname])
REFERENCES [dbo].[usuarios] ([nickname])
GO
ALTER TABLE [dbo].[Partida_Jugador] CHECK CONSTRAINT [fk_nickname]
GO
USE [master]
GO
ALTER DATABASE [Othello] SET  READ_WRITE 
GO
