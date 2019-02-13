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
	[Fact_Num]				numeric(18) identity(1,1)  NOT NULL ,
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
	[Rol_Nombre]		varchar(50) NOT NULL,
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
	[Usuario_Id]					int identity(1,1)  NOT NULL ,
	[Usuario_Username]				varchar(20) NOT NULL ,
	[Usuario_Password]				binary(32) NOT NULL ,
	[Usuario_Estado]				bit NULL,
	[Usuario_Primer_Logueo]			bit not null,
	[Usuario_Intentos_Fallidos]		int not null
)
go

ALTER TABLE [GESTION_DE_GATOS].[Usuarios]
	ADD CONSTRAINT [XPKUsuario] PRIMARY KEY  CLUSTERED ([Usuario_Id] ASC)
go
ALTER TABLE [GESTION_DE_GATOS].[Usuarios]
	ADD CONSTRAINT DF_Primer_Logueo DEFAULT 1 FOR Usuario_Primer_Logueo;
go
ALTER TABLE [GESTION_DE_GATOS].[Usuarios]
	ADD CONSTRAINT DF_Intentos DEFAULT 0 FOR Usuario_Intentos_Fallidos;
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
CREATE TABLE [GESTION_DE_GATOS].[Puntos]
(
	[Puntos_Id] int identity (1,1) NOT NULL,
	[Cli_Tipo_Doc]	  int NOT NULL,
	[Cli_Doc]         numeric(18)  NOT NULL ,
	[Puntos_FechaVencimiento] datetime NOT NULL,
	[Puntos_Cantidad] int NULL,
	[Puntos_Fue_Canjeado]  bit not null
)
go
ALTER TABLE [GESTION_DE_GATOS].[Puntos]
ADD CONSTRAINT [XPKPuntos] PRIMARY KEY CLUSTERED ([Puntos_Id] ASC)
go
ALTER TABLE [GESTION_DE_GATOS].[Puntos]
  ADD CONSTRAINT [FK_Puntos_Cliente]
  FOREIGN KEY(Cli_Tipo_Doc,Cli_Doc) REFERENCES [GESTION_DE_GATOS].[Clientes](Cli_Tipo_Doc_Id,Cli_Doc)
go
ALTER TABLE [GESTION_DE_GATOS].[Premios]
	ADD CONSTRAINT [XPKPremios] PRIMARY KEY  CLUSTERED ([Premio_Id] ASC)
go
CREATE TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
( 
	[Tar_Cred_Id]				int identity(1,1)  NOT NULL ,
	[Tar_Cred_Num]				BIGINT  NOT NULL,
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
	[Ubic_Tipo_Cod]			int  identity(1,1) NOT NULL ,
	[Ubic_Tipo_Descr]			varchar(50)  NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones_Tipo]
	ADD CONSTRAINT [XPKUbicaciones_Tipo] PRIMARY KEY  CLUSTERED ([Ubic_Tipo_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Compras]
( 
	[Compra_Id]					int identity(1,1)  NOT NULL ,
	[Compra_Forma_Pago_Desc]	nvarchar(255)  NOT NULL ,
	[Compra_Publicacion]		int  NOT NULL,
	[Compra_Cli_Doc]			numeric(18) NOT NULL,
	[Compra_Cli_Tipo_Doc]		int NOT NULL,
	[Compra_Fecha]				smalldatetime NOT NULL,
	[Compra_Fue_Facturada]		Bit NULL,
	[Compra_Tarj_Cred_Id]		int,
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
	[Public_Estado_Id]			int NOT NULL,
	[Public_Editor]				int NULL,
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
	[Grado_Descr]			varchar(50) NOT NULL,
	[Grado_Habilitado]		bit NOT NULL
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
	ADD CONSTRAINT [FK_Ubic_Tipo_Cod] FOREIGN KEY ([Ubic_Tipo_Cod]) REFERENCES [GESTION_DE_GATOS].[Ubicaciones_Tipo]([Ubic_Tipo_Cod])
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
	ADD CONSTRAINT [FK_Public_Estado_Id] FOREIGN KEY ([Public_Estado_Id]) REFERENCES [GESTION_DE_GATOS].[Publicaciones_Estado]([Public_Est_Id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE GESTION_DE_GATOS.Publicaciones 
	ADD CONSTRAINT FK_Public_Editor FOREIGN KEY (Public_Editor) REFERENCES GESTION_DE_GATOS.Usuarios(Usuario_Id); 
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

ALTER TABLE GESTION_DE_GATOS.Compras
 ADD CONSTRAINT DF_Forma_Pago DEFAULT 'EFECTIVO' FOR Compra_Forma_Pago_Desc
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
	INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre,Rol_Estado) VALUES ('ADMINISTRADOR GENERAL',1)
	INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre,Rol_Estado) VALUES ('EMPRESA',1)
	INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre,Rol_Estado) VALUES ('CLIENTE',1)
	INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre, Rol_Estado) VALUES('EDITOR', 1);
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
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,14)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,15)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,16)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,17)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,18)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,19)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,20)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,21)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,22)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (1,23)
	   -- Empresa
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,7)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,8)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,9)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,16)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (2,17)
	   -- Cliente
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,10)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,11)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,12)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,13)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,18)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,19)
	INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (3,20)
	   -- Editor
    INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES (4,17)
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
	INSERT INTO GESTION_DE_GATOS.Rubros (Rubro_Descr) VALUES ('Teatro')
	INSERT INTO GESTION_DE_GATOS.Rubros (Rubro_Descr) VALUES ('Cine')
	INSERT INTO GESTION_DE_GATOS.Rubros (Rubro_Descr) VALUES ('Concierto')
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
	-- inserto espectaculos
	SET IDENTITY_INSERT GESTION_DE_GATOS.Espectaculos ON;
	INSERT INTO GESTION_DE_GATOS.Espectaculos (Espec_Cod,Espec_Desc,Espec_Fecha,Espec_Fecha_Venc,Espec_Rubro_Cod,Espec_Emp_Cuit,Espec_Estado)
		SELECT Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc,1,Espec_Empresa_Cuit,1 FROM gd_esquema.Maestra
		GROUP BY Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc,Espec_Empresa_Cuit
	SET IDENTITY_INSERT GESTION_DE_GATOS.Espectaculos OFF;
	-- inserto ubicaciones_tipo
	SET IDENTITY_INSERT GESTION_DE_GATOS.Ubicaciones_Tipo  ON;
	INSERT INTO GESTION_DE_GATOS.Ubicaciones_Tipo (Ubic_Tipo_Cod,Ubic_Tipo_Descr) 
		SELECT Ubicacion_Tipo_Codigo,Ubicacion_Tipo_Descripcion FROM gd_esquema.Maestra
		GROUP BY Ubicacion_Tipo_Codigo,Ubicacion_Tipo_Descripcion
	SET IDENTITY_INSERT GESTION_DE_GATOS.Ubicaciones_Tipo  OFF;
	-- inserto grados 
	INSERT INTO GESTION_DE_GATOS.Grados (Grado_Descr,Grado_Comision,Grado_Habilitado) VALUES ('ALTA',0.5,1)
	INSERT INTO GESTION_DE_GATOS.Grados (Grado_Descr,Grado_Comision,Grado_Habilitado) VALUES ('MEDIA',0.3,1)
	INSERT INTO GESTION_DE_GATOS.Grados (Grado_Descr,Grado_Comision,Grado_Habilitado) VALUES ('BAJA',0.1,1)
	-- inserto estados de publicaciones
	INSERT INTO GESTION_DE_GATOS.Publicaciones_Estado(Public_Est_Descr,Public_Est_Posible_Cambio) VALUES ('BORRADOR',1)
	INSERT INTO GESTION_DE_GATOS.Publicaciones_Estado (Public_Est_Descr,Public_Est_Posible_Cambio) VALUES ('PUBLICADA',1)
	INSERT INTO GESTION_DE_GATOS.Publicaciones_Estado (Public_Est_Descr,Public_Est_Posible_Cambio) VALUES ('FINALIZADA',0)
	-- inserto facturas
	SET IDENTITY_INSERT GESTION_DE_GATOS.Facturas  ON;
	INSERT INTO GESTION_DE_GATOS.Facturas (Fact_Num,Fact_Total,Fact_Fecha,Fact_Emp_Cuit)
		SELECT Factura_Nro,Factura_Total,Factura_Fecha,Espec_Empresa_Cuit FROM gd_esquema.Maestra
		WHERE Factura_Nro is not null 
		GROUP BY Espectaculo_Cod,Espectaculo_Fecha,Factura_Nro,Factura_Total,Factura_Fecha,Espec_Empresa_Cuit ORDER BY Factura_Nro
	SET IDENTITY_INSERT GESTION_DE_GATOS.Facturas  OFF;
	--inserto publicaciones
	-- ACLARACION: como la fecha de hoy es mayor a la fecha de vencimiento del espectaculo, todas las publciaciones estan finalizadas
	-- establezco que todas tiene un grado de publicacion bajo(10%), y que la fecha de creacion es dos dias antes de la fecha del espectaculo
	INSERT INTO GESTION_DE_GATOS.Publicaciones (Public_Fecha_Creacion,Public_Grado_Cod,Public_Espec_Cod,Public_Estado_Id)
		SELECT DATEADD(DAY,-2,Espectaculo_Fecha),3,Espectaculo_Cod,3 FROM gd_esquema.Maestra GROUP BY Espectaculo_Cod,Espectaculo_Fecha
	-- inserto las compras
	INSERT INTO GESTION_DE_GATOS.Compras (Compra_Publicacion,Compra_Forma_Pago_Desc,Compra_Cli_Doc,Compra_Cli_Tipo_Doc,Compra_Fecha,Compra_Fue_Facturada) 
		SELECT (SELECT TOP 1 Public_Cod FROM GESTION_DE_GATOS.Publicaciones  WHERE Public_Espec_Cod = Espectaculo_Cod and Public_Cod is not null)
			,isnull(Forma_Pago_Desc,'Tarjeta')
			,Cli_Dni
			,1
			,Compra_Fecha
			,(case when Factura_Nro is null then 0 else 1 end)
		FROM gd_esquema.Maestra
		WHERE Compra_Fecha is not null
		GROUP BY Cli_Dni,Compra_Fecha,Espectaculo_Cod,Ubicacion_Tipo_Codigo,Ubicacion_Fila,Ubicacion_Asiento, Forma_Pago_Desc,Factura_Nro
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
		SELECT Factura_Nro,SUM(Ubicacion_Precio),COUNT(*) 
		FROM gd_esquema.Maestra 
		WHERE Factura_Fecha is not null 
		GROUP BY Factura_Nro,Ubicacion_Fila,Ubicacion_Asiento,Ubicacion_Tipo_Codigo,Ubicacion_Precio
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
	INSERT INTO GESTION_DE_GATOS.Usuarios (Usuario_Username,Usuario_Password,Usuario_Estado) VALUES ('admin',HASHBYTES('SHA2_256','w23e'),1)
	INSERT INTO GESTION_DE_GATOS.Rol_Por_Usuario (Usuario_Id,Rol_Id)
		SELECT Usuario_Id,1 FROM GESTION_DE_GATOS.Usuarios where Usuario_Username='admin'
