-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3307
-- Létrehozás ideje: 2026. Okt 10. 10:44
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `webapppeldadb`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasarlo`
--

CREATE TABLE `vasarlo` (
  `Id` int(11) NOT NULL,
  `Nev` varchar(128) NOT NULL,
  `Cim` varchar(256) DEFAULT NULL,
  `Email` varchar(128) NOT NULL,
  `Telefon` varchar(16) DEFAULT NULL,
  `Pontszam` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `vasarlo`
--

INSERT INTO `vasarlo` (`Id`, `Nev`, `Cim`, `Email`, `Telefon`, `Pontszam`) VALUES
(1, 'Kiss János', 'Budapest, Fő utca 1.', 'kissj@mail.com', '06-30-123-4567', 100),
(2, 'Nagy Péter', 'Debrecen, Kossuth utca 5.', 'nagyp@mail.com', '06-30-765-4321', 200),
(3, 'Don Alajandro', '1234 Budapest Fő tér 2', 'alejandro@mail.com', '+36306547128', 10),
(4, 'Buster Keaton', '21256 New York, 6th ave 3', 'keaton@mail.com', '+12456987', 2400),
(5, 'Axel Rose', '12346 Los Angeles', 'rose@mail.com', '+12456', 10);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `vasarlo`
--
ALTER TABLE `vasarlo`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `vasarlo`
--
ALTER TABLE `vasarlo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
