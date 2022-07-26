--/*---------------------------TABLAS----------------------------------*/
--/*-------------------------------------------------------------------*/

--/*---------------TABLA SERVICIOS DISPONIBLES EN EL NEGOCIO-----------------------*/
CREATE TABLE SERVICIOS(
ID_SERVICIO INT NOT NULL IDENTITY(1,1),
NOMBRE_SERVICIO VARCHAR(20) NOT NULL,
PRIMARY KEY(ID_SERVICIO));

--/*--------------INSERTS SERVICIOS DISPONIBLES--------------------------------*/
INSERT INTO SERVICIOS(NOMBRE_SERVICIO) VALUES ('LAVADO');
INSERT INTO SERVICIOS(NOMBRE_SERVICIO) VALUES ('TIENDA');

-- SELECT * FROM SERVICIOS;
-- DROP TABLE SERVICIOS;
-- NO SE PUEDE ELIMINAR LA TABLA DE SERVICIOS DISPONIBLES, SI LA TABLA DE INVENTARIO TIENE ALGUN DATO!

--/*---------------TABLA INVENTARIO COMPLETO-----------------------*/
CREATE TABLE INVENTARIO_SERVICIOS(
ID_PRODUCTO INT NOT NULL IDENTITY(1,1),
DESCRIPCION VARCHAR(60) NOT NULL,
PRECIO DECIMAL(8,2) NOT NULL,
CANTIDAD_DISPONIBLE INT NOT NULL,
URL_IMAGE VARCHAR(100), 
ID_SERVICIO INT NOT NULL FOREIGN KEY REFERENCES SERVICIOS(ID_SERVICIO),
PRIMARY KEY(ID_PRODUCTO));

--/*--------------INSERTS INVENTARIO LAVADOS--------------------------------*/
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO1',5000,100,'',1);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO2',6000,100,'',1);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO3',7000,100,'',1);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO4',8000,100,'',1);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO5',9000,100,'',1);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO6',9600, 100,'',1);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO7',15000,100,'',1);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('LAVADO8',20000,100,'',1);
--/*--------------INSERTS INVENTARIO TIENDA--------------------------------*/
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO1',5000,100,'',2);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO2',6000,100,'',2);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO3',7000,100,'',2);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO4',8000,100,'',2);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO5',9000,100,'',2);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO6',12000, 100,'',2);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO7',15000,100,'',2);
INSERT INTO INVENTARIO_SERVICIOS(DESCRIPCION, PRECIO, CANTIDAD_DISPONIBLE, URL_IMAGE, ID_SERVICIO) 
VALUES('PRODUCTO8',20000,100,'',2);


-- DROP TABLE INVENTARIO_SERVICIOS;
-- SELECT * FROM INVENTARIO_SERVICIOS;
-- TRUNCATE TABLE INVENTARIO_SERVICIOS;

--/*---------------TABLA REGISTRO CAMBIOS DE INVENTARIO-----------------------*/
CREATE TABLE REGISTROS_INVENTARIO(
ID INT NOT NULL IDENTITY(1,1),
ACCION VARCHAR(100),
DESCRIPCION VARCHAR(100),
CANTIDAD INT,
FECHA DATE,
ID_SERVICIO INT FOREIGN KEY REFERENCES SERVICIOS(ID_SERVICIO),
PRIMARY KEY (ID)
);
--DROP TABLE REGISTROS_INVENTARIO;
--SELECT * FROM REGISTROS_INVENTARIO;
-- TRUNCATE TABLE REGISTROS_INVENTARIO;


--NOTAS--
--EL ID NO IMPORTA PORQUE SE VA A REINICIAR LA TABLA CADA VEZ QUE SE REGISTRE UN NUEVO USUARIO. SOLO SIRVE PARA EL "ORDEN" DE LOS PRODUCTOS EN EL CARRITO.
--NO SE PUEDE ELIMINAR O VACIAR LA TABLA INVENTARIO, SI CARRITO TIENE ALGUN DATO! _FK
-- FK evita que se elimina el valor que existe relacionado por el FK, en la tabla principal.

