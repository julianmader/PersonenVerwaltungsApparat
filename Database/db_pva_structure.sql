-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 26. Feb 2021 um 16:02
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

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_addresses`
--

DROP TABLE IF EXISTS `tb_addresses`;
CREATE TABLE `tb_addresses` (
  `A_ID` int(11) NOT NULL,
  `Street` varchar(255) DEFAULT NULL,
  `StreetNumber` varchar(255) DEFAULT NULL,
  `City` varchar(255) DEFAULT NULL,
  `PostalCode` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  `Employee` int(11) DEFAULT NULL,
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
-- Tabellenstruktur für Tabelle `tb_departmentsemployees`
--

DROP TABLE IF EXISTS `tb_departmentsemployees`;
CREATE TABLE `tb_departmentsemployees` (
  `D_ID` int(11) NOT NULL,
  `E_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_employees`
--

DROP TABLE IF EXISTS `tb_employees`;
CREATE TABLE `tb_employees` (
  `E_ID` int(11) NOT NULL,
  `Matchcode` varchar(255) DEFAULT NULL,
  `Gender` int(11) NOT NULL DEFAULT 0 COMMENT '0: Male\r\n1: Female',
  `Forename` varchar(255) DEFAULT NULL,
  `Surname` varchar(255) DEFAULT NULL,
  `Birth` date DEFAULT NULL,
  `PhoneNumber` varchar(255) DEFAULT 'NULL',
  `Email` varchar(255) DEFAULT NULL,
  `Address` int(11) DEFAULT NULL,
  `Department` int(11) DEFAULT NULL,
  `Position` int(11) DEFAULT NULL,
  `Contract` int(11) DEFAULT NULL,
  `AdditionalInformation` varchar(255) DEFAULT 'NULL'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_employeesaddresses`
--

DROP TABLE IF EXISTS `tb_employeesaddresses`;
CREATE TABLE `tb_employeesaddresses` (
  `E_ID` int(11) NOT NULL,
  `A_ID` int(11) NOT NULL
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
-- Tabellenstruktur für Tabelle `tb_positionsemployees`
--

DROP TABLE IF EXISTS `tb_positionsemployees`;
CREATE TABLE `tb_positionsemployees` (
  `P_ID` int(11) NOT NULL,
  `E_ID` int(11) NOT NULL
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
-- Indizes für die Tabelle `tb_addresses`
--
ALTER TABLE `tb_addresses`
  ADD PRIMARY KEY (`A_ID`);

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
  ADD UNIQUE KEY `Matchcode` (`Matchcode`);

--
-- Indizes für die Tabelle `tb_departmentsemployees`
--
ALTER TABLE `tb_departmentsemployees`
  ADD PRIMARY KEY (`D_ID`,`E_ID`);

--
-- Indizes für die Tabelle `tb_employees`
--
ALTER TABLE `tb_employees`
  ADD PRIMARY KEY (`E_ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`);

--
-- Indizes für die Tabelle `tb_employeesaddresses`
--
ALTER TABLE `tb_employeesaddresses`
  ADD PRIMARY KEY (`E_ID`,`A_ID`);

--
-- Indizes für die Tabelle `tb_positions`
--
ALTER TABLE `tb_positions`
  ADD PRIMARY KEY (`P_ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`);

--
-- Indizes für die Tabelle `tb_positionsemployees`
--
ALTER TABLE `tb_positionsemployees`
  ADD PRIMARY KEY (`P_ID`,`E_ID`);

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
  ADD PRIMARY KEY (`R_ID`,`E_ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `tb_addresses`
--
ALTER TABLE `tb_addresses`
  MODIFY `A_ID` int(11) NOT NULL AUTO_INCREMENT;

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
-- Constraints der Tabelle `tb_employeesaddresses`
--
ALTER TABLE `tb_employeesaddresses`
  ADD CONSTRAINT `tb_employeesaddresses_ibfk_1` FOREIGN KEY (`E_ID`) REFERENCES `tb_employees` (`E_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tb_employeesaddresses_ibfk_2` FOREIGN KEY (`A_ID`) REFERENCES `tb_addresses` (`A_ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
