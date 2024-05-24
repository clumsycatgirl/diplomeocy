-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Mag 24, 2024 alle 17:47
-- Versione del server: 10.4.28-MariaDB
-- Versione PHP: 8.0.28

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
-- Struttura della tabella `games`
--

CREATE TABLE `games` (
  `Id` int(11) NOT NULL,
  `IdTable` int(6) NOT NULL,
  `Moves` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT '',
  `PlayerCountries` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT '',
  `State` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `games`
--

INSERT INTO `games` (`Id`, `IdTable`, `Moves`, `PlayerCountries`, `State`) VALUES
(1, 0, '', '', ''),
(110619, 384921, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Kiel\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(112782, 640269, '', '[]', ''),
(156735, 572911, '', '', ''),
(227917, 306595, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(429777, 697907, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(456746, 800085, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(525852, 489489, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(704671, 41542, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Kiel\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(926370, 926370, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":1,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":1,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":1,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":1,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":1,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":1,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":1,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":1,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(937246, 806460, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(980103, 622725, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Kiel\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', ''),
(982039, 411206, '', '[{\"Name\":\"Meowmeow\",\"Countries\":[{\"Name\":\"England\",\"Territories\":[{\"Name\":\"London\"},{\"Name\":\"Liverpool\"},{\"Name\":\"Edinburgh\"},{\"Name\":\"Wales\"},{\"Name\":\"Yorkshire\"},{\"Name\":\"Clyde\"}]}],\"Units\":[{\"Country\":0,\"Type\":0,\"Location\":\"London\"},{\"Country\":0,\"Type\":0,\"Location\":\"Liverpool\"},{\"Country\":0,\"Type\":0,\"Location\":\"Edinburgh\"}]},{\"Name\":\"Willyx\",\"Countries\":[{\"Name\":\"Germany\",\"Territories\":[{\"Name\":\"Berlin\"},{\"Name\":\"Munich\"},{\"Name\":\"Ruhr\"},{\"Name\":\"Kiel\"},{\"Name\":\"Silesia\"},{\"Name\":\"Prussia\"}]}],\"Units\":[{\"Country\":2,\"Type\":0,\"Location\":\"Berlin\"},{\"Country\":2,\"Type\":0,\"Location\":\"Munich\"},{\"Country\":2,\"Type\":0,\"Location\":\"Kiel\"}]},{\"Name\":\"Red\",\"Countries\":[{\"Name\":\"Austria\",\"Territories\":[{\"Name\":\"Vienna\"},{\"Name\":\"Budapest\"},{\"Name\":\"Trieste\"},{\"Name\":\"Tyrolia\"},{\"Name\":\"Bohemia\"},{\"Name\":\"Galicia\"}]}],\"Units\":[{\"Country\":3,\"Type\":0,\"Location\":\"Vienna\"},{\"Country\":3,\"Type\":0,\"Location\":\"Budapest\"},{\"Country\":3,\"Type\":0,\"Location\":\"Trieste\"}]},{\"Name\":\"BrofessorAdamo\",\"Countries\":[{\"Name\":\"Turkey\",\"Territories\":[{\"Name\":\"Ankara\"},{\"Name\":\"Constantinople\"},{\"Name\":\"Smyrna\"},{\"Name\":\"Armenia\"},{\"Name\":\"Syria\"}]}],\"Units\":[{\"Country\":6,\"Type\":0,\"Location\":\"Ankara\"},{\"Country\":6,\"Type\":0,\"Location\":\"Constantinople\"},{\"Country\":6,\"Type\":0,\"Location\":\"Smyrna\"}]},{\"Name\":\"Extra273\",\"Countries\":[{\"Name\":\"France\",\"Territories\":[{\"Name\":\"Paris\"},{\"Name\":\"Marseilles\"},{\"Name\":\"Brest\"},{\"Name\":\"Picardy\"},{\"Name\":\"Burgundy\"},{\"Name\":\"Gascony\"}]}],\"Units\":[{\"Country\":1,\"Type\":0,\"Location\":\"Paris\"},{\"Country\":1,\"Type\":0,\"Location\":\"Marseilles\"},{\"Country\":1,\"Type\":0,\"Location\":\"Brest\"}]},{\"Name\":\"FakeJoakimBroden\",\"Countries\":[{\"Name\":\"Italy\",\"Territories\":[{\"Name\":\"Rome\"},{\"Name\":\"Naples\"},{\"Name\":\"Venice\"},{\"Name\":\"Piedmont\"},{\"Name\":\"Tuscany\"},{\"Name\":\"Apuleia\"}]}],\"Units\":[{\"Country\":4,\"Type\":0,\"Location\":\"Rome\"},{\"Country\":4,\"Type\":0,\"Location\":\"Naples\"},{\"Country\":4,\"Type\":0,\"Location\":\"Venice\"}]},{\"Name\":\"Hatsune Miku\",\"Countries\":[{\"Name\":\"Russia\",\"Territories\":[{\"Name\":\"Moscow\"},{\"Name\":\"SaintPetersburg\"},{\"Name\":\"Warsaw\"},{\"Name\":\"Sevastopol\"},{\"Name\":\"Ukraine\"},{\"Name\":\"Livonia\"},{\"Name\":\"Finland\"}]}],\"Units\":[{\"Country\":5,\"Type\":0,\"Location\":\"Moscow\"},{\"Country\":5,\"Type\":0,\"Location\":\"SaintPetersburg\"},{\"Country\":5,\"Type\":0,\"Location\":\"Warsaw\"},{\"Country\":5,\"Type\":1,\"Location\":\"Sevastopol\"}]}]', '');

-- --------------------------------------------------------

--
-- Struttura della tabella `players`
--

CREATE TABLE `players` (
  `Id` int(11) NOT NULL,
  `IdTable` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `players`
--

INSERT INTO `players` (`Id`, `IdTable`, `IdUser`) VALUES
(4, 841312, 1),
(5, 455518, 1),
(6, 719497, 1),
(7, 411178, 1),
(8, 592137, 1),
(9, 378862, 1),
(10, 572911, 1),
(11, 732796, 1),
(12, 640269, 1),
(13, 384921, 1),
(14, 622725, 1),
(15, 41542, 1),
(16, 800085, 1),
(17, 489489, 1),
(18, 411206, 1),
(19, 806460, 1),
(20, 306595, 1),
(21, 697907, 1),
(22, 926370, 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `tables`
--

CREATE TABLE `tables` (
  `Id` int(6) NOT NULL,
  `Date` date NOT NULL,
  `Host` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `tables`
--

INSERT INTO `tables` (`Id`, `Date`, `Host`) VALUES
(0, '2024-05-22', 1),
(41542, '2024-05-23', 1),
(205207, '2024-05-23', 1),
(306595, '2024-05-23', 1),
(330871, '2024-05-23', 1),
(378862, '2024-05-23', 1),
(384921, '2024-05-23', 1),
(411178, '2024-05-23', 1),
(411206, '2024-05-23', 1),
(455518, '2024-05-23', 1),
(489489, '2024-05-23', 1),
(502793, '2024-05-23', 1),
(572911, '2024-05-23', 1),
(592137, '2024-05-23', 1),
(622725, '2024-05-23', 1),
(640269, '2024-05-23', 1),
(697907, '2024-05-24', 1),
(719497, '2024-05-23', 1),
(732796, '2024-05-23', 1),
(800085, '2024-05-23', 1),
(806460, '2024-05-23', 1),
(841312, '2024-05-23', 1),
(863397, '2024-05-23', 1),
(926370, '2024-05-24', 1),
(939345, '2024-05-23', 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Surname` varchar(255) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `PathImage` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `users`
--

INSERT INTO `users` (`Id`, `Name`, `Surname`, `Username`, `Password`, `PathImage`) VALUES
(1, 'meow', 'meow', 'meow', 'meow', ''),
(2, 'mr', 'meow', 'meow', 'meow', '/assets/images/kittators/Giorgio.png');

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdTable` (`IdTable`);

--
-- Indici per le tabelle `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdTable` (`IdTable`),
  ADD KEY `IdUser` (`IdUser`);

--
-- Indici per le tabelle `tables`
--
ALTER TABLE `tables`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Host` (`Host`);

--
-- Indici per le tabelle `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `games`
--
ALTER TABLE `games`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=982040;

--
-- AUTO_INCREMENT per la tabella `players`
--
ALTER TABLE `players`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT per la tabella `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `games`
--
ALTER TABLE `games`
  ADD CONSTRAINT `games_ibfk_1` FOREIGN KEY (`IdTable`) REFERENCES `tables` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `players`
--
ALTER TABLE `players`
  ADD CONSTRAINT `players_ibfk_1` FOREIGN KEY (`IdUser`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `players_ibfk_2` FOREIGN KEY (`IdTable`) REFERENCES `tables` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `tables`
--
ALTER TABLE `tables`
  ADD CONSTRAINT `tables_ibfk_1` FOREIGN KEY (`Host`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