--/*---------------TABLA CARRITO DE LA COMPRA-----------------------*/
CREATE TABLE CARRITO(
ID_PROD INT NOT NULL IDENTITY(1,1),
DESCRIPCION VARCHAR(60) NOT NULL,
PRECIO DECIMAL(8,2) NOT NULL,
CANTIDAD INT NOT NULL,
TOTAL DECIMAL (10,2) NOT NULL,
ID_PRODUCTO INT NOT NULL FOREIGN KEY REFERENCES INVENTARIO_SERVICIOS(ID_PRODUCTO),
PRIMARY KEY(ID_PROD));

-- SELECT * FROM CARRITO;
-- TRUNCATE TABLE CARRITO;
-- DROP TABLE CARRITO;

CREATE TABLE REGISTROS_CARRITO(
ID INT NOT NULL IDENTITY(1,1),
ACCION VARCHAR(100),
DESCRIPCION VARCHAR(60) NOT NULL,
PRECIO DECIMAL(6,2) NOT NULL,
CANTIDAD INT NOT NULL,
FECHA DATE,
ID_PROD INT,
PRIMARY KEY (ID)
);

-- DROP TABLE REGISTROS_CARRITO;
-- SELECT * FROM REGISTROS_CARRITO;


--/*---------------TABLA EMPLEADOS & ROLES---------------*/

CREATE TABLE ROLES(
ID_ROL INT NOT NULL IDENTITY(1,1),
DESCRIPCION VARCHAR(50) NOT NULL,
ID_SERVICIO INT FOREIGN KEY REFERENCES SERVICIOS(ID_SERVICIO),
PRIMARY KEY(ID_ROL));


CREATE TABLE EMPLEADOS(
ID_EMPLEADO INT NOT NULL IDENTITY(1,1),
NOMBRE VARCHAR(100) NOT NULL,
APELLIDO1 VARCHAR(100) NOT NULL,
APELLIDO2 VARCHAR(100) NOT NULL,
USERNAME VARCHAR(100) NOT NULL,
PASSHASH BINARY(150) NOT NULL,
FECHA_INGRESO DATE NOT NULL,
CORREO VARCHAR(100) NOT NULL,
ID_ROL INT NOT NULL FOREIGN KEY REFERENCES SERVICIOS(ID_SERVICIO),
PRIMARY KEY (ID_EMPLEADO)
);

-- DROP TABLE EMPLEADOS;
-- DROP TABLE ROLES;
-- SELECT * FROM  EMPLEADOS;

--/*---------------TABLA REGISTRO COMPRAS COMPLETADAS-----------------------*/
CREATE TABLE REGISTRO_COMPRAS(
ID_COMPRA INT NOT NULL IDENTITY(1,1),
CEDULA_CLIENTE VARCHAR(20) NOT NULL,
NOMBRE_CLIENTE VARCHAR(50),
CORREO VARCHAR(100),
TELEFONO VARCHAR(100),
FECHA DATE,
TOTAL_COMPRA DECIMAL(10,2),
ID_METODO INT FOREIGN KEY REFERENCES METODOS_PAGO(ID_METODO),
ID_EMPLEADO INT NOT NULL FOREIGN KEY REFERENCES EMPLEADOS(ID_EMPLEADO),
NOMBRE_EMPLEADO VARCHAR(50),
PRIMARY KEY(ID_COMPRA));

CREATE TABLE METODOS_PAGO(
ID_METODO INT NOT NULL IDENTITY(1,1),
DESCRIPCION VARCHAR(50) NOT NULL,
PRIMARY KEY(ID_METODO));

INSERT INTO METODOS_PAGO(DESCRIPCION) 
VALUES('EFECTIVO');
INSERT INTO METODOS_PAGO(DESCRIPCION) 
VALUES('TARJETA');

-- SELECT * FROM METODOS_PAGO;


-- DROP TABLE REGISTRO_COMPRAS;
-- SELECT * FROM REGISTRO_COMPRAS;
-- TRUNCATE TABLE REGISTRO_COMPRAS;
--REGISTRO LLENA EL TOTAL CON EL CARRITO Y REGISTRA LOS DATOS DEL CLIENTE
--CLIENTES ATENDIDOS ES UN REGISTRO DE TODOS LOS CLIENTES QUE SE HA ATENDIDO, SIN REPETIR, POR CEDULA.

--se llena con un trigger a partir de los registros de compras.

