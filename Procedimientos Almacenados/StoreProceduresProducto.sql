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
CREATE PROCEDURE agregarProducto
@nombre varchar(100),
@descripcion text,
@marca varchar(45),
@precio decimal(12,2),
@costo decimal(12,2),
@minimo int,
@stock int,
@idproveedorpro int
AS
BEGIN
INSERT INTO productos (nombre, descripcion, marca, precio, costo, minimo, stok,idproveedorpro ) VALUES (@nombre,
@descripcion,
@marca,
@precio,
@costo,
@minimo, 
@stock, 
@idproveedorpro)
END		
GO
CREATE PROCEDURE actualizarProducto
@nombre varchar(100),
@descripcion text,
@marca varchar(45),
@precio decimal(12,2),
@costo decimal(12,2),
@minimo int,
@stock int,
@idproveedorpro int,
@id int
AS
BEGIN
UPDATE productos SET nombre=@nombre,
descripcion=@descripcion,
marca=@marca,
precio=@precio,
costo=@costo,
minimo=@minimo,
stok =@stock,
idproveedorpro =@idproveedorpro
WHERE idproducto = @id
END
GO

CREATE PROCEDURE eliminarProducto
@idproducto int
AS
BEGIN
DELETE FROM productos WHERE idproducto = @idproducto
END
GO