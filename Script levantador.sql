USE GD2C2018
GO
--Creación schema y tablas
CREATE SCHEMA [GESTION_DE_GATOS]
GO



-- clientes, empresas y domicilio
CREATE TABLE [GESTION_DE_GATOS].[Clientes]
( 
	[Cli_Tipo_Doc_Id]		int  NOT NULL,
	[Cli_Doc]				numeric(15)  NOT NULL ,
	[Cli_Apellido]			varchar(30)  NOT NULL ,
	[Cli_Nombre]			varchar(30)  NOT NULL ,
	[Cli_Cuil]				numeric(12)  NULL, 
	[Cli_Fecha_Nac]			smalldatetime  NOT NULL ,
	[Cli_Fecha_Creacion]    smalldatetime  NOT NULL,
	[Cli_Mail]				varchar(50)  NOT NULL ,
	[Cli_Tel]				numeric(20)   NULL,
	[Cli_Domicilio_Id]		int  NOT NULL ,
	[Cli_Puntos]			numeric(12) NULL,
	[Cli_Usuario_Id]		integer NOT NULL
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
	[Dom_Id]			 integer identity(1,1),
	[Dom_Cod_Postal]     numeric(4)  NOT NULL ,
	[Dom_Localidad]      varchar(20)   NULL ,
	[Dom_Piso]           varchar(8)  NULL ,
	[Dom_Depto]          char(4)  NULL ,
	[Dom_Nro_Calle]      numeric(8)  NOT NULL ,
	[Dom_Calle]          varchar(60)  NULL 
)
go

ALTER TABLE [GESTION_DE_GATOS].[Domicilios]
	ADD CONSTRAINT [XPKDomicilio] PRIMARY KEY  CLUSTERED ([Dom_Id] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Empresas]
( 
	[Emp_Cuit]				numeric(12)  NOT NULL ,
	[Emp_Razon_Social]		varchar(255)  NOT NULL ,
	[Emp_Fecha_Creacion]    smalldatetime  NOT NULL,
	[Emp_Mail]				varchar(50) NOT NULL,
	[Emp_Dom_Id]			integer NOT NULL,
	[Emp_Usuario_Id]		integer NOT NULL,
	[Emp_Tel]				numeric(20) NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Empresas]
	ADD CONSTRAINT [XPKEmpresa] PRIMARY KEY  CLUSTERED ([Emp_Cuit] ASC)
go

-- facturas e items facturas

CREATE TABLE [GESTION_DE_GATOS].[Facturas]
( 
	[Fact_Num]				integer  NOT NULL ,
	[Fact_Forma_Pago]		varchar(20)  NOT NULL ,
	[Fact_Total]			float  NOT NULL ,
	[Fact_Fecha]			smalldatetime  NOT NULL ,
	[Fact_Emp_Cuit]			numeric(12)  NOT NULL 
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
	[Usuario_User]			varchar(20) NOT NULL ,
	[Usuario_Pass]			binary(32) NOT NULL ,
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
	[Cli_Doc]         numeric(15)  NOT NULL 
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
	[Tar_Cred_Num]				integer  NOT NULL,
	[Tar_Cred_Venc]				smalldatetime NOT NULL,
	[Tar_Cred_Banco]			varchar(50) NOT NULL,
	[Tar_Cred_Cli_Tipo_Doc]		int NOT NULL,
	[Tar_Cred_Cli_Doc]			numeric(15) NOT NULL  
)
go

ALTER TABLE [GESTION_DE_GATOS].[Tarjetas_Credito]
	ADD CONSTRAINT [XPKTarjetas_Credito] PRIMARY KEY  CLUSTERED ([Tar_Cred_Id] ASC)
go
CREATE TABLE [GESTION_DE_GATOS].[Espectaculos]
( 
	[Espec_Cod]				int  NOT NULL ,
	[Espec_Desc]            varchar(100)  NOT NULL,
	[Espec_Fecha]			smalldatetime NOT NULL,
	[Espec_Hora]			time NOT NULL,
	[Espec_Fecha_Venc]		smalldatetime NOT NULL,
	[Espec_Rubro_Cod]		int NOT NULL,
	[Espec_Emp_Cuit]		numeric(12) NOT NULL,
	[Espec_Dom_Id]			int NOT NULL,
	[Espec_Estado]			bit NOT NULL
	  
)
go

