SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_ORDER_GET_BY_ID]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PR_ORDER_GET_BY_ID] AS' 
END
GO

-- =======================================================================================================================================
/*

    Nome:       PR_ORDER_GET_BY_ID
    Autor:      Caio Salvador

     Descrição:        
		Busca o pedido pelo id
*/
-- =======================================================================================================================================
ALTER PROCEDURE [dbo].[PR_ORDER_GET_BY_ID]
    @Id int
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
		WHERE
		O.Id = @Id
END
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'PROCEDURE',N'PR_ORDER_GET_BY_ID', NULL,NULL))
BEGIN
	EXEC sys.sp_dropextendedproperty
	@name=N'MS_Description', 
	@level0type=N'SCHEMA', @level0name=N'dbo', 
	@level1type=N'PROCEDURE',@level1name=N'PR_ORDER_GET_BY_ID'
END
GO

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_ORDER_GET_BY_ID') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para buscar o pedido pelo id.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para buscar o pedido pelo id.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_ORDER_GET_BY_ID'
END
GO
