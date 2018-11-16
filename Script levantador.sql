USE GD2C2018
GO
--Creación schema y tablas
CREATE SCHEMA [GESTION_DE_GATOS]
GO

-- clientes, empresas y domicilio
CREATE TABLE [GESTION_DE_GATOS].[Clientes]
( 
	[Cli_Doc]				numeric(15)  NOT NULL ,
	[Cli_Tipo_Doc]			varchar(15)  NOT NULL,
	[Cli_Apellido]			varchar(30)  NOT NULL ,
	[Cli_Nombre]			varchar(30)  NOT NULL ,
	[Cli_Cuil]				numeric(12)  NOT NULL, 
	[Cli_Fecha_Nac]			smalldatetime  NOT NULL ,
	[Cli_Fecha_Creacion]    smalldatetime  NOT NULL,
	[Cli_Mail]				varchar(50)  NOT NULL ,
	[Cli_Tel]				numeric(20)  NOT NULL,
	[Cli_Domicilio_Id]		varchar(50)  NOT NULL ,
	[Cli_Puntos]			numeric(12) NULL,
	[Cli_User_Id]			integer NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Clientes]
	ADD CONSTRAINT [XPKClientes] PRIMARY KEY  CLUSTERED ([Cli_Tipo_Doc] ASC,[Cli_Doc] ASC)
go