end
go





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



GO
IF (OBJECT_ID('crearEmpresa', 'P') IS NOT NULL) DROP PROCEDURE crearEmpresa
GO
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



GO
IF (OBJECT_ID('sp_crear_cliente', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_cliente
GO
create procedure sp_crear_cliente (@tipoDoc int,@doc numeric(18),@cuil nvarchar(255),@nombre nvarchar(255),
								@apellido nvarchar(255), @fechaNac datetime, @dom_id INT,
								@mail nvarchar(255), @telefono numeric(20), @cli_id int OUTPUT,
								@contraseña varchar(32),@fecha_creacion datetime)
as
begin
	declare @nuevoUsuario int
	begin transaction
		begin try
			begin
			if @contraseña = ''
				set @contraseña= convert(varchar(32),'palconet2018')
			INSERT INTO GESTION_DE_GATOS.Usuarios 
			(Usuario_Username,Usuario_Password,Usuario_Estado) 
			VALUES (convert(varchar,@tipoDoc)+convert(varchar,@doc),
			HASHBYTES('SHA2_256',@contraseña),
			1)
			set  @nuevoUsuario = (SELECT TOP 1 Usuario_Id FROM GESTION_DE_GATOS.Usuarios ORDER BY Usuario_Id DESC)
			INSERT INTO GESTION_DE_GATOS.Clientes 
			(Cli_Tipo_Doc_Id,Cli_Doc,Cli_Apellido,Cli_Nombre,Cli_Cuil,Cli_Fecha_Nac,
				Cli_Fecha_Creacion,Cli_Mail,Cli_Tel,Cli_Domicilio_Id,Cli_Usuario_Id,Cli_Habilitado)
			VALUES (@tipoDoc,@doc,@apellido,@nombre,@cuil,@fechaNac,@fecha_creacion,@mail,@telefono,@dom_id,@nuevoUsuario,1)
			set @cli_id = (SELECT TOP 1 convert(int,convert(varchar,Cli_Tipo_Doc_Id)+convert(varchar,Cli_Doc)) 
					FROM GESTION_DE_GATOS.Clientes ORDER BY Cli_Fecha_Creacion DESC)
			INSERT INTO GESTION_DE_GATOS.Rol_Por_Usuario (Rol_Id,Usuario_Id) VALUES (3,@nuevoUsuario)
			end
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		RAISERROR('Hubo un error al crear el cliente',16,0)
		end catch
	IF @@TRANCOUNT > 0  
        commit transaction;
end
go


GO
IF (OBJECT_ID('sp_crear_tarjeta', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_tarjeta 
GO
CREATE PROCEDURE sp_crear_tarjeta(@num BIGINT,@venc datetime,@banco nvarchar(50),@tipoDoc int,@doc numeric(18))
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
CREATE PROCEDURE sp_existe_cliente (@tipoDoc int,@doc decimal,@cuil nvarchar(255), @existencias INT OUTPUT)
AS BEGIN
	
	if(@cuil <> '') SET @existencias = (SELECT COUNT(*) FROM GESTION_DE_GATOS.Clientes WHERE Cli_Cuil = @cuil);
	else SET @existencias = (SELECT COUNT(*) FROM GESTION_DE_GATOS.Clientes WHERE Cli_Tipo_Doc_Id = @tipoDoc AND Cli_Doc = @doc);
END 
GO

GO
IF (OBJECT_ID('sp_cambiar_estado_cliente', 'P') IS NOT NULL) DROP PROCEDURE sp_cambiar_estado_cliente 
GO
CREATE PROCEDURE sp_cambiar_estado_cliente (@tipoDoc int,@doc decimal,@estadoFinal bit)
AS BEGIN
	UPDATE GESTION_DE_GATOS.Clientes SET Cli_Habilitado = @estadoFinal WHERE Cli_Tipo_Doc_Id = @tipoDoc AND Cli_Doc = @doc
END


GO
IF (OBJECT_ID('sp_crear_grado', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_grado 
GO
CREATE PROCEDURE sp_crear_grado(@grado float,@descripcion varchar(50))
AS BEGIN
	declare @cantidad int
	set @cantidad = (SELECT isnull(COUNT(*),0) FROM GESTION_DE_GATOS.Grados WHERE @descripcion = Grado_Descr or @grado = Grado_Comision)
	if @cantidad > 0
		raiserror('Ya existe un grado con esa descripcion y/o esa comision',16,0)
	else
		INSERT INTO GESTION_DE_GATOS.Grados (Grado_Comision,Grado_Descr) VALUES (round(@grado,2),@descripcion)
END 
go

GO
IF (OBJECT_ID('sp_historial_cliente', 'P') IS NOT NULL) DROP PROCEDURE sp_historial_cliente 
GO
CREATE PROCEDURE sp_historial_cliente(@tipoDoc int,@doc int,@flag int,@pagina int)
AS BEGIN
	if @flag = 1 
		SELECT TOP 1 COUNT(*) OVER () AS TotalRecords
		  FROM GESTION_DE_GATOS.Compras c
		  JOIN GESTION_DE_GATOS.Ubicaciones u ON u.Ubic_Compra_Id = c.Compra_Id
		  JOIN GESTION_DE_GATOS.Espectaculos e ON e.Espec_Cod = u.Ubic_Espec_Cod
		  JOIN GESTION_DE_GATOS.Rubros r ON r.Rubro_Cod = e.Espec_Rubro_Cod
		  WHERE c.Compra_Cli_Doc = @doc and c.Compra_Cli_Tipo_Doc=@tipoDoc
		  GROUP BY c.Compra_Id,c.Compra_Fecha,e.Espec_Fecha,e.Espec_Desc,r.Rubro_Descr
		  ORDER BY c.Compra_Id
	else
		SELECT  SUM (Ubic_Precio) as total,c.Compra_Fecha,e.Espec_Fecha as fecha_espectaculo,isnull(e.Espec_Desc,'') as descripcion_espectaculo,r.Rubro_Descr
		  FROM GESTION_DE_GATOS.Compras c
		  JOIN GESTION_DE_GATOS.Ubicaciones u ON u.Ubic_Compra_Id = c.Compra_Id
		  JOIN GESTION_DE_GATOS.Espectaculos e ON e.Espec_Cod = u.Ubic_Espec_Cod
		  JOIN GESTION_DE_GATOS.Rubros r ON r.Rubro_Cod = e.Espec_Rubro_Cod
		  WHERE c.Compra_Cli_Doc = 43468403 and c.Compra_Cli_Tipo_Doc=1
		  GROUP BY c.Compra_Id,c.Compra_Fecha,e.Espec_Fecha,e.Espec_Desc,r.Rubro_Descr
		  ORDER BY c.Compra_Id
		  OFFSET @pagina ROWS FETCH NEXT 20 ROWS ONLY
END 
go


GO
IF (OBJECT_ID('sp_modificar_grado', 'P') IS NOT NULL) DROP PROCEDURE sp_modificar_grado 
GO
CREATE PROCEDURE sp_modificar_grado(@id int,@comision float,@descripcion varchar(50),@habilitado bit)
AS BEGIN
	declare @cantidad int
	set @cantidad = (SELECT isnull(COUNT(*),0) FROM GESTION_DE_GATOS.Grados WHERE (@descripcion = Grado_Descr or @comision = Grado_Comision) and Grado_Cod <> @id)
	if @cantidad > 0
		raiserror('Ya existe un grado con esa descripcion y/o esa comision',16,0)
	else
		UPDATE GESTION_DE_GATOS.Grados SET Grado_Comision = @comision, Grado_Descr = @descripcion, Grado_Habilitado = @habilitado WHERE Grado_Cod = @id
END 
go

IF (OBJECT_ID('sp_cambiar_estado_grado', 'P') IS NOT NULL) DROP PROCEDURE sp_cambiar_estado_grado
GO
CREATE procedure dbo.sp_cambiar_estado_grado (@id int,@estado_final bit)
AS BEGIN
	UPDATE GESTION_DE_GATOS.Grados SET Grado_Habilitado = @estado_final WHERE Grado_Cod = @id
END

GO 
IF (OBJECT_ID('sp_cambiar_estado_rol', 'P') IS NOT NULL) DROP PROCEDURE sp_cambiar_estado_rol
GO
CREATE procedure dbo.sp_cambiar_estado_rol (@id int,@estado_final bit)
AS BEGIN
	UPDATE GESTION_DE_GATOS.Roles SET Rol_Estado = @estado_final WHERE Rol_Id = @id
END
GO

GO 
IF (OBJECT_ID('sp_modificar_rol', 'P') IS NOT NULL) DROP PROCEDURE sp_modificar_rol
GO
CREATE procedure dbo.sp_modificar_rol (@id int,@nombre varchar(20),@habilitado bit)
AS BEGIN
	declare @cantidad int
	set @cantidad = (SELECT TOP 1 isnull(COUNT(*),0) FROM GESTION_DE_GATOS.Roles where Rol_Id <> @id and Rol_Nombre =@nombre)
	if @cantidad=0
		UPDATE GESTION_DE_GATOS.Roles SET Rol_Nombre = @nombre,Rol_Estado=@habilitado WHERE Rol_Id=@id
	else
		raiserror('Ya existe un rol con ese nombre',16,0)
END
GO

USE GD2C2018;
go


GO
IF (OBJECT_ID('sp_autenticar_usuario', 'P') IS NOT NULL) DROP PROCEDURE sp_autenticar_usuario 
GO
CREATE PROCEDURE sp_autenticar_usuario
(
    @user VARCHAR(20),
	@password VARCHAR(32),
	@tipoUsuario char(2),
	@tipoDocumento int,
	@salida INT OUTPUT)
AS
BEGIN
	declare @usuarioExistente int
	if @tipoUsuario = 'C'
	begin
		SET @usuarioExistente =(SELECT ISNULL((SELECT TOP 1 u.Usuario_Id
			FROM [GD2C2018].[GESTION_DE_GATOS].Clientes c
			JOIN [GD2C2018].[GESTION_DE_GATOS].Usuarios u ON u.Usuario_Id = c.Cli_Usuario_Id 
			WHERE c.Cli_Tipo_Doc_Id = @tipoDocumento AND c.Cli_Doc = convert(int,@user)
			GROUP BY u.Usuario_Estado,u.Usuario_Id), 0));
		if @usuarioExistente <> 0
			UPDATE GESTION_DE_GATOS.Usuarios SET Usuario_Intentos_Fallidos =  (SELECT TOP 1 Usuario_Intentos_Fallidos FROM GESTION_DE_GATOS.Usuarios where Usuario_Id = @usuarioExistente)+1 where  Usuario_Id = @usuarioExistente 
		SET @salida = (SELECT ISNULL((SELECT TOP 1 u.Usuario_Id
			FROM [GD2C2018].[GESTION_DE_GATOS].Clientes c
			JOIN [GD2C2018].[GESTION_DE_GATOS].Usuarios u ON u.Usuario_Id = c.Cli_Usuario_Id 
			WHERE u.Usuario_Password = HASHBYTES('SHA2_256', @password) AND c.Cli_Tipo_Doc_Id = @tipoDocumento AND c.Cli_Doc = convert(int,@user)
			GROUP BY u.Usuario_Estado,u.Usuario_Id), 0));
	end
	if @tipoUsuario = 'E'
	begin
		SET @usuarioExistente =(SELECT ISNULL((SELECT u.Usuario_Id
		FROM [GD2C2018].[GESTION_DE_GATOS].Empresas e
		JOIN [GD2C2018].[GESTION_DE_GATOS].Usuarios u ON u.Usuario_Id = e.Emp_Usuario_Id 
		WHERE e.Emp_Cuit = @user
		GROUP BY u.Usuario_Estado,u.Usuario_Id), 0))
		if @usuarioExistente<> 0
			UPDATE GESTION_DE_GATOS.Usuarios SET Usuario_Intentos_Fallidos =  (SELECT TOP 1 Usuario_Intentos_Fallidos FROM GESTION_DE_GATOS.Usuarios where Usuario_Id = @usuarioExistente)+1 where  Usuario_Id = @usuarioExistente 
		SET @salida = (SELECT ISNULL((SELECT u.Usuario_Id
		FROM [GD2C2018].[GESTION_DE_GATOS].Empresas e
		JOIN [GD2C2018].[GESTION_DE_GATOS].Usuarios u ON u.Usuario_Id = e.Emp_Usuario_Id 
		WHERE u.Usuario_Password = HASHBYTES('SHA2_256', @password) AND  e.Emp_Cuit = @user
		GROUP BY u.Usuario_Estado,u.Usuario_Id), 0));
	end
	if @tipoUsuario = 'O'
	begin
		SET @usuarioExistente =(SELECT ISNULL((SELECT u.Usuario_Id
		FROM [GD2C2018].[GESTION_DE_GATOS].Usuarios u
		WHERE u.Usuario_Username = @user
		GROUP BY u.Usuario_Estado,u.Usuario_Id), 0))
		if @usuarioExistente <> 0
			UPDATE GESTION_DE_GATOS.Usuarios SET Usuario_Intentos_Fallidos =  (SELECT TOP 1 Usuario_Intentos_Fallidos FROM GESTION_DE_GATOS.Usuarios where Usuario_Id = @usuarioExistente)+1 where  Usuario_Id = @usuarioExistente 
		SET @salida = (SELECT ISNULL((SELECT u.Usuario_Id
		FROM [GD2C2018].[GESTION_DE_GATOS].Usuarios u
		WHERE u.Usuario_Password = HASHBYTES('SHA2_256', @password) AND  u.Usuario_Username = @user
		GROUP BY u.Usuario_Estado,u.Usuario_Id), 0));
	end
		
	IF @salida = 0
	BEGIN
		RAISERROR ('Usuario o contraseña incorrecta', 16, 0)
		RETURN;
	END
END
go

IF (OBJECT_ID('sp_cambiar_contraseña', 'P') IS NOT NULL) DROP PROCEDURE sp_cambiar_contraseña 
go
CREATE PROCEDURE sp_cambiar_contraseña @idUsuario int,@contraseña VARCHAR(32),@tamaño int
AS 
BEGIN
	UPDATE GESTION_DE_GATOS.Usuarios SET Usuario_Password = HASHBYTES('SHA2_256',@contraseña) WHERE Usuario_Id = @idUsuario
	UPDATE GESTION_DE_GATOS.Usuarios SET Usuario_Primer_Logueo = 0 WHERE Usuario_Id = @idUsuario
END
go


IF (OBJECT_ID('sp_buscar_usuario', 'P') IS NOT NULL) DROP PROCEDURE sp_buscar_usuario 
go
CREATE PROCEDURE sp_buscar_usuario @idUsuario int
AS BEGIN
		SELECT u.Usuario_Id, u.Usuario_Username, u.Usuario_Estado, ISNULL(u.Usuario_Primer_Logueo, 0)
		FROM GESTION_DE_GATOS.Usuarios u
				LEFT JOIN  GESTION_DE_GATOS.Rol_Por_Usuario
					ON GESTION_DE_GATOS.Rol_Por_Usuario.Usuario_Id = u.Usuario_Id
                LEFT JOIN GESTION_DE_GATOS.Roles
					ON GESTION_DE_GATOS.Roles.Rol_Id = GESTION_DE_GATOS.Rol_Por_Usuario.Rol_Id
		WHERE u.Usuario_Id = @idUsuario
		UPDATE GESTION_DE_GATOS.Usuarios 
			SET Usuario_Estado = 1, Usuario_Intentos_Fallidos = 0
			WHERE Usuario_Id = @idUsuario
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

IF (OBJECT_ID('sp_crear_rol', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_rol
go
CREATE PROCEDURE sp_crear_rol @nombre varchar(20),@id int OUTPUT
AS BEGIN
		INSERT INTO GESTION_DE_GATOS.Roles (Rol_Nombre,Rol_Estado) VALUES (@nombre,1)
		set @id = (SELECT TOP 1 Rol_Id FROM GESTION_DE_GATOS.Roles ORDER BY Rol_Id DESC)
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


GO
IF (OBJECT_ID('sp_agregar_domicilio', 'P') IS NOT NULL) DROP PROCEDURE sp_agregar_domicilio 
GO
CREATE PROCEDURE sp_agregar_domicilio (@calle nvarchar(50),@nro numeric(18), @depto nvarchar(50),
									   @localidad varchar(20),@piso numeric(18),@cp nvarchar(50),
									   @dom_id INT OUTPUT)
AS BEGIN
	DECLARE @salida INT = 0;
	if @piso = 0
		set @piso=null
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
		RAISERROR ('Domicilio ya existente', 16, 0)
		RETURN;
	END	
END
GO

IF (OBJECT_ID('sp_get_domicilios', 'P') IS NOT NULL) DROP PROCEDURE sp_get_domicilios
GO
CREATE PROCEDURE sp_get_domicilios (@calle nvarchar(50), @nro numeric(18))
AS BEGIN
	SELECT * FROM GESTION_DE_GATOS.Domicilios
		WHERE Dom_Calle LIKE @calle AND Dom_Nro_Calle = @nro;
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
		RAISERROR ('CUIT para empresa ya registrado', 16, 0)
		RETURN;
	END
	IF @razon_encontrada <> 0
	BEGIN
		RAISERROR ('Razon Social para empresa ya registrado.', 16, 0)
		RETURN;
	END
END
go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'sp_crear_empresa')
            AND type IN ( N'P', N'PC' ) ) DROP PROCEDURE sp_crear_empresa
go
CREATE procedure dbo.sp_crear_empresa (@razon_social nvarchar(255), @cuit nvarchar(255), 
									   @mail nvarchar(50), @telefono numeric(20), @dom_id INT, @contraseña varchar(32),@fecha_creacion datetime)
as
begin
	declare @nuevoUsuario int
	EXEC sp_validar_empresa @razon_social, @cuit;
	begin transaction
		begin try
			begin
				if @contraseña = ''
					set @contraseña= convert(varchar(32),'palconet2018')
				INSERT INTO GESTION_DE_GATOS.Usuarios 
				(Usuario_Username,Usuario_Password,Usuario_Estado) 
				VALUES (@cuit,
					HASHBYTES('SHA2_256',@contraseña),
					1)
				SET @nuevoUsuario = (SELECT TOP 1 Usuario_Id FROM GESTION_DE_GATOS.Usuarios ORDER BY Usuario_Id DESC)
				INSERT INTO GESTION_DE_GATOS.Empresas 
				(Emp_Razon_Social, Emp_Cuit, Emp_Fecha_Creacion, Emp_Mail, Emp_Dom_Id,
					Emp_Usuario_Id, Emp_Tel)
				VALUES (@razon_social, @cuit, @fecha_creacion, @mail, @dom_id, @nuevoUsuario, @telefono)
				INSERT INTO GESTION_DE_GATOS.Rol_Por_Usuario(Rol_Id,Usuario_Id) VALUES (2,@nuevoUsuario)
			end
		end try
		begin catch
			IF @@TRANCOUNT > 0  
				rollback transaction;
			RAISERROR('Hubo un error al crear la empresa, motivo: %s',16,0)
		end catch
		IF @@TRANCOUNT > 0  
        	commit transaction;
end
GO

IF (OBJECT_ID('sp_actualizar_empresa', 'P') IS NOT NULL) DROP PROCEDURE sp_actualizar_empresa
go
CREATE procedure dbo.sp_actualizar_empresa (@razon_social nvarchar(255), @cuit nvarchar(255),
								@mail nvarchar(50),@telefono numeric(20),
								@domicilio_id INT, @habilitada INT)
AS BEGIN
	UPDATE GESTION_DE_GATOS.Empresas
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
	SELECT @resultado = Emp_Habilitada FROM GESTION_DE_GATOS.Empresas WHERE Emp_Cuit = @cuit;
END
GO



IF (OBJECT_ID('sp_modificar_cliente', 'P') IS NOT NULL) DROP PROCEDURE sp_modificar_cliente
go
CREATE procedure dbo.sp_modificar_cliente (@tipoDoc INT, @doc numeric(18), @cuil nvarchar(255), @nombre nvarchar(255),
											@apellido nvarchar(255), @fechaNac datetime,
											@mail nvarchar(255), @telefono numeric(20), @habilitado BIT)
AS BEGIN
	UPDATE [GESTION_DE_GATOS].Clientes
		SET [Cli_Apellido] = @apellido, [Cli_Nombre] = @nombre
      		,[Cli_Cuil] = @cuil, [Cli_Fecha_Nac] = @fechaNac, [Cli_Mail] = @mail, [Cli_Tel] = @telefono
      		,[Cli_Habilitado] = @habilitado
		WHERE [Cli_Tipo_Doc_Id] = @tipoDoc AND [Cli_Doc] = @doc;
END
GO

IF (OBJECT_ID('sp_crear_espectaculo', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_espectaculo
go
CREATE PROCEDURE sp_crear_espectaculo(@espec_desc NVARCHAR(255), @espec_fecha DATETIME,
										@espec_fecha_vencimiento DATETIME, @espec_rubro_codigo INT,
										@espec_emp_cuit NVARCHAR(255), @espec_dom_id INT, @espec_cod INT OUTPUT)
AS BEGIN
INSERT INTO GESTION_DE_GATOS.Espectaculos ([Espec_Desc], [Espec_Fecha], [Espec_Fecha_Venc], [Espec_Rubro_Cod]
			      							,[Espec_Emp_Cuit], [Espec_Dom_Id], [Espec_Estado])
			VALUES(@espec_desc, @espec_fecha, @espec_fecha_vencimiento, @espec_rubro_codigo, @espec_emp_cuit, @espec_dom_id, 1);
SET @espec_cod = (SELECT TOP 1 Espec_Cod FROM GESTION_DE_GATOS.Espectaculos ORDER BY Espec_Cod DESC);
END
GO

IF (OBJECT_ID('sp_crear_publicacion', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_publicacion
GO
CREATE PROCEDURE sp_crear_publicacion(@pub_desc NVARCHAR(255), @pub_grado_cod INT, @pub_fecha_creacion DATETIME, 
										@espec_cod NUMERIC(18,0), @pub_estado_id INT, @editor_id INT)
AS BEGIN
	DECLARE @pub_id INT
	INSERT INTO GESTION_DE_GATOS.Publicaciones ([Public_Desc], [Public_Fecha_Creacion], [Public_Grado_Cod]
	      										 , [Public_Espec_Cod], [Public_Estado_Id], Public_Editor)
		VALUES (@pub_desc, @pub_fecha_creacion, @pub_grado_cod, @espec_cod, @pub_estado_id, @editor_id);
	SET @pub_id = (SELECT TOP 1 Public_Cod FROM GESTION_DE_GATOS.Publicaciones ORDER BY Public_Cod DESC);
	EXEC dbo.sp_actualizar_rol_editor @editor_id;
END
GO

IF (OBJECT_ID('sp_actualizar_rol_editor', 'P') IS NOT NULL) DROP PROCEDURE sp_actualizar_rol_editor
GO
CREATE PROCEDURE sp_actualizar_rol_editor(@editor_id INT)
AS BEGIN
	DECLARE @esEditor INT = 0;
	SET @esEditor = (SELECT COUNT(1) FROM GESTION_DE_GATOS.Rol_Por_Usuario 
						WHERE Usuario_Id = @editor_id AND Rol_Id = 4)
	IF(@esEditor = 0)
		BEGIN
			INSERT INTO GESTION_DE_GATOS.Rol_Por_Usuario (Usuario_Id, Rol_Id)
						VALUES(@editor_id, 4);
		END
END
GO


IF (OBJECT_ID('sp_actualizar_publicacion', 'P') IS NOT NULL) DROP PROCEDURE sp_actualizar_publicacion
GO
CREATE PROCEDURE sp_actualizar_publicacion(@pub_cod INT, @pub_desc NVARCHAR(255), @pub_grado_cod INT, 
											@espec_cod INT, @pub_estado_id INT, @editor_id INT)
AS BEGIN
	DECLARE @pub_id INT
	UPDATE GESTION_DE_GATOS.Publicaciones
		SET [Public_Desc] = @pub_desc, [Public_Grado_Cod] = @pub_grado_cod, 
			[Public_Espec_Cod] = @espec_cod, [Public_Estado_Id] = @pub_estado_id, Public_Editor = @editor_id
		WHERE Public_Cod = @pub_cod;
	EXEC dbo.sp_actualizar_rol_editor @editor_id;
END
GO

IF (OBJECT_ID('sp_actualizar_espectaculo', 'P') IS NOT NULL) DROP PROCEDURE sp_actualizar_espectaculo
GO
CREATE PROCEDURE sp_actualizar_espectaculo(@espec_cod INT, @espec_desc NVARCHAR(255), @espec_fecha DATETIME,
										@espec_fecha_vencimiento DATETIME, @espec_rubro_codigo INT,
										@espec_emp_cuit NVARCHAR(255), @espec_dom_id INT, 
										@espec_estado BIT)
AS BEGIN
	UPDATE GESTION_DE_GATOS.Espectaculos 
		SET [Espec_Desc] = @espec_desc, [Espec_Fecha] = @espec_fecha, [Espec_Fecha_Venc] = @espec_fecha_vencimiento,
			[Espec_Rubro_Cod] = @espec_rubro_codigo, [Espec_Emp_Cuit] = @espec_emp_cuit, [Espec_Dom_Id] = @espec_dom_id,
			[Espec_Estado] = @espec_estado
		WHERE Espec_Cod = @espec_cod;
END
GO



IF (OBJECT_ID('sp_crear_ubicaciones', 'P') IS NOT NULL) DROP PROCEDURE sp_crear_ubicaciones
go
CREATE procedure sp_crear_ubicaciones(@ubic_tipo INT, @ubic_precio NUMERIC(18), @ubic_espec_codigo NUMERIC(18),
								  		@cnt_filas INT, @cnt_asientos INT)
AS BEGIN 
	DECLARE @indice_fila INT = 0;
	DECLARE @indice_asiento INT = 0;
	BEGIN
		IF @ubic_precio < 0
		BEGIN
			RAISERROR ('El precio de las ubicaciones no puede ser menor a 0', 16, 0)
		END
		WHILE @indice_fila < @cnt_filas
		BEGIN
		    WHILE @indice_asiento < @cnt_asientos
			BEGIN
				INSERT INTO GESTION_DE_GATOS.Ubicaciones(Ubic_Fila, Ubic_Asiento, Ubic_Precio,
									  Ubic_Espec_Cod, Ubic_Tipo_Cod, Ubic_Sin_Numerar) 
						VALUES(dbo.obtenerLetra(@indice_fila), @indice_asiento, @ubic_precio, @ubic_espec_codigo, @ubic_tipo, 0);
				SET @indice_asiento = @indice_asiento + 1;
			END;
		   SET @indice_fila = @indice_fila + 1;
		   SET @indice_asiento = 0;
		END;
	END
END
GO

IF (OBJECT_ID('sp_eliminar_ubicaciones', 'P') IS NOT NULL) DROP PROCEDURE sp_eliminar_ubicaciones
go
CREATE procedure sp_eliminar_ubicaciones(@ubic_espec_codigo NUMERIC(18))
AS BEGIN 
	DELETE FROM GESTION_DE_GATOS.Ubicaciones WHERE Ubic_Espec_Cod = @ubic_espec_codigo;
END

go
IF (OBJECT_ID('sp_get_sectores', 'P') IS NOT NULL) DROP PROCEDURE sp_get_sectores
go
CREATE procedure sp_get_sectores(@ubic_espec_codigo NUMERIC(18))
AS BEGIN 
	SELECT COUNT(distinct [Ubic_Fila]) filas, COUNT(distinct [Ubic_Asiento]) asientos, 
			[Ubic_Precio], Ubicaciones.Ubic_Tipo_Cod, Ubic_Tipo_Descr
  		FROM [GD2C2018].[GESTION_DE_GATOS].[Ubicaciones]
  		JOIN [GD2C2018].[GESTION_DE_GATOS].[Ubicaciones_Tipo] ON Ubicaciones.Ubic_Tipo_Cod = Ubicaciones_Tipo.Ubic_Tipo_Cod
  		WHERE Ubic_Espec_Cod = @ubic_espec_codigo
  		GROUP BY Ubic_Precio, Ubicaciones.Ubic_Tipo_Cod, Ubic_Tipo_Descr
END
GO

IF (OBJECT_ID('sp_realizar_compra', 'P') IS NOT NULL) DROP PROCEDURE sp_realizar_compra
go
CREATE procedure sp_realizar_compra(@public_id INT, @cli_doc_num numeric(18), @cli_doc_tipo INT,
									@fecha DATETIME, @cli_tarj_cred_id INT, @ubic_id INT)
AS BEGIN
	DECLARE @compra_id INT;
	INSERT INTO GESTION_DE_GATOS.Compras ([Compra_Publicacion],[Compra_Cli_Doc],[Compra_Cli_Tipo_Doc],
		[Compra_Fecha],[Compra_Tarj_Cred_Id], [Compra_Forma_Pago_Desc])
		VALUES(@public_id, @cli_doc_num, @cli_doc_tipo, @fecha, @cli_tarj_cred_id, 'TARJETA');
	SET @compra_id = (SELECT TOP 1 Compra_Id FROM GESTION_DE_GATOS.Compras ORDER BY Compra_Id DESC);
	UPDATE GESTION_DE_GATOS.Ubicaciones 
		SET Ubic_Compra_Id = @compra_id 
		WHERE Ubic_Id = @ubic_id;
	INSERT INTO GESTION_DE_GATOS.PUNTOS ([Cli_Tipo_Doc], [Cli_Doc], [Puntos_FechaVencimiento], [Puntos_Cantidad])
		VALUES (@cli_doc_tipo, @cli_doc_num, DATEADD(day, 30, @fecha), 100);
END
GO

go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'dbo.SPLIT_STRING')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function dbo.SPLIT_STRING;
go
CREATE FUNCTION dbo.SPLIT_STRING
(
    @sString nvarchar(2048),
    @cDelimiter nchar(1)
)
RETURNS @tParts TABLE ( part nvarchar(2048) )
AS
BEGIN
    if @sString is null return
    declare @iStart int,
            @iPos int
    if substring( @sString, 1, 1 ) = @cDelimiter 
    begin
        set @iStart = 2
        insert into @tParts
        values( null )
    end
    else 
        set @iStart = 1
    while 1=1
    begin
        set @iPos = charindex( @cDelimiter, @sString, @iStart )
        if @iPos = 0
            set @iPos = len( @sString )+1
        if @iPos - @iStart > 0          
            insert into @tParts
            values  ( substring( @sString, @iStart, @iPos-@iStart ))
        else
            insert into @tParts
            values( null )
        set @iStart = @iPos+1
        if @iStart > len( @sString ) 
            break
    end
    RETURN

END

go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[obtenerLetra]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].[obtenerLetra];
go
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
return '!'
end;




go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'obtenerTrimestre')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function obtenerTrimestre;
go
create function obtenerTrimestre(@fecha Date)
returns int
as
begin
declare @numeroTrimestre int
set @numeroTrimestre= case	when Month(@fecha)/3 between 0 and 1 then 1
							when Month(@fecha)/3 between 1 and 2 then 2
							when Month(@fecha)/3 between 2 and 3 then 3
							when Month(@fecha)/3 between 3 and 4 then 4
					  end
return @numeroTrimestre
end;
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'empresasConLocalidadesSinVender')
           AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function empresasConLocalidadesSinVender;

go

use GD2C2018
go
create function empresasConLocalidadesSinVender (@gradoVisibilidad numeric(11), @mes int,@año int, @trimestre int)
returns table
as
return(
	select top 5  * from(select top 5  emp.Emp_Razon_Social,esp.Espec_Fecha, grad.Grado_Descr
	 from GESTION_DE_GATOS.Empresas emp
	join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Emp_Cuit=emp.Emp_Cuit
	join GESTION_DE_GATOS.Ubicaciones ubi on  ubi.Ubic_Espec_Cod = esp.Espec_Cod
	join GESTION_DE_GATOS.Publicaciones pub on pub.Public_Espec_Cod= esp.Espec_Cod
	join GESTION_DE_GATOS.Grados grad on Public_Grado_Cod=grad.Grado_Cod
	where (@gradoVisibilidad is null Or Public_Estado_Id = @gradoVisibilidad) and ((@mes is null) OR Month(Espec_Fecha)=@mes) and (Year(Espec_Fecha)=@año or @año is null)
	and ubi.Ubic_Compra_Id is null and @trimestre= [dbo].[obtenerTrimestre](esp.Espec_Fecha)
	group by emp.Emp_Razon_Social, esp.Espec_Fecha,grad.Grado_Descr
	order by Count(Ubic_Id) DESC) empre
	order by empre.Espec_Fecha DESC, empre.Grado_Descr
)
GO
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'clientesConMayoresPuntosVencidos')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function clientesConMayoresPuntosVencidos
;
go
create function clientesConMayoresPuntosVencidos (@año int, @trimestre int )
returns table
as

return(
select top 5 concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc)) as Cliente,SUM(pun.Puntos_Cantidad) as Cantidad
from GESTION_DE_GATOS.Clientes cli
join GESTION_DE_GATOS.Puntos pun on cli.Cli_Tipo_Doc_Id= pun.Cli_Tipo_Doc and cli.Cli_Doc=pun.Cli_Doc
where  @trimestre> [dbo].[obtenerTrimestre](pun.Puntos_FechaVencimiento) and @año>=year(pun.Puntos_FechaVencimiento)
group by  concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc))
order by sum(pun.Puntos_Cantidad) DESC
)
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'clientesConMayorCantidadDeComprasPorEmpresa')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function clientesConMayorCantidadDeComprasPorEmpresa
go
create  function clientesConMayorCantidadDeComprasPorEmpresa (@año int,@trimestre int)
returns table

