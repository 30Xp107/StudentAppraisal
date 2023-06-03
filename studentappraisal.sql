-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 07, 2022 at 09:40 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

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

--
-- Dumping data for table `addcourse`
--

INSERT INTO `addcourse` (`id`, `program`) VALUES
(10, 'BSIT');

-- --------------------------------------------------------

--
-- Table structure for table `addsubject`
--

CREATE TABLE `addsubject` (
  `id` int(11) NOT NULL,
  `Subject` longtext NOT NULL,
  `Description` varchar(255) NOT NULL,
  `Credit` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `addsubject`
--

INSERT INTO `addsubject` (`id`, `Subject`, `Description`, `Credit`) VALUES
(17, 'GEC 6', 'Art Appreciation', 3),
(18, 'GEC 4', 'Mathematics in Modern World', 3),
(19, 'PE 1', 'Educational Gymnastics', 3),
(20, 'GEC 1', 'Understanding the Self', 3),
(21, 'GEC 2', 'Readings in Philippine History', 3),
(22, 'GEC 5', 'Purposive Communication 1', 3),
(23, 'GEE 2', 'Panitikang Filipino', 3),
(24, 'COMSC 1', 'Discrete Structures', 3),
(25, 'GEE 3', 'Purposive Communication 2', 3),
(26, 'STAT 3', 'Probability and Inferential Statistics ', 3),
(27, 'COMSC 2', 'Discrete Structures 2', 3),
(28, 'DSTRU 1', 'Data Structures and Algorithms', 3),
(29, 'APDEV 1', 'Application Development Emerging Technologies', 3),
(30, 'COMSC 3', 'ALgorithms and Complexity', 3),
(31, 'COMSC 4', 'System Fundamentals', 3),
(32, 'CPROG 3', 'Object Oriented Programming', 3),
(33, 'MATH 6', 'Calculus 1', 3),
(34, 'GEC 7', 'Ethics', 3),
(35, 'TPREN 1', 'Technopreneurship', 3),
(36, 'COMSC 5', 'Automata Theory and Society', 3),
(37, 'COMSC 6', 'Software Engineering 1     ', 3),
(38, 'COMPE 1', 'Computer Science Elective 1', 3),
(39, 'INMGT 1', 'Information Management', 3),
(40, 'COMSC 8', 'Programming Languagaes', 3),
(41, 'COMSC 9', 'Software Engineering 2', 3),
(42, 'COMSC 10', 'Methods of Research  in Computing', 3),
(43, 'COMPE 2', 'Computer Science Elective 2', 3),
(44, 'COMPE 3', 'Computer Science Elective 3', 3),
(45, 'COMPE 4', 'Computer Elective 4', 3),
(46, 'COMPE 5', 'Computer Elective 5', 3),
(47, 'OPSYS 1', 'Operating Systems', 3),
(48, 'COMSC 12', 'Networks and Communication', 3),
(49, 'COMSC 13', 'CS Thesis Writing 1', 3),
(50, 'COMSC 14', 'Parallel and Distributed System', 3),
(52, 'COMSC 15', 'CS Thesis Writing 2', 3),
(53, 'COMPE 6', 'Computer Science Elective 6', 3),
(54, 'GEE 1', 'Masining na Pagpapahayag', 3),
(55, 'CSITC 1', 'Introduction to Computing', 3);

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

--
-- Dumping data for table `instructoraccount`
--

INSERT INTO `instructoraccount` (`id`, `InstructorID`, `InstructorName`, `ContactNo`, `DateofBirth`, `username`, `password`, `InstructorStatus`) VALUES
(11, '34567', 'qwe', '35678', '2022-10-11', 'qwe', 'qwe', 'Admin');

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

--
-- Dumping data for table `studentaccount`
--

INSERT INTO `studentaccount` (`ID`, `StudentID`, `StudentName`, `Program`, `YearLevel`, `ContactNo`, `DateofBirth`, `StudentStatus`, `username`, `password`, `InstructorName`, `instructorID`) VALUES
(42, '123456', 'Mae Veelyn Bernesto L.', 'BSIT', '4th Year', '092365138227', '2022-11-01', 'student', 'mae', 'mae', 'qwe', '34567');

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
  `Description` varchar(255) NOT NULL,
  `Credit` int(11) NOT NULL,
  `Semester` longtext NOT NULL,
  `FinalGrade` double NOT NULL,
  `Proceed` text NOT NULL,
  `StudentStatus` text NOT NULL,
  `InstructorName` longtext NOT NULL,
  `InstructorID` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `studentrating`
--

INSERT INTO `studentrating` (`ID`, `StudentName`, `StudentID`, `Program`, `YearLevel`, `Course`, `Description`, `Credit`, `Semester`, `FinalGrade`, `Proceed`, `StudentStatus`, `InstructorName`, `InstructorID`) VALUES
(41, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'GEC 6', 'Art Appreciation', 3, '1st Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(42, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'GEC 4', 'Mathematics in Modern World', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(43, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'PE 1', 'Educational Gymnastics', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(44, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'GEE 1', 'Masining na Pagpapahayag', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(45, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'CSITC 1', 'Introduction to Computing', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(46, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'GEC 1', 'Understanding the Self', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(47, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'GEC 2', 'Readings in Philippine History', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(48, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'GEC 5', 'Purposive Communication 1', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(49, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'GEE 2', 'Panitikang Filipino', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(50, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '1st Year', 'COMSC 1', 'Discrete Structures', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(51, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'GEE 3', 'Purposive Communication 2', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(52, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'STAT 3', 'Probability and Inferential Statistics ', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(53, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'COMSC 2', 'Discrete Structures 2', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(54, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'DSTRU 1', 'Data Structures and Algorithms', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(55, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'APDEV 1', 'Application Development Emerging Technologies', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(56, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'COMSC 3', 'ALgorithms and Complexity', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(57, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'COMSC 4', 'System Fundamentals', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(58, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'CPROG 3', '3', 0, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(59, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'MATH 6', 'Calculus 1', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(60, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '2nd Year', 'GEC 7', 'Ethics', 3, '2nd Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(61, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'TPREN 1', 'Technopreneurship', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(62, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMSC 5', 'Automata Theory and Society', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(63, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMSC 6', 'Software Engineering 1     ', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(64, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMPE 1', 'Computer Science Elective 1', 3, '1st Semester', 3, 'Yes', 'asdas', 'qwe', '34567'),
(65, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'INMGT 1', 'Information Management', 3, '1st Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(66, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMSC 8', 'Programming Languagaes', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(67, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMSC 9', 'Software Engineering 2', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(68, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMSC 10', 'Methods of Research  in Computing', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(69, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMPE 2', 'Computer Science Elective 2', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(70, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '3rd Year', 'COMPE 3', 'Computer Science Elective 3', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(71, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'COMPE 4', 'Computer Elective 4', 3, '1st Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(72, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'COMPE 5', 'Computer Elective 5', 3, '1st Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(73, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'OPSYS 1', 'Operating Systems', 3, '1st Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(74, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'COMSC 12', 'Networks and Communication', 3, '1st Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(75, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'COMSC 13', 'CS Thesis Writing 1', 3, '1st Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(76, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'COMSC 14', 'Parallel and Distributed System', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(77, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'COMSC 15', 'CS Thesis Writing 2', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567'),
(78, 'Mae Veelyn Bernesto L.', '123456', 'BSIT', '4th Year', 'COMPE 6', 'Computer Science Elective 6', 3, '2nd Semester', 3, 'Yes', 'student', 'qwe', '34567');

-- --------------------------------------------------------

--
-- Table structure for table `yearlevel`
--

CREATE TABLE `yearlevel` (
  `id` int(11) NOT NULL,
  `YearLevel` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `yearlevel`
--

INSERT INTO `yearlevel` (`id`, `YearLevel`) VALUES
(6, '1st Year'),
(7, '2nd Year'),
(8, '3rd Year'),
(9, '4th Year'),
(10, '5th Year');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `addsubject`
--
ALTER TABLE `addsubject`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;

--
-- AUTO_INCREMENT for table `instructoraccount`
--
ALTER TABLE `instructoraccount`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `studentaccount`
--
ALTER TABLE `studentaccount`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT for table `studentrating`
--
ALTER TABLE `studentrating`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=80;

--
-- AUTO_INCREMENT for table `yearlevel`
--
ALTER TABLE `yearlevel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
