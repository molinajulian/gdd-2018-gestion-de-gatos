
USE GD2C2018;
go

sp_addmessage @msgnum = 50001,  
              @severity = 10,  
              @msgtext = 'Usuario no encontrado.';
GO
IF (OBJECT_ID('sp_autenticar_usuario', 'P') IS NOT NULL) DROP PROCEDURE sp_autenticar_usuario 
GO
CREATE PROCEDURE sp_autenticar_usuario
(
    @user VARCHAR(20),
	@password VARCHAR(32),
	@salida INT OUTPUT)
AS
BEGIN
    SET @salida = (SELECT ISNULL((SELECT COUNT(1)
		FROM [GD2C2018].[GESTION_DE_GATOS].Usuarios
		WHERE [Usuario_Username] = @user AND [Usuario_Password] = HASHBYTES('SHA2_256', @password)
		GROUP BY [Usuario_Estado]), 0));
	IF @salida = 0
	BEGIN
		RAISERROR (50001, 10, 1)
		RETURN;
	END
END
go

IF (OBJECT_ID('sp_buscar_usuario', 'P') IS NOT NULL) DROP PROCEDURE sp_buscar_usuario 
go
CREATE PROCEDURE sp_buscar_usuario @username varchar(20)
AS BEGIN
		SELECT u.Usuario_Id, u.Usuario_Username, u.Usuario_Estado
		FROM GESTION_DE_GATOS.Usuarios u
				JOIN  GESTION_DE_GATOS.Rol_Por_Usuario
					ON GESTION_DE_GATOS.Rol_Por_Usuario.Usuario_Id = u.Usuario_Id
                JOIN GESTION_DE_GATOS.Roles
					ON GESTION_DE_GATOS.Roles.Rol_Id = GESTION_DE_GATOS.Rol_Por_Usuario.Rol_Id
		WHERE u.Usuario_Username = @username
END
go

IF (OBJECT_ID('sp_roles_usuario', 'P') IS NOT NULL) DROP PROCEDURE sp_roles_usuario
go
CREATE PROCEDURE sp_roles_usuario @user_id varchar(20)
AS BEGIN
		SELECT GESTION_DE_GATOS.Roles.Rol_Id, GESTION_DE_GATOS.Roles.Rol_Nombre
			FROM GESTION_DE_GATOS.Rol_Por_Usuario 
			JOIN GESTION_DE_GATOS.Roles 
				ON GESTION_DE_GATOS.Roles.Rol_Id = GESTION_DE_GATOS.Rol_Por_Usuario.Rol_Id
			WHERE Rol_Estado = 1 AND GESTION_DE_GATOS.Rol_Por_Usuario.Usuario_Id = @user_id
			GROUP BY GESTION_DE_GATOS.Roles.Rol_Id, GESTION_DE_GATOS.Roles.Rol_Nombre;
END
go

IF (OBJECT_ID('sp_funcionalidades_por_rol', 'P') IS NOT NULL) DROP PROCEDURE sp_funcionalidades_por_rol
go
CREATE PROCEDURE sp_funcionalidades_por_rol @rol_id INT
AS BEGIN
	SELECT [GESTION_DE_GATOS].Funcionalidades.Func_Id, [GESTION_DE_GATOS].Funcionalidades.Func_Descr
	  FROM [GESTION_DE_GATOS].[Funcionalidad_Por_Rol]
	  JOIN [GESTION_DE_GATOS].Funcionalidades 
		ON [GESTION_DE_GATOS].Funcionalidad_Por_Rol.Func_Id = [GESTION_DE_GATOS].Funcionalidades.Func_Id
	  WHERE Rol_id = @rol_id;
END 
go


sp_addmessage @msgnum = 50004,  
              @severity = 10,  
              @msgtext = 'Domicilio ya existente.';
GO
IF (OBJECT_ID('sp_agregar_domicilio', 'P') IS NOT NULL) DROP PROCEDURE sp_agregar_domicilio 
GO
CREATE PROCEDURE sp_agregar_domicilio (@calle nvarchar(50),@nro numeric(18), @depto nvarchar(50),
									   @localidad varchar(20),@piso numeric(18),@cp nvarchar(50),
									   @dom_id INT OUTPUT)
