create function obtenerLetra(@posicion numeric(11))
returns char(1) 

begin 
if(@posicion=0)
return'a' 
if(@posicion=1)
return'b' 
if(@posicion=2)
return'c' 
if(@posicion=3)
return 'd'
if(@posicion=4)
return'e' 
if(@posicion=5)
return'f'
if(@posicion=6)
return'g' 
if(@posicion=7)
return'h' 
if(@posicion=8)
return'i' 
if(@posicion=9)
return'j' 
if(@posicion=10)
return'k' 
if(@posicion=11)
return'l' 
if(@posicion=12)
return'm' 
if(@posicion=13)
return'n' 
if(@posicion=14)
return'o' 
if(@posicion=15)
return'p' 
if(@posicion=16)
return'q' 
if(@posicion=17)
return'r' 
if(@posicion=18)
return's' 
if(@posicion=19)
return't' 
if(@posicion=20)
return 'u'
if(@posicion=21)
return'v' 
if(@posicion=22)
return'w' 
if(@posicion=23)
return'x' 
if(@posicion=24)
return'y' 
if(@posicion=25)
return'z' 
RAISERROR('La posicion ingresada no corresponde a una letra',11,1,@mensajeError)
return '!'
end

go
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

Create PROCEDURE [dbo].[sp.crear_publicacion] (@descripcion VARCHAR(128),@fechaPublicacion DateTime, 
												@gradoId Numeric(11),@espectaculoId Numeric(11),@Estado Numeric(11),
												@username VARCHAR(128),@filas numeric(11),@asientos numeric(11),@descripcionEspectaculo varchar(128),
												@fechaEspectaculo DATETIME,@hora TIME,@fechaVencimiento DATETIME,@rubroId NUMERIC(11),@empresaId varchar(128)
												,@domicilioId numeric(11),@salida int OUTPUT)

as 
begin
		declare @tienePermisos char(3)
		declare @espectaculoAsociado numeric(11)
		declare @cantidadFilas numeric(11)
		declare @cantidadAsientos numeric(11)
		declare @ultimaUbicacion numeric(11)
		declare @letra char(1)
		
		set @cantidadFilas=0
		set @cantidadAsientos=0
		begin transaction
		begin try
		set @tienePermisos  = dbo.tienePermisos(@username,'CREAR PUBLICACION')
		if @tienePermisos = 'SI'
			begin
			set @espectaculoAsociado= [dbo].[sp.crear_espectaculo](@descripcionEspectaculo ,@fechaEspectaculo , @hora ,@fechaVencimiento ,@rubroId ,@empresaId ,@domicilioId,null )
			INSERT into  GESTION_DE_GATOS.Publicaciones VALUES (@descripcion ,@fechaPublicacion , @gradoId ,@espectaculoAsociado ,0 ,@username )
			while @cantidadFilas< @filas 
				Begin
					while @cantidadAsientos< @asientos
						Begin
							set @letra=[dbo].obtenerLetra(@cantidadFilas)
							[dbo].[sp.crear_ubicacion](@letra,@cantidadAsientos,0,@Precio,@EspectaculoAsociado,null,null)
						set @cantidadAsientos=@cantidadAsientos+1
						End
				set @cantidadFilas=@cantidadFilas+1
				End
				set @salida= (Select TOP 1 Public_Cod from GESTION_DE_GATOS.Publicaciones order by Public_Cod DESC)
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
												@rubroId NUMERIC(11),@empresaId varchar(128),@domicilioId numeric(11),@salida int OUTPUT)

as 
begin
		
		begin transaction
		begin try
		
			begin
			INSERT into  GESTION_DE_GATOS.Espectaculos VALUES (@descripcion ,@fecha , @hora ,@fechaVencimiento ,@rubroId ,@empresaId ,@domicilioId,null )
			end
		set @salida= (SELECT TOP 1 Espec_Cod from GESTION_DE_GATOS.Espectaculos order by Espec_Cod DESC)
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
	Create PROCEDURE [dbo].[sp.update_espectaculo] (@Id numeric(11),@descripcion varchar(128),@fecha DATETIME,@hora TIME,@fechaVencimiento DATETIME,
												@rubroId NUMERIC(11),@empresaId varchar(128),@domicilioId numeric(11))

as 
begin
		
		begin transaction
		begin try
		
			begin
			Update  GESTION_DE_GATOS.Espectaculos 
			
			set Espec_Desc=@descripcion, Espec_Dom_Id=@domicilioId, Espec_Emp_Cuit=@empresaId, Espec_Rubro_Cod=@rubroId,Espec_Fecha_Venc=@fechaVencimiento
			,Espec_Fecha=@fecha
			where Espec_Cod = @Id
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

go
Create PROCEDURE [dbo].[sp.update_publicacion] (@Id numeric(11),@descripcion VARCHAR(128),@fechaPublicacion DateTime, 
												@gradoId Numeric(11),@espectaculoId Numeric(11),@Estado Numeric(11),@username VARCHAR(128),
												@descripcionEspectaculo varchar(128),
												@fechaEspectaculo DATETIME,@hora TIME,@fechaVencimiento DATETIME,@rubroId NUMERIC(11),@empresaId varchar(128)
												,@domicilioId numeric(11))

as 
begin
		declare @tienePermisos char(3)
		begin transaction
		begin try
		set @tienePermisos  = dbo.tienePermisos(@username,'MODIFICAR PUBLICACION')
		if @tienePermisos = 'SI'
			begin
			UPDATE  GESTION_DE_GATOS.Publicaciones 
			set Public_Desc=@descripcion ,Public_Fecha_Creacion= @fechaPublicacion , Public_Grado_Cod=@gradoId ,Public_Espec_Cod=@espectaculoId ,Public_Estado_Id=@Estado 
			where Public_Cod=@Id
			UPDATE GESTION_DE_GATOS.Espectaculos
			set Espec_Desc=@descripcionEspectaculo, Espec_Dom_Id=@domicilioId, Espec_Emp_Cuit=@empresaId, Espec_Rubro_Cod=@rubroId,Espec_Fecha_Venc=@fechaVencimiento
			,Espec_Fecha=@fechaEspectaculo
			where Espec_Cod = @espectaculoId
			
			end
		else
		throw 11,'El usuario no tiene permisos para esta acción',1
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al modificar la publicacion, motivo: %s',11,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;

end;

