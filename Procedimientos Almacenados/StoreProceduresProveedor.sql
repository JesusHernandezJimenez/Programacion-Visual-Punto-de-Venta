-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE agregarProveedor
@nombrepro varchar(255),
@direccion text,
@rfc varchar(18),
@telefono varchar(20)
AS
BEGIN
INSERT INTO proveedor (nombrepro, direccion, rfc, telefono) VALUES (@nombrepro,@direccion,@rfc,@telefono)
END
GO

CREATE PROCEDURE actualizarProveedor
@id int,
@nombrepro varchar(255),
@direccion text,
@rfc varchar(18),
@telefono varchar(20)
AS
BEGIN
UPDATE proveedor SET nombrepro=@nombrepro, direccion=@direccion, rfc=@rfc, telefono=@telefono
WHERE idproveedor=@id
END
GO

CREATE PROCEDURE eliminarProveedor
@id int
AS
BEGIN
DELETE FROM proveedor WHERE idproveedor = @id
END
GO
