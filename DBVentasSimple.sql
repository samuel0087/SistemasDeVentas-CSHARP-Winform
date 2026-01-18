CREATE DATABASE DBVentasSimple;
USE DBVentasSimple;
CREATE TABLE Clientes(
    IdCliente int not null IDENTITY(1, 1) PRIMARY KEY,
    Nombre varchar(30) not null,
    Apellido varchar(30) not null,
    Dni varchar(30) not null UNIQUE,
    Telefono varchar(30) null,
    Email varchar(50) null,
    Estado bit not null
);

CREATE TABLE Productos(
    IdProducto int not null IDENTITY(1,1) PRIMARY KEY,
    Codigo varchar(10) not null UNIQUE,
    Nombre varchar(30) not null,
    Marca varchar(30) not null,
    Descripcion varchar(50) null,
    Precio decimal(10, 2) not null,
    Stock int not null CHECK (Stock >= 0),
    Estado bit not null
);

CREATE TABLE Ventas(
    IdVenta int not null IDENTITY(1, 1) PRIMARY KEY,
    IdCliente int not null,
    Fecha DATETIME not null,
    MontoFinal decimal(10,2) not null,
    CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes (IdCliente)
);

CREATE TABLE ProductosXVentas(
    IdVenta int not null,
    IdProducto int not null,
    Cantidad int not null CHECK (Cantidad > 0),
    MontoTotal decimal(10, 2) not null
    CONSTRAINT PK_ProductosXVentas PRIMARY KEY (IdVenta, IdProducto),
    CONSTRAINT FK_ProductosXVentas_Ventas FOREIGN KEY (IdVenta) REFERENCES Ventas (IdVenta),
    CONSTRAINT FK_ProductosXVentas_Productos FOREIGN KEY (IdProducto) REFERENCES Productos (IdProducto)
);

USE DBVentasSimple;
/*Carga Clientes*/
INSERT INTO Clientes (Nombre, Apellido, Dni, Telefono, Email, Estado) VALUES
('Juan', 'Pérez', '30123456', '1122334455', 'juan.perez@gmail.com', 1),
('María', 'Gómez', '28987654', '1144556677', 'maria.gomez@gmail.com', 1),
('Carlos', 'López', '33444555', NULL, 'carlos.lopez@gmail.com', 1),
('Ana', 'Martínez', '31222333', '1166778899', NULL, 1),
('Luis', 'Fernández', '27111222', '1199887766', 'luis.fernandez@gmail.com', 0);

/*Carga Productos*/
INSERT INTO Productos (Codigo, Nombre, Marca, Descripcion, Precio, Stock, Estado) VALUES
('P001', 'Mouse USB', 'Logitech', 'Mouse óptico', 8500.00, 25, 1),
('P002', 'Teclado', 'Genius', 'Teclado USB estándar', 12000.00, 15, 1),
('P003', 'Monitor 24', 'Samsung', 'Monitor LED 24 pulgadas', 95000.00, 8, 1),
('P004', 'Notebook', 'HP', 'Notebook i5 8GB RAM', 550000.00, 5, 1),
('P005', 'Parlantes', 'Sony', 'Parlantes estéreo', 30000.00, 0, 1),
('P006', 'Impresora', 'Epson', 'Impresora multifunción', 180000.00, 3, 0);


/*Carga Ventas*/
INSERT INTO Ventas (IdCliente, Fecha, MontoFinal) VALUES
(1, '2025-01-10 10:30:00', 20500.00),
(2, '2025-01-11 15:45:00', 95000.00),
(3, '2025-01-12 18:10:00', 567000.00);


/*Carga Productos ventas*/
-- Venta 1 (Juan Pérez)
INSERT INTO ProductosXVentas (IdVenta, IdProducto, Cantidad, MontoTotal) VALUES
(1, 1, 1, 8500.00),   -- Mouse
(1, 2, 1, 12000.00); -- Teclado

-- Venta 2 (María Gómez)
INSERT INTO ProductosXVentas (IdVenta, IdProducto, Cantidad, MontoTotal) VALUES
(2, 3, 1, 95000.00); -- Monitor

-- Venta 3 (Carlos López)
INSERT INTO ProductosXVentas (IdVenta, IdProducto, Cantidad, MontoTotal) VALUES
(3, 4, 1, 550000.00), -- Notebook
(3, 1, 2, 17000.00);  -- 2 Mouse