AS BEGIN
	DECLARE @salida INT = 0;
    SET @salida = (SELECT ISNULL((SELECT COUNT(1)
		FROM [GD2C2018].[GESTION_DE_GATOS].Domicilios
		WHERE Dom_Cod_Postal = @cp AND Dom_Localidad = @localidad AND Dom_Piso = @piso 
				AND Dom_Depto = @depto AND Dom_Nro_Calle = @nro AND Dom_Calle = @calle), 0));
	IF @salida = 0
	BEGIN 
		INSERT INTO GESTION_DE_GATOS.Domicilios 
		(Dom_Localidad, Dom_Cod_Postal,Dom_Piso,Dom_Depto,Dom_Nro_Calle,Dom_Calle) VALUES (@localidad, @cp,@piso,@depto,@nro,@calle);
		SET @dom_id = (SELECT TOP 1 Dom_Id FROM GESTION_DE_GATOS.Domicilios ORDER BY Dom_Id DESC);
	END
	ELSE
	BEGIN
		RAISERROR (50004, 10, 1)
		RETURN;
	END	
END
GO

IF (OBJECT_ID('sp_get_domicilios', 'P') IS NOT NULL) DROP PROCEDURE sp_get_domicilios
GO
CREATE PROCEDURE sp_get_domicilios (@calle nvarchar(50), @nro numeric(18))
AS BEGIN
	SELECT * FROM GESTION_DE_GATOS.Domicilios
		WHERE Dom_Calle = @calle AND Dom_Nro_Calle = @nro;
END 
go

IF (OBJECT_ID('sp_eliminar_domicilio', 'P') IS NOT NULL) DROP PROCEDURE sp_eliminar_domicilio 
GO
CREATE PROCEDURE sp_eliminar_domicilio (@calle nvarchar(50),@nro numeric(18), @depto nvarchar(50),
									 @localidad varchar(20),@piso numeric(18),@cp nvarchar(50))
AS BEGIN
    DELETE FROM [GD2C2018].[GESTION_DE_GATOS].Domicilios
		WHERE Dom_Cod_Postal = @cp AND Dom_Localidad = @localidad AND Dom_Piso = @piso 
				AND Dom_Depto = @depto AND Dom_Nro_Calle = @nro AND Dom_Calle = @calle;
END
GO

IF (OBJECT_ID('sp_actualizar_domicilio', 'P') IS NOT NULL) DROP PROCEDURE sp_actualizar_domicilio 
GO
CREATE PROCEDURE sp_actualizar_domicilio (@dom_id INT, @calle nvarchar(50),@nro numeric(18), @depto nvarchar(50),
									 @localidad varchar(20),@piso numeric(18),@cp nvarchar(50))
AS BEGIN
    UPDATE [GD2C2018].[GESTION_DE_GATOS].Domicilios
		SET Dom_Cod_Postal = @cp, Dom_Localidad = @localidad, Dom_Piso = @piso,
			Dom_Depto = @depto, Dom_Nro_Calle = @nro, Dom_Calle = @calle
		WHERE Dom_Id = @dom_id;
END
GO