ALTER TABLE [GESTION_DE_GATOS].[Espectaculos]
	ADD CONSTRAINT [XPKEspectaculos] PRIMARY KEY  CLUSTERED ([Espec_Cod] ASC)
go

CREATE TABLE [GESTION_DE_GATOS].[Rubros]
( 
	[Rubro_Cod]			int identity(1,1)  NOT NULL ,
	[Rubro_Descr]		varchar(50)  NOT NULL
)
go

ALTER TABLE [GESTION_DE_GATOS].[Rubros]
	ADD CONSTRAINT [XPKRubros] PRIMARY KEY  CLUSTERED ([Rubro_Cod] ASC)
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
	[Compra_Cli_Doc]			numeric(15) NOT NULL,
	[Compra_Cli_Tipo_Doc]		int NOT NULL,
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
	ADD CONSTRAINT [FK_Public_Estado_Id] FOREIGN KEY ([Public_Estado_Id]) REFERENCES [GESTION_DE_GATOS].[Publicaciones_Tipo]([Public_Tipo_Id])
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

ALTER TABLE [GESTION_DE_GATOS].[Domicilios]
	ADD CONSTRAINT [UN_Calle_Nro] UNIQUE (Dom_Calle,Dom_Nro_Calle)

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'migracion')
            AND type IN ( N'P', N'PC' ) )