as 

return(
select top 5 concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc)) as Cliente,COUNT(comp.Compra_Id)as Cantidad,Emp_Cuit as Empresa
 from GESTION_DE_GATOS.Clientes cli
join GESTION_DE_GATOS.Compras comp on comp.Compra_Cli_Tipo_Doc=cli.Cli_Tipo_Doc_Id and comp.Compra_Cli_Doc=cli.Cli_Doc
join GESTION_DE_GATOS.Publicaciones publ on publ.Public_Cod=comp.Compra_Publicacion
join GESTION_DE_GATOS.Espectaculos esp on publ.Public_Espec_Cod= esp.Espec_Cod
join GESTION_DE_GATOS.Empresas emp on Espec_Emp_Cuit= emp.Emp_Cuit
where @trimestre= [dbo].[obtenerTrimestre](comp.Compra_Fecha) and year(comp.Compra_Fecha)=@año
group by concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc)), Emp_Cuit
order by Count(comp.Compra_Id) DESC
);
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'consultarPuntos')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function consultarPuntos;
go
create function consultarPuntos(@idCliente nvarchar (16), @fechaHoy datetime)
returns int 
as
begin
declare @puntos int
set @puntos= (select Sum(pun.Puntos_Cantidad) from GESTION_DE_GATOS.Clientes cli
			  join GESTION_DE_GATOS.Puntos pun on concat(convert(nvarchar(16),pun.Cli_Tipo_Doc),convert(nvarchar(11),pun.Cli_Doc))=@idCliente
			  
			  where pun.Puntos_FechaVencimiento>@fechaHoy
			  group by concat(convert(nvarchar(16),pun.Cli_Tipo_Doc),convert(nvarchar(11),pun.Cli_Tipo_Doc)))
