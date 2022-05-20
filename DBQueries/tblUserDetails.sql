drop table [tblUserdetails]

/****** Object:  Table [dbo].[tblUserDetails]    Script Date: 17-05-2022 21:53:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create TABLE [dbo].[tblUserdetails](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](1000) NULL,
	[EmailId] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[RoleId] [int] NULL,
	[IsActive] [int] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedOn] [date] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [date] NOT NULL,
 CONSTRAINT [PK_tblUserDetails] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUserdetails] ADD  CONSTRAINT [DF_UserDetails_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tblUserdetails] ADD  CONSTRAINT [DF_UserDetails_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO

