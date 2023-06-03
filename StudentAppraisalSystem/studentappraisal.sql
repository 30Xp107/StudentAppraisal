-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 11, 2022 at 05:01 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `studentappraisal`
--

-- --------------------------------------------------------

--
-- Table structure for table `addcourse`
--

CREATE TABLE `addcourse` (
  `id` int(11) NOT NULL,
  `program` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `addsubject`
--

CREATE TABLE `addsubject` (
  `id` int(11) NOT NULL,
  `Subject` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `instructoraccount`
--

CREATE TABLE `instructoraccount` (
  `id` int(11) NOT NULL,
  `InstructorID` text NOT NULL,
  `InstructorName` text NOT NULL,
  `ContactNo` text NOT NULL,
  `DateofBirth` date NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `InstructorStatus` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `studentaccount`
--

CREATE TABLE `studentaccount` (
  `ID` int(11) NOT NULL,
  `StudentID` text NOT NULL,
  `StudentName` text NOT NULL,
  `Program` text NOT NULL,
  `YearLevel` longtext NOT NULL,
  `ContactNo` text NOT NULL,
  `DateofBirth` date NOT NULL,
  `StudentStatus` text NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `InstructorName` longtext NOT NULL,
  `instructorID` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `studentrating`
--

CREATE TABLE `studentrating` (
  `ID` int(11) NOT NULL,
  `StudentName` longtext NOT NULL,
  `StudentID` text NOT NULL,
  `Program` longtext NOT NULL,
  `YearLevel` longtext NOT NULL,
  `Course` longtext NOT NULL,
  `Semester` longtext NOT NULL,
  `FinalGrade` int(11) NOT NULL,
  `Proceed` text NOT NULL,
  `StudentStatus` text NOT NULL,
  `InstructorName` longtext NOT NULL,
  `InstructorID` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `yearlevel`
--

CREATE TABLE `yearlevel` (
  `id` int(11) NOT NULL,
  `YearLevel` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `addcourse`
--
ALTER TABLE `addcourse`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `addsubject`
--
ALTER TABLE `addsubject`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `instructoraccount`
--
ALTER TABLE `instructoraccount`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `studentaccount`
--
ALTER TABLE `studentaccount`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `studentrating`
--
ALTER TABLE `studentrating`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `yearlevel`
--
ALTER TABLE `yearlevel`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `addcourse`
--
ALTER TABLE `addcourse`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `addsubject`
--
ALTER TABLE `addsubject`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `instructoraccount`
--
ALTER TABLE `instructoraccount`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `studentaccount`
--
ALTER TABLE `studentaccount`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `studentrating`
--
ALTER TABLE `studentrating`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `yearlevel`
--
ALTER TABLE `yearlevel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
