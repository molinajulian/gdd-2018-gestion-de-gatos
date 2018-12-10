
Create PROCEDURE [dbo].[sp.crear_ubicacion] (@fila CHAR(1),@asiento Numeric(11), @SinNumerar Binary(1),@Precio Float(11),@EspecCodigo Numeric(11),@UbicacionTipo Numeric(11),@username VARCHAR(128))

as 
begin
		declare @tienePermisos char(3)
		begin transaction
		begin try
		set @tienePermisos  = dbo.tienePermisos(@username,'CREAR UBICACION')
		if @tienePermisos = 'SI'
			begin
			INSERT into  GESTION_DE_GATOS.Ubicaciones VALUES (@fila, @asiento,@SinNumerar,@Precio,@EspecCodigo,@UbicacionTipo,null)
			end
		else
		throw 11,'El usuario no tiene permisos para esta acción',1
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al crear la ubicacion, motivo: %s',11,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
end

;
USE [GD2C2018]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
Go

Create PROCEDURE [dbo].[sp.crear_publicacion] (@descripcion VARCHAR(128),@fechaPublicacion DateTime, @gradoId Numeric(11),@espectaculoId Numeric(11),@fechaEspec DateTime,@Estado Numeric(11),@username VARCHAR(128))

as 
begin
		declare @tienePermisos char(3)
		begin transaction
		begin try
		set @tienePermisos  = dbo.tienePermisos(@username,'CREAR PUBLICACION')
		if @tienePermisos = 'SI'
			begin
			INSERT into  GESTION_DE_GATOS.Publicaciones VALUES (@descripcion ,@fechaPublicacion , @gradoId ,@espectaculoId ,@fechaEspec ,@Estado ,@username )
			end
		else
		throw 11,'El usuario no tiene permisos para esta acción',1
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al crear la publicacion, motivo: %s',11,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
end;
USE [GD2C2018]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
Go

Create PROCEDURE [dbo].[sp.crear_espectaculo] (@descripcion varchar(128),@fecha DATETIME,@hora TIME,@fechaVencimiento DATETIME,
												@rubroId NUMERIC(11),@empresaId varchar(128),@domicilioId numeric(11))

as 
begin
		
		begin transaction
		begin try
		
			begin
			INSERT into  GESTION_DE_GATOS.Espectaculos VALUES (@descripcion ,@fecha , @hora ,@fechaVencimiento ,@rubroId ,@empresaId ,@domicilioId,null )
			end
		
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al crear el espectaculo, motivo: %s',11,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
end;
	
go
	Create PROCEDURE [dbo].[sp.crear_grado] (@comision float(11),@descripcion varchar(128))

as 
begin
		
		begin transaction
		begin try
		
			begin
			INSERT into  GESTION_DE_GATOS.Grados VALUES (@comision,@descripcion)
			end
		
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al crear el grado, motivo: %s',11,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
end;
	
