-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 07. Mrz 2021 um 23:06
-- Server-Version: 10.4.17-MariaDB
-- PHP-Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `db_pva`
--
CREATE DATABASE IF NOT EXISTS `db_pva` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_pva`;

DELIMITER $$
--
-- Prozeduren
--
DROP PROCEDURE IF EXISTS `DeleteAllContracts`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllContracts` ()  BEGIN

	DELETE FROM tb_contracts;
    ALTER TABLE tb_contracts AUTO_INCREMENT = 1;
    
END$$

DROP PROCEDURE IF EXISTS `DeleteAllDepartments`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllDepartments` ()  BEGIN

	DELETE FROM tb_departments;
    ALTER TABLE tb_departments AUTO_INCREMENT = 1;
END$$

DROP PROCEDURE IF EXISTS `DeleteAllEmployees`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllEmployees` ()  BEGIN

	DELETE FROM tb_employees;
    ALTER TABLE tb_employees AUTO_INCREMENT = 1;
END$$

DROP PROCEDURE IF EXISTS `DeleteAllPositions`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllPositions` ()  BEGIN

	DELETE FROM tb_positions;
    ALTER TABLE tb_positions AUTO_INCREMENT = 1;    
END$$

DROP PROCEDURE IF EXISTS `DeleteAllRooms`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllRooms` ()  BEGIN

	DELETE FROM tb_rooms;
    ALTER TABLE tb_rooms AUTO_INCREMENT = 1;    
END$$

DROP PROCEDURE IF EXISTS `DeleteContract`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteContract` (IN `C_ID` INT)  BEGIN

	DELETE FROM tb_contracts
    WHERE tb_contracts.C_ID = C_ID;
    
END$$

DROP PROCEDURE IF EXISTS `DeleteDepartment`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteDepartment` (IN `D_ID` INT)  BEGIN

	DELETE FROM tb_departments
    WHERE tb_departments.D_ID = D_ID;
    
END$$

DROP PROCEDURE IF EXISTS `DeleteEmployee`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteEmployee` (IN `E_ID` INT)  BEGIN
	DELETE FROM tb_employees
    WHERE tb_employees.E_ID = E_ID;
END$$

DROP PROCEDURE IF EXISTS `DeletePosition`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeletePosition` (IN `P_ID` INT)  BEGIN

	DELETE FROM tb_positions
    WHERE tb_positions.P_ID = P_ID;
    
END$$

DROP PROCEDURE IF EXISTS `DeleteRoom`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteRoom` (IN `R_ID` INT)  BEGIN

	DELETE FROM tb_rooms
    WHERE tb_rooms.R_ID = R_ID;
    
END$$

DROP PROCEDURE IF EXISTS `GetAllContracts`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllContracts` ()  BEGIN

	SELECT C_ID AS ID, Matchcode, Name, WorkTime, Holidays, Salary, Start, End, TrailEnd, Description, HasEnd FROM tb_contracts;
    
END$$

DROP PROCEDURE IF EXISTS `GetAllDepartments`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllDepartments` ()  BEGIN

	SELECT D_ID AS ID, Matchcode, Name, CostCenter, Manager, Description FROM tb_departments;
    ALTER TABLE tb_departments AUTO_INCREMENT = 1;
    
END$$

DROP PROCEDURE IF EXISTS `GetAllEmployees`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllEmployees` ()  BEGIN
		SELECT E_ID AS ID, Matchcode, Gender, Forename, Surname, Birth, PhoneNumber, Email, Department, Position, Contract, AdditionalInformation, Street, StreetNumber, City, PostalCode FROM tb_employees;
END$$

DROP PROCEDURE IF EXISTS `GetAllPositions`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllPositions` ()  BEGIN

	SELECT P_ID AS ID, Matchcode, Name, Description FROM tb_positions;
    
END$$

DROP PROCEDURE IF EXISTS `GetAllRooms`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllRooms` ()  BEGIN

	SELECT R_ID AS ID, Matchcode, Name, RoomNumber, FloorNumber, Size, Description FROM tb_rooms;

END$$

DROP PROCEDURE IF EXISTS `GetContract`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetContract` (IN `C_ID` INT)  BEGIN

	SELECT C_ID AS ID, Matchcode, Name, WorkTime, Holidays, Salary, Start, End, TrailEnd, Description, HasEnd FROM tb_contracts
    WHERE tb_contracts.C_ID = C_ID;
    
END$$

DROP PROCEDURE IF EXISTS `GetDepartment`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDepartment` (IN `D_ID` INT)  BEGIN

	SELECT D_ID AS ID, Matchcode, Name, CostCenter, Manager, Description FROM tb_departments
    WHERE tb_departments.D_ID = D_ID;
    