CREATE TABLE [GESTION_DE_GATOS].[Domicilios]
( 
	[Dom_Id]			 integer identity(1,1),
	[Dom_Cod_Postal]     numeric(4)  NOT NULL ,
	[Dom_Localidad]      varchar(20)  NOT NULL ,
	[Dom_Piso]           varchar(8)  NULL ,
	[Dom_Depto]          char(4)  NULL ,
	[Dom_Nro_Calle]      numeric(8)  NOT NULL ,
	[Dom_Calle]          varchar(60)  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Domicilios]
	ADD CONSTRAINT [XPKDomicilio] PRIMARY KEY  CLUSTERED ([Dom_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Espec_Empresas]
( 
	[Espec_Emp_Cuit]				numeric(12)  NOT NULL ,
	[Espec_Emp_Razon_Social]		varchar(50)  NOT NULL ,
	[Espec_Emp_Tel]					numeric(20)  NOT NULL ,
	[Espec_Emp_Fecha_Creacion]      smalldatetime  NOT NULL,
	[Espec_Emp_Mail]				varchar(50) NOT NULL,
	[Esoec_Dom_Id]					integer NOT NULL,
	[Espec_Emp_User_Id]				integer NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Espec_Empresas]
	ADD CONSTRAINT [XPKEspec_Empresa] PRIMARY KEY  CLUSTERED ([Espec_Emp_Cuit] ASC)
go

-- facturas e items facturas

CREATE TABLE [GESTION_DE_GATOS].[Facturas]
( 
	[Fact_Num]				integer  NOT NULL ,
	[Fact_Forma_De_Pago]    varchar(20)  NOT NULL ,
	[Fact_Total]			float  NOT NULL ,
	[Fact_Fecha]			smalldatetime  NOT NULL ,
	[Fact_Espec_Emp_Cuit]   numeric(12)  NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Facturas]
	ADD CONSTRAINT [XPKFacturas] PRIMARY KEY  CLUSTERED ([Fact_Num] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Item_Facturas]
( 

	[Item_Fact_Id]			integer identity(1,1)  NOT NULL ,
	[Item_Fact_Num]         integer  NOT NULL ,
	[Item_Fact_Cant]		integer  NOT NULL ,
	[Item_Fact_Monto]       float  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Item_Facturas]
	ADD CONSTRAINT [XPKItem_Facturas] PRIMARY KEY  CLUSTERED ([Item_Fact_Id] ASC,[Item_Fact_Num] ASC)
go

-- usuarios,roles y funcionalidades
CREATE TABLE [GESTION_DE_GATOS].[Funcionalidades]
( 
	[Func_Id]					integer identity(1,1)  NOT NULL ,
	[Func_Descripcion]			varchar(30)  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Funcionalidades]
	ADD CONSTRAINT [XPKFuncionalidades] PRIMARY KEY  CLUSTERED ([Func_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Roles]
( 
	[Rol_Id]			int identity(1,1),
	[Rol_Func_Id]       integer unique NOT NULL ,
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
	[Usuario_Rol]			int  NOT NULL ,
	[Usuario_Username]		varchar(20)  NULL ,
	[Usuario_Password]		varchar(20)  NULL ,
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
	[Cli_Doc]         numeric(15)  NOT NULL,
	[Cli_Tipo_Doc]	  numeric(15) NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Premios_Adquiridos]
	ADD CONSTRAINT [XPKPremios_Adquiridos] PRIMARY KEY  CLUSTERED ([Premio_Id] ASC,[Cli_Doc] ASC,[Cli_Tipo_Doc] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Premios]
( 
	[Premio_Id]					int identity(1,1)  NOT NULL ,
	[Premio_Descripcion]        varchar(50)  NOT NULL,
	[Premio_Puntos]				int NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Premios]
	ADD CONSTRAINT [XPKPremios] PRIMARY KEY  CLUSTERED ([Premio_Id] ASC)
go
CREATE TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
( 
	[Tarjeta_Cred_Id]				int identity(1,1)  NOT NULL ,
	[Tarjeta_Cred_Num]				integer  NOT NULL,
	[Tarjeta_Cred_Vencimiento]		smalldatetime NOT NULL,
	[Tarjeta_Cred_Banco]			varchar(50) NOT NULL,
	[Tarjeta_Cred_Cli_Id]			int NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
	ADD CONSTRAINT [XPKTarjetas_Credito] PRIMARY KEY  CLUSTERED ([Tarjeta_Cred_Id] ASC)
go
CREATE TABLE [GESTION_DE_GATOS].[Espectaculos]
( 
	[Espec_Cod]				int  NOT NULL ,
	[Espec_Desc]            varchar(100)  NOT NULL,
	[Espec_Fecha]			smalldatetime NOT NULL,
	[Espec_Hora]			time NOT NULL,
	[Espec_Fecha_Venc]		smalldatetime NOT NULL,
	[Espec_Rubro_Id]		int NOT NULL,
	[Espec_Empresa_Cuit]	numeric(12) NOT NULL,
	[Espec_Dom_Id]			int NOT NULL,
	[Espec_Estado]			bit NOT NULL
	  
)
go

ALTER TABLE [GESTION_DE_GATOS].[Espectaculos]
	ADD CONSTRAINT [XPKEspectaculos] PRIMARY KEY  CLUSTERED ([Espec_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Espec_Rubros]
( 
	[Espec_Rubro_Cod]			int identity(1,1)  NOT NULL ,
	[Premio_Descripcion]        varchar(50)  NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Espec_Rubros]
	ADD CONSTRAINT [XPKEspec_Rubros] PRIMARY KEY  CLUSTERED ([Espec_Rubro_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Ubicaciones]
( 
	[Ubic_Id]				int  identity(1,1) NOT NULL ,
	[Ubic_Fila]				int  NOT NULL,
	[Ubic_Asiento]			varchar(5) NOT NULL,
	[Ubic_Sin_Numerar]		varchar(5) NOT NULL,
	[Ubic_Precio]			float NOT NULL,
	[Ubic_Espec_Cod]		int NOT NULL,
	[Ubic_Tipo_Cod]			int NOT NULL,
	[Ubic_Compra_id]		int NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones]
	ADD CONSTRAINT [XPKUbicaciones] PRIMARY KEY  CLUSTERED ([Ubic_Id] ASC)
go


CREATE TABLE [GESTION_DE_GATOS].[Ubicaciones_Tipo]
( 
	[Ubic_Cod]				int  NOT NULL ,
	[Ubic_Descripcion]		varchar(50)  NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Ubicaciones_Tipo]
	ADD CONSTRAINT [XPKUbicaciones_Tipo] PRIMARY KEY  CLUSTERED ([Ubic_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Compras]
( 
	[Compra_Id]					int identity(1,1)  NOT NULL ,
	[Compra_Publicación]		int  NOT NULL,
	[Compra_Cli_Doc]			numeric(15) NOT NULL,
	[Compra_Tipo_Doc]			varchar(15) NOT NULL,
	[Compra_Fecha]				smalldatetime NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Compras]
	ADD CONSTRAINT [XPKCompras] PRIMARY KEY  CLUSTERED ([Compra_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Publicaciones]
( 
	[Public_Cod]				int  NOT NULL ,
	[Public_Desc]				varchar(200)  NOT NULL,
	[Public_Fecha]				smalldatetime NOT NULL,
	[Public_Grado_Cod]			int NOT NULL,
	[Public_Espec_Cod]			int NOT NULL,
	[Public_Fact_Num]			int NOT NULL,
	[Public_Estado_Id]			int NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Publicaciones]
	ADD CONSTRAINT [XPKPublicaciones] PRIMARY KEY  CLUSTERED ([Public_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Publicaciones_Tipo]
( 
	[Public_Tipo_Id]				int identity(1,1)  NOT NULL,
	[Public_Tipo_Descr]				varchar(20) NOT NULL,
	[Public_Tipo_Posible_Cambio]	bit NOT NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Publicaciones_Tipo]
	ADD CONSTRAINT [XPKPublicaciones_Tipo] PRIMARY KEY  CLUSTERED ([Public_Tipo_Id] ASC)
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
----

/*ALTER TABLE [GESTION_DE_GATOS].[Direcciones]
	ADD CONSTRAINT [R_42] FOREIGN KEY ([clie_dni]) REFERENCES [GESTION_DE_GATOS].[CLIENTES]([clie_dni])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[EMPRESAS]
	ADD CONSTRAINT [R_52] FOREIGN KEY ([emp_rubro]) REFERENCES [GESTION_DE_GATOS].[Rubros]([rubr_id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[FACTURAS]
	ADD CONSTRAINT [R_1] FOREIGN KEY ([fact_cliente]) REFERENCES [GESTION_DE_GATOS].[CLIENTES]([clie_dni])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[FACTURAS]
	ADD CONSTRAINT [R_11] FOREIGN KEY ([fact_emp_cuit]) REFERENCES [GESTION_DE_GATOS].[EMPRESAS]([emp_cuit])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Item_Pago]
	ADD CONSTRAINT [R_54] FOREIGN KEY ([pago_id]) REFERENCES [GESTION_DE_GATOS].[Pagos]([pago_id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Item_Pago]
	ADD CONSTRAINT [R_55] FOREIGN KEY ([fact_numero]) REFERENCES [GESTION_DE_GATOS].[FACTURAS]([fact_numero])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Item_Devolucion]
	ADD CONSTRAINT [R_58] FOREIGN KEY ([dev_id]) REFERENCES [GESTION_DE_GATOS].[Devoluciones]([dev_id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Item_Devolucion]
	ADD CONSTRAINT [R_59] FOREIGN KEY ([fact_numero]) REFERENCES [GESTION_DE_GATOS].[FACTURAS]([fact_numero])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Item_Rendicion]
	ADD CONSTRAINT [R_56] FOREIGN KEY ([fact_numero]) REFERENCES [GESTION_DE_GATOS].[FACTURAS]([fact_numero])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Item_Rendicion]
	ADD CONSTRAINT [R_57] FOREIGN KEY ([rend_id]) REFERENCES [GESTION_DE_GATOS].[Rendiciones]([rend_id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Items_Factura]
	ADD CONSTRAINT [R_2] FOREIGN KEY ([item_fact_numero]) REFERENCES [GESTION_DE_GATOS].[FACTURAS]([fact_numero])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Pagos]
	ADD CONSTRAINT [R_38] FOREIGN KEY ([pago_suc_cod_post]) REFERENCES [GESTION_DE_GATOS].[SUCURSALES]([suc_cod_post])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Rendiciones]
	ADD CONSTRAINT [R_53] FOREIGN KEY ([rend_empresa]) REFERENCES [GESTION_DE_GATOS].[EMPRESAS]([emp_cuit])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Roles_Funcionalidades]
	ADD CONSTRAINT [R_24] FOREIGN KEY ([rol_id]) REFERENCES [GESTION_DE_GATOS].[Roles]([rol_id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Roles_Funcionalidades]
	ADD CONSTRAINT [R_25] FOREIGN KEY ([func_nombre]) REFERENCES [GESTION_DE_GATOS].[Funcionalidades]([func_nombre])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Roles_Usuarios]
	ADD CONSTRAINT [R_21] FOREIGN KEY ([user_name]) REFERENCES [GESTION_DE_GATOS].[USUARIOS]([user_name])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Roles_Usuarios]
	ADD CONSTRAINT [R_23] FOREIGN KEY ([rol_id]) REFERENCES [GESTION_DE_GATOS].[Roles]([rol_id])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [GESTION_DE_GATOS].[Sucursal_Usuario]
	ADD CONSTRAINT [R_45] FOREIGN KEY ([user_name]) REFERENCES [GESTION_DE_GATOS].[USUARIOS]([user_name])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [GESTION_DE_GATOS].[Sucursal_Usuario]
	ADD CONSTRAINT [R_46] FOREIGN KEY ([suc_cod_post]) REFERENCES [GESTION_DE_GATOS].[SUCURSALES]([suc_cod_post])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go*/