IF (OBJECT_ID('sp_crear_empresa', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_empresa
go
CREATE procedure dbo.sp_crear_empresa (@razon_social nvarchar(255), @cuit nvarchar(255), 
									   @mail nvarchar(50), @telefono numeric(20), @dom_id INT)
as
begin
	declare @nuevoUsuario int
	EXEC sp_validar_empresa @razon_social, @cuit;
	begin transaction
		begin try
			begin
				INSERT INTO GESTION_DE_GATOS.Usuarios 
				(Usuario_Username,Usuario_Password,Usuario_Estado) 
				VALUES (@cuit,
					HASHBYTES('SHA2_256','palconet2018'),
					1)
				SET @nuevoUsuario = (SELECT TOP 1 Usuario_Id FROM GESTION_DE_GATOS.Usuarios ORDER BY Usuario_Id DESC)
				INSERT INTO GESTION_DE_GATOS.Empresas 
				(Emp_Razon_Social, Emp_Cuit, Emp_Fecha_Creacion, Emp_Mail, Emp_Dom_Id,
					Emp_Usuario_Id, Emp_Tel)
				VALUES (@razon_social, @cuit, GETDATE(), @mail, @dom_id, @nuevoUsuario, @telefono)
			end
		end try
		begin catch
			IF @@TRANCOUNT > 0  
				rollback transaction;
			declare @mensajeError nvarchar(4000)
			SELECT @mensajeError = ERROR_MESSAGE() 
			RAISERROR('Hubo un error al crear la empresa, motivo: %s',11,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        	commit transaction;
end
GO



sp_addmessage @msgnum = 50002,  
              @severity = 10,  
              @msgtext = 'CUIT para empresa ya registrado.';
GO
sp_addmessage @msgnum = 50003,  
              @severity = 10,  
              @msgtext = 'Razon Social para empresa ya registrado.';
GO
IF (OBJECT_ID('sp_validar_empresa', 'P') IS NOT NULL) DROP PROCEDURE sp_validar_empresa 
GO
CREATE PROCEDURE sp_validar_empresa (@razon_social nvarchar(255), @cuit nvarchar(255))
AS BEGIN
	DECLARE @razon_encontrada INT = 0;
	DECLARE @cuit_encontrado INT = 0;
    SET @razon_encontrada = (SELECT ISNULL((SELECT COUNT(1)
		FROM [GD2C2018].[GESTION_DE_GATOS].Empresas
		WHERE [Emp_Razon_Social] = @razon_social), 0));
    SET @cuit_encontrado = (SELECT ISNULL((SELECT COUNT(1)
		FROM [GD2C2018].[GESTION_DE_GATOS].Empresas
		WHERE [Emp_Cuit] = @cuit), 0));
	IF @cuit_encontrado <> 0
	BEGIN
		RAISERROR (50002, 10, 1)
		RETURN;
	END
	IF @razon_encontrada <> 0
	BEGIN
		RAISERROR (50003, 10, 1)
		RETURN;
	END
END
go


IF (OBJECT_ID('sp_actualizar_empresa', 'P') IS NOT NULL) DROP PROCEDURE sp_actualizar_empresa
go
CREATE procedure dbo.sp_actualizar_empresa (@razon_social nvarchar(255), @cuit nvarchar(255),
								@mail nvarchar(50),@telefono numeric(20),
								@domicilio_id INT, @habilitada INT)
AS BEGIN
	UPDATE [GESTION_DE_GATOS].Empresas
		SET Emp_Mail = @mail, Emp_Tel = @telefono, Emp_Habilitada = @habilitada, Emp_Razon_Social = @razon_social,
			Emp_Dom_Id = @domicilio_id
		WHERE Emp_Cuit = @cuit; 
END
GO


IF (OBJECT_ID('sp_cambiar_estado_empresa', 'P') IS NOT NULL) DROP PROCEDURE sp_cambiar_estado_empresa
GO
CREATE procedure dbo.sp_cambiar_estado_empresa (@cuit nvarchar(255), @estado_final INT, @resultado INT OUTPUT)
AS BEGIN
	UPDATE GESTION_DE_GATOS.Empresas SET Emp_Habilitada = @estado_final WHERE Emp_Cuit = @cuit;
	SELECT @resultado = Emp_Habilitada FROM GESTION_DE_GATOS.Empresas WHERE Emp_Cuit = @cuit);
END
GO


ALTER TABLE GESTION_DE_GATOS.Ubicaciones
 ADD CONSTRAINT DF_Ubic_Sin_Numerar DEFAULT 0 FOR Ubic_Sin_Numerar;

IF (OBJECT_ID('sp_agregar_ubicacion', 'P') IS NOT NULL) DROP PROCEDURE sp_agregar_ubicacion
GO
CREATE procedure dbo.sp_agregar_ubicacion(@ubic_tipo INT, @ubic_precio NUMERIC(18), @ubic_espec_codigo NUMERIC(18)
										  @cnt_filas INT, @cnt_asientos INT)
AS BEGIN 
	DECLARE @indice_fila INT = 0;
	DECLARE @indice_asiento INT = 0;
	BEGIN
		WHILE @indice_fila < @cnt_filas
		BEGIN
		    WHILE @indice_asiento < @cnt_asientos
			BEGIN
				INSERT INTO Ubicacion(Ubic_Fila, Ubic_Asiento, Ubic_Precio
									  Ubic_Espec_Cod, Ubic_Tipo_Cod) 
						VALUES(@indice_fila, @indice_asiento, @ubic_precio, @ubic_espec_codigo, @ubic_tipo);
				SET @indice_asiento = @indice_asiento + 1;
			END;
		   SET @indice_fila = @indice_fila + 1;
		END;
	END
END
GO