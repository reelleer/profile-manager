USE [master]
GO
/****** Object:  Database [dbErasmus]    Script Date: 5/24/2024 10:51:57 AM ******/
CREATE DATABASE [dbProfiles] COLLATE Modern_Spanish_CI_AI
GO
USE [dbProfiles]
GO

/****** Object:  Table [dbo].[Profiles]    Script Date: 5/24/2024 10:51:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[ProfileId] [uniqueidentifier] NOT NULL
		CONSTRAINT [DF_Profiles_Id] DEFAULT newid(),
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[BirthDate] [date] NULL,
	[BirthPlace] [varchar](150) NULL,
	[Country] [varchar](150) NULL,
	[Address] [varchar](150) NULL,
	[Phone] [varchar](100) NULL,
	[Email] [sysname] NULL,
	[Twitter] [sysname] NULL,
	[Facebook] [sysname] NULL,
	[Linkedin] [sysname] NULL,
	[Instagram] [sysname] NULL,
	[Working] [tinyint] NULL,
	[FullName]  AS (([Name]+' ')+[LastName]),
	[OriEmail] [sysname] NOT NULL,
	[Updated] [datetime] NULL,
	CONSTRAINT [PK_Profiles]
		PRIMARY KEY CLUSTERED ([ProfileId]),
	CONSTRAINT [UI_Profiles]
		UNIQUE NONCLUSTERED ([Email])
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studies]    Script Date: 5/24/2024 10:51:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studies](
	[StudyId] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [uniqueidentifier] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Country] [varchar](150) NULL,
	[University] [sysname] NULL,
	[Study] [sysname] NULL,
	[Begin] [date] NULL,
	[End] [date] NULL,
	CONSTRAINT [PK_Studies]
		PRIMARY KEY CLUSTERED ([StudyId]),
	CONSTRAINT [UI_Studies]
		UNIQUE NONCLUSTERED ([ProfileId], [Study], [Begin], [End]),
	CONSTRAINT [FK_Studies_Profiles]
		FOREIGN KEY([ProfileId])
		REFERENCES [dbo].[Profiles] ([ProfileId])
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Polls]    Script Date: 5/24/2024 10:51:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polls](
	[ProfileId] [uniqueidentifier] NOT NULL,
	[Opportunities] [varchar](1000) NOT NULL,
	[Activities] [varchar](1000) NOT NULL,
	[Contacts] [tinyint] NOT NULL
		CONSTRAINT [DF_Poll_Contacts] DEFAULT 0,
	[Follower] [bit] NOT NULL
		CONSTRAINT [DF_Polls_Follower] DEFAULT 0,
	CONSTRAINT [PK_Polls]
		PRIMARY KEY CLUSTERED ([ProfileId]),
	CONSTRAINT [FK_Polls_Profiles]
		FOREIGN KEY([ProfileId])
		REFERENCES [dbo].[Profiles] ([ProfileId])
) ON [PRIMARY]
GO