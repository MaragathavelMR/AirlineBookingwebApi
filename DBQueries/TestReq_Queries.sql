/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [UserId]
      ,[UserName]
      ,[Password]
      ,[EmailId]
      ,[ContactNo]
      ,[Gender]
      ,[City]
      ,[RoleId]
      ,[IsActive]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ModifiedBy]
      ,[ModifiedDate]
  FROM [AirlineDB].[dbo].[tblUserdetails]

  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [AirlineID]
      ,[AirlineName]
      ,[RegOn]
      ,[RegBy]
      ,[IsActive]
      ,[Remarks]
  FROM [AirlineDB].[dbo].[tblAirlineRegister]

  SELECT TOP (1000) [FlightId]
      ,[FlightNo]
      ,[AirlineName]
      ,[FlightName]
      ,[FromPlace]
      ,[ToPlace]
      ,[DepartureDetails]
      ,[ArrivalDetails]
      ,[AvailableSeats]
      ,[SchldDays]
      ,[InstrumentUsed]
      ,[TicketFare]
      ,[MealOption]
      ,[AddedOn]
      ,[AddedBy]
  FROM [AirlineDB].[dbo].[tblFlightdetails]

  SELECT TOP (1000) [Id]
      ,[Pnr]
      ,[UserId]
      ,[FlightNo]
      ,[NoofPassengers]
      ,[IsOneWay]
      ,[DepartureTime]
      ,[ArrivalTime]
      ,[BookedOn]
      ,[BookedBy]
      ,[Status]
  FROM [AirlineDB].[dbo].[tblBookingdetails]

  SELECT TOP (1000) [PsngrId]
      ,[Pnr]
      ,[PsngrName]
      ,[PsngrAge]
      ,[PsngrGender]
      ,[PsngrSeatNo]
      ,[IsMealOpted]
      ,[Price]
      ,[BookedBy]
      ,[BookedOn]
      ,[Status]
  FROM [AirlineDB].[dbo].[tblPassengerLists]

  