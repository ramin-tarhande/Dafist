/****** Object:  Table [dbo].[EmpAtd]    Script Date: 2020-04-19 01:06:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmpAtd](
	[AtdId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[PunchTime] [datetime] NOT NULL
) ON [PRIMARY]

GO


