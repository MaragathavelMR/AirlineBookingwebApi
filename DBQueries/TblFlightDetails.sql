--USE [NewAirlineDB]
--GO

--/****** Object:  Table [dbo].[tblFlightDetails]    Script Date: 17-05-2022 21:13:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblFlightDetails]') AND type in (N'U'))
DROP TABLE [dbo].[tblFlightDetails]
GO

/****** Object:  Table [dbo].[tblFlightDetails]    Script Date: 17-05-2022 21:13:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFlightdetails](
	[FlightId] [int] IDENTITY(1,1) NOT NULL,
	[FlightNo] [varchar](20) NOT NULL,
	[AirlineName] [varchar](50) NULL,
	[FlightName] [varchar](50) NULL,
	[FromPlace] [varchar](50) NULL,
	[ToPlace] [varchar](50) NULL,
	[DepartureDetails] [date] NULL,
	[ArrivalDetails] [date] NULL,
	[AvailableSeats] [int] NOT NULL,
	[SchldDays] [varchar](50) NULL,
	[InstrumentUsed] [varchar](50) NULL,
	[TicketFare] [decimal](18, 5) NULL,
	[MealOption] [varchar](50) NOT NULL,
	[AddedOn] [date] NULL,
	[AddedBy] [varchar](50) NULL
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



