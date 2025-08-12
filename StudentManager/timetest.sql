-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Aug 12, 2025 at 04:23 PM
-- Server version: 8.0.30
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `timetest`
--

-- --------------------------------------------------------

--
-- Table structure for table `categoriess`
--

CREATE TABLE `categoriess` (
  `id` int NOT NULL,
  `name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `classes`
--

CREATE TABLE `classes` (
  `id` int NOT NULL,
  `class_name` varchar(50) NOT NULL,
  `school_year` varchar(20) NOT NULL,
  `user_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `classes`
--

INSERT INTO `classes` (`id`, `class_name`, `school_year`, `user_id`) VALUES
(1, '10A1', '2024-2025', 25),
(2, '11A2', '2024-2025', 17),
(7, '12A1', '2024-2025', 18),
(8, '10A2', '2024-2025', 17);

-- --------------------------------------------------------

--
-- Table structure for table `grades`
--

CREATE TABLE `grades` (
  `id` int NOT NULL,
  `user_id` int NOT NULL,
  `subject_id` int NOT NULL,
  `school_year` varchar(20) NOT NULL,
  `semester` int NOT NULL,
  `oral_score` float DEFAULT NULL,
  `fifteen_score` float DEFAULT NULL,
  `one_period_score` float DEFAULT NULL,
  `exam_score` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `grades`
--

INSERT INTO `grades` (`id`, `user_id`, `subject_id`, `school_year`, `semester`, `oral_score`, `fifteen_score`, `one_period_score`, `exam_score`) VALUES
(1, 15, 1, '2024-2025', 1, 8, 9, 7, 8),
(2, 15, 2, '2024-2025', 1, 7, 8, 6, 9.5),
(3, 15, 3, '2024-2025', 1, 9, 8, 7, 9),
(5, 16, 2, '2024-2025', 1, 9.5, 8.5, 7.5, 9.5),
(6, 16, 3, '2024-2025', 1, 8, 8, 7, 6),
(7, 16, 1, '2024-2025', 1, 9, 9, 9, 9);

-- --------------------------------------------------------

--
-- Table structure for table `parents`
--

CREATE TABLE `parents` (
  `id` int NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `phone_number` varchar(15) DEFAULT NULL,
  `relationship` enum('Bố','Mẹ','Người giám hộ','Khác') DEFAULT NULL,
  `user_id` int NOT NULL,
  `email` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `parents`
--

INSERT INTO `parents` (`id`, `full_name`, `phone_number`, `relationship`, `user_id`, `email`) VALUES
(1, 'Le Thi Phuong', '09717402389', 'Mẹ', 13, 'lethiphuong@gmail.com'),
(2, 'Le Van Quan', '0971740239', 'Bố', 14, 'lavencu@gmail.com'),
(3, 'Le Van Hoang', '09717402389', 'Bố', 15, 'lavenHoang@gmail.com'),
(4, 'Le Van Hoang', '0971740239', 'Bố', 15, 'levanhoang@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int NOT NULL,
  `role_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `role_name`) VALUES
(3, 'admin'),
(1, 'student'),
(2, 'teacher');

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE `subjects` (
  `id` int NOT NULL,
  `subject_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `subjects`
--

INSERT INTO `subjects` (`id`, `subject_name`) VALUES
(1, 'Toán'),
(2, 'Văn'),
(3, 'Tiếng Anh'),
(5, 'Vat Ly'),
(6, 'Hóa Học');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int NOT NULL,
  `code` varchar(20) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `date_of_birth` date DEFAULT NULL,
  `gender` enum('Nam','Nữ','Khác') DEFAULT NULL,
  `class_id` int DEFAULT NULL,
  `address` text,
  `phone_number` varchar(15) DEFAULT NULL,
  `role_id` int NOT NULL,
  `avatar_url` varchar(255) DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `subject_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `code`, `full_name`, `date_of_birth`, `gender`, `class_id`, `address`, `phone_number`, `role_id`, `avatar_url`, `password`, `subject_id`) VALUES
(13, 'HS001', 'Lê Văn An', '2003-05-15', 'Nam', 2, '789 Đường C, Quận 3', '0956789012', 1, 'https://example.com/students/an.jpg', '$2a$10$a3STM0.xfOeYpScT8xq4u.W//s3mSyfI5va3R15R.4kfAlrqooaF.', 5),
(14, 'HS002', 'Trần Thị Bình', '2008-07-20', 'Nữ', 1, '456 Đường B, Quận 2', '0945678901', 1, 'https://example.com/students/binh.jpg', '$2y$10$samplehash5', 5),
(15, 'HS003', 'Lê Văn Cường', '2003-05-15', 'Nam', 2, '789 Đường C, Quận 3', '0956789012', 1, 'https://example.com/students/cuong.jpg', '$2a$10$bcWRd8MaPNRfWJVC7TiCXeppQPkf6VEuVwEQ4ffL.7mlhKnyGdP2a', 5),
(16, 'GV001', 'Nguyễn Thị Hồng', NULL, 'Nam', 1, 'rêtrtrt', '0901234567', 2, 'https://example.com/teachers/hong.jpg', '$2a$10$sHjSZQKESFZTg45yORHAtuaqk6jylp6tM6vUkbnkQibe/TXI87TcO', 1),
(17, 'GV002', 'Trần Văn Nam', NULL, NULL, 2, NULL, '0912345678', 2, 'https://example.com/teachers/nam.jpg', '$2y$10$samplehash2', 2),
(18, 'GV003', 'Lê Thị Mai', NULL, NULL, 2, NULL, '0923456789', 2, 'https://example.com/teachers/mai.jpg', '$2y$10$samplehash3', 3),
(24, 'HS004', 'Le Minh Tien', '2002-05-15', 'Nam', 1, 'Viet Nam', '0983478583', 1, NULL, '$2a$10$VmiUOcVSnaL0mqtBnxAZ7.9MkDZED3BrxobgUNVwEm5ACydIjqi6q', 5),
(25, 'GV004', 'Le Quang Minh', '2002-05-15', 'Nam', 1, 'Viet Nam', '0983478583', 2, NULL, '$2a$10$Y8d.eimu0Fpwv1INgBI.ne0ULDnSPqtFGBYaT2rhwBtiyfM2WxefC', 2),
(26, 'ADMIN001', 'Le Quang Duy', '2002-05-15', 'Nam', 2, 'Viet Nam', '0983478583', 3, NULL, '$2a$10$u/wmhclIyp1oRTbJnZdQjONv4Fhw81RBlc1S4fBEOyLq7hiq2EmNC', 2),
(27, 'HS005', 'Lê Trần Phong', '2025-03-30', 'Nam', 1, 'Miền nam Việt nam', '0983647295', 1, NULL, '$2a$10$I83ZhG3JT55kVqzgh1aPFOMig3FaQ3MSXCMmJPam7s79BgeW3r81G', 5),
(30, 'HS006', 'Lê Trần Phong', '2025-03-30', 'Nam', 1, 'Miền nam Việt nam', '0983647295', 1, NULL, '$2a$10$jdsTOWMn9SZtkQ90pzrsI.pDZhnitgsQZfRm6ymB9htZnZMumuw3u', 5);

-- --------------------------------------------------------

--
-- Table structure for table `your_entity`
--

CREATE TABLE `your_entity` (
  `id` bigint NOT NULL,
  `name` varchar(255) NOT NULL,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `expired_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `your_entity`
--

INSERT INTO `your_entity` (`id`, `name`, `created_at`, `updated_at`, `expired_at`) VALUES
(1, 'name tien le', '2025-04-10 14:46:31', '2025-04-10 14:46:31', '2025-04-13 17:49:31');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categoriess`
--
ALTER TABLE `categoriess`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `classes`
--
ALTER TABLE `classes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `grades`
--
ALTER TABLE `grades`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_user` (`user_id`),
  ADD KEY `fk_subject` (`subject_id`);

--
-- Indexes for table `parents`
--
ALTER TABLE `parents`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `role_name` (`role_name`);

--
-- Indexes for table `subjects`
--
ALTER TABLE `subjects`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `class_id` (`class_id`),
  ADD KEY `role_id` (`role_id`),
  ADD KEY `subject_id` (`subject_id`);

--
-- Indexes for table `your_entity`
--
ALTER TABLE `your_entity`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categoriess`
--
ALTER TABLE `categoriess`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `classes`
--
ALTER TABLE `classes`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `grades`
--
ALTER TABLE `grades`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `parents`
--
ALTER TABLE `parents`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `subjects`
--
ALTER TABLE `subjects`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `your_entity`
--
ALTER TABLE `your_entity`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `classes`
--
ALTER TABLE `classes`
  ADD CONSTRAINT `classes_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `grades`
--
ALTER TABLE `grades`
  ADD CONSTRAINT `fk_subject` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`id`),
  ADD CONSTRAINT `fk_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `parents`
--
ALTER TABLE `parents`
  ADD CONSTRAINT `parents_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`),
  ADD CONSTRAINT `users_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`),
  ADD CONSTRAINT `users_ibfk_3` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
