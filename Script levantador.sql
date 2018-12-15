USE GD2C2018
GO
--Creación schema y tablas
CREATE SCHEMA [GESTION_DE_GATOS]
GO



-- clientes, empresas y domicilio
CREATE TABLE [GESTION_DE_GATOS].[Clientes]
( 
	[Cli_Tipo_Doc_Id]		int  NOT NULL,
	[Cli_Doc]				numeric(18)  NOT NULL ,
	[Cli_Apellido]			nvarchar(255)  NOT NULL ,
	[Cli_Nombre]			nvarchar(255)  NOT NULL ,
	[Cli_Cuil]				nvarchar(255)  NULL, 
	[Cli_Fecha_Nac]			datetime  NOT NULL ,
	[Cli_Fecha_Creacion]    datetime  NOT NULL,
	[Cli_Mail]				nvarchar(255)  NOT NULL ,
	[Cli_Tel]				numeric(20)   NULL,
	[Cli_Domicilio_Id]		int  NOT NULL ,
	[Cli_Puntos]			numeric(12) NULL,
	[Cli_Usuario_Id]		integer NOT NULL,
	[Cli_Habilitado]		bit NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Clientes]
	ADD CONSTRAINT [XPKClientes] PRIMARY KEY  CLUSTERED ([Cli_Tipo_Doc_Id] ASC,[Cli_Doc] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Tipos_Doc]
