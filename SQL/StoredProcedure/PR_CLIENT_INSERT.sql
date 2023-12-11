SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_CLIENT_INSERT]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PR_CLIENT_INSERT] AS' 
END
GO

-- =======================================================================================================================================
/*

    Nome:       PR_CLIENT_INSERT
    Autor:      Caio Salvador
 
     Descrição:        
		Insere o cliente
*/
-- =======================================================================================================================================

ALTER PROCEDURE [dbo].[PR_CLIENT_INSERT]
	@Name varchar(100),
	@Email varchar(100),
	@Contact varchar(100)
AS
	BEGIN

	INSERT INTO Client(Name, Email, Contact)
	VALUES(@Name, @Email, @Contact)

END
GO

IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'PROCEDURE',N'PR_CLIENT_INSERT', NULL,NULL))
BEGIN
	EXEC sys.sp_dropextendedproperty
	@name=N'MS_Description', 
	@level0type=N'SCHEMA', @level0name=N'dbo', 
	@level1type=N'PROCEDURE',@level1name=N'PR_CLIENT_INSERT'
END
GO

IF NOT EXISTS (SELECT NULL FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('PR_CLIENT_INSERT') AND [name] = N'MS_Description' AND [value] =  N'Procedimento para inserir o cliente.')
BEGIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = N'Procedimento para inserir o cliente.',
	@level0type = N'SCHEMA', @level0name = N'dbo',
	@level1type = N'PROCEDURE', @level1name=N'PR_CLIENT_INSERT'
END
GO