drop procedure migracion
go					 
create procedure migracion 
as
begin
	-- inserto domicilios de la empresa
	insert into GESTION_DE_GATOS.Domicilios 
	(Dom_Cod_Postal,Dom_Piso,Dom_Depto,Dom_Nro_Calle,Dom_Calle)
	SELECT  convert(numeric(4),Espec_Empresa_Cod_Postal) as Dom_Cod_Postal,
			convert(varchar(8),Espec_Empresa_Piso) as Dom_Piso,
			convert(char(4),Espec_Empresa_Depto) as Dom_Depto,
			convert(numeric(8),Espec_Empresa_Nro_Calle) as Dom_Nro_Calle,
			convert(varchar(60),Espec_Empresa_Dom_Calle) as Dom_Calle
			FROM [gd_esquema].[Maestra]
			GROUP BY 
			Espec_Empresa_Dom_Calle,
			Espec_Empresa_Nro_Calle,
			Espec_Empresa_Depto,
			Espec_Empresa_Piso,
			Espec_Empresa_Cod_Postal
	-- inserto usuarios de las empresas
	INSERT INTO GESTION_DE_GATOS.Usuarios (Usuario_User,Usuario_Pass,Usuario_Estado)
		SELECT convert(varchar(20),convert(numeric(15),SUBSTRING(Espec_Empresa_Cuit,0,3)+SUBSTRING(Espec_Empresa_Cuit,4,8)+SUBSTRING(Espec_Empresa_Cuit,13,2))),
		HASHBYTES('SHA2_256','palconet2018'),
		1 FROM gd_esquema.Maestra
		GROUP BY Espec_Empresa_Cuit
	-- inserto empresas
	INSERT INTO GESTION_DE_GATOS.Empresas 
	(Emp_Cuit,Emp_Razon_Social,Emp_Fecha_Creacion,Emp_Mail,Emp_Dom_Id,Emp_Usuario_Id)
		SELECT convert(numeric(15),SUBSTRING(Espec_Empresa_Cuit,0,3)+SUBSTRING(Espec_Empresa_Cuit,4,8)+SUBSTRING(Espec_Empresa_Cuit,13,2)),
		Espec_Empresa_Razon_Social,
		convert(smalldatetime,Espec_Empresa_Fecha_Creacion),
		convert(varchar(50),Espec_Empresa_Mail),
		Dom_Id,
		Usuario_Id
		FROM gd_esquema.Maestra 
		JOIN GESTION_DE_GATOS.Domicilios d ON Espec_Empresa_Dom_Calle+convert(varchar,Espec_Empresa_Nro_Calle) = d.Dom_Calle+convert(varchar,d.Dom_Nro_Calle)
		JOIN GESTION_DE_GATOS.Usuarios u ON u.Usuario_User = convert(numeric(15),SUBSTRING(Espec_Empresa_Cuit,0,3)+SUBSTRING(Espec_Empresa_Cuit,4,8)+SUBSTRING(Espec_Empresa_Cuit,13,2))
		GROUP BY Espec_Empresa_Cuit,Espec_Empresa_Razon_Social,Espec_Empresa_Fecha_Creacion,Espec_Empresa_Mail,Dom_Id,Usuario_Id
	-- inserto rubros de los espectaculos
	INSERT INTO GESTION_DE_GATOS.Rubros (Rubro_Descr) 
		SELECT Espectaculo_Rubro_Descripcion FROM gd_esquema.Maestra
		GROUP BY Espectaculo_Rubro_Descripcion
	-- inserto domicilios de los clientes
	INSERT INTO GESTION_DE_GATOS.Domicilios 
	(Dom_Cod_Postal,Dom_Piso,Dom_Depto,Dom_Nro_Calle,Dom_Calle)
	SELECT convert(numeric(4),Cli_Cod_Postal) as Dom_Cod_Postal,
		convert(varchar(8),Cli_Piso) as Dom_Piso,
		convert(char(4),Cli_Depto) as Dom_Depto,
		convert(numeric(8),Cli_Nro_Calle) as Dom_Nro_Calle,
		convert(varchar(60),Cli_Dom_Calle) as Dom_Calle 
		FROM gd_esquema.Maestra
		GROUP BY Cli_Dni,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal
		HAVING Cli_Dom_Calle is not null
	-- inserto tipos de doc
	INSERT INTO GESTION_DE_GATOS.Tipos_Doc (Tipo_Doc_Descr) VALUES('DNI')
	INSERT INTO GESTION_DE_GATOS.Tipos_Doc (Tipo_Doc_Descr) VALUES('Libreta Cívica')
	-- inserto usuarios para clientes
	declare @dni int
	set @dni = (SELECT top 1 Tipo_Doc_Id from GESTION_DE_GATOS.Tipos_Doc Where Tipo_Doc_Descr = 'DNI')
	INSERT INTO GESTION_DE_GATOS.Usuarios (Usuario_User,Usuario_Pass,Usuario_Estado)
		SELECT 
		@dni+convert(varchar,Cli_Dni),
		HASHBYTES('SHA2_256','palconet2018'),
		1 FROM gd_esquema.Maestra
		GROUP BY Cli_Dni
		HAVING Cli_Dni is not null
	-- inserto clientes
	INSERT INTO GESTION_DE_GATOS.Clientes
	(Cli_Tipo_Doc_Id,Cli_Doc,Cli_Apellido,Cli_Nombre,Cli_Fecha_Nac,
	 Cli_Fecha_Creacion,Cli_Mail,Cli_Domicilio_Id,Cli_Usuario_Id)
		SELECT @dni,
			convert(numeric(9),Cli_Dni),
			convert(varchar(30),Cli_Apeliido),
			convert(varchar(30),Cli_Nombre),
			convert(smalldatetime,Cli_Fecha_Nac),
			GETDATE(),
			convert(varchar(50),Cli_Mail),
			u.Usuario_Id,
			d.Dom_Id
		FROM gd_esquema.Maestra
		JOIN GESTION_DE_GATOS.Usuarios u ON u.Usuario_User = @dni+Cli_Dni
		JOIN GESTION_DE_GATOS.Domicilios d ON d.Dom_Calle+convert(varchar,d.Dom_Nro_Calle) = Cli_Dom_Calle+convert(varchar,Cli_Nro_Calle)
		GROUP BY Cli_Dni,Cli_Apeliido,Cli_Nombre,Cli_Fecha_Nac,Cli_Mail,u.Usuario_Id,d.Dom_Id
end
go

/*
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
DROP TABLE [GESTION_DE_GATOS].[Publicaciones_Tipo]
DROP TABLE [GESTION_DE_GATOS].[Espectaculos]
DROP TABLE [GESTION_DE_GATOS].[Facturas]
DROP TABLE [GESTION_DE_GATOS].[Empresas]
USE [GD2C2018]
DROP TABLE [GESTION_DE_GATOS].[Tipos_Doc]
GO
DROP SCHEMA [GESTION_DE_GATOS]
*/