--/*---------------TABLA REGISTRA CLIENTES ATENDIDOS (SIN DUPLICAR X CEDULA)--------------*/
CREATE TABLE CLIENTES_ATENDIDOS(
ID_CLIENTE INT NOT NULL IDENTITY(1,1),
CEDULA_CLIENTE VARCHAR(20) NOT NULL,
NOMBRE_CLIENTE VARCHAR(50),
CORREO VARCHAR(100),
TELEFONO VARCHAR(100),
FECHA DATE,
ID_COMPRA INT NOT NULL FOREIGN KEY REFERENCES REGISTRO_COMPRAS(ID_COMPRA),
PRIMARY KEY(ID_CLIENTE));

--SELECT * FROM CLIENTES_ATENDIDOS;
-- DROP TABLE CLIENTES_ATENDIDOS;



--/*---------------------------PROCEDIMIENTOS----------------------------------*/
--/*-------------------------------------------------------------------*/
--/*-------------------------------------------------------------------*/

--/*-----------------procedimiento para añadir empleado, con usuario y contraseña encriptada-----------------*/
GO
CREATE PROCEDURE añadeRol
    @DESCRIPCION VARCHAR(100), 
    @IDSERVICIO INT
AS
BEGIN
INSERT INTO ROLES(DESCRIPCION,ID_SERVICIO)
VALUES(@DESCRIPCION,@IDSERVICIO);
END;

-- DROP PROCEDURE añadeRol;
-- EXEC añadeRol @DESCRIPCION ='ADMIN',@IDSERVICIO = 1;
-- SELECT * FROM ROLES;
GO
CREATE PROCEDURE añadeEmpleado
    @PNOMBRE VARCHAR(100), 
    @PAPELLIDO1 VARCHAR(100), 
    @PAPELLIDO2 VARCHAR(100),
    @PUSERNAME VARCHAR(100),
    @PPASSWORD VARCHAR(100),
	@PFECHAINGRESO DATE,
	@PCORREO VARCHAR(100),
	@PIDROL INT
AS
BEGIN
SELECT @PFECHAINGRESO = GETDATE();
INSERT INTO EMPLEADOS(NOMBRE,APELLIDO1,APELLIDO2,USERNAME,PASSHASH,FECHA_INGRESO, CORREO, ID_ROL)
VALUES(@PNOMBRE,@PAPELLIDO1,@PAPELLIDO2,@PUSERNAME,HASHBYTES('SHA2_512', @PPASSWORD),@PFECHAINGRESO, @PCORREO, @PIDROL);
END;
-- DROP PROCEDURE añadeEmpleado;
-- EXEC añadeEmpleado @PNOMBRE ='MANU',@PAPELLIDO1 = 'GONZALEZ',@PAPELLIDO2 = 'VARELA', @PUSERNAME = 'MANU1',@PPASSWORD = '123',@PFECHAINGRESO = '',@PCORREO='manu_4_94@hotmail.com',@PIDROL = 1;
-- SELECT * FROM EMPLEADOS;

--/*-----procedimientos para vaciar carrito e inventario (no se pueden usar si existen llaves foraneas)----------------*/
GO  
CREATE PROCEDURE dbo.vaciarCarrito
AS   
TRUNCATE TABLE CARRITO;
GO  

GO  
CREATE PROCEDURE dbo.vaciarInventario
AS   
TRUNCATE TABLE INVENTARIO_SERVICIOS;
GO 


--/*-----procedimiento para validar login----------------*/
CREATE PROCEDURE validarUsuario  
    @PUSERNAME VARCHAR(100),
    @PPASSWORD VARCHAR(100)
AS
BEGIN
SELECT * FROM EMPLEADOS 
WHERE USERNAME=@PUSERNAME AND PASSHASH=HASHBYTES('SHA2_512', @PPASSWORD)
END;

--/*-----procedimiento para cambiar contraseña----------------*/
CREATE PROCEDURE cambiarContraseña
@PUSERNAME VARCHAR(50),
@PPASSWORD VARCHAR(50)
AS
BEGIN
UPDATE EMPLEADOS
   SET PASSHASH = HASHBYTES('SHA2_512', @PPASSWORD)
 WHERE USERNAME = @PUSERNAME
END;


-- EXEC cambiarContraseña @PUSERNAME = 'MANU1',@PPASSWORD = '1234';

-- select * from empleados;

