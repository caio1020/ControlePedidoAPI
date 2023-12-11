SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Product]') AND TYPE IN (N'U')) 
BEGIN

    CREATE TABLE [dbo].Product(
        [Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
        [ProductName] [varchar](100) NOT NULL,
        [ProductValue] [DECIMAL] NOT NULL ,
		[Amount] [int] NOT NULL
		 )
	
END
GO