return @puntos
end
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'comprasMasAntiguas')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function comprasMasAntiguas;

go
create function comprasMasAntiguas(@cantidad int, @empresaCuit nvarchar(255))
returns table
as
return(
select top (@cantidad) comp.Compra_Id from GESTION_DE_GATOS.Compras comp
join  GESTION_DE_GATOS.Publicaciones publ on publ.Public_Cod=comp.Compra_Publicacion
join GESTION_DE_GATOS.Espectaculos esp on publ.Public_Espec_Cod= esp.Espec_Cod
where Espec_Emp_Cuit=@empresaCuit and comp.Compra_Fue_Facturada =0
order by comp.Compra_Fecha ASC);
go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'rendirItemsFactura')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function rendirItemsFactura;
go

create function rendirItemsFactura(@cantidad int, @empresaCuit nvarchar(255))
Returns TABLE
as
return(
select 
sum(ubi.Ubic_Precio*Grado_Comision) as monto, Count(ubi.Ubic_Id) as cantidad  
from GESTION_DE_GATOS.Publicaciones publ
join GESTION_DE_GATOS.Grados gra on publ.Public_Grado_Cod=gra.Grado_Cod
join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Cod= publ.Public_Espec_Cod
join GESTION_DE_GATOS.Ubicaciones ubi on ubi.Ubic_Espec_Cod=esp.Espec_Cod
join GESTION_DE_GATOS.Compras comp on comp.Compra_Publicacion=Public_Cod
where comp.Compra_Id in( select * from comprasMasAntiguas(@cantidad,@empresaCuit)) 
group by  comp.Compra_Id
)
 go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GenerarRendicionComisiones')
            AND type IN ( N'P', N'PC' ) )