END$$

DROP PROCEDURE IF EXISTS `GetEmployee`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEmployee` (IN `E_ID` INT)  BEGIN

	SELECT E_ID AS ID, Matchcode, Gender, Forename, Surname, Birth, PhoneNumber, Email, Department, Position, Contract, AdditionalInformation, Street, StreetNumber, City, PostalCode 
            WHERE tb_employees.E_ID = E_ID;
    
END$$

DROP PROCEDURE IF EXISTS `GetPosition`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPosition` (IN `P_ID` INT)  BEGIN

	SELECT P_ID AS ID, Matchcode, Name, Description FROM tb_positions
    WHERE tb_positions.P_ID = P_ID;
    
END$$

DROP PROCEDURE IF EXISTS `GetRoom`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetRoom` (IN `R_ID` INT)  BEGIN

	SELECT * FROM tb_rooms
    WHERE tb_rooms.R_ID = R_ID;
    
END$$

DROP PROCEDURE IF EXISTS `GetRoomID`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetRoomID` (IN `Matchcode` VARCHAR(255))  BEGIN

	SELECT tb_rooms.R_ID FROM tb_rooms
    WHERE tb_rooms.Matchcode = Matchcode;
    
END$$

DROP PROCEDURE IF EXISTS `SaveContract`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SaveContract` (IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `WorkTime` INT, IN `Holidays` INT, IN `Salary` INT, IN `Start` DATE, IN `End` DATE, IN `TrailEnd` DATE, IN `Description` VARCHAR(255), IN `HasEnd` BOOLEAN)  BEGIN

	INSERT INTO tb_contracts (Matchcode, Name, WorkTime, Holidays, Salary, Start, End, TrailEnd, Description, HasEnd)
    VALUES (Matchcode, Name, WorkTime, Holidays, Salary, Start, End, TrailEnd, Description, HasEnd);
    
END$$

DROP PROCEDURE IF EXISTS `SaveDepartment`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SaveDepartment` (IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `CostCenter` VARCHAR(255), IN `Manager` INT, IN `Description` VARCHAR(255))  BEGIN

	INSERT INTO tb_departments (Matchcode, Name, CostCenter, Manager, Description)
    VALUES (Matchcode, Name, CostCenter, Manager, Description);
    
END$$

DROP PROCEDURE IF EXISTS `SaveEmployee`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SaveEmployee` (IN `Matchcode` VARCHAR(255), IN `Gender` INT, IN `Forename` VARCHAR(255), IN `Surname` VARCHAR(255), IN `Birth` DATE, IN `PhoneNumber` VARCHAR(255), IN `Email` VARCHAR(255), IN `Department` INT, IN `Position` INT, IN `Contract` INT, IN `AdditionalInformation` VARCHAR(255), IN `Street` VARCHAR(255), IN `StreetNumber` VARCHAR(255), IN `City` VARCHAR(255), IN `PostalCode` VARCHAR(255))  BEGIN
	INSERT INTO tb_employees (Matchcode, Gender, Forename, Surname, Birth, PhoneNumber, Email, Department, Position, Contract, AdditionalInformation, Street, StreetNumber, City, PostalCode)
    VALUES (Matchcode, Gender, Forename, Surname, Birth, PhoneNumber, Email, Department, Position, Contract, AdditionalInformation, Street, StreetNumber, City, PostalCode);

END$$

DROP PROCEDURE IF EXISTS `SavePosition`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SavePosition` (IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `Description` VARCHAR(255))  BEGIN

	INSERT INTO tb_positions (Matchcode, Name, Description)
    VALUES (Matchcode, Name, Description);
    
END$$

DROP PROCEDURE IF EXISTS `SaveRoom`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SaveRoom` (IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `RoomNumber` INT, IN `FloorNumber` INT, IN `Size` INT, IN `Description` VARCHAR(255))  BEGIN

	INSERT INTO tb_rooms (Matchcode, Name, RoomNumber, FloorNumber, Size, Description)
    VALUES (Matchcode, Name, RoomNumber, FloorNumber, Size, Description);
    
END$$

DROP PROCEDURE IF EXISTS `SaveRoomEmployees`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SaveRoomEmployees` (IN `R_ID` INT, IN `E_ID` INT)  BEGIN

	INSERT INTO tb_roomsemployees (R_ID, E_ID)
    VALUES (R_ID, E_ID);
    
