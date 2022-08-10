/****** Object:  Table [dbo].[Comment2]    Script Date: 2020-03-10 02:09:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comment3](
	[Id] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[MoodId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[AuthorScore] [int] NOT NULL,
 CONSTRAINT [PK_Comment3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
