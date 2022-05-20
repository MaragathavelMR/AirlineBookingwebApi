--USE [NewAirlineDB]
--GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPassengerLists]') AND type in (N'U'))
DROP TABLE [dbo].[tblPassengerLists]
GO
/****** Object:  Table [dbo].[tblPassengerDetails]    Script Date: 17-05-2022 21:52:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblPassengerLists](
	[PsngrId] [int] IDENTITY(1,1) NOT NULL,
	[Pnr] [int] NULL,
	[PsngrName] [varchar](50) NULL,
	[PsngrAge] [int] NULL,
	[PsngrGender] [varchar](50) NULL,
	[PsngrSeatNo] [varchar](50) NULL,
	[IsMealOpted] [varchar](50) NOT NULL,
	[Price] [int] NULL,
	[BookedBy] [varchar](50) NULL,
	[BookedOn] [datetime] NOT NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tblPassengerDetails] PRIMARY KEY CLUSTERED 
(
	[PsngrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblPassengerLists] ADD  CONSTRAINT [DF_UserBookingDetails_IsMealOpted]  DEFAULT ('N') FOR [IsMealOpted]
GO
ALTER TABLE [dbo].[tblPassengerLists] ADD  CONSTRAINT [DF_UserBookingDetails_CreatedDate]  DEFAULT (getdate()) FOR [BookedOn]
GO