drop procedure GenerarRendicionComisiones;

go
create procedure GenerarRendicionComisiones (@cantidad int,@empresaCuit nvarchar(255), @username varchar(255),@fechaHoy datetime)
 as
 begin 
  declare @tienePermisos char(3),@ultimaFactura numeric(18)
		begin transaction
		begin try
			INSERT into  GESTION_DE_GATOS.Facturas (Fact_Emp_Cuit, Fact_Fecha)
			values(@empresaCuit,@fechaHoy)
			set @ultimaFactura= (select top 1 f.Fact_Num from GESTION_DE_GATOS.Facturas f order by f.Fact_Num desc)
			insert into GESTION_DE_GATOS.Item_Facturas (Item_Fact_Num,Item_Fact_Monto,Item_Fact_Cant)
			select @ultimaFactura,* from rendirItemsFactura(@cantidad,@empresaCuit)
			update GESTION_DE_GATOS.Facturas 
			set Fact_Total= (select sum(ifact.Item_Fact_Cant*ifact.Item_Fact_Monto) from GESTION_DE_GATOS.Item_Facturas ifact where ifact.Item_Fact_Num =@ultimaFactura group by ifact.Item_Fact_Id  )
			where Fact_Num= @ultimaFactura
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al hacer la  rendicion de comisiones, motivo: %s',16,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
		end
 go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[calcularPuntos]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].calcularPuntos;
