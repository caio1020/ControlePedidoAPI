SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[OrderItem]') AND TYPE IN (N'U')) 
BEGIN

    CREATE TABLE [dbo].[OrderItem](
        [Id] [int] IDENTITY (1,1) PRIMARY KEY NOT NULL,
		[OrderId] [int] NOT NULL,
		[ProductId] [INT] NULL
	CONSTRAINT [FK_ORDERITEM_ORDER] FOREIGN KEY ([OrderId])
		REFERENCES [dbo].[ORDER] ([Id]),
	CONSTRAINT [FK_ORDERITEM_PRODUCT] FOREIGN KEY ([ProductId])
		REFERENCES [dbo].[Product] ([Id])
		 )
	
END
GO