/*
CREATE PROCEDURE validarUsuario  
    @PUSERNAME VARCHAR(100),
    @PPASSWORD VARCHAR(100)
AS
BEGIN
DECLARE
@USERID INT,
@responseMessage NVARCHAR(250)=''
    SET NOCOUNT ON
    IF EXISTS (SELECT TOP 1 ID_EMPLEADO FROM EMPLEADOS WHERE USERNAME=@PUSERNAME)
    BEGIN
        SET @USERID=(SELECT ID_EMPLEADO FROM EMPLEADOS WHERE USERNAME=@PUSERNAME AND PASSHASH=HASHBYTES('SHA2_512', @PPASSWORD))
     IF(@userID IS NULL)
           SET @responseMessage='Incorrect password'
       ELSE 
           SET @responseMessage='User successfully logged in'
    END
    ELSE
       SET @responseMessage='Invalid login'
END
GO
*/
-- drop procedure validarUsuario;

--/*---------------------------TRIGGERS----------------------------------*/
--/*-------------------------------------------------------------------*/

--REGISTRA CLIENTES (PASARLO A PROCEDIMIENTO PARA QUE HAYA "IF" DE SI YA EXISTE LA CÉDULA O NO)
/*
CREATE TRIGGER REGISTRACLIENTES
ON REGISTRO_COMPRAS
AFTER INSERT 
AS
BEGIN
DECLARE
@CEDULA_CLIENTE INT,
@NOMBRE_CLIENTE VARCHAR(50),
@CORREO VARCHAR(100),
@TELEFONO VARCHAR(100),
@FECHA DATE
SELECT @CEDULA_CLIENTE=INSERTED.CEDULA_CLIENTE,
@NOMBRE_CLIENTE=INSERTED.NOMBRE_CLIENTE,
@CORREO=INSERTED.CORREO,
@TELEFONO=INSERTED.TELEFONO,
@FECHA = INSERTED.FECHA FROM INSERTED;
INSERT INTO CLIENTES_ATENDIDOS(CEDULA_CLIENTE,NOMBRE_CLIENTE,CORREO,TELEFONO,FECHA) VALUES (@CEDULA_CLIENTE,@NOMBRE_CLIENTE,@CORREO,@TELEFONO,@FECHA);
END;
-- drop trigger REGISTRACLIENTES; 
*/


--/*-------------------------------------------------------------------*/
--/*----------------------TRIGGERS--------------------------------*/
--/*--------------REGISTRAN CAMBIOS EN EL INVENTARIO---------------------------*/
CREATE TRIGGER REGISTROINVENTARIO
ON INVENTARIO_SERVICIOS
AFTER INSERT
AS
BEGIN
DECLARE
@VACCION VARCHAR(250),
@DESCRIPCION VARCHAR(100),
@CANTIDAD INT,
@FECHA DATE,
@IDSERVICIO INT
SELECT @DESCRIPCION = INSERTED.DESCRIPCION,
@CANTIDAD = INSERTED.CANTIDAD_DISPONIBLE,
@IDSERVICIO = INSERTED.ID_SERVICIO,
@FECHA = GETDATE() FROM INSERTED;
INSERT INTO REGISTROS_INVENTARIO (ACCION, DESCRIPCION, CANTIDAD, FECHA, ID_SERVICIO) VALUES ('Se insertaron datos en INVENTARIO',@DESCRIPCION,@CANTIDAD,@FECHA,@IDSERVICIO);
END;
-- drop trigger REGISTROINVENTARIO;
--/*-------------------------------------------------------------------*/
CREATE TRIGGER REGISTROINVENTARIOUPDATE
ON INVENTARIO_SERVICIOS
AFTER UPDATE
AS
BEGIN
DECLARE
@VACCION VARCHAR(250),
@DESCRIPCION VARCHAR(100),
@CANTIDAD INT,
@FECHA DATE,
@IDSERVICIO INT
SELECT @DESCRIPCION = INSERTED.DESCRIPCION,
@CANTIDAD = INSERTED.CANTIDAD_DISPONIBLE,
@IDSERVICIO = INSERTED.ID_SERVICIO,
@FECHA = GETDATE() FROM INSERTED;
INSERT INTO REGISTROS_INVENTARIO (ACCION, DESCRIPCION, CANTIDAD, FECHA, ID_SERVICIO) VALUES ('Se actualizaron datos en INVENTARIO',@DESCRIPCION,@CANTIDAD,@FECHA, @IDSERVICIO);
END;
-- drop trigger REGISTROINVENTARIOUPDATE;
--/*-------------------------------------------------------------------*/
CREATE TRIGGER REGISTROINVENTARIODELETE
ON INVENTARIO_SERVICIOS
AFTER DELETE
AS
BEGIN
DECLARE
@VACCION VARCHAR(250),
@DESCRIPCION VARCHAR(100),
@CANTIDAD INT,
@FECHA DATE,
@IDSERVICIO INT
SELECT @DESCRIPCION = DELETED.DESCRIPCION,
@CANTIDAD = DELETED.CANTIDAD_DISPONIBLE,
@IDSERVICIO = DELETED.ID_SERVICIO,
@FECHA = GETDATE() FROM DELETED;
INSERT INTO REGISTROS_INVENTARIO (ACCION, DESCRIPCION, CANTIDAD, FECHA, ID_SERVICIO) VALUES ('Se eliminaron datos en INVENTARIO',@DESCRIPCION,@CANTIDAD,@FECHA,@IDSERVICIO);
END;
-- drop trigger REGISTROINVENTARIODELETE;
--/*-------------------------------------------------------------------*/