go
create function calcularPuntos (@cantidadUbicaciones int , @fecha smalldatetime)
returns int
as
begin
declare @salida int  
set @salida=@cantidadUbicaciones * 100
return @salida
end
go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[localidadesDisponibles]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].localidadesDisponibles;
go 

create function localidadesDisponibles (@unaPublicacion int)
returns table
as 


return(select ubi.Ubic_Id from GESTION_DE_GATOS.Publicaciones publ 
		join GESTION_DE_GATOS.Espectaculos esp on publ.Public_Espec_Cod=esp.Espec_Cod
		join GESTION_DE_GATOS.Ubicaciones ubi on ubi.Ubic_Espec_Cod=esp.Espec_Cod
		where ubi.Ubic_Compra_Id is null)

go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[existeEspectaculoMismaHoraMismoLugar]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].existeEspectaculoMismaHoraMismoLugar
go 
create function existeEspectaculoMismaHoraMismoLugar(@fecha datetime, @domicilioId int)
returns int
as
begin
declare @salida int
set @salida= (select Count(*) from GESTION_DE_GATOS.Espectaculos esp where esp.Espec_Fecha= @fecha and esp.Espec_Dom_Id=@domicilioId )
return @salida
end			
go
use GD2C2018
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[obtenerItemsDeCompras]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].obtenerItemsDeCompras
go
create function obtenerItemsDeCompras(@PublicacionCod int )
returns table

