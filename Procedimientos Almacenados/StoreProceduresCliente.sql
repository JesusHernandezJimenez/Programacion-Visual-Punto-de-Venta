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
CREATE PROCEDURE agregarCliente
@nombre varchar(255),
@direccion text,
@telefono varchar(20)
AS
BEGIN
INSERT INTO cliente (nombre, direccion, telefono) VALUES (@nombre, @direccion, @telefono)
END
GO

CREATE PROCEDURE actualizarCliente
@id int,
@nombre varchar(255),
@direccion text,
@telefono varchar(20)
AS
BEGIN
UPDATE cliente SET nombre=@nombre, direccion=@direccion, telefono=@telefono WHERE idcliente=@id
END
GO

CREATE PROCEDURE eliminarCliente
@id int
AS
BEGIN
DELETE FROM cliente WHERE idcliente=@id
END
GO