USE [PruebaSyspotec]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Usuarios]    Script Date: 14/04/2024 9:53:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_Usuarios]

	@opc CHAR(10),
	@IdUsuario INT = 0,
	@Nombre VARCHAR(50) = null,
	@CorreoElectronico VARCHAR(50) = null,
	@FechaCreacion DATETIME = null

AS
BEGIN
DECLARE
@mensaje NVARCHAR(max),
@estado NVARCHAR(max),
@identificador NVARCHAR(max)

	IF @opc = 'LISTAR'
	BEGIN
		SELECT IdUsuario, Nombre, CorreoElectronico, FechaCreacion FROM Usuarios;
	END

	IF @opc = 'LISTAR_ID'
	BEGIN
		SELECT IdUsuario, Nombre, CorreoElectronico, FechaCreacion FROM Usuarios WHERE IdUsuario = @IdUsuario
	END

	IF @opc = 'CREAR'
	BEGIN
		INSERT INTO Usuarios(Nombre, CorreoElectronico, FechaCreacion) VALUES(@Nombre, @CorreoElectronico, GETDATE());
		SET @mensaje = 'Registro realizado con exito';
		SET @estado = 'Ok';
		SET @identificador = SCOPE_IDENTITY();
		SELECT @mensaje AS mensaje, @estado as estado, CAST(SCOPE_IDENTITY() AS DECIMAL(10, 2)) AS identificador
	END

	IF @opc = 'ACTUALIZAR'
	BEGIN
		UPDATE Usuarios SET Nombre = @Nombre, CorreoElectronico = @CorreoElectronico, FechaCreacion = GETDATE() WHERE IdUsuario = @IdUsuario;
		SET @mensaje = 'Actualizacion Exitosa';
		SET @estado = 'Ok';
		SET @identificador = SCOPE_IDENTITY();
		SELECT @mensaje AS mensaje, @estado AS estado, CAST(@IdUsuario AS DECIMAL(10, 2)) AS identificador
	END

	IF @opc = 'ELIMINAR'
	BEGIN
		DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario;
		SET @mensaje = 'Usuario eliminado con exito';
		SET @estado = 'Ok';
		SET @identificador = SCOPE_IDENTITY();
		SELECT @mensaje AS mensaje, @estado AS estado, CAST(0 AS DECIMAL(10, 2)) AS identificador
	END

END