as

return(select sum(ubi.Ubic_Precio*Grado_Comision) as monto, Count(ubi.Ubic_Id) as cantidad  
						from GESTION_DE_GATOS.Publicaciones publ
						join GESTION_DE_GATOS.Grados gra on publ.Public_Grado_Cod=gra.Grado_Cod
						join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Cod= publ.Public_Espec_Cod
						join GESTION_DE_GATOS.Ubicaciones ubi on ubi.Ubic_Espec_Cod=esp.Espec_Cod
						join GESTION_DE_GATOS.Compras comp on comp.Compra_Publicacion=Public_Cod
						where comp.Compra_Publicacion=@PublicacionCod  and comp.Compra_Fue_Facturada=0
						group by  comp.Compra_Id)


 go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'FacturarPublicacion')
            AND type IN ( N'P', N'PC' ) )
drop procedure FacturarPublicacion;

go
create procedure FacturarPublicacion(@PublicacionCod int,@fechaHoy datetime)
as
	declare @ultimaFactura numeric(18)
	declare @empresaCuit nvarchar(255)
	declare @esFinalizada int
		set @empresaCuit= (select top 1 esp.Espec_Emp_Cuit
							from GESTION_DE_GATOS.Publicaciones publ join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Cod=publ.Public_Espec_Cod
							where publ.Public_Cod=@PublicacionCod)	
		set @esFinalizada= (select top 1 publ.Public_Estado_Id from GESTION_DE_GATOS.Publicaciones publ where publ.Public_Cod=@PublicacionCod)
		begin transaction
		begin try
		if(@esFinalizada=3)
		begin 
			INSERT into  GESTION_DE_GATOS.Facturas (Fact_Emp_Cuit, Fact_Fecha)
			values(@empresaCuit,@fechaHoy)
			set @ultimaFactura= (select top 1 f.Fact_Num from GESTION_DE_GATOS.Facturas f order by f.Fact_Num desc)
			insert into GESTION_DE_GATOS.Item_Facturas (Item_Fact_Num,Item_Fact_Monto,Item_Fact_Cant) 
                SELECT @ultimaFactura, * FROM obtenerItemsDeCompras(@PublicacionCod)
			update GESTION_DE_GATOS.Facturas
			set Fact_Total = (select sum(ifact.Item_Fact_Cant*ifact.Item_Fact_Monto) 
                                from GESTION_DE_GATOS.Item_Facturas ifact 
                                where ifact.Item_Fact_Num =@ultimaFactura)
			where Fact_Num = @ultimaFactura
		end
		else throw 11,'La publicacion no esta finalizada',1	 
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al realizar la factura, motivo: %s',16,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
		