( 
	[Tipo_Doc_Id]					integer identity(1,1)  NOT NULL ,
	[Tipo_Doc_Descr]				varchar(30)  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Tipos_Doc]
	ADD CONSTRAINT [XPK_Tipo_Doc_Id] PRIMARY KEY  CLUSTERED ([Tipo_Doc_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Domicilios]
( 
	[Dom_Id]			 int identity(1,1),
	[Dom_Cod_Postal]     nvarchar(50)  NOT NULL ,
	[Dom_Localidad]      varchar(20)   NULL ,
	[Dom_Piso]           numeric(18)  NULL ,
	[Dom_Depto]          nvarchar(50)  NULL ,
	[Dom_Nro_Calle]      numeric(18)  NOT NULL ,
	[Dom_Calle]          nvarchar(50)  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Domicilios]
	ADD CONSTRAINT [XPKDomicilio] PRIMARY KEY  CLUSTERED ([Dom_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Empresas]
( 
	[Emp_Cuit]				nvarchar(255)  NOT NULL ,
	[Emp_Razon_Social]		nvarchar(255)  NOT NULL ,
	[Emp_Fecha_Creacion]    datetime  NOT NULL,
	[Emp_Mail]				nvarchar(50) NOT NULL,
	[Emp_Dom_Id]			integer NOT NULL,
	[Emp_Usuario_Id]		integer NOT NULL,
	[Emp_Tel]				numeric(20) NULL,
	[Emp_Habilitada]		integer DEFAULT 1
)
go

ALTER TABLE [GESTION_DE_GATOS].[Empresas]
	ADD CONSTRAINT [XPKEmpresa] PRIMARY KEY  CLUSTERED ([Emp_Cuit] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Facturas]
( 
	[Fact_Num]				numeric(18)  NOT NULL ,
	[Fact_Forma_Pago]		nvarchar(255)  NOT NULL ,
	[Fact_Total]			numeric(18,2)  NOT NULL ,
	[Fact_Fecha]			datetime  NOT NULL ,
	[Fact_Emp_Cuit]			nvarchar(255)  NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Facturas]
	ADD CONSTRAINT [XPKFacturas] PRIMARY KEY  CLUSTERED ([Fact_Num] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Item_Facturas]
( 

	[Item_Fact_Id]			integer identity(1,1)  NOT NULL ,
	[Item_Fact_Num]         numeric(18)  NOT NULL ,
	[Item_Fact_Cant]		numeric(18)  NOT NULL ,
	[Item_Fact_Monto]       numeric(18,2)  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Item_Facturas]
	ADD CONSTRAINT [XPKItem_Facturas] PRIMARY KEY  CLUSTERED ([Item_Fact_Id] ASC,[Item_Fact_Num] ASC)
go

-- usuarios,roles y funcionalidades
CREATE TABLE [GESTION_DE_GATOS].[Funcionalidades]
( 
	[Func_Id]					integer identity(1,1)  NOT NULL ,
	[Func_Descr]				varchar(30)  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Funcionalidades]
	ADD CONSTRAINT [XPKFuncionalidades] PRIMARY KEY  CLUSTERED ([Func_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Roles]
( 
	[Rol_Id]			int identity(1,1),
	[Rol_Nombre]		varchar(20) NOT NULL,
	[Rol_Estado]		bit  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Roles]
	ADD CONSTRAINT [XPKRol] PRIMARY KEY  CLUSTERED ([Rol_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Funcionalidad_Por_Rol]
( 
	[Rol_Id]		 int NOT NULL,
	[Func_Id]        int  NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Funcionalidad_Por_Rol]
	ADD CONSTRAINT [XPKFuncionalidad_Por_Rol] PRIMARY KEY  CLUSTERED ([Rol_id] ASC,[Func_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Rol_Por_Usuario]
( 
	[Rol_Id]        int  NOT NULL ,
	[Usuario_Id]	int  NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Rol_Por_Usuario]
	ADD CONSTRAINT [XPKRol_Por_Usuario] PRIMARY KEY  CLUSTERED ([Rol_Id] ASC,[Usuario_Id] ASC)
go
CREATE TABLE [GESTION_DE_GATOS].[Usuarios]
( 
	[Usuario_Id]			int identity(1,1)  NOT NULL ,
	[Usuario_Username]		varchar(20) NOT NULL ,
	[Usuario_Password]			binary(32) NOT NULL ,
	[Usuario_Estado]		bit NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Usuarios]
	ADD CONSTRAINT [XPKUsuario] PRIMARY KEY  CLUSTERED ([Usuario_Id] ASC)
go

--premios, premios adquiridos y tarjetas de credito
CREATE TABLE [GESTION_DE_GATOS].[Premios_Adquiridos]
( 
	[Premio_Id]       int  NOT NULL ,
	[Cli_Tipo_Doc]	  int NOT NULL,
	[Cli_Doc]         numeric(18)  NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Premios_Adquiridos]
	ADD CONSTRAINT [XPKPremios_Adquiridos] PRIMARY KEY  CLUSTERED ([Premio_Id] ASC,[Cli_Tipo_Doc] ASC,[Cli_Doc] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Premios]
( 
	[Premio_Id]					int identity(1,1)  NOT NULL ,
	[Premio_Desc]				varchar(50)  NOT NULL,
	[Premio_Puntos]				int NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Premios]
	ADD CONSTRAINT [XPKPremios] PRIMARY KEY  CLUSTERED ([Premio_Id] ASC)
go
CREATE TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
( 
	[Tar_Cred_Id]				int identity(1,1)  NOT NULL ,
	[Tar_Cred_Num]				numeric(16)  NOT NULL,
	[Tar_Cred_Venc]				smalldatetime NOT NULL,
	[Tar_Cred_Banco]			varchar(50) NOT NULL,
	[Tar_Cred_Cli_Tipo_Doc]		int NOT NULL,
	[Tar_Cred_Cli_Doc]			numeric(18) NOT NULL  
)
go

ALTER TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
	ADD CONSTRAINT [XPKTarjetas_Credito] PRIMARY KEY  CLUSTERED ([Tar_Cred_Id] ASC)
go
CREATE TABLE [GESTION_DE_GATOS].[Espectaculos]
( 
	[Espec_Cod]				numeric(18) identity(1,1)  NOT NULL ,
	[Espec_Desc]            nvarchar(255)  NOT NULL,
	[Espec_Fecha]			datetime NOT NULL,
	[Espec_Hora]			time NOT NULL,
	[Espec_Fecha_Venc]		datetime NOT NULL,
	[Espec_Rubro_Cod]		int NOT NULL,
	[Espec_Emp_Cuit]		nvarchar(255) NOT NULL,
	[Espec_Dom_Id]			int  NULL,
	[Espec_Estado]			bit NOT NULL
)
go


ALTER TABLE [GESTION_DE_GATOS].[Espectaculos]
	ADD CONSTRAINT [XPKEspectaculos] PRIMARY KEY  CLUSTERED ([Espec_Cod] ASC)
go
ALTER TABLE [GESTION_DE_GATOS].[Espectaculos]
	ADD CONSTRAINT DF_Espec_Estado DEFAULT 1 FOR Espec_Estado;
go


CREATE TABLE [GESTION_DE_GATOS].[Rubros]
( 
	[Rubro_Cod]			int identity(1,1)  NOT NULL ,
	[Rubro_Descr]		nvarchar(255)  NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Rubros]
	ADD CONSTRAINT [XPKRubros] PRIMARY KEY  CLUSTERED ([Rubro_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Ubicaciones]
( 
	[Ubic_Id]				int  identity(1,1) NOT NULL ,
	[Ubic_Fila]				varchar(3)  NOT NULL,
	[Ubic_Asiento]			numeric(18) NOT NULL,
	[Ubic_Sin_Numerar]		bit NOT NULL,
	[Ubic_Precio]			numeric(18) NOT NULL,
	[Ubic_Espec_Cod]		numeric(18) NOT NULL,
	[Ubic_Tipo_Cod]			int NOT NULL,
	[Ubic_Compra_Id]		int NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones]
	ADD CONSTRAINT [XPKUbicaciones] PRIMARY KEY  CLUSTERED ([Ubic_Id] ASC)
go


CREATE TABLE [GESTION_DE_GATOS].[Ubicaciones_Tipo]
( 
	[Ubic_Cod]				int  identity(1,1) NOT NULL ,
	[Ubic_Descr]			varchar(50)  NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones_Tipo]
	ADD CONSTRAINT [XPKUbicaciones_Tipo] PRIMARY KEY  CLUSTERED ([Ubic_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Compras]
( 
	[Compra_Id]					int identity(1,1)  NOT NULL ,
	[Compra_Publicacion]		int  NOT NULL,
	[Compra_Cli_Doc]			numeric(18) NOT NULL,
	[Compra_Cli_Tipo_Doc]		int NOT NULL,
	[Compra_Fecha]				smalldatetime NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Compras]
	ADD CONSTRAINT [XPKCompras] PRIMARY KEY  CLUSTERED ([Compra_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Publicaciones]
( 
	[Public_Cod]				int  identity(1,1) NOT NULL ,
	[Public_Desc]				varchar(255)   NULL,
	[Public_Fecha_Creacion]		datetime NOT NULL,
	[Public_Grado_Cod]			int NOT NULL,
	[Public_Espec_Cod]			numeric(18) NOT NULL,
	[Public_Fact_Num]			numeric(18) NULL,
	[Public_Estado_Id]			int NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Publicaciones]
	ADD CONSTRAINT [XPKPublicaciones] PRIMARY KEY  CLUSTERED ([Public_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Publicaciones_Estado]
( 
	[Public_Est_Id]				int identity(1,1)  NOT NULL,
	[Public_Est_Descr]				varchar(20) NOT NULL,
	[Public_Est_Posible_Cambio]	bit NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Publicaciones_Estado]
	ADD CONSTRAINT [XPKPublicaciones_Estado] PRIMARY KEY  CLUSTERED ([Public_Est_Id] ASC)
go


CREATE TABLE [GESTION_DE_GATOS].[Grados]
( 
	[Grado_Cod]				int identity(1,1)  NOT NULL ,
	[Grado_Comision]		float  NOT NULL,
	[Grado_Descr]			varchar(50) NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Grados]
	ADD CONSTRAINT [XPKGrados] PRIMARY KEY  CLUSTERED ([Grado_Cod] ASC)
go

----FKs

ALTER TABLE [GESTION_DE_GATOS].[Rol_Por_Usuario]
	ADD CONSTRAINT [FK_Usuario_Id] FOREIGN KEY ([Usuario_Id]) REFERENCES [GESTION_DE_GATOS].[Usuarios]([Usuario_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE [GESTION_DE_GATOS].[Rol_Por_Usuario]
	ADD CONSTRAINT [FK_Rol_Id] FOREIGN KEY ([Rol_Id]) REFERENCES [GESTION_DE_GATOS].[Roles]([Rol_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Funcionalidad_Por_Rol]
	ADD CONSTRAINT [FK_Func_Rol_Id] FOREIGN KEY ([Rol_Id]) REFERENCES [GESTION_DE_GATOS].[Roles]([Rol_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Funcionalidad_Por_Rol]
	ADD CONSTRAINT [FK_Func_Func_Id] FOREIGN KEY ([Rol_Id]) REFERENCES [GESTION_DE_GATOS].[Funcionalidades]([Func_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
ALTER TABLE [GESTION_DE_GATOS].[Empresas]
	ADD CONSTRAINT [FK_Dom_Id] FOREIGN KEY ([Emp_Dom_Id]) REFERENCES [GESTION_DE_GATOS].[Domicilios]([Dom_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Empresas]
	ADD CONSTRAINT [FK_Emp_Usuario_Id] FOREIGN KEY ([Emp_Usuario_Id]) REFERENCES [GESTION_DE_GATOS].[Usuarios]([Usuario_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Clientes]
	ADD CONSTRAINT [FK_Cli_Domicilio_Id] FOREIGN KEY ([Cli_Domicilio_Id]) REFERENCES [GESTION_DE_GATOS].[Domicilios]([Dom_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Clientes]
	ADD CONSTRAINT [FK_Cli_Usuario_Id] FOREIGN KEY ([Cli_Usuario_Id]) REFERENCES [GESTION_DE_GATOS].[Usuarios]([Usuario_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Clientes]
	ADD CONSTRAINT [FK_Cli_Tipo_Doc_Id] FOREIGN KEY ([Cli_Tipo_Doc_Id]) REFERENCES [GESTION_DE_GATOS].[Tipos_Doc]([Tipo_Doc_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Premios_Adquiridos]
	ADD CONSTRAINT [FK_Premio_Id] FOREIGN KEY ([Premio_Id]) REFERENCES [GESTION_DE_GATOS].[Premios]([Premio_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Premios_Adquiridos]
  ADD CONSTRAINT [FK_Premios_Adq_Cliente_Doc]
  FOREIGN KEY(Cli_Tipo_Doc,Cli_Doc) REFERENCES [GESTION_DE_GATOS].[Clientes](Cli_Tipo_Doc_Id,Cli_Doc)


ALTER TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
  ADD CONSTRAINT [FK_Tarjeta_Cliente]
  FOREIGN KEY(Tar_Cred_Cli_Tipo_Doc,Tar_Cred_Cli_Doc) REFERENCES [GESTION_DE_GATOS].[Clientes](Cli_Tipo_Doc_Id,Cli_Doc)

ALTER TABLE [GESTION_DE_GATOS].[Espectaculos]
	ADD CONSTRAINT [FK_Espec_Rubro_Cod] FOREIGN KEY ([Espec_Rubro_Cod]) REFERENCES [GESTION_DE_GATOS].[Rubros]([Rubro_Cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Espectaculos]
	ADD CONSTRAINT [FK_Espec_Emp_Cuit] FOREIGN KEY ([Espec_Emp_Cuit]) REFERENCES [GESTION_DE_GATOS].[Empresas]([Emp_Cuit])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Espectaculos]
	ADD CONSTRAINT [FK_Espec_Dom_Id] FOREIGN KEY ([Espec_Dom_Id]) REFERENCES [GESTION_DE_GATOS].[Domicilios]([Dom_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones]
	ADD CONSTRAINT [FK_Ubic_Espec_Cod] FOREIGN KEY ([Ubic_Espec_Cod]) REFERENCES [GESTION_DE_GATOS].[Espectaculos]([Espec_Cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones]
	ADD CONSTRAINT [FK_Ubic_Tipo_Cod] FOREIGN KEY ([Ubic_Tipo_Cod]) REFERENCES [GESTION_DE_GATOS].[Ubicaciones_Tipo]([Ubic_Cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones]
	ADD CONSTRAINT [FK_Ubic_Compra_Id] FOREIGN KEY ([Ubic_Compra_Id]) REFERENCES [GESTION_DE_GATOS].[Compras]([Compra_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Compras]
	ADD CONSTRAINT [FK_Compra_Publicacion_Id] FOREIGN KEY ([Compra_Publicacion]) REFERENCES [GESTION_DE_GATOS].[Publicaciones]([Public_Cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Compras]
  ADD CONSTRAINT [FK_Compra_Cliente]
  FOREIGN KEY(Compra_Cli_Tipo_Doc,Compra_Cli_Doc) REFERENCES [GESTION_DE_GATOS].[Clientes](Cli_Tipo_Doc_Id,Cli_Doc)


ALTER TABLE [GESTION_DE_GATOS].[Publicaciones]
	ADD CONSTRAINT [FK_Public_Grado_Cod] FOREIGN KEY ([Public_Grado_Cod]) REFERENCES [GESTION_DE_GATOS].[Grados]([Grado_Cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Publicaciones]
	ADD CONSTRAINT [FK_Public_Espec_Cod] FOREIGN KEY ([Public_Espec_Cod]) REFERENCES [GESTION_DE_GATOS].[Espectaculos]([Espec_Cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Publicaciones]
	ADD CONSTRAINT [FK_Public_Fact_Num] FOREIGN KEY ([Public_Fact_Num]) REFERENCES [GESTION_DE_GATOS].[Facturas]([Fact_Num])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Publicaciones]
	ADD CONSTRAINT [FK_Public_Estado_Id] FOREIGN KEY ([Public_Estado_Id]) REFERENCES [GESTION_DE_GATOS].[Publicaciones_Estado]([Public_Est_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Facturas]
	ADD CONSTRAINT [FK_Fact_Empresa_Cuit] FOREIGN KEY ([Fact_Emp_Cuit]) REFERENCES [GESTION_DE_GATOS].[Empresas]([Emp_Cuit])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Item_Facturas]
	ADD CONSTRAINT [FK_Item_Fact_Num] FOREIGN KEY ([Item_Fact_Num]) REFERENCES [GESTION_DE_GATOS].[Facturas]([Fact_Num])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE GESTION_DE_GATOS.Ubicaciones
 ADD CONSTRAINT DF_Ubic_Sin_Numerar DEFAULT 0 FOR Ubic_Sin_Numerar;

-- creacion de indices
CREATE INDEX In_Usuario_Username ON [GESTION_DE_GATOS].[Usuarios] (Usuario_Username)
go

CREATE UNIQUE INDEX In_Cli_Doc ON [GESTION_DE_GATOS].[Clientes] (Cli_Tipo_Doc_Id,Cli_Doc)
go

CREATE INDEX In_Cli_Nombre ON [GESTION_DE_GATOS].[Clientes] (Cli_Nombre)
go

CREATE INDEX In_Cli_Apellido ON [GESTION_DE_GATOS].[Clientes] (Cli_Apellido)
go

CREATE INDEX In_Cli_Mail ON [GESTION_DE_GATOS].[Clientes] (Cli_Mail)
go

CREATE INDEX In_Emp_Razon_Social ON [GESTION_DE_GATOS].[Empresas] (Emp_Razon_Social)
go

CREATE INDEX In_Emp_Mail ON [GESTION_DE_GATOS].[Empresas] (Emp_Mail)
go

CREATE INDEX In_Ubic_Compra ON [GESTION_DE_GATOS].[Ubicaciones] (Ubic_Compra_Id)
go

CREATE INDEX In_Public_Espectaculo ON [GESTION_DE_GATOS].[Publicaciones] (Public_Espec_Cod)
go

--funciones y store procedures
IF object_id(N'tienePermisos', N'FN') IS NOT NULL
    DROP FUNCTION tienePermisos
go
create function tienePermisos(@Usuario_Username varchar(20),@Funcionalidad_Descripcion varchar(30))
returns char(3)
as
begin
	declare @usuarioId int;
	declare @intPermisos int;
	declare @rta char(3);
	set @usuarioId = (select top 1 Usuario_Id from GESTION_DE_GATOS.Usuarios where Usuario_Username = @Usuario_Username)
	set @intPermisos = (SELECT TOP 1 u.Usuario_Id  FROM GESTION_DE_GATOS.Usuarios u
						JOIN GESTION_DE_GATOS.Rol_Por_Usuario ru ON ru.Usuario_Id = u.Usuario_Id
						JOIN GESTION_DE_GATOS.Roles r ON r.Rol_Id = ru.Rol_Id
						JOIN GESTION_DE_GATOS.Funcionalidad_Por_Rol fr ON fr.Rol_Id = r.Rol_Id
						JOIN GESTION_DE_GATOS.Funcionalidades f ON f.Func_Id = fr.Func_Id 
						WHERE u.Usuario_Id = @usuarioId AND Func_Descr =@Funcionalidad_Descripcion)
	if (@intPermisos > 0)
		set @rta = 'SI'
	else 
		set @rta = 'NO'
	return @rta
end
go

IF object_id(N'cuitANumeros', N'FN') IS NOT NULL
    DROP FUNCTION cuitANumeros
go
go
create function cuitANumeros(@cuit varchar(255))
returns varchar(20)
as
begin
	return convert(varchar(20),convert(numeric(15),SUBSTRING(@cuit,0,3)+SUBSTRING(@cuit,4,8)+SUBSTRING(@cuit,13,2)))
end



go
IF EXISTS (SELECT * FROM sys.objects WHERE [name] = N'actualizarPuntos' AND [type] = 'TR')
BEGIN
      DROP TRIGGER [GESTION_DE_GATOS].[actualizarPuntos];
END;
go
create trigger actualizarPuntos on GESTION_DE_GATOS.Compras after INSERT 
as
begin
	declare @idCompra int;
	declare @totalCompra int;
	declare @puntosAnteriores int;
	declare @clienteDoc numeric(18);
	declare @clienteTipoDoc int;
	set @idCompra = (select top 1 Compra_Id from GESTION_DE_GATOS.Compras ORDER BY Compra_Id ASC)
	set @clienteDoc = (select top 1 Compra_Cli_Doc from GESTION_DE_GATOS.Compras ORDER BY Compra_Id ASC)
	set @clienteTipoDoc = (select top 1 Compra_Cli_Tipo_Doc from GESTION_DE_GATOS.Compras ORDER BY Compra_Id ASC)
	set @totalCompra = (select SUM(Ubic_Precio) from GESTION_DE_GATOS.Ubicaciones WHERE Ubic_Compra_id = @idCompra)
	set @puntosAnteriores = (select top 1 isnull(Cli_Puntos,0) from GESTION_DE_GATOS.Clientes where Cli_Tipo_Doc_Id+Cli_Doc = @clienteTipoDoc+@clienteDoc )
	UPDATE GESTION_DE_GATOS.Clientes SET Cli_Puntos = @puntosAnteriores+(ROUND(@totalCompra*0.1,0)) WHERE Cli_Tipo_Doc_Id+Cli_Doc = @clienteTipoDoc+@clienteDoc
end

go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'eliminarEmpresa')
            AND type IN ( N'P', N'PC' ) )
drop procedure eliminarEmpresa
go
create procedure eliminarEmpresa (@usuario int,@cuit nvarchar(255))
as
begin
	begin try
	declare @tienePermisos char(3)
	set @tienePermisos = dbo.tienePermisos(@usuario,'ELIMINAR EMPRESA')
	if @tienePermisos = 'SI'
		UPDATE GESTION_DE_GATOS.Usuarios SET Usuario_Estado = 0 WHERE Usuario_Username = dbo.cuitANumeros(@cuit)
	else
		throw 50000,'El usuario no tiene permisos para esta acción',1
	end try
	begin catch
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al eliminar la empresa, motivo: %s',11,1,@mensajeError)
	end catch
end


IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'crearEmpresa')
            AND type IN ( N'P', N'PC' ) )
drop procedure crearEmpresa
go
create procedure crearEmpresa (@cuit nvarchar(255),@nombre nvarchar(255),@creacion datetime,@mail nvarchar(50),
								@codPostal nvarchar(50),@localidad varchar(20),@piso numeric(18),
								@depto nvarchar(50),@nro numeric(18),@calle nvarchar(50),@usuario int)
as
begin
	declare @nuevoUsuario int
	declare @nuevoDomicilio int
	declare @tienePermisos char(3)
	begin transaction
		begin try
		set @tienePermisos  = dbo.tienePermisos(@usuario,'CREAR EMPRESA')
		if @tienePermisos = 'SI'
			begin
			INSERT INTO GESTION_DE_GATOS.Usuarios 
			(Usuario_Username,Usuario_Password,Usuario_Estado) 
			VALUES (dbo.cuitANumeros(@cuit),
			HASHBYTES('SHA2_256','palconet2018'),
			1)
			set  @nuevoUsuario = (SELECT TOP 1 Usuario_Id FROM GESTION_DE_GATOS.Usuarios ORDER BY Usuario_Id ASC)
			INSERT INTO GESTION_DE_GATOS.Domicilios 
				(Dom_Cod_Postal,Dom_Piso,Dom_Depto,Dom_Nro_Calle,Dom_Calle) VALUES (@codPostal,@piso,@depto,@nro,@calle)
			set @nuevoDomicilio = (SELECT TOP 1 Dom_Id FROM GESTION_DE_GATOS.Domicilios ORDER BY Dom_Id ASC)
			INSERT INTO GESTION_DE_GATOS.Empresas 
			(Emp_Cuit,Emp_Razon_Social,Emp_Fecha_Creacion,Emp_Mail,Emp_Dom_Id,Emp_Usuario_Id)
			VALUES (@cuit,@nombre,@creacion,@mail,@nuevoDomicilio,@nuevoUsuario)
			end
		else
			throw 11,'El usuario no tiene permisos para esta acción',1
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


IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'sp_crear_cliente')
            AND type IN ( N'P', N'PC' ) )
drop procedure sp_crear_cliente
go
create procedure sp_crear_cliente (@tipoDoc int,@doc numeric(18),@cuil nvarchar(255),@nombre nvarchar(255),
								@apellido nvarchar(255),@fechaNac datetime,@fechaCreacion datetime,
								@mail nvarchar(255),@telefono numeric(20),@calle nvarchar(50),@nro numeric(18),
								@depto nvarchar(50),@localidad varchar(20),@piso nvarchar(18),@cp nvarchar(18),@salida int OUTPUT)
as
begin
	declare @nuevoUsuario int
	declare @nuevoDomicilio int
	begin transaction
		begin try
			begin
			INSERT INTO GESTION_DE_GATOS.Usuarios 
			(Usuario_Username,Usuario_Password,Usuario_Estado) 
			VALUES (convert(varchar,@tipoDoc)+convert(varchar,@doc),
			HASHBYTES('SHA2_256','palconet2018'),
			1)
			if @depto = ''
				set @depto=null;
			else
				set @depto=convert(numeric(18),@depto)
			if @piso =''
				set @piso= null;
			else
				set @piso = convert(numeric(18),@piso)
			set  @nuevoUsuario = (SELECT TOP 1 Usuario_Id FROM GESTION_DE_GATOS.Usuarios ORDER BY Usuario_Id DESC)
			INSERT INTO GESTION_DE_GATOS.Domicilios 
				(Dom_Cod_Postal,Dom_Piso,Dom_Depto,Dom_Nro_Calle,Dom_Calle) VALUES (@cp,@piso,@depto,@nro,@calle)
			set @nuevoDomicilio = (SELECT TOP 1 Dom_Id FROM GESTION_DE_GATOS.Domicilios ORDER BY Dom_Id DESC)
			INSERT INTO GESTION_DE_GATOS.Clientes 
			(Cli_Tipo_Doc_Id,Cli_Doc,Cli_Apellido,Cli_Nombre,Cli_Cuil,Cli_Fecha_Nac,Cli_Fecha_Creacion,Cli_Mail,Cli_Tel,Cli_Domicilio_Id,Cli_Usuario_Id,Cli_Habilitado)
			VALUES (@tipoDoc,@doc,@apellido,@nombre,@cuil,@fechaNac,@fechaCreacion,@mail,@telefono,@nuevoDomicilio,@nuevoUsuario,1)
			set @salida = (SELECT TOP 1 convert(int,convert(varchar,Cli_Tipo_Doc_Id)+convert(varchar,Cli_Doc)) FROM GESTION_DE_GATOS.Clientes ORDER BY Cli_Fecha_Creacion DESC)
			end
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al crear el cliente, motivo: %s',11,1,@mensajeError)
		end catch
	IF @@TRANCOUNT > 0  
        commit transaction;
end

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'canjearPuntos')
            AND type IN ( N'P', N'PC' ) )
drop procedure canjearPuntos
go
create procedure canjearPuntos (@clienteTipoDoc int,@ClienteDoc numeric(18),@PremioId int)
as
begin
	declare @tienePermisos char(3);
	declare @puntosCliente int;
	declare @puntosPremio int;
	declare @errorMensaje varchar;
	set @puntosCliente = (select top 1 Cli_Puntos from GESTION_DE_GATOS.Clientes where Cli_Tipo_Doc_Id+Cli_Doc = @clienteTipoDoc+@ClienteDoc)
	set @puntosPremio = (select top 1 Premio_Puntos from GESTION_DE_GATOS.Premios where Premio_Id = @PremioId)
	set @tienePermisos = dbo.tienePermisos('1'+convert(varchar,@clienteDoc),'CANJEAR PUNTOS')
	if(@tienePermisos = 'SI')
	begin
		if @puntosCliente > @puntosPremio
			begin
			begin tran 
			UPDATE GESTION_DE_GATOS.Clientes SET Cli_Puntos = @puntosCliente-@puntosPremio WHERE Cli_Tipo_Doc_Id+Cli_Doc = @clienteTipoDoc+@ClienteDoc
			INSERT INTO GESTION_DE_GATOS.Premios_Adquiridos (Cli_Tipo_Doc,Cli_Doc,Premio_Id) VALUES (@clienteTipoDoc,@ClienteDoc,@PremioId)
			if @@ERROR <> 0 
				rollback 
			commit tran 
			end
		else
			RAISERROR('El usuario no tiene puntos suficientes',11,2)
	end
	else
		RAISERROR('El usuario no tiene permisos para realizar esta acción',11,2)
end



go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'migracion')
            AND type IN ( N'P', N'PC' ) )
drop procedure migracion
go					 
create procedure migracion
as
begin
	-- Inserto roles
	INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre,Rol_Estado) VALUES ('ADMINISTRATIVO',1)
	INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre,Rol_Estado) VALUES ('EMPRESA',1)
	INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre,Rol_Estado) VALUES ('CLIENTE',1)
	-- Inserto funcionalidades
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('CREAR CLIENTE')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('EDITAR CLIENTE')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('ELIMINAR CLIENTE')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('CREAR EMPRESA')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('EDITAR EMPRESA')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('ELIMINAR EMPRESA')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('CREAR ROL')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('EDITAR ROL')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('ELIMINAR ROL')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('CREAR CATEGORIA')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('EDITAR CATEGORIA')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('ELIMINAR CATEGORIA')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('CREAR GRADO PUBLICACION')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('EDITAR GRADO PUBLICACION')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('ELIMINAR GRADO PUBLICACION')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('GENERAR PUBLICACION')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('EDITAR PUBLICACION')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('COMPRAR UBICACION')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('HISTORIAL CLIENTE')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('CANJEAR Y ADMINISTRAR PUNTOS')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('REGISTRAR USUARIO')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('PAGAR COMISIONES')
	INSERT INTO GESTION_DE_GATOS.Funcionalidades (Func_Descr) VALUES ('LISTADO ESTADISTICO')
	-- Inserto funcionalidad por rol
	   -- Administrativo
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,1)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,2)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,3)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,4)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,5)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,6)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,7)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,8)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,9)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,10)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,11)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,12)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,13)
	   -- Empresa
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,7)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,8)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,9)
	   -- Cliente
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,10)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,11)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,12)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,13)
	-- inserto domicilios de la empresa
	insert into GESTION_DE_GATOS.Domicilios 
	(Dom_Cod_Postal,Dom_Piso,Dom_Depto,Dom_Nro_Calle,Dom_Calle)
	SELECT  Espec_Empresa_Cod_Postal as Dom_Cod_Postal,
			Espec_Empresa_Piso as Dom_Piso,
			Espec_Empresa_Depto as Dom_Depto,
			Espec_Empresa_Nro_Calle as Dom_Nro_Calle,
			Espec_Empresa_Dom_Calle as Dom_Calle
			FROM [gd_esquema].[Maestra]
			GROUP BY 
			Espec_Empresa_Dom_Calle,
			Espec_Empresa_Nro_Calle,
			Espec_Empresa_Depto,
			Espec_Empresa_Piso,
			Espec_Empresa_Cod_Postal
	-- inserto usuarios de las empresas
	INSERT INTO GESTION_DE_GATOS.Usuarios (Usuario_Username,Usuario_Password,Usuario_Estado)
		SELECT convert(varchar(20),convert(numeric(15),SUBSTRING(Espec_Empresa_Cuit,0,3)+SUBSTRING(Espec_Empresa_Cuit,4,8)+SUBSTRING(Espec_Empresa_Cuit,13,2))),
		HASHBYTES('SHA2_256','palconet2018'),
		1 FROM gd_esquema.Maestra
		GROUP BY Espec_Empresa_Cuit
	-- inserto usuarios por rol empresas
	INSERT INTO GESTION_DE_GATOS.Rol_Por_Usuario (Usuario_Id,Rol_Id)
		SELECT Usuario_Id,2 FROM GESTION_DE_GATOS.Usuarios
	-- inserto empresas
	INSERT INTO GESTION_DE_GATOS.Empresas 
	(Emp_Cuit,Emp_Razon_Social,Emp_Fecha_Creacion,Emp_Mail,Emp_Dom_Id,Emp_Usuario_Id)
		SELECT Espec_Empresa_Cuit,
		Espec_Empresa_Razon_Social,
		Espec_Empresa_Fecha_Creacion,
		Espec_Empresa_Mail,
		Dom_Id,
		Usuario_Id
		FROM gd_esquema.Maestra 
		JOIN GESTION_DE_GATOS.Domicilios d ON Espec_Empresa_Dom_Calle+convert(varchar,Espec_Empresa_Nro_Calle) = d.Dom_Calle+convert(varchar,d.Dom_Nro_Calle)
		JOIN GESTION_DE_GATOS.Usuarios u ON u.Usuario_Username = convert(numeric(15),SUBSTRING(Espec_Empresa_Cuit,0,3)+SUBSTRING(Espec_Empresa_Cuit,4,8)+SUBSTRING(Espec_Empresa_Cuit,13,2))
		GROUP BY Espec_Empresa_Cuit,Espec_Empresa_Razon_Social,Espec_Empresa_Fecha_Creacion,Espec_Empresa_Mail,Dom_Id,Usuario_Id
	-- inserto rubros de los espectaculos
	INSERT INTO GESTION_DE_GATOS.Rubros (Rubro_Descr) 
		SELECT Espectaculo_Rubro_Descripcion FROM gd_esquema.Maestra
		GROUP BY Espectaculo_Rubro_Descripcion
	-- inserto domicilios de los clientes
	INSERT INTO GESTION_DE_GATOS.Domicilios 
	(Dom_Cod_Postal,Dom_Piso,Dom_Depto,Dom_Nro_Calle,Dom_Calle)
	SELECT Cli_Cod_Postal as Dom_Cod_Postal,
		Cli_Piso as Dom_Piso,
		Cli_Depto as Dom_Depto,
		Cli_Nro_Calle as Dom_Nro_Calle,
		Cli_Dom_Calle as Dom_Calle 
		FROM gd_esquema.Maestra
		GROUP BY Cli_Dni,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal
		HAVING Cli_Dom_Calle is not null
	-- inserto tipos de doc
	INSERT INTO GESTION_DE_GATOS.Tipos_Doc (Tipo_Doc_Descr) VALUES('DNI')
	INSERT INTO GESTION_DE_GATOS.Tipos_Doc (Tipo_Doc_Descr) VALUES('Libreta Cívica')
	-- inserto usuarios para clientes
	declare @dni int
	set @dni = (SELECT top 1 Tipo_Doc_Id from GESTION_DE_GATOS.Tipos_Doc Where Tipo_Doc_Descr = 'DNI')
	INSERT INTO GESTION_DE_GATOS.Usuarios (Usuario_Username,Usuario_Password,Usuario_Estado)
		SELECT 
		convert(varchar,@dni)+convert(varchar,Cli_Dni),
		HASHBYTES('SHA2_256','palconet2018'),
		1 FROM gd_esquema.Maestra
		GROUP BY Cli_Dni
		HAVING Cli_Dni is not null
	-- inserto rol por usuario clientes
	INSERT INTO GESTION_DE_GATOS.Rol_Por_Usuario (Usuario_Id,Rol_Id)
		SELECT Usuario_Id,3 FROM GESTION_DE_GATOS.Usuarios WHERE Usuario_Id > 15
	-- inserto clientes
	INSERT INTO GESTION_DE_GATOS.Clientes
	(Cli_Tipo_Doc_Id,Cli_Doc,Cli_Apellido,Cli_Nombre,Cli_Fecha_Nac,
	 Cli_Fecha_Creacion,Cli_Mail,Cli_Domicilio_Id,Cli_Usuario_Id,Cli_Habilitado)
		SELECT @dni,
			Cli_Dni,
			Cli_Apeliido,
			Cli_Nombre,
			Cli_Fecha_Nac,
			GETDATE(),
			Cli_Mail,
			u.Usuario_Id,
			d.Dom_Id,
			1
		FROM gd_esquema.Maestra
		JOIN GESTION_DE_GATOS.Usuarios u ON u.Usuario_Username = convert(varchar,@dni)+convert(varchar,Cli_Dni)
		JOIN GESTION_DE_GATOS.Domicilios d ON d.Dom_Calle+convert(varchar,d.Dom_Nro_Calle) = Cli_Dom_Calle+convert(varchar,Cli_Nro_Calle)
		GROUP BY Cli_Dni,Cli_Apeliido,Cli_Nombre,Cli_Fecha_Nac,Cli_Mail,u.Usuario_Id,d.Dom_Id
	-- inserto rubros
	INSERT INTO GESTION_DE_GATOS.Rubros (Rubro_Descr) SELECT Espectaculo_Rubro_Descripcion from gd_esquema.Maestra GROUP BY Espectaculo_Rubro_Descripcion
	-- inserto espectaculos
	SET IDENTITY_INSERT GESTION_DE_GATOS.Espectaculos ON;
	INSERT INTO GESTION_DE_GATOS.Espectaculos (Espec_Cod,Espec_Desc,Espec_Fecha,Espec_Hora,Espec_Fecha_Venc,Espec_Rubro_Cod,Espec_Emp_Cuit,Espec_Estado)
		SELECT Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Fecha,convert(char(5), Espectaculo_Fecha, 108) [time],Espectaculo_Fecha_Venc,1,Espec_Empresa_Cuit,1 FROM gd_esquema.Maestra
		GROUP BY Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc,Espec_Empresa_Cuit
	SET IDENTITY_INSERT GESTION_DE_GATOS.Espectaculos OFF;
	-- inserto ubicaciones_tipo
	SET IDENTITY_INSERT GESTION_DE_GATOS.Ubicaciones_Tipo  ON;
	INSERT INTO GESTION_DE_GATOS.Ubicaciones_Tipo (Ubic_Cod,Ubic_Descr) 
		SELECT Ubicacion_Tipo_Codigo,Ubicacion_Tipo_Descripcion FROM gd_esquema.Maestra
		GROUP BY Ubicacion_Tipo_Codigo,Ubicacion_Tipo_Descripcion
	SET IDENTITY_INSERT GESTION_DE_GATOS.Ubicaciones_Tipo  OFF;
	-- inserto grados 
	INSERT INTO GESTION_DE_GATOS.Grados (Grado_Descr,Grado_Comision) VALUES ('ALTA',0.5)
	INSERT INTO GESTION_DE_GATOS.Grados (Grado_Descr,Grado_Comision) VALUES ('MEDIA',0.3)
	INSERT INTO GESTION_DE_GATOS.Grados (Grado_Descr,Grado_Comision) VALUES ('BAJA',0.1)
	-- inserto estados de publicaciones
	INSERT INTO GESTION_DE_GATOS.Publicaciones_Estado(Public_Est_Descr,Public_Est_Posible_Cambio) VALUES ('BORRADOR',1)
	INSERT INTO GESTION_DE_GATOS.Publicaciones_Estado (Public_Est_Descr,Public_Est_Posible_Cambio) VALUES ('PUBLICADA',1)
	INSERT INTO GESTION_DE_GATOS.Publicaciones_Estado (Public_Est_Descr,Public_Est_Posible_Cambio) VALUES ('FINALIZADA',0)
	-- inserto facturas
	INSERT INTO GESTION_DE_GATOS.Facturas (Fact_Num,Fact_Forma_Pago,Fact_Total,Fact_Fecha,Fact_Emp_Cuit)
		SELECT Factura_Nro,Forma_Pago_Desc,Factura_Total,Factura_Fecha,Espec_Empresa_Cuit FROM gd_esquema.Maestra
		WHERE Factura_Nro is not null 
		GROUP BY Espectaculo_Cod,Espectaculo_Fecha,Factura_Nro,Forma_Pago_Desc,Factura_Total,Factura_Fecha,Espec_Empresa_Cuit ORDER BY Factura_Nro
	--inserto publicaciones
	-- ACLARACION: como la fecha de hoy es mayor a la fecha de vencimiento del espectaculo, todas las publciaciones estan finalizadas
	-- establezco que todas tiene un grado de publicacion bajo(10%), y que la fecha de creacion es dos dias antes de la fecha del espectaculo
	INSERT INTO GESTION_DE_GATOS.Publicaciones (Public_Fecha_Creacion,Public_Grado_Cod,Public_Espec_Cod,Public_Estado_Id,Public_Fact_Num)
		SELECT DATEADD(DAY,-2,Espectaculo_Fecha),3,Espectaculo_Cod,3,Factura_Nro FROM gd_esquema.Maestra GROUP BY Espectaculo_Cod,Espectaculo_Fecha,Factura_Nro
	-- inserto las compras
	INSERT INTO GESTION_DE_GATOS.Compras (Compra_Publicacion,Compra_Cli_Doc,Compra_Cli_Tipo_Doc,Compra_Fecha) 
		SELECT (SELECT TOP 1 Public_Cod FROM GESTION_DE_GATOS.Publicaciones  WHERE Public_Espec_Cod = Espectaculo_Cod and Public_Cod is not null)
			,Cli_Dni
			,1
			,Compra_Fecha
		FROM gd_esquema.Maestra
		WHERE Compra_Fecha is not null
		GROUP BY Cli_Dni,Compra_Fecha,Espectaculo_Cod,Ubicacion_Tipo_Codigo,Ubicacion_Fila,Ubicacion_Asiento
		ORDER BY Espectaculo_Cod,Cli_Dni
	-- inserto ubicaciones
	INSERT INTO GESTION_DE_GATOS.Ubicaciones (Ubic_Fila,Ubic_Asiento,Ubic_Sin_Numerar,Ubic_Precio,Ubic_Espec_Cod,Ubic_Tipo_Cod,Ubic_Compra_Id)
		SELECT Ubicacion_Fila,Ubicacion_Asiento,Ubicacion_Sin_numerar,Ubicacion_Precio,Espectaculo_Cod,Ubicacion_Tipo_Codigo,
		CASE WHEN Compra_Fecha is not null  THEN (SELECT TOP 1 Compra_Id FROM GESTION_DE_GATOS.Compras c WHERE c.Compra_Cli_Tipo_Doc= 1 AND c.Compra_Cli_Doc = Cli_Dni AND c.Compra_Fecha = Compra_Fecha and c.Compra_Publicacion = (SELECT TOP 1 Public_Cod FROM GESTION_DE_GATOS.Publicaciones WHERE Public_Espec_Cod = Espectaculo_Cod ) ) 
		ELSE null
		END as Compra_Id FROM gd_esquema.Maestra
		ORDER BY Compra_Id
	-- inserto items facturas
	INSERT INTO GESTION_DE_GATOS.Item_Facturas (Item_Fact_Num,Item_Fact_Monto,Item_Fact_Cant) 
		SELECT	p.Public_Fact_Num,
				(SELECT TOP 1 Item_Factura_Monto 
				FROM gd_esquema.Maestra 
				WHERE u.Ubic_Asiento = Ubicacion_Asiento and u.Ubic_Fila = Ubicacion_Fila and u.Ubic_Precio = Ubicacion_Precio and Item_Factura_Monto is not null),
				COUNT(u.Ubic_Compra_Id) 
		FROM GESTION_DE_GATOS.Compras
		JOIN GESTION_DE_GATOS.Publicaciones p ON Compra_Publicacion = p.Public_Cod
		JOIN GESTION_DE_GATOS.Ubicaciones u ON u.Ubic_Compra_Id = Compra_Id
		WHERE Public_Fact_Num is not null
		GROUP BY p.Public_Fact_Num,u.Ubic_Compra_Id,u.Ubic_Precio,u.Ubic_Asiento,u.Ubic_Fila
		ORDER BY p.Public_Fact_Num
	-- inserto premios
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('TAZA',300)
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('PLATO',400)
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('PAVA ELECTRICA',1300)
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('MESA DE LUZ',5500)
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('VIAJE A SAN PABLO',48000)
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('CARGADOR USB',2800)
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('SOMBRILLA',6800)
	INSERT INTO GESTION_DE_GATOS.Premios (Premio_Desc,Premio_Puntos) VALUES ('CARPA',17000)
	-- inserto un usuario administrador
	INSERT INTO GESTION_DE_GATOS.Usuarios (Usuario_Username,Usuario_Password,Usuario_Estado) VALUES ('admin',HASHBYTES('SHA2_256','admin'),1)
	INSERT INTO GESTION_DE_GATOS.Rol_Por_Usuario (Usuario_Id,Rol_Id)
		SELECT Usuario_Id,1 FROM GESTION_DE_GATOS.Usuarios where Usuario_Username='admin'
