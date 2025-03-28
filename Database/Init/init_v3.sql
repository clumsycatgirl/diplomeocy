-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Generation Time: Mar 28, 2025 at 08:06 PM
-- Server version: 8.0.32
-- PHP Version: 8.2.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `diplomeocy`
--

-- --------------------------------------------------------

--
-- Table structure for table `dataprotectionkeys`
--

CREATE TABLE `dataprotectionkeys` (
  `Id` int NOT NULL,
  `FriendlyName` varchar(255) DEFAULT NULL,
  `Xml` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `games`
--

CREATE TABLE `games` (
  `Id` int NOT NULL,
  `IdTable` int NOT NULL,
  `Moves` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `PlayerCountries` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `State` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `games`
--

INSERT INTO `games` (`Id`, `IdTable`, `Moves`, `PlayerCountries`, `State`) VALUES
(1, 0, '', '', ''),
(110619, 384921, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Kiel\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(112782, 640269, '', '[]', ''),
(132207, 132207, '', '[]', ''),
(145003, 145003, '', '[]', ''),
(152537, 152537, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":null},{\"Country\":2,\"Type\":0,\"Location\":null},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Holland\"},{\"Country\":1,\"Type\":0,\"Location\":\"Ruhr\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]}]', ''),
(156735, 572911, '', '', ''),
(164977, 164977, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":null},{\"Country\":5,\"Type\":1,\"Location\":null},{\"Country\":5,\"Type\":0,\"Location\":null},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Ukraine\"},{\"Country\":2,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":2,\"Type\":1,\"Location\":\"Prussia\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]}]', ''),
(178923, 178923, '', '[]', ''),
(226489, 226489, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(227917, 306595, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(235261, 235261, '', '[]', ''),
(243123, 243123, '', '[]', ''),
(252867, 252867, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"},{\"Name\":\"Rumania\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"BlackSea\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]}]', ''),
(275458, 275458, '', '[]', ''),
(279275, 279275, '', '[]', ''),
(292775, 292775, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"},{\"Name\":\"Galicia\"},{\"Name\":\"Rumania\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Galicia\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]}]', ''),
(327839, 327839, '', '[]', ''),
(356834, 356834, '', '[]', ''),
(363444, 363444, '', '[]', ''),
(366882, 366882, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(403898, 403898, '', '[]', ''),
(411237, 411237, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(411346, 411346, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(415518, 415518, '', '[]', ''),
(429777, 697907, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(453617, 453617, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Spain\"},{\"Name\":\"Belgium\"},{\"Name\":\"Portugal\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Trieste\"},{\"Name\":\"Serbia\"},{\"Name\":\"NorthAfrica\"},{\"Name\":\"Holland\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Holland\"},{\"Country\":1,\"Type\":0,\"Location\":\"Burgundy\"},{\"Country\":1,\"Type\":1,\"Location\":\"MidAtlanticOcean\"},{\"Country\":1,\"Type\":0,\"Location\":\"Serbia\"},{\"Country\":1,\"Type\":0,\"Location\":\"NorthAfrica\"},{\"Country\":1,\"Type\":1,\"Location\":\"NorthAtlanticOcean\"},{\"Country\":1,\"Type\":1,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":1,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Spain\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Tuscany\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Gascony\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"},{\"Name\":\"Albania\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"AdriaticSea\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"NorthSea\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"London\"}]}]', ''),
(453876, 453876, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"},{\"Name\":\"Bulgaria\"},{\"Name\":\"Rumania\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Serbia\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Sevastopol\"},{\"Country\":6,\"Type\":0,\"Location\":\"Serbia\"},{\"Country\":6,\"Type\":1,\"Location\":\"Rumania\"},{\"Country\":6,\"Type\":1,\"Location\":\"AegeanSea\"},{\"Country\":6,\"Type\":1,\"Location\":\"Constantinople\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":null}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]}]', ''),
(456746, 800085, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(462435, 462435, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(474344, 474344, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(476325, 476325, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', '');
INSERT INTO `games` (`Id`, `IdTable`, `Moves`, `PlayerCountries`, `State`) VALUES
(480841, 480841, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(507227, 507227, '', '[]', ''),
(525197, 525197, '', '[]', ''),
(525852, 489489, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(529040, 529040, '', '[]', ''),
(558859, 558859, '', '[]', ''),
(564006, 564006, '', '[]', ''),
(566601, 566601, '', '[]', ''),
(585314, 585314, '', '[]', ''),
(585426, 585426, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Silesia\"},{\"Country\":2,\"Type\":0,\"Location\":\"Bohemia\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]}]', ''),
(586606, 586606, '', '[]', ''),
(594292, 594292, '', '[]', ''),
(609189, 609189, '', '[]', ''),
(610182, 610182, '', '[]', ''),
(614994, 614994, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(623427, 623427, '', '[]', ''),
(628138, 628138, '', '[]', ''),
(663186, 663186, '', '[]', ''),
(672287, 672287, '', '[]', ''),
(682731, 682731, '', '[]', ''),
(683334, 683334, '', '[]', ''),
(693980, 693980, '', '[]', ''),
(704671, 41542, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Kiel\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(722913, 722913, '', '[]', ''),
(734404, 734404, '', '[]', ''),
(742360, 742360, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"},{\"Name\":\"Bulgaria\"},{\"Name\":\"Galicia\"},{\"Name\":\"Serbia\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Serbia\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"},{\"Country\":6,\"Type\":1,\"Location\":\"BlackSea\"},{\"Country\":6,\"Type\":0,\"Location\":\"Galicia\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Rumania\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Greece\"},{\"Name\":\"Greece\"},{\"Name\":\"Constantinople\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Rumania\"},{\"Country\":3,\"Type\":0,\"Location\":\"Ukraine\"},{\"Country\":3,\"Type\":1,\"Location\":\"Constantinople\"}]}]', ''),
(747758, 747758, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"},{\"Name\":\"Prussia\"},{\"Name\":\"Silesia\"},{\"Name\":\"Galicia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Rumania\"},{\"Name\":\"GulfOfBothania\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"BlackSea\"},{\"Name\":\"Serbia\"},{\"Name\":\"Sweden\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Bulgaria\"},{\"Name\":\"Albania\"},{\"Name\":\"Norway\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Greece\"},{\"Name\":\"Denmark\"},{\"Name\":\"Holland\"},{\"Name\":\"Tunis\"},{\"Name\":\"Belgium\"},{\"Name\":\"NorthAfrica\"},{\"Name\":\"Gascony\"},{\"Name\":\"Spain\"},{\"Name\":\"Portugal\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Serbia\"},{\"Country\":5,\"Type\":1,\"Location\":\"Spain\"},{\"Country\":5,\"Type\":0,\"Location\":\"Piedmont\"},{\"Country\":5,\"Type\":1,\"Location\":\"Portugal\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]}]', ''),
(762672, 762672, '', '[]', ''),
(783037, 783037, '', '[]', ''),
(811130, 811130, '', '[]', ''),
(814703, 814703, '', '[]', ''),
(823008, 823008, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(823083, 823083, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(883739, 883739, '', '[]', ''),
(926370, 926370, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(929794, 929794, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"},{\"Name\":\"Vienna\"},{\"Name\":\"Spain\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Apuleia\"},{\"Country\":4,\"Type\":1,\"Location\":\"Spain\"},{\"Country\":4,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":4,\"Type\":1,\"Location\":\"TyrrhenianSea\"},{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Serbia\"},{\"Name\":\"Rumania\"},{\"Name\":\"Bulgaria\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Serbia\"},{\"Country\":3,\"Type\":0,\"Location\":\"Bulgaria\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]}]', ''),
(937246, 806460, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(947604, 947604, '', '[]', ''),
(951705, 951705, '', '[]', ''),
(968330, 968330, '', '[]', ''),
(974677, 974677, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":null},{\"Country\":3,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Burgundy\"},{\"Country\":1,\"Type\":0,\"Location\":\"Gascony\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]}]', ''),
(980103, 622725, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Kiel\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(982039, 411206, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(988833, 988833, '', '[{\"Name\":\"meow\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"},{\"Name\":\"Rumania\"},{\"Name\":\"Silesia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Bohemia\"},{\"Country\":3,\"Type\":0,\"Location\":\"Rumania\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"meow1\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"meow2\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"meow3\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"meow4\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"meow5\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]},{\"Name\":\"meow6\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]}]', '');

-- --------------------------------------------------------

--
-- Table structure for table `players`
--

CREATE TABLE `players` (
  `Id` int NOT NULL,
  `IdTable` int NOT NULL,
  `IdUser` int NOT NULL,
  `Country` enum('England','France','Germany','Austria','Italy','Russia','Turkey') COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `players`
--

INSERT INTO `players` (`Id`, `IdTable`, `IdUser`, `Country`) VALUES
(4, 841312, 1, 'England'),
(5, 455518, 1, 'England'),
(6, 719497, 1, 'England'),
(7, 411178, 1, 'England'),
(8, 592137, 1, 'England'),
(9, 378862, 1, 'England'),
(10, 572911, 1, 'England'),
(11, 732796, 1, 'England'),
(12, 640269, 1, 'England'),
(13, 384921, 1, 'England'),
(14, 622725, 1, 'England'),
(15, 41542, 1, 'England'),
(16, 800085, 1, 'England'),
(17, 489489, 1, 'England'),
(18, 411206, 1, 'England'),
(19, 806460, 1, 'England'),
(20, 306595, 1, 'England'),
(21, 697907, 1, 'England'),
(22, 926370, 1, 'England'),
(38, 462435, 1, 'England'),
(39, 476325, 1, 'England'),
(40, 823008, 1, 'England'),
(41, 480841, 1, 'England'),
(42, 614994, 1, 'England'),
(43, 474344, 1, 'England'),
(44, 823083, 1, 'England'),
(45, 411237, 1, 'England'),
(46, 366882, 1, 'England'),
(47, 366882, 3, 'England'),
(48, 366882, 4, 'England'),
(49, 366882, 5, 'England'),
(50, 366882, 6, 'England'),
(51, 366882, 7, 'England'),
(52, 366882, 8, 'England'),
(53, 411346, 1, 'England'),
(54, 226489, 1, 'England'),
(55, 226489, 3, 'England'),
(56, 226489, 4, 'England'),
(57, 226489, 5, 'England'),
(58, 564006, 1, 'England'),
(59, 564006, 3, 'England'),
(60, 564006, 4, 'England'),
(61, 564006, 5, 'England'),
(62, 564006, 6, 'England'),
(63, 564006, 7, 'England'),
(64, 564006, 8, 'England'),
(65, 783037, 1, 'England'),
(66, 783037, 3, 'England'),
(68, 783037, 4, 'England'),
(69, 783037, 5, 'England'),
(70, 783037, 6, 'England'),
(71, 783037, 7, 'England'),
(72, 783037, 8, 'England'),
(73, 363444, 1, 'England'),
(74, 363444, 3, 'England'),
(75, 363444, 4, 'England'),
(76, 363444, 5, 'England'),
(77, 363444, 6, 'England'),
(78, 363444, 7, 'England'),
(79, 363444, 8, 'England'),
(80, 529040, 1, 'England'),
(81, 529040, 3, 'England'),
(82, 529040, 4, 'England'),
(83, 529040, 5, 'England'),
(84, 529040, 6, 'England'),
(85, 529040, 7, 'England'),
(86, 529040, 8, 'England'),
(87, 507227, 1, 'England'),
(88, 507227, 3, 'England'),
(89, 507227, 4, 'England'),
(90, 507227, 5, 'England'),
(91, 507227, 6, 'England'),
(92, 507227, 7, 'England'),
(93, 507227, 8, 'England'),
(94, 814703, 1, 'England'),
(95, 814703, 4, 'England'),
(96, 814703, 5, 'England'),
(97, 814703, 6, 'England'),
(98, 814703, 7, 'England'),
(99, 814703, 8, 'England'),
(100, 814703, 3, 'England'),
(101, 623427, 1, 'England'),
(102, 623427, 3, 'England'),
(103, 623427, 4, 'England'),
(104, 623427, 5, 'England'),
(105, 623427, 6, 'England'),
(106, 623427, 7, 'England'),
(107, 623427, 8, 'England'),
(108, 235261, 1, 'England'),
(109, 235261, 3, 'England'),
(110, 235261, 4, 'England'),
(111, 235261, 5, 'England'),
(112, 235261, 6, 'England'),
(113, 235261, 7, 'England'),
(114, 235261, 8, 'England'),
(115, 566601, 1, 'England'),
(116, 566601, 3, 'England'),
(117, 566601, 4, 'England'),
(118, 566601, 5, 'England'),
(119, 566601, 6, 'England'),
(120, 566601, 7, 'England'),
(121, 566601, 8, 'England'),
(122, 243123, 1, 'England'),
(123, 243123, 3, 'England'),
(124, 243123, 4, 'England'),
(125, 243123, 5, 'England'),
(126, 243123, 6, 'England'),
(127, 243123, 7, 'England'),
(128, 243123, 8, 'England'),
(129, 734404, 1, 'England'),
(130, 734404, 3, 'England'),
(131, 734404, 4, 'England'),
(132, 734404, 5, 'England'),
(133, 734404, 6, 'England'),
(134, 734404, 7, 'England'),
(135, 734404, 8, 'England'),
(136, 951705, 1, 'England'),
(137, 951705, 3, 'England'),
(138, 951705, 4, 'England'),
(139, 951705, 5, 'England'),
(140, 951705, 6, 'England'),
(141, 951705, 7, 'England'),
(142, 951705, 8, 'England'),
(143, 594292, 1, 'England'),
(144, 594292, 3, 'England'),
(145, 594292, 4, 'England'),
(146, 594292, 5, 'England'),
(147, 594292, 6, 'England'),
(148, 594292, 7, 'England'),
(149, 594292, 8, 'England'),
(150, 525197, 1, 'England'),
(151, 525197, 3, 'England'),
(152, 525197, 4, 'England'),
(153, 525197, 5, 'England'),
(154, 525197, 6, 'England'),
(155, 525197, 7, 'England'),
(156, 525197, 8, 'England'),
(157, 415518, 1, 'England'),
(158, 415518, 3, 'England'),
(159, 415518, 4, 'England'),
(160, 415518, 5, 'England'),
(161, 415518, 6, 'England'),
(162, 415518, 7, 'England'),
(163, 415518, 8, 'England'),
(164, 722913, 1, 'England'),
(165, 722913, 3, 'England'),
(166, 722913, 4, 'England'),
(167, 722913, 5, 'England'),
(168, 722913, 6, 'England'),
(169, 722913, 7, 'England'),
(170, 722913, 8, 'England'),
(171, 327839, 1, 'England'),
(172, 327839, 3, 'England'),
(173, 327839, 4, 'England'),
(174, 327839, 5, 'England'),
(175, 327839, 6, 'England'),
(176, 327839, 7, 'England'),
(177, 327839, 8, 'England'),
(178, 356834, 1, 'England'),
(179, 356834, 3, 'England'),
(180, 356834, 4, 'England'),
(181, 356834, 5, 'England'),
(182, 356834, 6, 'England'),
(183, 356834, 7, 'England'),
(184, 356834, 8, 'England'),
(185, 947604, 1, 'England'),
(186, 279275, 1, 'England'),
(187, 145003, 1, 'England'),
(188, 275458, 1, 'England'),
(189, 275458, 3, 'England'),
(190, 275458, 4, 'England'),
(191, 275458, 5, 'England'),
(192, 275458, 6, 'England'),
(194, 275458, 7, 'England'),
(195, 275458, 8, 'England'),
(196, 663186, 1, 'England'),
(197, 663186, 3, 'England'),
(198, 663186, 4, 'England'),
(199, 663186, 5, 'England'),
(200, 663186, 6, 'England'),
(201, 663186, 8, 'England'),
(202, 663186, 7, 'England'),
(203, 403898, 1, 'England'),
(204, 403898, 3, 'England'),
(205, 403898, 4, 'England'),
(206, 403898, 5, 'England'),
(207, 403898, 6, 'England'),
(208, 403898, 7, 'England'),
(209, 403898, 8, 'England'),
(210, 693980, 1, 'England'),
(211, 693980, 3, 'England'),
(212, 693980, 4, 'England'),
(213, 693980, 5, 'England'),
(215, 693980, 6, 'England'),
(216, 693980, 7, 'England'),
(217, 693980, 8, 'England'),
(218, 762672, 1, 'England'),
(219, 762672, 3, 'England'),
(220, 762672, 4, 'England'),
(221, 762672, 5, 'England'),
(222, 762672, 6, 'England'),
(223, 762672, 7, 'England'),
(224, 762672, 8, 'England'),
(225, 628138, 1, 'England'),
(226, 628138, 3, 'England'),
(227, 628138, 4, 'England'),
(228, 628138, 5, 'England'),
(229, 628138, 6, 'England'),
(230, 628138, 7, 'England'),
(231, 628138, 8, 'England'),
(232, 132207, 1, 'England'),
(233, 132207, 3, 'England'),
(234, 132207, 4, 'England'),
(235, 132207, 5, 'England'),
(236, 132207, 6, 'England'),
(237, 132207, 7, 'England'),
(238, 132207, 8, 'England'),
(239, 682731, 1, 'England'),
(240, 682731, 3, 'England'),
(241, 682731, 4, 'England'),
(242, 682731, 5, 'England'),
(243, 682731, 6, 'England'),
(244, 682731, 7, 'England'),
(245, 682731, 8, 'England'),
(246, 883739, 1, 'England'),
(247, 883739, 4, 'England'),
(248, 883739, 5, 'England'),
(249, 883739, 3, 'England'),
(250, 883739, 6, 'England'),
(251, 883739, 7, 'England'),
(252, 883739, 8, 'England'),
(253, 683334, 1, 'England'),
(254, 683334, 3, 'England'),
(255, 683334, 4, 'England'),
(256, 683334, 5, 'England'),
(257, 683334, 6, 'England'),
(258, 683334, 7, 'England'),
(259, 683334, 8, 'England'),
(260, 610182, 1, 'England'),
(261, 610182, 3, 'England'),
(262, 610182, 4, 'England'),
(263, 610182, 5, 'England'),
(264, 610182, 6, 'England'),
(265, 610182, 7, 'England'),
(266, 610182, 8, 'England'),
(267, 178923, 1, 'England'),
(268, 178923, 3, 'England'),
(269, 178923, 4, 'England'),
(270, 178923, 5, 'England'),
(271, 178923, 6, 'England'),
(272, 178923, 7, 'England'),
(273, 178923, 8, 'England'),
(274, 609189, 1, 'England'),
(275, 609189, 3, 'England'),
(276, 609189, 4, 'England'),
(277, 609189, 5, 'England'),
(278, 609189, 6, 'England'),
(279, 609189, 7, 'England'),
(280, 609189, 8, 'England'),
(281, 968330, 1, 'England'),
(282, 968330, 3, 'England'),
(283, 968330, 4, 'England'),
(284, 968330, 5, 'England'),
(285, 968330, 6, 'England'),
(286, 968330, 7, 'England'),
(287, 968330, 8, 'England'),
(288, 811130, 1, 'England'),
(289, 811130, 3, 'England'),
(290, 811130, 4, 'England'),
(291, 811130, 5, 'England'),
(292, 811130, 6, 'England'),
(293, 811130, 7, 'England'),
(294, 811130, 8, 'England'),
(295, 586606, 1, 'England'),
(296, 586606, 3, 'England'),
(297, 586606, 4, 'England'),
(298, 586606, 5, 'England'),
(299, 586606, 6, 'England'),
(300, 586606, 7, 'England'),
(301, 586606, 8, 'England'),
(303, 164977, 1, 'England'),
(304, 164977, 3, 'England'),
(305, 164977, 4, 'England'),
(306, 164977, 5, 'England'),
(307, 164977, 6, 'England'),
(308, 164977, 7, 'England'),
(309, 164977, 8, 'England'),
(310, 152537, 1, 'England'),
(311, 152537, 3, 'England'),
(312, 152537, 4, 'England'),
(313, 152537, 5, 'England'),
(314, 152537, 6, 'England'),
(315, 152537, 7, 'England'),
(316, 152537, 8, 'England'),
(317, 974677, 1, 'England'),
(318, 974677, 3, 'England'),
(319, 974677, 4, 'England'),
(320, 974677, 5, 'England'),
(321, 974677, 6, 'England'),
(322, 974677, 7, 'England'),
(323, 974677, 8, 'England'),
(324, 585426, 1, 'England'),
(325, 585426, 3, 'England'),
(326, 585426, 4, 'England'),
(327, 585426, 5, 'England'),
(328, 585426, 6, 'England'),
(329, 585426, 7, 'England'),
(330, 585426, 8, 'England'),
(331, 672287, 1, 'England'),
(332, 672287, 3, 'England'),
(333, 672287, 4, 'England'),
(334, 672287, 5, 'England'),
(335, 672287, 6, 'England'),
(336, 672287, 7, 'England'),
(337, 672287, 8, 'England'),
(338, 747758, 1, 'England'),
(339, 747758, 3, 'England'),
(340, 747758, 4, 'England'),
(341, 747758, 5, 'England'),
(342, 747758, 6, 'England'),
(343, 747758, 7, 'England'),
(344, 747758, 8, 'England'),
(345, 988833, 1, 'England'),
(346, 988833, 3, 'England'),
(347, 988833, 4, 'England'),
(348, 988833, 5, 'England'),
(349, 988833, 6, 'England'),
(350, 988833, 7, 'England'),
(351, 988833, 8, 'England'),
(352, 252867, 1, 'England'),
(353, 252867, 3, 'England'),
(354, 252867, 4, 'England'),
(355, 252867, 5, 'England'),
(356, 252867, 6, 'England'),
(357, 252867, 7, 'England'),
(358, 252867, 8, 'England'),
(359, 292775, 1, 'England'),
(360, 292775, 4, 'England'),
(361, 292775, 5, 'England'),
(362, 292775, 3, 'England'),
(363, 292775, 6, 'England'),
(364, 292775, 7, 'England'),
(365, 292775, 8, 'England'),
(366, 453876, 1, 'England'),
(367, 453876, 3, 'England'),
(368, 453876, 4, 'England'),
(369, 453876, 5, 'England'),
(370, 453876, 6, 'England'),
(372, 453876, 8, 'England'),
(373, 453876, 7, 'England'),
(376, 742360, 1, 'England'),
(377, 742360, 3, 'England'),
(378, 742360, 4, 'England'),
(379, 742360, 5, 'England'),
(380, 742360, 6, 'England'),
(381, 742360, 7, 'England'),
(382, 742360, 8, 'England'),
(383, 453617, 1, 'England'),
(384, 453617, 3, 'England'),
(385, 453617, 4, 'England'),
(386, 453617, 5, 'England'),
(387, 453617, 6, 'England'),
(388, 453617, 7, 'England'),
(389, 453617, 8, 'England'),
(390, 929794, 1, 'England'),
(391, 929794, 3, 'England'),
(392, 929794, 4, 'England'),
(393, 929794, 5, 'England'),
(394, 929794, 6, 'England'),
(395, 929794, 7, 'England'),
(396, 929794, 8, 'England'),
(397, 585314, 1, 'England'),
(398, 585314, 3, 'England'),
(399, 585314, 4, 'England'),
(400, 585314, 5, 'England'),
(401, 585314, 6, 'England'),
(402, 585314, 7, 'England'),
(403, 585314, 8, 'England'),
(404, 558859, 1, 'England'),
(405, 558859, 3, 'England'),
(406, 558859, 4, 'England'),
(407, 558859, 5, 'England'),
(408, 558859, 6, 'England'),
(409, 558859, 7, 'England'),
(410, 558859, 8, 'England'),
(412, 275727, 12, 'England');

-- --------------------------------------------------------

--
-- Table structure for table `tables`
--

CREATE TABLE `tables` (
  `Id` int NOT NULL,
  `Date` date NOT NULL,
  `Host` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tables`
--

INSERT INTO `tables` (`Id`, `Date`, `Host`) VALUES
(0, '2024-05-22', 1),
(41542, '2024-05-23', 1),
(132207, '2024-05-25', 1),
(145003, '2024-05-25', 1),
(152537, '2024-05-25', 1),
(164977, '2024-05-25', 1),
(178923, '2024-05-25', 1),
(198823, '2025-03-07', 10),
(205207, '2024-05-23', 1),
(226489, '2024-05-24', 1),
(235261, '2024-05-24', 1),
(243123, '2024-05-25', 1),
(252867, '2024-05-25', 1),
(275458, '2024-05-25', 1),
(275727, '2025-03-09', 12),
(279275, '2024-05-25', 1),
(292775, '2024-05-25', 1),
(306595, '2024-05-23', 1),
(327839, '2024-05-25', 1),
(330871, '2024-05-23', 1),
(356834, '2024-05-25', 1),
(363444, '2024-05-24', 1),
(366882, '2024-05-24', 1),
(378862, '2024-05-23', 1),
(384921, '2024-05-23', 1),
(403898, '2024-05-25', 1),
(411178, '2024-05-23', 1),
(411206, '2024-05-23', 1),
(411237, '2024-05-24', 1),
(411346, '2024-05-24', 1),
(415518, '2024-05-25', 1),
(453617, '2024-05-25', 1),
(453876, '2024-05-25', 1),
(455518, '2024-05-23', 1),
(462435, '2024-05-24', 1),
(474344, '2024-05-24', 1),
(476325, '2024-05-24', 1),
(480841, '2024-05-24', 1),
(489489, '2024-05-23', 1),
(502793, '2024-05-23', 1),
(507227, '2024-05-24', 1),
(525197, '2024-05-25', 1),
(529040, '2024-05-24', 1),
(558859, '2024-05-25', 1),
(564006, '2024-05-24', 1),
(566601, '2024-05-25', 1),
(572911, '2024-05-23', 1),
(585314, '2024-05-25', 1),
(585426, '2024-05-25', 1),
(586606, '2024-05-25', 1),
(592137, '2024-05-23', 1),
(593917, '2025-03-07', 10),
(594292, '2024-05-25', 1),
(609189, '2024-05-25', 1),
(610182, '2024-05-25', 1),
(614994, '2024-05-24', 1),
(622725, '2024-05-23', 1),
(623427, '2024-05-24', 1),
(628138, '2024-05-25', 1),
(640269, '2024-05-23', 1),
(663186, '2024-05-25', 1),
(672287, '2024-05-25', 1),
(682731, '2024-05-25', 1),
(683334, '2024-05-25', 1),
(693980, '2024-05-25', 1),
(697907, '2024-05-24', 1),
(719497, '2024-05-23', 1),
(722913, '2024-05-25', 1),
(732796, '2024-05-23', 1),
(734404, '2024-05-25', 1),
(742360, '2024-05-25', 1),
(747758, '2024-05-25', 1),
(762672, '2024-05-25', 1),
(783037, '2024-05-24', 1),
(800085, '2024-05-23', 1),
(806460, '2024-05-23', 1),
(811130, '2024-05-25', 1),
(814703, '2024-05-24', 1),
(823008, '2024-05-24', 1),
(823083, '2024-05-24', 1),
(841312, '2024-05-23', 1),
(863397, '2024-05-23', 1),
(883739, '2024-05-25', 1),
(926370, '2024-05-24', 1),
(929794, '2024-05-25', 1),
(939345, '2024-05-23', 1),
(947604, '2024-05-25', 1),
(951705, '2024-05-25', 1),
(968330, '2024-05-25', 1),
(974677, '2024-05-25', 1),
(988833, '2024-05-25', 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` int NOT NULL,
  `Username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `PathImage` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Theme` enum('Dark','Light') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT 'Light'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`, `PathImage`, `Theme`) VALUES
(1, 'meow', '806EC396527434CED7ED350A0E7F96EBCECED03C8BA3036E172DA0D3E51B10AF', '', 'Light'),
(2, 'meow', 'meow', '/assets/images/kittators/Giorgio.png', 'Light'),
(3, 'meow1', 'meow1', '/assets/images/kittators/Kitler.png', 'Light'),
(4, 'meow2', 'meow2', '/assets/images/kittators/Leonin.png', 'Light'),
(5, 'meow3', 'meow3', '/assets/images/kittators/Churchill.png', 'Light'),
(6, 'meow4', 'meow4', '/assets/images/kittators/Elisabetta.png', 'Light'),
(7, 'meow5', 'meow5', '/assets/images/kittators/Giorgio.png', 'Light'),
(8, 'meow6', 'meow6', '/assets/images/kittators/Meowmed.png', 'Light'),
(10, 'HatsuneMiku3', '806EC396527434CED7ED350A0E7F96EBCECED03C8BA3036E172DA0D3E51B10AF', '/assets/images/kittators/Stalin.png', 'Light'),
(11, 'HatsuneMiku2', 'F6D46E7B5FEDFEBFCF5D8602640C1DFA48952D3D852756B684D3060E14EF0C4E', '/assets/images/kittators/Elisabetta.png', 'Light'),
(12, 'HatsuneMiku', '806EC396527434CED7ED350A0E7F96EBCECED03C8BA3036E172DA0D3E51B10AF', '/assets/images/kittators/Stalin.png', 'Dark');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdTable` (`IdTable`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdTable` (`IdTable`),
  ADD KEY `IdUser` (`IdUser`);

--
-- Indexes for table `tables`
--
ALTER TABLE `tables`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Host` (`Host`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `games`
--
ALTER TABLE `games`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=988834;

--
-- AUTO_INCREMENT for table `players`
--
ALTER TABLE `players`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=413;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `games`
--
ALTER TABLE `games`
  ADD CONSTRAINT `games_ibfk_1` FOREIGN KEY (`IdTable`) REFERENCES `tables` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `players`
--
ALTER TABLE `players`
  ADD CONSTRAINT `players_ibfk_1` FOREIGN KEY (`IdUser`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `players_ibfk_2` FOREIGN KEY (`IdTable`) REFERENCES `tables` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tables`
--
ALTER TABLE `tables`
  ADD CONSTRAINT `tables_ibfk_1` FOREIGN KEY (`Host`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
