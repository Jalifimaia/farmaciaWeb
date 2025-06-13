-- Crear la base de datos
CREATE DATABASE FarmaciaBBDD;
GO

-- Usar esa base de datos
USE FarmaciaBBDD;
GO

-- Crear tabla Medicamento
CREATE TABLE Medicamento (
    Id_Medicamento INT PRIMARY KEY IDENTITY(1,1),
    Nombre text NOT NULL,
    Precio int NOT NULL,
    Stock INT NOT NULL,
    Fecha_Vencimiento DATE NOT NULL
);


INSERT INTO Medicamento (Nombre, Precio, Stock, Fecha_Vencimiento)
VALUES 
('Paracetamoliticos', 150.00, 50, '2025-12-01'),
('Ibuprofeno', 200.00, 30, '2024-10-15');


select * from medicamento

 -- Crear tabla Rol

 CREATE TABLE Rol (
	Id_Rol INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR (50)
 );
 
 -- Crear tabla Usuario

 CREATE TABLE Usuario (
	Id_Usuario INT PRIMARY KEY IDENTITY (1,1),
	Nombre TEXT NOT NULL,
	Correo TEXT NOT NULL,
	Contrasenia TEXT NOT NULL,
	Id_Rol INT NOT NULL,
	FOREIGN KEY (Id_Rol)
	REFERENCES Rol (Id_Rol)
 );

 -- Crear tabla Cliente

 CREATE TABLE Cliente (
	Id_Cliente INT PRIMARY KEY IDENTITY (1,1),
	Nombre TEXT NOT NULL,
	Tipo_Perfil VARCHAR (50) NOT NULL
);


 -- Crear tabla Ventas

 CREATE TABLE Ventas (
	Id_Venta INT PRIMARY KEY IDENTITY (1,1),
	Fecha DATE NOT NULL,
	Total FLOAT NOT NULL,
	Id_Usuario INT NOT NULL,
	Id_Cliente INT NOT NULL,
	FOREIGN KEY (Id_Cliente)
	REFERENCES Cliente(Id_Cliente),
	FOREIGN KEY (Id_Usuario)
	REFERENCES Usuario(Id_Usuario)
);

-- Crear tabla DetalleVenta

CREATE TABLE DetalleVenta (
	Id_Detalle INT PRIMARY KEY IDENTITY (1,1),
	Cantidad BIGINT NOT NULL,
	PrecioUnitario FLOAT NOT NULL,
	SubTotal FLOAT NOT NULL,
	Id_Venta INT NOT NULL,
	Id_Medicamento INT NOT NULL
	FOREIGN KEY (Id_Venta)
	REFERENCES Ventas(Id_Venta),
	FOREIGN KEY (Id_Medicamento)
	REFERENCES Medicamento (Id_Medicamento)
);