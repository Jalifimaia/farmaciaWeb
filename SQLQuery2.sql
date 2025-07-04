

-- Crear la base de datos
CREATE DATABASE FarmaciaBBDD;
GO

-- Usar esa base de datos
USE FarmaciaBBDD;
GO

-- Crear tabla Medicamento
CREATE TABLE Medicamento (
    Id_Medicamento INT PRIMARY KEY IDENTITY(1,1),
    Nombre varchar(100) NOT NULL,
    Precio int NOT NULL,
    Stock INT NOT NULL,
    Fecha_Vencimiento DATE NOT NULL
);

INSERT INTO Medicamento (Nombre, Precio, Stock, Fecha_Vencimiento)
VALUES 
('Paracetamoliticos', 150.00, 50, '2025-12-01'),
('Ibuprofeno', 200.00, 30, '2024-10-15');

-- Crear tabla Rol
CREATE TABLE Rol (
	Id_Rol INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR(50)
);

-- Crear tabla Usuario
CREATE TABLE Usuario (
	Id_Usuario INT PRIMARY KEY IDENTITY(1,1),
	Nombre TEXT NOT NULL,
	Correo_Electronico  TEXT NOT NULL,
	Contraseña TEXT NOT NULL,
	Id_Rol INT NOT NULL,
	FOREIGN KEY (Id_Rol) REFERENCES Rol(Id_Rol)
);

-- Crear tabla Cliente
CREATE TABLE Cliente (
    Id_Cliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre TEXT NOT NULL,
    Apellido TEXT NOT NULL,
    Correo_Electronico TEXT NOT NULL,
    DNI VARCHAR(20) NOT NULL,
    Tipo_Cliente VARCHAR(50) NOT NULL
);

-- Crear tabla Ventas
CREATE TABLE Ventas (
	Id_Venta INT PRIMARY KEY IDENTITY(1,1),
	Fecha DATE NOT NULL,
	Total FLOAT NOT NULL,
	Id_Usuario INT NOT NULL,
	Id_Cliente INT NOT NULL,
	FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id_Cliente),
	FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
);

-- Crear tabla DetalleVenta
CREATE TABLE DetalleVenta (
    Id_Detalle INT PRIMARY KEY IDENTITY(1,1),
    Cantidad BIGINT NOT NULL,
    PrecioUnitario FLOAT NOT NULL,
    SubTotal FLOAT NOT NULL,
    Id_Venta INT NOT NULL,
    Id_Medicamento INT NOT NULL,
    FOREIGN KEY (Id_Venta) REFERENCES Ventas(Id_Venta),
    FOREIGN KEY (Id_Medicamento) REFERENCES Medicamento(Id_Medicamento)
);

-- =============================================
-- SP: Buscar Usuarios por Nombre o Correo
-- =============================================
GO
CREATE PROCEDURE sp_BuscarUsuarios
    @Criterio NVARCHAR(100)
AS
BEGIN
    SELECT Id_Usuario, Nombre, Correo_Electronico , Contraseña, Id_Rol
    FROM Usuario
    WHERE Nombre LIKE '%' + @Criterio + '%'
       OR Correo_Electronico LIKE '%' + @Criterio + '%';
END;
GO

 CREATE PROCEDURE sp_RegistrarCliente
     @Nombre VARCHAR(100),
     @Apellido VARCHAR(100),
     @Correo_Electronico VARCHAR(100),
     @DNI VARCHAR(20),
     @Tipo_Cliente VARCHAR(50)
 AS
 BEGIN
     INSERT INTO Cliente (Nombre, Apellido, Correo_Electronico, DNI, Tipo_Cliente)
     VALUES (@Nombre, @Apellido, @Correo_Electronico, @DNI, @Tipo_Cliente);
END;
 GO

CREATE PROCEDURE sp_BuscarCliente
    @Criterio VARCHAR(100)
AS
BEGIN
    SELECT * FROM Cliente
    WHERE Nombre LIKE '%' + @Criterio + '%'
       OR Tipo_Cliente LIKE '%' + @Criterio + '%';
END;
GO

CREATE PROCEDURE sp_ListarUsuarios
AS
BEGIN
    SELECT Id_Usuario, Nombre, Correo_Electronico, Contraseña, Id_Rol
    FROM Usuario;
END;
GO


-- Crear un cliente
INSERT INTO Cliente (Nombre, Apellido, Correo_Electronico, DNI, Tipo_Cliente)
VALUES ('Juan', 'Pérez', 'juan@gmail.com', '12345678', 'Normal');

-- Crear un usuario (vendedor)
INSERT INTO Rol (Id_Rol, Nombre) VALUES (1, 'Vendedor'); -- solo si no existe

INSERT INTO Usuario (Nombre, Correo_Electronico, Contraseña, Id_Rol)
VALUES ('Carlos Vendedor', 'carlos@farmacia.com', 'clave123', 1);

-- Crear un medicamento
INSERT INTO Medicamento (Nombre, Precio, Stock, Fecha_Vencimiento)
VALUES ('Paracetamol', 150, 100, '2025-12-01');

-- Verificar Cliente
SELECT * FROM Cliente;

-- Verificar Usuario
SELECT * FROM Usuario;

-- Verificar Medicamento
SELECT * FROM Medicamento;
select* from Ventas
-- Insertar en Ventas
INSERT INTO Ventas (Fecha, Total, Id_Usuario, Id_Cliente)
VALUES (GETDATE(), 300, 1, 1); -- ID válidos asumidos

-- Obtener el ID de la venta recién creada
DECLARE @IdVenta INT = SCOPE_IDENTITY();

-- Insertar detalle
INSERT INTO DetalleVenta (Cantidad, PrecioUnitario, SubTotal, Id_Venta, Id_Medicamento)
VALUES (2, 150, 300, @IdVenta, 1);
