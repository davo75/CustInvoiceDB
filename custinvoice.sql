--
-- Database:	`041110777_invoice`
-- Author:		David Pyle 041110777
 			
DROP SCHEMA IF EXISTS 041110777_invoice;
CREATE SCHEMA 041110777_invoice;
USE 041110777_invoice;

CREATE TABLE Customer (
	CustNum 		smallint(5) unsigned 		NOT NULL AUTO_INCREMENT,
	FirstName 		varchar(30) 				NOT NULL,
	LastName		varchar(30) 				NOT NULL,	
	StreetName 		varchar(30) 			 	NOT NULL,
	Suburb 			varchar(20)			 		NOT NULL,
	AddressState 	varchar(30) 				NOT NULL,
	PostCode 		varchar(10) 				NOT NULL,
	ContactPhone 	varchar(30)					NOT NULL,
	Company 		varchar(30) 				NOT NULL,
	
	PRIMARY KEY (CustNum)
  
);

INSERT INTO Customer (CustNum, FirstName, LastName, StreetName, Suburb, AddressState, PostCode, ContactPhone, Company) VALUES
(1, "Valentino", 	"Rossi", 		"46 Grand Prom", 		"Dianella", 	"WA", 	"6059", "0478220117",	"Yamaha"),
(2, "Jorge", 		"Lorenzo", 		"99 Flinders Ave", 		"Darwin", 		"NT", 	"6061", "0478221847", 	"Yamaha"),
(3, "Marc", 		"Marquez", 		"93 Mill Lane", 		"Melbourne", 	"VIC", 	"6061", "1512281438", 	"Honda"),
(4, "Dani", 		"Pedrosa", 		"26 Rundle St", 		"Adelaide", 	"SA", 	"6000", "0478220114", 	"Honda"),
(5, "Andrea", 		"Iannone", 		"29 Craven Avenue", 	"Canberra", 	"ACT", 	"6000", "0456322954", 	"Ducati"),
(6, "Andrea", 		"Dovizioso", 	"4 Edgedale Road", 		"Sydney", 		"NSW", 	"6000", "0328475912", 	"Ducati"),
(7, "Bradley", 		"Smith", 		"38 Blossom Avenue", 	"Brisbane", 	"QLD", 	"6000", "0858733992", 	"Yamaha");


CREATE TABLE Item (
	ItemNum 		smallint(5) unsigned 		NOT NULL AUTO_INCREMENT,
	ItemName 		varchar(30) 				NOT NULL,
	Description		varchar(50) 				NOT NULL,
	Cost 			decimal(10,2) 				NOT NULL,	
	
	PRIMARY KEY (ItemNum)
	
);

INSERT INTO Item (ItemNum, ItemName, Description, Cost) VALUES
(1, "Mouse", 		"Wireless Mouse", 				14.99),
(2, "Macbook Pro", 	"i7 8Gb RAM 15-inch", 			1450.00),
(3, "Monitor", 		"DELL 16:9 24inch", 			350.00),
(4, "Dock", 		"USB HDMI DVI Dual Monitor",	200.00),
(5, "Keyboard", 	"Wireless Keyboard", 			34.99),
(6, "USB Drive", 	"SanDisk 16GB", 				59.00);


CREATE TABLE Invoice (
	InvoiceNum 		smallint(5) unsigned 		NOT NULL AUTO_INCREMENT,
	PaymentStatus 	boolean		 				NOT NULL,
	PaymentDate		date		 				NOT NULL,
	PaymentDueDate	date		 				NOT NULL,
	CustNum 		smallint(5) unsigned		NOT NULL,
	
	PRIMARY KEY (InvoiceNum),
	FOREIGN KEY (CustNum) 	REFERENCES Customer (CustNum) 	ON DELETE CASCADE ON UPDATE CASCADE
  
);
INSERT INTO Invoice (InvoiceNum, PaymentStatus, PaymentDate, PaymentDueDate, CustNum) VALUES
(1, false, '2016-01-01', '2016-06-01',1),
(2, false, '2016-01-01', '2016-06-01',1),
(3, false, '2016-01-01', '2016-06-01',2),
(4, false, '2016-01-01', '2016-06-01',5);


CREATE TABLE InvoiceItem (
	InvoiceNum 		smallint(5) unsigned 		NOT NULL,
	ItemNum 		smallint(5) unsigned 		NOT NULL,
	Qty 			smallint(5) 				NOT NULL,
	
	PRIMARY KEY (InvoiceNum, ItemNum),
	FOREIGN KEY (InvoiceNum) 		REFERENCES Invoice (InvoiceNum) 		ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ItemNum) 			REFERENCES Item (ItemNum) 				ON DELETE CASCADE ON UPDATE CASCADE
	
);

INSERT INTO InvoiceItem (InvoiceNum, ItemNum, Qty) VALUES
(1,1,2),
(1,2,2),
(2,3,1),
(2,4,2),
(3,5,3),
(3,6,4),
(4,1,2),
(4,2,2),
(4,3,1);

DROP PROCEDURE IF EXISTS InsertCust;

DELIMITER //

CREATE PROCEDURE InsertCust(OUT CustNum INT, IN FirstName VARCHAR(30), IN LastName VARCHAR(30), IN StreetName VARCHAR(30), IN Suburb VARCHAR(20), IN AddressState VARCHAR(30), IN PostCode VARCHAR(10), IN ContactPhone VARCHAR(30), IN Company VARCHAR(30))
BEGIN
	SET @FirstName = FirstName;
    SET @LastName = LastName;
    SET @StreetName = StreetName;
    SET @Suburb = Suburb;
    SET @AddressState = AddressState;
    SET @PostCode = PostCode;
    SET @ContactPhone = ContactPhone;
    SET @Company = Company;
    
  INSERT INTO customer (FirstName, LastName, StreetName, Suburb, AddressState, PostCode, ContactPhone, Company)
 VALUES (@FirstName, @LastName, @StreetName, @Suburb, @AddressState, @PostCode, @ContactPhone, @Company);

  SET CustNum = LAST_INSERT_ID();
END//

DELIMITER ;

DROP PROCEDURE IF EXISTS InsertInv;

DELIMITER //

CREATE PROCEDURE InsertInv(OUT InvoiceNum INT, IN PaymentStatus boolean, IN PaymentDate date, IN PaymentDueDate date, IN CustNum smallint(5))
BEGIN
	SET @PaymentStatus = PaymentStatus;
    SET @PaymentDate = PaymentDate;
    SET @PaymentDueDate = PaymentDueDate;
	SET @CustNum = CustNum;
    
  INSERT INTO Invoice (PaymentStatus, PaymentDate, PaymentDueDate, CustNum)
 VALUES (@PaymentStatus, @PaymentDate, @PaymentDueDate, @CustNum);

  SET InvoiceNum = LAST_INSERT_ID();
END//

DELIMITER ;
