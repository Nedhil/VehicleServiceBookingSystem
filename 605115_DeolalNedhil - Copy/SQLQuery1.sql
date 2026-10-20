CREATE Database WorkshopDB;
GO

Use WorkshopDB;
Go
CREATE TABLE ServiceBookings
(
BookingID INT PRIMARY KEY IDENTITY(1,1),
CustomerName VARCHAR(100) NOT NULL,
VehicleRegistration VARCHAR(20) NOT NULL,
ServiceType VARCHAR(50) NOT NULL,
BookingDate DATE NOT NULL,
Cost DECIMAL(10,2)NOT NULL
);
GO
INSERT INTO ServiceBookings (CustomerName, VehicleRegistration,ServiceType,BookingDate,Cost)
VALUES
(
'Nedhil Deolal','ABC123GP','Oil Chnage','2016-10-25',1200.00
),
(
'Mo Salah','XYZ890GP','Major Service','2016-10-28',3500.00
),
(
'Aubery Graham','SCR159GP','Brake Replacement','2016-11-02',2100.50
)