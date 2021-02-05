-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 05. Feb 2021 um 09:18
-- Server-Version: 10.4.17-MariaDB
-- PHP-Version: 8.0.0

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

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_companycar`
--

CREATE TABLE `tb_companycar` (
  `Brand` varchar(120) DEFAULT NULL,
  `Name` varchar(120) DEFAULT NULL,
  `Kennzeichen` varchar(120) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_contract`
--

CREATE TABLE `tb_contract` (
  `C_ID` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `WorkTime` int(11) DEFAULT NULL,
  `Holidays` int(11) DEFAULT NULL,
  `Salary` int(11) DEFAULT NULL,
  `WorkStart` date DEFAULT NULL,
  `trialPeriod` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_departments`
--

CREATE TABLE `tb_departments` (
  `D_ID` int(11) NOT NULL,
  `Name` varchar(150) DEFAULT NULL,
  `KstStelle` int(11) DEFAULT NULL,
  `Description` varchar(120) DEFAULT NULL,
  `D_Leader` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_employee`
--

CREATE TABLE `tb_employee` (
  `PNr` int(11) NOT NULL,
  `Salutation` varchar(255) DEFAULT NULL,
  `Firstname` varchar(255) DEFAULT NULL,
  `Lastname` varchar(255) DEFAULT NULL,
  `Street` varchar(255) DEFAULT NULL,
  `City` varchar(100) DEFAULT NULL,
  `Birthday` date DEFAULT NULL,
  `P_ID` int(11) DEFAULT NULL,
  `D_ID` int(11) DEFAULT NULL,
  `C_ID` int(11) DEFAULT NULL,
  `Phone` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_employeescars`
--

CREATE TABLE `tb_employeescars` (
  `PNr` int(11) DEFAULT NULL,
  `Kennzeichen` varchar(120) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_positions`
--

CREATE TABLE `tb_positions` (
  `P_ID` int(11) NOT NULL,
  `Name` varchar(120) DEFAULT NULL,
  `Desciption` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `tb_companycar`
--
ALTER TABLE `tb_companycar`
  ADD PRIMARY KEY (`Kennzeichen`);

--
-- Indizes für die Tabelle `tb_contract`
--
ALTER TABLE `tb_contract`
  ADD PRIMARY KEY (`C_ID`);

--
-- Indizes für die Tabelle `tb_departments`
--
ALTER TABLE `tb_departments`
  ADD PRIMARY KEY (`D_ID`),
  ADD KEY `D_Leader` (`D_Leader`);

--
-- Indizes für die Tabelle `tb_employee`
--
ALTER TABLE `tb_employee`
  ADD PRIMARY KEY (`PNr`),
  ADD KEY `P_ID` (`P_ID`),
  ADD KEY `D_ID` (`D_ID`),
  ADD KEY `C_ID` (`C_ID`);

--
-- Indizes für die Tabelle `tb_employeescars`
--
ALTER TABLE `tb_employeescars`
  ADD KEY `PNr` (`PNr`),
  ADD KEY `Kennzeichen` (`Kennzeichen`);

--
-- Indizes für die Tabelle `tb_positions`
--
ALTER TABLE `tb_positions`
  ADD PRIMARY KEY (`P_ID`);

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `tb_departments`
--
ALTER TABLE `tb_departments`
  ADD CONSTRAINT `tb_departments_ibfk_1` FOREIGN KEY (`D_Leader`) REFERENCES `tb_employee` (`PNr`);

--
-- Constraints der Tabelle `tb_employee`
--
ALTER TABLE `tb_employee`
  ADD CONSTRAINT `tb_employee_ibfk_1` FOREIGN KEY (`P_ID`) REFERENCES `tb_positions` (`P_ID`),
  ADD CONSTRAINT `tb_employee_ibfk_2` FOREIGN KEY (`D_ID`) REFERENCES `tb_departments` (`D_ID`),
  ADD CONSTRAINT `tb_employee_ibfk_3` FOREIGN KEY (`C_ID`) REFERENCES `tb_contract` (`C_ID`);

--
-- Constraints der Tabelle `tb_employeescars`
--
ALTER TABLE `tb_employeescars`
  ADD CONSTRAINT `tb_employeescars_ibfk_1` FOREIGN KEY (`PNr`) REFERENCES `tb_employee` (`PNr`),
  ADD CONSTRAINT `tb_employeescars_ibfk_2` FOREIGN KEY (`Kennzeichen`) REFERENCES `tb_companycar` (`Kennzeichen`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
