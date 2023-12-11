SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_PRODUCT_UPDATE]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PR_PRODUCT_UPDATE] AS' 
END
GO

-- =======================================================================================================================================
/*

    Nome:       PR_PRODUCT_UPDATE
    Autor:      Caio Salvador
 
     Descrição:        
		Insere o pedido
*/
-- =======================================================================================================================================
ALTER PROCEDURE [dbo].[PR_PRODUCT_UPDATE]
    @Id INT,
    @Name VARCHAR(100) = NULL,
    @Value DECIMAL = NULL,
    @Amount INT = NULL
AS
BEGIN
    -- Atualiza o produto apenas com os campos que foram fornecidos
    UPDATE Product
    SET
        ProductName = ISNULL(@Name, ProductName),
        ProductValue = ISNULL(@Value, ProductValue),
		Amount = ISNULL(@Amount, Amount)
    WHERE Id = @Id;    
END
GO

IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'PROCEDURE',N'PR_PRODUCT_UPDATE', NULL,NULL))
BEGIN
	EXEC sys.sp_dropextendedproperty
	@name=N'MS_Description', 
	@level0type=N'SCHEMA', @level0name=N'dbo', 
	@level1type=N'PROCEDURE',@level1name=N'PR_PRODUCT_UPDATE'
END
GO

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_PRODUCT_UPDATE') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para atualizar o produto.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para atualizar o produto.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_PRODUCT_UPDATE'
END
GO
