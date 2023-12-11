SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_ORDER_DELETE]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PR_ORDER_DELETE] AS' 
END
GO

-- =======================================================================================================================================
/*

    Nome:       PR_ORDER_DELETE
    Autor:      Caio Salvador
 
     Descrição:        
		Deleta o pedido
*/
-- =======================================================================================================================================
ALTER PROCEDURE [dbo].[PR_ORDER_DELETE]
    @Id INT
    
AS
BEGIN
	DELETE FROM OrderItem
	WHERE OrderId = @Id
	
	DELETE from [ORDER]
	WHERE Id = @Id

END
GO

IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'PROCEDURE',N'PR_ORDER_DELETE', NULL,NULL))
BEGIN
	EXEC sys.sp_dropextendedproperty
	@name=N'MS_Description', 
	@level0type=N'SCHEMA', @level0name=N'dbo', 
	@level1type=N'PROCEDURE',@level1name=N'PR_ORDER_DELETE'
END
GO

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_ORDER_DELETE') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para deletar o pedido.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para deletar o pedido.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_ORDER_DELETE'
END
GO
