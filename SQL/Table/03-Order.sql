SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Order]') AND TYPE IN (N'U')) 
BEGIN

    CREATE TABLE [dbo].[Order](
        [Id] [int] IDENTITY (1,1) PRIMARY KEY NOT NULL,
		[ClientId] [int] NOT NULL,
		[OrderData] [DATETIME] NULL,
		[Value] [DECIMAL] NULL
	CONSTRAINT [FK_OBDER_CLIENT] FOREIGN KEY ([ClientId])
		REFERENCES [dbo].[CLIENT] ([Id])
		 ) ON [PRIMARY]
	
END
GO
