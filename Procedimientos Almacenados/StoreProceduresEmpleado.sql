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
CREATE PROCEDURE agregarEmpleado
@nombre varchar(255),
@direccion varchar(255),
@telefono varchar(20),
@usuario varchar(100),
@contrasenia varchar(100),
@sexo char(2),
@fecha_nacimiento date,
@cargo varchar(30)
AS
BEGIN
INSERT INTO empleado(nombre, direccion, telefono, usuario, contrasenia, sexo, fecha_nacimiento, cargo) VALUES 
(@nombre, @direccion, @telefono, @usuario, @contrasenia, @sexo, @fecha_nacimiento, @cargo)
END
GO

CREATE PROCEDURE actualizarEmpleado
@id int,
@nombre varchar(255),
@direccion varchar(255),
@telefono varchar(20),
@usuario varchar(100),
@contrasenia varchar(100),
@sexo char(2),
@fecha date,
@cargo varchar(30)
AS
BEGIN
UPDATE empleado SET nombre=@nombre, direccion=@direccion, telefono=@telefono, usuario=@usuario,
contrasenia=@contrasenia, sexo=@sexo, fecha_nacimiento=@fecha, cargo=@cargo
WHERE idempleado=@id
END
GO

CREATE PROCEDURE eliminarEmpleado
@id int
AS
BEGIN
DELETE FROM empleado WHERE idempleado= @id
END
GO