END$$

DROP PROCEDURE IF EXISTS `UpdateContract`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateContract` (IN `C_ID` INT, IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `WorkTime` INT, IN `Holidays` INT, IN `Salary` INT, IN `Start` DATE, IN `End` DATE, IN `TrailEnd` DATE, IN `Description` VARCHAR(255), IN `HasEnd` BOOLEAN)  BEGIN

	CALL DeleteContract(C_ID);

	INSERT INTO tb_contracts (C_ID, Matchcode, Name, WorkTime, Holidays, Salary, Start, End, TrailEnd, Description, HasEnd)
    VALUES (C_ID, Matchcode, Name, WorkTime, Holidays, Salary, Start, End, TrailEnd, Description, HasEnd);
    
END$$

DROP PROCEDURE IF EXISTS `UpdateDepartment`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateDepartment` (IN `D_ID` INT, IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `CostCenter` VARCHAR(255), IN `Manager` INT, IN `Description` VARCHAR(255))  BEGIN
	CALL DeleteDepartment(D_ID);

	INSERT INTO tb_departments (D_ID, Matchcode, Name, CostCenter, Manager, Description)
    VALUES (Matchcode, Name, CostCenter, Manager, Description);
    
END$$

DROP PROCEDURE IF EXISTS `UpdateEmployee`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateEmployee` (IN `E_ID` INT, IN `Matchcode` VARCHAR(255), IN `Gender` INT, IN `Forename` VARCHAR(255), IN `Surname` VARCHAR(255), IN `Birth` DATE, IN `PhoneNumber` VARCHAR(255), IN `Email` VARCHAR(255), IN `Department` INT, IN `Position` INT, IN `Contract` INT, IN `AdditionalInformation` VARCHAR(255), IN `Street` VARCHAR(255), IN `StreetNumber` VARCHAR(255), IN `City` VARCHAR(255), IN `PostalCode` VARCHAR(255))  BEGIN
	CALL DeleteEmployee(E_ID);

	INSERT INTO tb_employees (E_ID, Matchcode, Gender, Forename, Surname, Birth, PhoneNumber, Email, Department, Position, Contract, AdditionalInformation, Street, StreetNumber, City, PostalCode)
    VALUES (E_ID, Matchcode, Gender, Forename, Surname, Birth, PhoneNumber, Email, Department, Position, Contract, AdditionalInformation, Street, StreetNumber, City, PostalCode);

END$$

DROP PROCEDURE IF EXISTS `UpdatePosition`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePosition` (IN `P_ID` INT, IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `Description` VARCHAR(255))  BEGIN
	
    CALL DeletePosition(P_ID);

	INSERT INTO tb_positions (P_ID, Matchcode, Name, Description)
    VALUES (Matchcode, Name, Description);
    
END$$

DROP PROCEDURE IF EXISTS `UpdateRoom`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateRoom` (IN `R_ID` INT, IN `Matchcode` VARCHAR(255), IN `Name` VARCHAR(255), IN `RoomNumber` INT, IN `FloorNumber` INT, IN `Size` INT, IN `Description` VARCHAR(255))  BEGIN
	
    CALL DeleteRoom(R_ID);

	INSERT INTO tb_rooms (R_ID, Matchcode, Name, RoomNumber, FloorNumber, Size, Description)
    VALUES (Matchcode, Name, RoomNumber, FloorNumber, Size, Description);
    
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_contracts`
--

