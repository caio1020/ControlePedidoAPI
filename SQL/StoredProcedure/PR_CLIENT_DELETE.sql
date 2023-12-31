USE [DB_Dkp_ControlePedido]
GO
/****** Object:  StoredProcedure [dbo].[PR_CLIENT_DELETE]    Script Date: 10/12/2023 23:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =======================================================================================================================================
/*

    Nome:       PR_CLIENT_DELETE
    Autor:      Caio Salvador
 
     Descrição:        
		Deleta o cliente
*/
-- =======================================================================================================================================

ALTER PROCEDURE [dbo].[PR_CLIENT_DELETE]
	@Id int
AS
	BEGIN

	DELETE FROM [Order] where ClientId = @Id

	DELETE FROM Client WHERE Id = @Id

END
