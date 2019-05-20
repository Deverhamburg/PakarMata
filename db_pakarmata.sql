-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 20, 2019 at 01:54 PM
-- Server version: 10.1.32-MariaDB
-- PHP Version: 5.6.36

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_pakarmata`
--

-- --------------------------------------------------------

--
-- Table structure for table `aturan`
--

CREATE TABLE `aturan` (
  `idaturan` varchar(10) NOT NULL,
  `idpenyakit` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `aturan`
--

INSERT INTO `aturan` (`idaturan`, `idpenyakit`) VALUES
('R01', 'P01'),
('R02', 'P02'),
('R03', 'P03');

-- --------------------------------------------------------

--
-- Table structure for table `daturan`
--

CREATE TABLE `daturan` (
  `idaturan` varchar(10) NOT NULL,
  `idgejala` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `daturan`
--

INSERT INTO `daturan` (`idaturan`, `idgejala`) VALUES
('R01', 'G01'),
('R01', 'G02'),
('R01', 'G03'),
('R01', 'G10'),
('R01', 'G05'),
('R01', 'G06'),
('R01', 'G07'),
('R02', 'G02'),
('R02', 'G03'),
('R02', 'G08'),
('R02', 'G09'),
('R02', 'G04'),
('R02', 'G11'),
('R03', 'G12'),
('R03', 'G13'),
('R03', 'G14');

-- --------------------------------------------------------

--
-- Table structure for table `dkonsultasi`
--

CREATE TABLE `dkonsultasi` (
  `idkonsultasi` varchar(11) NOT NULL,
  `idgejala` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dkonsultasi`
--

INSERT INTO `dkonsultasi` (`idkonsultasi`, `idgejala`) VALUES
('K02', 'G01'),
('K02', 'G02'),
('K02', 'G03'),
('K02', 'G05'),
('K02', 'G06'),
('K02', 'G07'),
('K02', 'G10'),
('K03', 'G03'),
('K03', 'G04'),
('K03', 'G07'),
('K04', 'G12'),
('K04', 'G13'),
('K04', 'G14');

-- --------------------------------------------------------

--
-- Table structure for table `gejala`
--

CREATE TABLE `gejala` (
  `idgejala` varchar(10) NOT NULL,
  `nmgejala` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `gejala`
--

INSERT INTO `gejala` (`idgejala`, `nmgejala`) VALUES
('G01', 'Merasakan Nyeri Dimata'),
('G02', 'Merasakan Sakit Kepala'),
('G03', 'Merasa Mual atau Muntah'),
('G04', 'Penglihatan Kabur atau Berkabut'),
('G05', 'Bagian Putih Mata Menjadi Merah'),
('G06', 'Ukuran Pupil Kiri dan Kanan Menjadi Berbeda'),
('G07', 'Mendadak Kehilangan Penglihatan'),
('G08', 'Merasa Nyeri Dimata dan Didahi'),
('G09', 'Mata Merah'),
('G10', 'Penurunan Penglihatan atau Penglihatan Kabur'),
('G11', 'Melihat Pelangi atau Lingkaran Cahaya'),
('G12', 'Merasa Ingin Mengedip Terus Menerus dengan Menekan Kedipan Berlebihan'),
('G13', 'Mata Terasa SakitKkarena Posisi Mata Dalam Keadaan Membengkak'),
('G14', 'Penglihatan yang Tadinya Kabur Lama Kelamaan akan Kembali Normal');

-- --------------------------------------------------------

--
-- Table structure for table `konsultasi`
--

CREATE TABLE `konsultasi` (
  `idkonsultasi` varchar(10) NOT NULL,
  `tanggal` date NOT NULL DEFAULT '0000-00-00',
  `nama` varchar(100) NOT NULL,
  `hasil` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `konsultasi`
--

INSERT INTO `konsultasi` (`idkonsultasi`, `tanggal`, `nama`, `hasil`) VALUES
('K02', '2019-05-20', 'bambang', 'Glaukoma Sudut Tertutup Akut'),
('K03', '2019-05-20', 'asd', 'Tidak Di Temukan'),
('K04', '2019-05-20', 'a', 'Glaukoma Kronik');

-- --------------------------------------------------------

--
-- Table structure for table `penyakit`
--

CREATE TABLE `penyakit` (
  `idpenyakit` varchar(10) NOT NULL,
  `nmpenyakit` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `penyakit`
--

INSERT INTO `penyakit` (`idpenyakit`, `nmpenyakit`) VALUES
('P01', 'Glaukoma Sudut Tertutup Akut'),
('P02', 'Glaukoma Juvenil'),
('P03', 'Glaukoma Kronik');

-- --------------------------------------------------------

--
-- Stand-in structure for view `vaturan`
-- (See below for the actual view)
--
CREATE TABLE `vaturan` (
`idaturan` varchar(10)
,`idpenyakit` varchar(10)
,`nmpenyakit` varchar(50)
,`idgejala` varchar(10)
,`nmgejala` varchar(100)
);

-- --------------------------------------------------------

--
-- Structure for view `vaturan`
--
DROP TABLE IF EXISTS `vaturan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vaturan`  AS  select `daturan`.`idaturan` AS `idaturan`,`aturan`.`idpenyakit` AS `idpenyakit`,`penyakit`.`nmpenyakit` AS `nmpenyakit`,`daturan`.`idgejala` AS `idgejala`,`gejala`.`nmgejala` AS `nmgejala` from (((`daturan` join `aturan` on((`aturan`.`idaturan` = `daturan`.`idaturan`))) join `penyakit` on((`penyakit`.`idpenyakit` = `aturan`.`idpenyakit`))) join `gejala` on((`daturan`.`idgejala` = `gejala`.`idgejala`))) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aturan`
--
ALTER TABLE `aturan`
  ADD PRIMARY KEY (`idaturan`);

--
-- Indexes for table `gejala`
--
ALTER TABLE `gejala`
  ADD PRIMARY KEY (`idgejala`);

--
-- Indexes for table `konsultasi`
--
ALTER TABLE `konsultasi`
  ADD PRIMARY KEY (`idkonsultasi`);

--
-- Indexes for table `penyakit`
--
ALTER TABLE `penyakit`
  ADD PRIMARY KEY (`idpenyakit`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
