SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_ORDER_INSERT]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PR_ORDER_INSERT] AS' 
END
GO

-- =======================================================================================================================================
/*

    Nome:       PR_ORDER_INSERT
    Autor:      Caio Salvador
 
     Descrição:        
		Insere o pedido
*/
-- =======================================================================================================================================
ALTER PROCEDURE [dbo].[PR_ORDER_INSERT]
    @ClientId INT,
    @Value DECIMAL,
    @ProductId INT
AS
BEGIN
    DECLARE @NovoPedidoId INT;

    -- Inserir o pedido
    INSERT INTO [Order] (ClientId, OrderData, Value)
    VALUES (@ClientId, GETDATE(), @Value);

    -- Obter o ID do novo pedido
    SET @NovoPedidoId = SCOPE_IDENTITY();

    -- Inserir os produtos associados ao pedido na tabela de junção
    INSERT INTO OrderItem (OrderId, ProductId)
    SELECT @NovoPedidoId, @ProductId
END
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'PROCEDURE',N'PR_ORDER_INSERT', NULL,NULL))
BEGIN
	EXEC sys.sp_dropextendedproperty
	@name=N'MS_Description', 
	@level0type=N'SCHEMA', @level0name=N'dbo', 
	@level1type=N'PROCEDURE',@level1name=N'PR_ORDER_INSERT'
END
GO

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_ORDER_INSERT') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para inserir o pedido.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para inserir o pedido.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_ORDER_INSERT'
END
GO
