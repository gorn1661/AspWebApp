-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 29 Gru 2017, 20:41
-- Wersja serwera: 10.1.28-MariaDB
-- Wersja PHP: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `bankdatabase`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `login` varchar(50) NOT NULL,
  `phone_number` varchar(12) NOT NULL,
  `confirmed_pone_number` tinyint(1) NOT NULL,
  `email` varchar(50) NOT NULL,
  `confirmed_email` tinyint(1) NOT NULL,
  `password_hash` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `clients`
--

INSERT INTO `clients` (`id`, `first_name`, `last_name`, `login`, `phone_number`, `confirmed_pone_number`, `email`, `confirmed_email`, `password_hash`) VALUES
(1, 'Adam', 'Nowak', 'adamXNowak66', '+48512654325', 1, 'adamXN@gmail.com', 1, 'bfr67ue4ygbfhjk'),
(2, 'Urszula', 'Majewski', 'UrszulaMajewski39539', '+48903629290', 1, 'UrszulaMajewski51@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(3, 'Arkadiusz', 'Chmielewski', 'ArkadiuszChmielewski96260', '+48225013144', 1, 'ArkadiuszChmielewski72@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(4, 'Artur', 'Kubiak', 'ArturKubiak31759', '+48442047583', 1, 'ArturKubiak17@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(5, 'S?awomir', 'Sadowski', 'S?awomirSadowski32016', '+48792394852', 1, 'S?awomirSadowski85@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(6, 'Sebastian', 'Wójcik', 'SebastianWójcik98004', '+48371682119', 1, 'SebastianWójcik88@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(7, 'Zbigniew', 'Zakrzewski', 'ZbigniewZakrzewski86572', '+48169320112', 1, 'ZbigniewZakrzewski58@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(8, 'Lambert', 'Dudek', 'LambertDudek96706', '+48544919223', 1, 'LambertDudek26@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(9, 'Krystian', 'Czerwi?ski', 'KrystianCzerwi?ski73786', '+48943905920', 1, 'KrystianCzerwi?ski91@gmail.com', 1, '24018924918015621322113611552296162101989510019724748'),
(10, 'Bart?omiej', 'Wieczorek', 'Bart?omiejWieczorek98767', '+48256279008', 1, 'Bart?omiejWieczorek68@gmail.com', 1, '24018924918015621322113611552296162101989510019724748');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
