-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 26. Feb 2021 um 12:43
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
  `ID` int(11) NOT NULL,
  `Street` varchar(255) DEFAULT NULL,
  `StreetNumber` varchar(255) DEFAULT NULL,
  `City` varchar(255) DEFAULT NULL,
  `PostalCode` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tb_employees`
--

DROP TABLE IF EXISTS `tb_employees`;
CREATE TABLE `tb_employees` (
  `ID` int(11) NOT NULL,
  `Matchcode` varchar(255) DEFAULT NULL,
  `Gender` int(11) NOT NULL DEFAULT 0 COMMENT '0: Male\r\n1: Female',
  `Forename` varchar(255) DEFAULT NULL,
  `Surname` varchar(255) DEFAULT NULL,
  `Birth` date DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Address` int(11) DEFAULT NULL,
  `Department` int(11) DEFAULT NULL,
  `Position` int(11) DEFAULT NULL,
  `Contract` int(11) DEFAULT NULL,
  `AddInfo` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `tb_addresses`
--
ALTER TABLE `tb_addresses`
  ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `tb_employees`
--
ALTER TABLE `tb_employees`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Matchcode` (`Matchcode`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `tb_addresses`
--
ALTER TABLE `tb_addresses`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tb_employees`
--
ALTER TABLE `tb_employees`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