end
go

GO
IF (OBJECT_ID('sp_crear_tarjeta', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_tarjeta 
GO
CREATE PROCEDURE sp_crear_tarjeta(@num numeric(16),@venc datetime,@banco nvarchar(50),@tipoDoc int,@doc numeric(18))
AS BEGIN
	INSERT INTO GESTION_DE_GATOS.Tarjetas_Credito (Tar_Cred_Num,Tar_Cred_Venc,Tar_Cred_Banco,Tar_Cred_Cli_Tipo_Doc,Tar_Cred_Cli_Doc)
	VALUES (@num,@venc,@banco,@tipoDoc,@doc)
END 
go


GO
IF (OBJECT_ID('sp_get_clientes', 'P') IS NOT NULL) DROP PROCEDURE sp_get_clientes 
GO
CREATE PROCEDURE sp_get_clientes
AS BEGIN
	SELECT td.Tipo_Doc_Descr,c.Cli_Doc,isnull(c.Cli_Cuil,'') as cuil, c.Cli_Nombre,c.Cli_Apellido,c.Cli_Mail,d.Dom_Calle,d.Dom_Nro_Calle,d.Dom_Depto,d.Dom_Piso,isnull(d.Dom_Localidad,'') as localidad,d.Dom_Cod_Postal,c.Cli_Habilitado
	  FROM GESTION_DE_GATOS.Clientes c
	  JOIN GESTION_DE_GATOS.Tipos_Doc td ON td.Tipo_Doc_Id = c.Cli_Tipo_Doc_Id
	  JOIN GESTION_DE_GATOS.Domicilios d  ON d.Dom_Id = c.Cli_Domicilio_Id
END 
go

GO
IF (OBJECT_ID('sp_get_tipos_doc', 'P') IS NOT NULL) DROP PROCEDURE sp_get_tipos_doc 
GO
CREATE PROCEDURE sp_get_tipos_doc 
AS BEGIN
	SELECT * FROM GESTION_DE_GATOS.Tipos_Doc
END 
go


GO
IF (OBJECT_ID('sp_get_cliente', 'P') IS NOT NULL) DROP PROCEDURE sp_get_cliente 
GO
CREATE PROCEDURE sp_get_cliente (@doc decimal,@descripcionTipoDoc nvarchar(30))
AS BEGIN
	SELECT TOP 1 td.Tipo_Doc_Descr,c.Cli_Doc,isnull(c.Cli_Cuil,'') as cuil, c.Cli_Nombre,c.Cli_Apellido,c.Cli_Mail,c.Cli_Tel,d.Dom_Calle,d.Dom_Nro_Calle,d.Dom_Depto,d.Dom_Piso,isnull(d.Dom_Localidad,'') as localidad,d.Dom_Cod_Postal,c.Cli_Habilitado
	  FROM GESTION_DE_GATOS.Clientes c
	  JOIN GESTION_DE_GATOS.Tipos_Doc td ON td.Tipo_Doc_Id = c.Cli_Tipo_Doc_Id
	  JOIN GESTION_DE_GATOS.Domicilios d  ON d.Dom_Id = c.Cli_Domicilio_Id
	  WHERE td.Tipo_Doc_Descr = @descripcionTipoDoc AND c.Cli_Doc = @doc
END 
go

GO

IF (OBJECT_ID('sp_existe_cliente', 'P') IS NOT NULL) DROP PROCEDURE sp_existe_cliente 
GO
CREATE PROCEDURE sp_existe_cliente (@tipoDoc int,@doc decimal,@cuil nvarchar, @existencias INT OUTPUT)
AS BEGIN
	
	if(@cuil <> '') SET @existencias = (SELECT COUNT(*) FROM GESTION_DE_GATOS.Clientes WHERE Cli_Cuil = @cuil);
	else SET @existencias = (SELECT COUNT(*) FROM GESTION_DE_GATOS.Clientes WHERE Cli_Tipo_Doc_Id = @tipoDoc AND Cli_Doc = @doc);
END 
GO

GO
IF (OBJECT_ID('sp_eliminar_cliente', 'P') IS NOT NULL) DROP PROCEDURE sp_eliminar_cliente 
GO
CREATE PROCEDURE sp_eliminar_cliente (@tipoDocDescr nvarchar(30),@doc decimal)
AS BEGIN
	UPDATE GESTION_DE_GATOS.Clientes SET Cli_Habilitado = 0 WHERE convert(nvarchar,Cli_Tipo_Doc_Id)+convert(nvarchar,Cli_Doc) = 
	(SELECT convert(nvarchar,c.Cli_Tipo_Doc_Id)+convert(nvarchar,c.Cli_Doc) FROM GESTION_DE_GATOS.Clientes c JOIN GESTION_DE_GATOS.Tipos_Doc td ON td.Tipo_Doc_Id = c.Cli_Tipo_Doc_Id
	WHERE td.Tipo_Doc_Descr = @tipoDocDescr AND c.Cli_Doc = @doc)
END 
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
/*
USE [GD2C2018]
ALTER TABLE [GESTION_DE_GATOS].[Rol_Por_Usuario] DROP CONSTRAINT FK_Usuario_Id,FK_Rol_Id
ALTER TABLE [GESTION_DE_GATOS].[Funcionalidad_Por_Rol] DROP CONSTRAINT FK_Func_Rol_Id,FK_Func_Func_Id
ALTER TABLE [GESTION_DE_GATOS].[Empresas] DROP CONSTRAINT FK_Dom_Id,FK_Emp_Usuario_Id
ALTER TABLE [GESTION_DE_GATOS].[Clientes] DROP CONSTRAINT FK_Cli_Domicilio_Id,FK_Cli_Tipo_Doc_Id,FK_Cli_Usuario_Id
ALTER TABLE [GESTION_DE_GATOS].[Premios_Adquiridos] DROP CONSTRAINT FK_Premio_Id,FK_Premios_Adq_Cliente_Doc
ALTER TABLE [GESTION_DE_GATOS].[Tarjetas_Credito] DROP CONSTRAINT FK_Tarjeta_Cliente
ALTER TABLE [GESTION_DE_GATOS].[Espectaculos] DROP CONSTRAINT FK_Espec_Rubro_Cod, FK_Espec_Emp_Cuit,FK_Espec_Dom_Id
ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones] DROP CONSTRAINT FK_Ubic_Tipo_Cod,FK_Ubic_Compra_Id,FK_Ubic_Espec_Cod
ALTER TABLE [GESTION_DE_GATOS].[Compras] DROP CONSTRAINT FK_Compra_Publicacion_Id,FK_Compra_Cliente
ALTER TABLE [GESTION_DE_GATOS].[Publicaciones] DROP CONSTRAINT FK_Public_Grado_Cod,FK_Public_Espec_Cod,FK_Public_Fact_Num,FK_Public_Estado_Id
ALTER TABLE [GESTION_DE_GATOS].[Facturas] DROP CONSTRAINT FK_Fact_Empresa_Cuit
ALTER TABLE [GESTION_DE_GATOS].[Item_Facturas] DROP CONSTRAINT FK_Item_Fact_Num
DROP TABLE [GESTION_DE_GATOS].[Funcionalidad_Por_Rol]
DROP TABLE [GESTION_DE_GATOS].[Rol_Por_Usuario]
DROP TABLE [GESTION_DE_GATOS].[Premios_Adquiridos]
DROP TABLE [GESTION_DE_GATOS].[Item_Facturas]
DROP TABLE [GESTION_DE_GATOS].[Premios]
DROP TABLE [GESTION_DE_GATOS].[Funcionalidades]
DROP TABLE [GESTION_DE_GATOS].[Roles]
DROP TABLE [GESTION_DE_GATOS].[Grados]
DROP TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
DROP TABLE [GESTION_DE_GATOS].[Ubicaciones]
DROP TABLE [GESTION_DE_GATOS].[Ubicaciones_Tipo]
DROP TABLE [GESTION_DE_GATOS].[Clientes]
DROP TABLE [GESTION_DE_GATOS].[Compras]
DROP TABLE [GESTION_DE_GATOS].[Domicilios]
DROP TABLE [GESTION_DE_GATOS].[Rubros]
DROP TABLE [GESTION_DE_GATOS].[Usuarios]
DROP TABLE [GESTION_DE_GATOS].[Publicaciones]
DROP TABLE [GESTION_DE_GATOS].[Publicaciones_Estado]
DROP TABLE [GESTION_DE_GATOS].[Espectaculos]
DROP TABLE [GESTION_DE_GATOS].[Facturas]
DROP TABLE [GESTION_DE_GATOS].[Empresas]
DROP TABLE [GESTION_DE_GATOS].[Tipos_Doc]
GO
DROP SCHEMA [GESTION_DE_GATOS]
*/