--USE [NewAirlineDB]
--GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblBookingdetails]') AND type in (N'U'))
DROP TABLE [dbo].[tblBookingdetails]
GO
/****** Object:  Table [dbo].[tblBookingDetails]    Script Date: 17-05-2022 21:52:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblBookingdetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pnr] [int] NULL,
	[UserId] [int] NOT NULL,
	[FlightNo] [varchar](50) NULL,
	[NoofPassengers] [int] NULL,
	[IsOneWay] [varchar](50) NULL,
	[DepartureTime] [datetime] NULL,
	[ArrivalTime] [datetime] NULL,
	[BookedOn] [datetime] NOT NULL,
	[BookedBy] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tblBookingDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblBookingDetails] ADD  CONSTRAINT [DF_BookingDetails_CreatedDate]  DEFAULT (getdate()) FOR [BookedOn]
GO


