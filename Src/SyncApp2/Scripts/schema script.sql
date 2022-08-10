/****** Object:  Table [dbo].[Author]    Script Date: 2020-02-29 12:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Athur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Better]    Script Date: 2020-02-29 12:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Better](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[Story] [nvarchar](100) NOT NULL,
	[Other] [int] NULL,
	[Kul] [nvarchar](5) NOT NULL,
	[IdG] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[AuthorScore] [int] NOT NULL,
 CONSTRAINT [PK_Better] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Good]    Script Date: 2020-02-29 12:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Good](
	[Id] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[Extra] [nvarchar](50) NOT NULL,
	[Klar] [nvarchar](50) NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_Good] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MySource]    Script Date: 2020-02-29 12:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MySource](
	[Id1] [int] NOT NULL,
	[Id2] [int] NOT NULL,
	[Title] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[IdU] [int] NOT NULL,
 CONSTRAINT [PK_MySource] PRIMARY KEY CLUSTERED 
(
	[Id1] ASC,
	[Id2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MyTarget]    Script Date: 2020-02-29 12:34:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyTarget](
	[IdUU] [int] NOT NULL,
	[Title] [nvarchar](10) NOT NULL,
	[Descrip] [nvarchar](50) NOT NULL,
	[Extra] [nvarchar](100) NOT NULL,
	[Id01] [int] NOT NULL,
	[Id02] [int] NOT NULL,
	[UpsertTime] [datetime] NULL,
	[Idx] [int] NULL,
 CONSTRAINT [PK_MyTarget] PRIMARY KEY CLUSTERED 
(
	[IdUU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Good] ADD  CONSTRAINT [DF_Good_Extra]  DEFAULT ((0)) FOR [Extra]
GO
ALTER TABLE [dbo].[MyTarget]  WITH CHECK ADD  CONSTRAINT [FK_MyTarget_MySource] FOREIGN KEY([Id01], [Id02])
REFERENCES [dbo].[MySource] ([Id1], [Id2])
GO
ALTER TABLE [dbo].[MyTarget] CHECK CONSTRAINT [FK_MyTarget_MySource]
GO
ALTER TABLE [dbo].[MyTarget]  WITH CHECK ADD  CONSTRAINT [CK_MyTarget] CHECK  (([Title]<>'juje'))
GO
ALTER TABLE [dbo].[MyTarget] CHECK CONSTRAINT [CK_MyTarget]
GO
