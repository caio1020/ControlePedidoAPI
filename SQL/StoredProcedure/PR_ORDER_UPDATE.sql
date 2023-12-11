SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_ORDER_UPDATE]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PR_ORDER_UPDATE] AS' 
END
GO

-- =======================================================================================================================================
/*

    Nome:       PR_ORDER_UPDATE
    Autor:      Caio Salvador
 
     Descrição:        
		Altera o pedido
*/
-- =======================================================================================================================================
ALTER PROCEDURE [dbo].[PR_ORDER_UPDATE]
    @Id INT,
    @ClientId INT = NULL,
    @Value DECIMAL = NULL,
    @ProductId INT = NULL
AS
BEGIN
    -- Atualiza o pedido apenas com os campos que foram fornecidos
    UPDATE [Order]
    SET
        ClientId = ISNULL(@ClientId, ClientId),
        Value = ISNULL(@Value, Value)
    WHERE Id = @Id;

    -- Atualiza os produtos associados ao pedido apenas com o campo que foi fornecido
    UPDATE OrderItem
    SET
        ProductId = ISNULL(@ProductId, ProductId)
    WHERE OrderId = @Id;
END
GO

IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'PROCEDURE',N'PR_ORDER_UPDATE', NULL,NULL))
BEGIN
	EXEC sys.sp_dropextendedproperty
	@name=N'MS_Description', 
	@level0type=N'SCHEMA', @level0name=N'dbo', 
	@level1type=N'PROCEDURE',@level1name=N'PR_ORDER_UPDATE'
END
GO

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_ORDER_UPDATE') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para alterar o pedido.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para alterar o pedido.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_ORDER_UPDATE'
END
GO
