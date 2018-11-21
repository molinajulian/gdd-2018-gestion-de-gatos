
USE gdd_maestra;

CREATE TABLE Usuarios (
	username VARCHAR(20),
	password VARCHAR(20)
);

CREATE TABLE Rol (
	rol_nombre VARCHAR(20) PRIMARY KEY,
	rol_habilitado BIT DEFAULT 1
);

INSERT INTO Rol (rol_nombre) VALUES('Empresa');
INSERT INTO Rol (rol_nombre) VALUES('Administrativo');
INSERT INTO Rol (rol_nombre) VALUES('Cliente');

CREATE TABLE Funcionalidad_x_Rol (
	rol_nombre VARCHAR(20),
	func_nombre VARCHAR (20),
	PRIMARY KEY (rol_nombre, func_nombre));
	
CREATE TABLE Funcionalidad(
	func_nombre VARCHAR(20) PRIMARY KEY	
);
