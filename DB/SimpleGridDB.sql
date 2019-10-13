USE [SimpleGridDB]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 9/29/2019 6:57:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Person]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Person](
	[xID] [int] IDENTITY(1,1) NOT NULL,
	[xFirstName] [nvarchar](100) NOT NULL,
	[xLastName] [nvarchar](100) NOT NULL,
	[xFatherName] [nvarchar](100) NOT NULL,
	[xNationalID] [nvarchar](20) NOT NULL,
	[xBirthCartPlace] [nvarchar](100) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[xID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

