-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 05. Mrz 2021 um 15:30
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

--
-- Daten für Tabelle `tb_contracts`
--

INSERT INTO `tb_contracts` (`C_ID`, `Matchcode`, `Name`, `WorkTime`, `Holidays`, `Salary`, `Start`, `End`, `TrailEnd`, `Description`, `HasEnd`) VALUES
(1, 'CONT1', 'Nicer Vertrag', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0);

--
-- Daten für Tabelle `tb_departments`
--

INSERT INTO `tb_departments` (`D_ID`, `Matchcode`, `Name`, `CostCenter`, `Manager`, `Description`) VALUES
(1, 'DEP1', 'NiceDepartment', '1000', NULL, 'Beste');

--
-- Daten für Tabelle `tb_employees`
--

INSERT INTO `tb_employees` (`E_ID`, `Matchcode`, `Gender`, `Forename`, `Surname`, `Birth`, `PhoneNumber`, `Email`, `Department`, `Position`, `Contract`, `AdditionalInformation`, `Street`, `StreetNumber`, `City`, `PostalCode`) VALUES
(1, 'JG', 1, 'Jeremy', 'Gassner', '2000-04-20', '0800 1234', 'jeremy@nice.de', 1, NULL, NULL, 'Ziemlich nice so', 'Hauptstraße', '3A', 'Nice Stadt', '87415');

--
-- Daten für Tabelle `tb_positions`
--

INSERT INTO `tb_positions` (`P_ID`, `Matchcode`, `Name`, `Description`) VALUES
(1, 'POS1', 'BestePosition', '1 nice Position');

--
-- Daten für Tabelle `tb_rooms`
--

INSERT INTO `tb_rooms` (`R_ID`, `Matchcode`, `Name`, `RoomNumber`, `FloorNumber`, `Size`, `Description`) VALUES
(1, 'ROOM1', 'Nicer Room', NULL, NULL, NULL, NULL),
(2, 'ROOM2', 'Nicer zweiter Room', NULL, NULL, NULL, NULL);

--
-- Daten für Tabelle `tb_roomsemployees`
--

INSERT INTO `tb_roomsemployees` (`R_ID`, `E_ID`) VALUES
(1, 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