go


/*go
--script para bajar todo
USE GD2C2018;
ALTER TABLE [GESTION_DE_GATOS].[Rol_Por_Usuario] DROP CONSTRAINT FK_Usuario_Id,FK_Rol_Id
ALTER TABLE [GESTION_DE_GATOS].[Funcionalidad_Por_Rol] DROP CONSTRAINT FK_Func_Rol_Id,FK_Func_Func_Id
ALTER TABLE [GESTION_DE_GATOS].[Empresas] DROP CONSTRAINT FK_Dom_Id,FK_Emp_Usuario_Id
ALTER TABLE [GESTION_DE_GATOS].[Clientes] DROP CONSTRAINT FK_Cli_Domicilio_Id,FK_Cli_Tipo_Doc_Id,FK_Cli_Usuario_Id
ALTER TABLE [GESTION_DE_GATOS].[Premios_Adquiridos] DROP CONSTRAINT FK_Premio_Id,FK_Premios_Adq_Cliente_Doc
ALTER TABLE [GESTION_DE_GATOS].[Tarjetas_Credito] DROP CONSTRAINT FK_Tarjeta_Cliente
ALTER TABLE [GESTION_DE_GATOS].[Espectaculos] DROP CONSTRAINT FK_Espec_Rubro_Cod, FK_Espec_Emp_Cuit,FK_Espec_Dom_Id
ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones] DROP CONSTRAINT FK_Ubic_Tipo_Cod,FK_Ubic_Compra_Id,FK_Ubic_Espec_Cod
ALTER TABLE [GESTION_DE_GATOS].[Compras] DROP CONSTRAINT FK_Compra_Publicacion_Id,FK_Compra_Cliente
ALTER TABLE [GESTION_DE_GATOS].[Publicaciones] DROP CONSTRAINT FK_Public_Grado_Cod,FK_Public_Espec_Cod,FK_Public_Estado_Id
ALTER TABLE [GESTION_DE_GATOS].[Facturas] DROP CONSTRAINT FK_Fact_Empresa_Cuit
ALTER TABLE [GESTION_DE_GATOS].[Item_Facturas] DROP CONSTRAINT FK_Item_Fact_Num
ALTER TABLE [GESTION_DE_GATOS].[Puntos] DROP CONSTRAINT FK_Puntos_Cliente
ALTER TABLE [GESTION_DE_GATOS].[Usuarios] DROP CONSTRAINT DF_Primer_Logueo
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
DROP TABLE [GESTION_DE_GATOS].[Publicaciones]
DROP TABLE [GESTION_DE_GATOS].[Usuarios]
DROP TABLE [GESTION_DE_GATOS].[Publicaciones_Estado]
DROP TABLE [GESTION_DE_GATOS].[Espectaculos]
DROP TABLE [GESTION_DE_GATOS].[Facturas]
DROP TABLE [GESTION_DE_GATOS].[Empresas]
DROP TABLE [GESTION_DE_GATOS].[Tipos_Doc]
DROP TABLE [GESTION_DE_GATOS].[Puntos]
GO
DROP SCHEMA [GESTION_DE_GATOS]
*/
