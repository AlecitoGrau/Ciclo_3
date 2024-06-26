USE [PruebaSyspotec]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_Tareas]

	@opc CHAR(10),
	@IdTarea INT = 0,
	@Titulo VARCHAR(100) = null,
	@Descripcion VARCHAR(500) = null,
	--@FechaTarea DATETIME,
	@IdUsuario INT = null
	
AS
BEGIN
DECLARE
@mensaje NVARCHAR(max),
@estado NVARCHAR(max),
@identificador NVARCHAR(max)

	IF @opc = 'LISTAR'
	BEGIN
		SELECT IdTarea, Titulo, Descripcion, FechaTarea, IdUsuario FROM Tareas;
	END

	IF @opc = 'LISTAR_ID'
	BEGIN
		SELECT IdTarea, Titulo, Descripcion, FechaTarea, IdUsuario FROM Tareas WHERE IdTarea = @IdTarea;
	END

	IF @opc = 'CREAR'
	BEGIN
		INSERT INTO Tareas(Titulo, Descripcion, FechaTarea, IdUsuario) VALUES(@Titulo, @Descripcion, GETDATE(), @IdUsuario);
		SET @mensaje = 'Creación de tarea exitosa';
		SET @estado = 'Ok';
		SET @identificador = SCOPE_IDENTITY();
		SELECT @mensaje AS mensaje, @estado AS estado, CAST(SCOPE_IDENTITY() AS DECIMAL(10, 2)) AS identificador
	END

	IF @opc = 'ACTUALIZAR'
	BEGIN
		UPDATE Tareas SET Titulo = @Titulo, Descripcion = @Descripcion, FechaTarea = GETDATE(), IdUsuario = @IdUsuario WHERE IdTarea = @IdTarea;
		SET @mensaje = 'Tarea actualizada con exito';
		SET @estado = 'Ok';
		SET @identificador = SCOPE_IDENTITY();
		SELECT @mensaje AS mensaje, @estado AS estado, CAST(@IdTarea AS DECIMAL(10, 2)) AS identificador
	END

	IF @opc =  'ELIMINAR'
	BEGIN
		DELETE FROM Tareas WHERE IdTarea = @IdTarea;
		SET @mensaje = 'Tarea eliminada con exito';
		SET @estado = 'Ok';
		SET @identificador = SCOPE_IDENTITY()
		SELECT @mensaje AS mensaje, @estado AS estado, CAST(0 AS DECIMAL(10, 2)) AS identificador
	END

	IF @opc = 'LISTAR_USUARIO'
	BEGIN
		SELECT IdUsuario, Nombre, CorreoElectronico, FechaCreacion FROM Usuarios;
	END

END
