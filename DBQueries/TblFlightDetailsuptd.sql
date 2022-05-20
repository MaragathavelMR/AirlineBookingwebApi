USE [AirlineDB]
GO

/****** Object:  Table [dbo].[tblFlightdetails]    Script Date: 19-05-2022 10:10:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblFlightdetails]') AND type in (N'U'))
DROP TABLE [dbo].[tblFlightdetails]
GO

/****** Object:  Table [dbo].[tblFlightdetails]    Script Date: 19-05-2022 10:10:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFlightdetails](
	[FlightId] [int] IDENTITY(1,1) NOT NULL,
	[FlightNo] [varchar](50) NULL,
	[AirlineName] [varchar](50) NULL,
	[FlightName] [varchar](50) NULL,
	[FromPlace] [varchar](50) NULL,
	[ToPlace] [varchar](50) NULL,
	[DepartureDetails] [datetime] NULL,
	[ArrivalDetails] [datetime] NULL,
	[AvailableSeats] [int] NOT NULL,
	[SchldDays] [varchar](50) NULL,
	[InstrumentUsed] [varchar](50) NULL,
	[TicketFare] [int] NULL,
	[MealOption] [varchar](50) NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[AddedBy] [varchar](50) NULL,
 CONSTRAINT [PK_tblFlightdetails] PRIMARY KEY CLUSTERED 
(
	[FlightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblFlightdetails] ADD  DEFAULT ((0)) FOR [AvailableSeats]
GO
ALTER TABLE [dbo].[tblFlightdetails] ADD  DEFAULT ('N') FOR [MealOption]
GO
ALTER TABLE [dbo].[tblFlightdetails] ADD  DEFAULT (getdate()) FOR [AddedOn]
GO

