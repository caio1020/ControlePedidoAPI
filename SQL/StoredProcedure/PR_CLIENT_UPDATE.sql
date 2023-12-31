USE [DB_Dkp_ControlePedido]
GO
/****** Object:  StoredProcedure [dbo].[PR_CLIENT_UPDATE]    Script Date: 11/12/2023 00:02:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================================================================================================
/*

    Nome:       PR_CLIENT_UPDATE
    Autor:      Caio Salvador
 
     Descrição:        
		Atualiza o cliente
*/
-- =======================================================================================================================================

ALTER PROCEDURE [dbo].[PR_CLIENT_UPDATE]
	@Id int,
	@Name varchar(100),
	@Email varchar(100),
	@Contact varchar(100)
AS
	BEGIN
    -- Atualiza o pedido apenas com os campos que foram fornecidos
    UPDATE Client
    SET
        Name = ISNULL(@Name, Name),
        Email = ISNULL(@Email, Email),
		Contact = ISNULL(@Contact, Contact)
    WHERE Id = @Id;    
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

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_ORDER_UPDATE') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para alterar o cliente.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para alterar o cliente.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_ORDER_UPDATE'
END
GO
