/****** Script for SelectTopNRows command from SSMS  ******/

UPDATE [dbo].[CitizenHouse]
   SET [CitizenId] = Id;
SELECT TOP 1000 [Id]
      ,[Length]
      ,[Width]
      ,[Area]
      ,[Floor]
      ,[CitizenId]
  FROM [CitizenDB].[dbo].[CitizenHouse]




    
UPDATE [dbo].[CitizenLand]
   SET [CitizenId] = Id;
SELECT TOP 1000 [Id]
      ,[VDC]
      ,[WardNo]
      ,[SheetNo]
      ,[KittaNo]
      ,[ValuationArea]
      ,[CitizenId]
  FROM [CitizenDB].[dbo].[CitizenLand]