--/*-------------------------------------------------------------------*/
--/*--------------REGISTRAN CAMBIOS EN EL CARRITO-------------*/
CREATE TRIGGER REGISTROCARRITO
ON CARRITO
AFTER INSERT
AS
BEGIN
DECLARE
@VACCION VARCHAR(250),
@DESCRIPCION VARCHAR(100),
@CANTIDAD INT,
@PRECIO DECIMAL,
@FECHA DATE,
@ID_PROD INT
SELECT @DESCRIPCION = INSERTED.DESCRIPCION,
@CANTIDAD = INSERTED.CANTIDAD,
@PRECIO = INSERTED.PRECIO,
@ID_PROD = INSERTED.ID_PROD,
@FECHA = GETDATE() FROM INSERTED;
INSERT INTO REGISTROS_CARRITO (ACCION, DESCRIPCION,PRECIO, CANTIDAD, FECHA, ID_PROD) VALUES ('Se insertaron datos en CARRITO',@DESCRIPCION, @PRECIO,@CANTIDAD,@FECHA, @ID_PROD);
END;
-- drop trigger REGISTROCARRITO;
--/*-------------------------------------------------------------------*/
CREATE TRIGGER REGISTROCARRITOUPDATE
ON CARRITO
AFTER UPDATE
AS
BEGIN
DECLARE
@VACCION VARCHAR(250),
@DESCRIPCION VARCHAR(100),
@PRECIO DECIMAL,
@CANTIDAD INT,
@FECHA DATE
SELECT @DESCRIPCION = INSERTED.DESCRIPCION,
@PRECIO = INSERTED.PRECIO,
@CANTIDAD = INSERTED.CANTIDAD,
@FECHA = GETDATE() FROM INSERTED;
INSERT INTO REGISTROS_CARRITO (ACCION, DESCRIPCION, PRECIO, CANTIDAD, FECHA) VALUES ('Se actualizaron datos en CARRITO',@DESCRIPCION,@PRECIO, @CANTIDAD,@FECHA);
END;
-- drop trigger REGISTROINVENTARIOUPDATE;
--/*-------------------------------------------------------------------*/
CREATE TRIGGER REGISTROCARRITODELETE
ON CARRITO
AFTER DELETE
AS
BEGIN
DECLARE
@VACCION VARCHAR(250),
@DESCRIPCION VARCHAR(100),
@PRECIO DECIMAL,
@CANTIDAD INT,
@FECHA DATE
SELECT @DESCRIPCION = DELETED.DESCRIPCION,
@PRECIO = DELETED.PRECIO,
@CANTIDAD = DELETED.CANTIDAD,
@FECHA = GETDATE() FROM DELETED;
INSERT INTO REGISTROS_CARRITO (ACCION, DESCRIPCION, PRECIO, CANTIDAD, FECHA) VALUES ('Se eliminaron datos en CARRITO',@DESCRIPCION,@PRECIO, @CANTIDAD,@FECHA);
END;
-- drop trigger REGISTROCARRITODELETE;


















