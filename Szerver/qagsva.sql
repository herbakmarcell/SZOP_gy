-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Dec 03. 21:24
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `qagsva`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `drive`
--

CREATE TABLE `drive` (
  `id` int(11) NOT NULL,
  `student_name` varchar(256) NOT NULL,
  `distance` int(11) NOT NULL,
  `hours` int(11) NOT NULL,
  `description` varchar(256) DEFAULT 'Közúti közlekedés',
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `drive`
--

INSERT INTO `drive` (`id`, `student_name`, `distance`, `hours`, `description`, `date`) VALUES
(1, 'user3', 0, 0, 'Tanuló felvéve (banyik)', '2023-12-03'),
(17, 'user3', 12, 2, 'Gyakorlópálya', '2023-12-01'),
(18, 'user3', 45, 2, 'Közúti közlekedés', '2023-12-02'),
(19, 'user2', 0, 0, 'Tanuló felvéve (kov)', '2023-12-03'),
(20, 'user2', 40, 4, 'Közúti közlekedés', '2023-11-29'),
(21, 'user2', 540, 25, 'Összes óra utólag', '2023-12-02'),
(22, 'user2', 10, 1, 'Forgalmi vizsga', '2023-12-06'),
(23, 'user3', 30, 2, 'Közúti közlekedés', '2023-11-30');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `student_instructor`
--

CREATE TABLE `student_instructor` (
  `id` int(11) NOT NULL,
  `student` varchar(256) NOT NULL,
  `instructor` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `student_instructor`
--

INSERT INTO `student_instructor` (`id`, `student`, `instructor`) VALUES
(1, 'user', NULL),
(2, 'user2', 'kov'),
(3, 'user3', 'banyik');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tests`
--

CREATE TABLE `tests` (
  `id` int(11) NOT NULL,
  `student` varchar(256) NOT NULL,
  `instructor` varchar(256) NOT NULL,
  `invigilator` varchar(256) DEFAULT 'Kiválasztás alatt',
  `status` varchar(256) DEFAULT 'Még nincs értékelve',
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `tests`
--

INSERT INTO `tests` (`id`, `student`, `instructor`, `invigilator`, `status`, `date`) VALUES
(1, 'user2', 'kov', 'ksanyi', 'Még nincs értékelve', '2023-12-06');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(256) NOT NULL,
  `password` varchar(256) NOT NULL,
  `name` varchar(256) NOT NULL,
  `role` varchar(256) NOT NULL DEFAULT 'STUDENT'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `name`, `role`) VALUES
(1, 'user', '1a1dc91c907325c69271ddf0c944bc72', 'Teszt Elek', 'STUDENT'),
(2, 'user2', '1a1dc91c907325c69271ddf0c944bc72', 'Lassú Anett', 'STUDENT'),
(3, 'user3', '1a1dc91c907325c69271ddf0c944bc72', 'Herbák Marcell', 'STUDENT'),
(4, 'banyik', '1a1dc91c907325c69271ddf0c944bc72', 'Banyik Nándor', 'INSTRUCTOR'),
(5, 'kov', '1a1dc91c907325c69271ddf0c944bc72', 'Kovásznai Gergely', 'INSTRUCTOR'),
(6, 'ksanyi', '1a1dc91c907325c69271ddf0c944bc72', 'Király Sándor', 'INVIGILATOR');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `drive`
--
ALTER TABLE `drive`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `student_instructor`
--
ALTER TABLE `student_instructor`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `tests`
--
ALTER TABLE `tests`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `drive`
--
ALTER TABLE `drive`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT a táblához `student_instructor`
--
ALTER TABLE `student_instructor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `tests`
--
ALTER TABLE `tests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
