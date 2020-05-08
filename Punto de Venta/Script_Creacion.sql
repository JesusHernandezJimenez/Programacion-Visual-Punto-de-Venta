create database puntoventa;
use puntoventa;
CREATE  TABLE proveedor(
  idproveedor INT NOT NULL identity(1,1) ,
  nombrepro VARCHAR(255) NULL ,
  direccion TEXT NULL ,
  rfc VARCHAR(18) NULL ,
  telefono VARCHAR(20) NULL ,
  PRIMARY KEY (idproveedor)); 

CREATE TABLE productos(
  idproducto INT NOT NULL identity(1,1) ,
  nombre varchar(100),
  descripcion TEXT NULL ,
  marca VARCHAR(45) NULL ,
  precio DECIMAL(12,2) NULL ,
  costo DECIMAL(12,2) NULL ,
  minimo INT NULL ,  /*la cantidad minima del prodcuto*/
  stok int,   /*cantidad en stok o en tienda*/
  idproveedorpro INT NOT NULL FOREIGN KEY REFERENCES proveedor(idproveedor), /*un producto es obtenido de un proveedor*/
  PRIMARY KEY (idproducto)
  );
CREATE INDEX fkindex ON productos (idproveedorpro);

CREATE TABLE almacen (
  idalmacen INT NOT NULL IDENTITY(1,1) ,
  cantidad INT NULL ,  
  idproductoalm int NOT NULL FOREIGN KEY REFERENCES productos(idproducto),
  PRIMARY KEY (idalmacen));
CREATE INDEX fkindex33 ON almacen (idproductoalm);


CREATE TABLE detcompras(
	iddetcompras int not null IDENTITY(1,1),
  cantidad_ind INT NULL ,  /*cantidad individual de cada producto*/
  precio DECIMAL(12,2) NULL , /*precio de compra*/
  subtotal decimal(12,2), /* total de la suma a pagar por ese pro*/
primary key(iddetcompras));

 CREATE TABLE compras ( /*un comprando productos a un proveedor*/
  idcompra INT NOT NULL IDENTITY(1,1) ,
  fecha DATE NULL , /*fecha de la compra*/
  cantidad_pro int, /*cantidad total de articulos comprados*/
  total DECIMAL(12,2) NULL , /*total de dinero de los aerticulos comprados*/
  idproductocom INT NOT NULL FOREIGN KEY REFERENCES productos(idproducto),  
  iddetcomprascom int NOT NULL FOREIGN KEY REFERENCES detcompras(iddetcompras),
  PRIMARY KEY (idcompra));
CREATE INDEX fkindex ON compras(idproductocom);
CREATE INDEX fkindex2 ON compras(iddetcomprascom);



  CREATE TABLE cliente (
  idcliente INT NOT NULL IDENTITY(1,1) ,
  nombre VARCHAR(255) NULL ,
  direccion TEXT NULL ,
  telefono VARCHAR(20) NULL ,
  PRIMARY KEY (idcliente));

  CREATE TABLE empleado (
  idempleado INT NOT NULL IDENTITY(1,1) ,
  nombre VARCHAR(255) NULL ,
  direccion varchar(255) NULL ,
  telefono VARCHAR(20) NULL ,
  usuario varchar(100),
  contrasenia varchar(100),
  sexo CHAR(2) NULL ,
  fecha_nacimiento DATE NULL ,
  cargo VARCHAR(30) NULL ,
 PRIMARY KEY (idempleado));

CREATE TABLE ventas ( /*ES ÚNICAMENTE PARA ALMACENAR TODO EL PROCESO DE VENTA DE UN PRODUCTO*/
  idventa INT NOT NULL IDENTITY(1,1) ,    /*SI TIENE RELACIÓN CON EL EMPLEADO Y EL CLIENTE*/
  fecha date,
  cantidadto INT NULL ,  /*cantidad individual de cada producto*/
  total decimal(12,2), /* total de la suma a pagar por ese pro*/
  idclienteven int NOT NULL FOREIGN KEY REFERENCES cliente(idcliente),
  idempleadoven int NOT NULL FOREIGN KEY REFERENCES empleado(idempleado),
  PRIMARY KEY (idventa));
CREATE INDEX fkindex1 ON ventas(idclienteven);
CREATE INDEX fkindex2 ON ventas(idempleadoven);


CREATE TABLE detventas(
iddetventas int not null IDENTITY(1,1),
  cantidad INT NULL ,  /*cantidad individuall de cada producto*/
  nombre varchar(255),
  precio DECIMAL(12,2) NULL , /*precio de compra*/
  subtotal DECIMAL(12,2),
    iddetventasven int NOT NULL FOREIGN KEY REFERENCES ventas(idventa),
 /* idproductoven int, POR QUE NO ESTÁ RELACIONADO? POR QUE SI EL PRODUCTO ACTUALIZA, SU PRECIO AFECTA LA VENTA
  INDEX fkindex3(idproductoven),    */
primary key(iddetventas));
CREATE INDEX fkindex ON detventas(iddetventasven);
