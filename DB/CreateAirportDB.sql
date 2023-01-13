CREATE DATABASE AirportDB;

USE AirportDB;

CREATE TABLE `Country` (
    `CountryId` int  NOT NULL AUTO_INCREMENT,
    `Name` nvarchar(500)  NOT NULL ,
    PRIMARY KEY (
        `CountryId`
    )
);

CREATE TABLE `City` (
    `CityId` int NOT NULL AUTO_INCREMENT,
    `Name` nvarchar(500)  NOT NULL ,
    `CountryID` int  NOT NULL ,
    PRIMARY KEY (
        `CityId`
    )
);

CREATE TABLE `Airport` (
    `AirportId` int  NOT NULL AUTO_INCREMENT,
    `Name` nvarchar(255)  NOT NULL ,
    `CityID` int NOT NULL ,
    PRIMARY KEY (
        `AirportId`
    )
);

CREATE TABLE `Airplane` (
    `AirplaneId` int NOT NULL AUTO_INCREMENT,
    `Capacity` smallint  NOT NULL ,
    `Description` nvarchar(3000)  NULL ,
    PRIMARY KEY (
        `AirplaneId`
    )
);

CREATE TABLE `Department` (
    `DepartmentId` int NOT NULL AUTO_INCREMENT,
    `Name` nvarchar(255)  NOT NULL ,
    PRIMARY KEY (
        `DepartmentId`
    )
);

CREATE TABLE `Employee` (
    `EmployeeId` int NOT NULL AUTO_INCREMENT,
    `FirstName` nvarchar(500)  NOT NULL ,
    `LastName` nvarchar(500)  NOT NULL ,
    `BirthDate` datetime  NOT NULL ,
    `AdditionalInformation` nvarchar(3000)  NULL ,
    `DepartmentId` int NOT NULL,
    PRIMARY KEY (
        `EmployeeId`
    )
);

CREATE TABLE `Flight` (
    `FlightId` int NOT NULL AUTO_INCREMENT,
    `Departure` DateTime  NOT NULL ,
    `Arrival` DateTime  NOT NULL ,
    `DepartureAirportId` int  NOT NULL ,
    `ArrivalAirportId` int  NOT NULL ,
    `AirplaneId` int NOT NULL ,
    PRIMARY KEY (
        `FlightId`
    )
);

CREATE TABLE `FlightStaff` (
    `FlightId` int  NOT NULL AUTO_INCREMENT,
    `EmployeeId` int  NOT NULL ,
    PRIMARY KEY (
        `FlightId`,`EmployeeId`
    )
);

CREATE TABLE `Passenger` (
    `PassengerId` int NOT NULL AUTO_INCREMENT,
    `FirstName` nvarchar(500)  NOT NULL ,
    `LastName` nvarchar(500)  NOT NULL ,
    `PassportNumber` nvarchar(255)  NOT NULL ,
    PRIMARY KEY (
        `PassengerId`
    ),
    CONSTRAINT `uc_Passenger_PassportNumber` UNIQUE (
        `PassportNumber`
    )
);

CREATE TABLE `Booking` (
    `BookingId` int NOT NULL AUTO_INCREMENT,
    `TransactionDate` Datetime  NOT NULL ,
    `PassengerId` int  NOT NULL ,
    `Seat` smallint  NOT NULL ,
    `Cost` decimal(15,2) NOT NULL ,
    `FlightId` int  NOT NULL ,
    PRIMARY KEY (
        `BookingId`
    )
);

ALTER TABLE `City` ADD CONSTRAINT `fk_City_CountryID` FOREIGN KEY(`CountryID`)
REFERENCES `Country` (`CountryId`);

ALTER TABLE `Airport` ADD CONSTRAINT `fk_Airport_CityID` FOREIGN KEY(`CityID`)
REFERENCES `City` (`CityId`);

ALTER TABLE `Employee` ADD CONSTRAINT `fk_Employee_DepartmentId` FOREIGN KEY(`DepartmentId`)
REFERENCES `Department` (`DepartmentId`);

ALTER TABLE `Flight` ADD CONSTRAINT `fk_Flight_DepartureAirportId` FOREIGN KEY(`DepartureAirportId`)
REFERENCES `Airport` (`AirportId`);

ALTER TABLE `Flight` ADD CONSTRAINT `fk_Flight_ArrivalAirportId` FOREIGN KEY(`ArrivalAirportId`)
REFERENCES `Airport` (`AirportId`);

ALTER TABLE `Flight` ADD CONSTRAINT `fk_Flight_AirplaneId` FOREIGN KEY(`AirplaneId`)
REFERENCES `Airplane` (`AirplaneId`);

ALTER TABLE `FlightStaff` ADD CONSTRAINT `fk_FlightStaff_FlightId` FOREIGN KEY(`FlightId`)
REFERENCES `Flight` (`FlightId`);

ALTER TABLE `FlightStaff` ADD CONSTRAINT `fk_FlightStaff_EmployeeId` FOREIGN KEY(`EmployeeId`)
REFERENCES `Employee` (`EmployeeId`);

ALTER TABLE `Booking` ADD CONSTRAINT `fk_Booking_PassengerId` FOREIGN KEY(`PassengerId`)
REFERENCES `Passenger` (`PassengerId`);

ALTER TABLE `Booking` ADD CONSTRAINT `fk_Booking_FlightId` FOREIGN KEY(`FlightId`)
REFERENCES `Flight` (`FlightId`);