DROP TABLE IF EXISTS `tb_contracts`;
CREATE TABLE `tb_contracts` (
  `C_ID` int(11) NOT NULL,
  `Matchcode` varchar(255) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `WorkTime` int(11) DEFAULT NULL,
  `Holidays` int(11) DEFAULT NULL,
  `Salary` int(11) DEFAULT NULL,
  `Start` date DEFAULT NULL,
  `End` date DEFAULT NULL,
  `TrailEnd` date DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `HasEnd` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_departments`
--

DROP TABLE IF EXISTS `tb_departments`;
CREATE TABLE `tb_departments` (
  `D_ID` int(11) NOT NULL,
  `Matchcode` varchar(255) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `CostCenter` varchar(255) DEFAULT NULL,
  `Manager` int(11) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_employees`
--

DROP TABLE IF EXISTS `tb_employees`;
CREATE TABLE `tb_employees` (
  `E_ID` int(11) NOT NULL,
  `Matchcode` varchar(255) NOT NULL,
  `Gender` int(11) NOT NULL DEFAULT 0 COMMENT '0: Neutral\r\n1: Male\r\n2: Female',
  `Forename` varchar(255) DEFAULT NULL,
  `Surname` varchar(255) DEFAULT NULL,
  `Birth` date DEFAULT NULL,
  `PhoneNumber` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Department` int(11) DEFAULT NULL,
  `Position` int(11) DEFAULT NULL,
  `Contract` int(11) DEFAULT NULL,
  `AdditionalInformation` varchar(255) DEFAULT NULL,
  `Street` varchar(255) DEFAULT NULL,
  `StreetNumber` varchar(255) DEFAULT NULL,
  `City` varchar(255) DEFAULT NULL,
  `PostalCode` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_positions`
--

DROP TABLE IF EXISTS `tb_positions`;
CREATE TABLE `tb_positions` (
  `P_ID` int(11) NOT NULL,
  `Matchcode` varchar(255) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_rooms`
--

DROP TABLE IF EXISTS `tb_rooms`;
CREATE TABLE `tb_rooms` (
  `R_ID` int(11) NOT NULL,
  `Matchcode` varchar(255) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `RoomNumber` int(11) DEFAULT NULL,
  `FloorNumber` int(11) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_roomsemployees`
--

DROP TABLE IF EXISTS `tb_roomsemployees`;
CREATE TABLE `tb_roomsemployees` (
  `R_ID` int(11) NOT NULL,
  `E_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `tb_contracts`
--
ALTER TABLE `tb_contracts`
  ADD PRIMARY KEY (`C_ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`);

--
-- Indizes für die Tabelle `tb_departments`
--
ALTER TABLE `tb_departments`
  ADD PRIMARY KEY (`D_ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`),
  ADD KEY `Manager` (`Manager`);

--
-- Indizes für die Tabelle `tb_employees`
--
ALTER TABLE `tb_employees`
  ADD PRIMARY KEY (`E_ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`),
  ADD KEY `Department` (`Department`),
  ADD KEY `Position` (`Position`),
  ADD KEY `Contract` (`Contract`);

--
-- Indizes für die Tabelle `tb_positions`
--
ALTER TABLE `tb_positions`
  ADD PRIMARY KEY (`P_ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`);

--
-- Indizes für die Tabelle `tb_rooms`
--
ALTER TABLE `tb_rooms`
  ADD PRIMARY KEY (`R_ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`);

--
-- Indizes für die Tabelle `tb_roomsemployees`
--
ALTER TABLE `tb_roomsemployees`
  ADD PRIMARY KEY (`R_ID`,`E_ID`),
  ADD KEY `E_ID` (`E_ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `tb_contracts`
--
ALTER TABLE `tb_contracts`
  MODIFY `C_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tb_departments`
--
ALTER TABLE `tb_departments`
  MODIFY `D_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tb_employees`
--
ALTER TABLE `tb_employees`
  MODIFY `E_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tb_positions`
--
ALTER TABLE `tb_positions`
  MODIFY `P_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tb_rooms`
--
ALTER TABLE `tb_rooms`
  MODIFY `R_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `tb_departments`
--
ALTER TABLE `tb_departments`
  ADD CONSTRAINT `tb_departments_ibfk_1` FOREIGN KEY (`Manager`) REFERENCES `tb_employees` (`E_ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints der Tabelle `tb_employees`
--
ALTER TABLE `tb_employees`
  ADD CONSTRAINT `tb_employees_ibfk_1` FOREIGN KEY (`Position`) REFERENCES `tb_positions` (`P_ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `tb_employees_ibfk_2` FOREIGN KEY (`Department`) REFERENCES `tb_departments` (`D_ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `tb_employees_ibfk_3` FOREIGN KEY (`Contract`) REFERENCES `tb_contracts` (`C_ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints der Tabelle `tb_roomsemployees`
--
ALTER TABLE `tb_roomsemployees`
  ADD CONSTRAINT `tb_roomsemployees_ibfk_1` FOREIGN KEY (`E_ID`) REFERENCES `tb_employees` (`E_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tb_roomsemployees_ibfk_2` FOREIGN KEY (`R_ID`) REFERENCES `tb_rooms` (`R_ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
