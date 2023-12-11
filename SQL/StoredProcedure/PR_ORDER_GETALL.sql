SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_ORDER_GETALL]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PR_ORDER_GETALL] AS' 
END
GO

-- =======================================================================================================================================
/*

    Nome:       PR_ORDER_GETALL
    Autor:      Caio Salvador
 
     Descrição:        
		Buscar todos os pedido
*/
-- =======================================================================================================================================
ALTER PROCEDURE [dbo].[PR_ORDER_GETALL]
    
AS
BEGIN
		SELECT
		O.Id,
		O.ClientId,
		C.Name AS ClientName,
		I.ProductId,
		P.ProductName AS ProductName,
		O.Value AS ValueOrder
		from [Order] O
		Inner join OrderItem I ON O.Id = I.OrderId
		inner join CLIENT C ON O.ClientId = C.Id
		inner join Product P on I.ProductId = P.Id
END
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'PROCEDURE',N'PR_ORDER_GETALL', NULL,NULL))
BEGIN
	EXEC sys.sp_dropextendedproperty
	@name=N'MS_Description', 
	@level0type=N'SCHEMA', @level0name=N'dbo', 
	@level1type=N'PROCEDURE',@level1name=N'PR_ORDER_GETALL'
END
GO

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_ORDER_GETALL') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para buscar todos os pedidos.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para buscar todos os pedidos.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_ORDER_GETALL'
END
GO
