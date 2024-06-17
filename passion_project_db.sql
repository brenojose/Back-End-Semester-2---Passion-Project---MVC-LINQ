-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 17, 2024 at 03:45 AM
-- Server version: 5.7.24
-- PHP Version: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `passion_project_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `CategoryId` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`CategoryId`, `Name`) VALUES
(1, 'Italian'),
(2, 'Indian'),
(3, 'Mexican'),
(4, 'Chinese'),
(5, 'American');

-- --------------------------------------------------------

--
-- Table structure for table `groceries`
--

CREATE TABLE `groceries` (
  `GroceryId` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `MealId` int(11) NOT NULL,
  `IngredientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `groceries`
--

INSERT INTO `groceries` (`GroceryId`, `Name`, `MealId`, `IngredientId`) VALUES
(1, 'Tomatoes', 1, 1),
(2, 'Chicken Breast', 2, 2),
(3, 'Ground Beef', 3, 3),
(4, 'Broccoli', 4, 4),
(5, 'Flour', 5, 5);

-- --------------------------------------------------------

--
-- Table structure for table `ingredients`
--

CREATE TABLE `ingredients` (
  `IngredientId` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Unit` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ingredients`
--

INSERT INTO `ingredients` (`IngredientId`, `Name`, `Unit`) VALUES
(1, 'Tomato', 'pcs'),
(2, 'Chicken', 'kg'),
(3, 'Beef', 'kg'),
(4, 'Broccoli', 'pcs'),
(5, 'Flour', 'g');

-- --------------------------------------------------------

--
-- Table structure for table `meals`
--

CREATE TABLE `meals` (
  `MealId` int(11) NOT NULL,
  `RecipeId` int(11) NOT NULL,
  `Day` varchar(100) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Note` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `meals`
--

INSERT INTO `meals` (`MealId`, `RecipeId`, `Day`, `Title`, `Note`) VALUES
(1, 1, 'Monday', 'Spaghetti Night', 'Family favorite.'),
(2, 2, 'Tuesday', 'Curry Night', 'Spicy and savory.'),
(3, 3, 'Wednesday', 'Taco Night', 'Always a hit.'),
(4, 4, 'Thursday', 'Stir Fry Night', 'Healthy and tasty.'),
(5, 5, 'Friday', 'Pancake Breakfast', 'Start the weekend right.');

-- --------------------------------------------------------

--
-- Table structure for table `recipeingredients`
--

CREATE TABLE `recipeingredients` (
  `RecipeId` int(11) NOT NULL,
  `IngredientId` int(11) NOT NULL,
  `Quantity` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `recipeingredients`
--

INSERT INTO `recipeingredients` (`RecipeId`, `IngredientId`, `Quantity`) VALUES
(1, 1, 3),
(2, 2, 1),
(3, 3, 0.5),
(4, 4, 2),
(5, 5, 200);

-- --------------------------------------------------------

--
-- Table structure for table `recipes`
--

CREATE TABLE `recipes` (
  `RecipeId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Description` text,
  `CategoryId` int(11) NOT NULL,
  `ImageUrl` varchar(255) DEFAULT NULL,
  `Instructions` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `recipes`
--

INSERT INTO `recipes` (`RecipeId`, `UserId`, `Title`, `Description`, `CategoryId`, `ImageUrl`, `Instructions`) VALUES
(1, 1, 'Spaghetti Bolognese', 'A classic Italian pasta dish.', 1, 'spaghetti.jpg', 'Cook pasta, prepare sauce, combine and serve.'),
(2, 2, 'Chicken Curry', 'A spicy and savory chicken curry.', 2, 'chickencurry.jpg', 'Cook chicken, prepare curry sauce, combine and serve.'),
(3, 3, 'Beef Tacos', 'Delicious beef tacos with fresh toppings.', 3, 'beeftacos.jpg', 'Cook beef, prepare toppings, assemble tacos and serve.'),
(4, 4, 'Vegetable Stir Fry', 'A healthy vegetable stir fry.', 4, 'veggiestirfry.jpg', 'Stir fry vegetables, add sauce, serve with rice.'),
(5, 5, 'Pancakes', 'Fluffy pancakes with syrup.', 5, 'pancakes.jpg', 'Prepare batter, cook pancakes, serve with syrup.');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserId` int(11) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `ProfilePicture` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserId`, `Username`, `Email`, `Password`, `ProfilePicture`) VALUES
(1, 'user1', 'user1@example.com', 'password1', 'profile1.jpg'),
(2, 'user2', 'user2@example.com', 'password2', 'profile2.jpg'),
(3, 'user3', 'user3@example.com', 'password3', 'profile3.jpg'),
(4, 'user4', 'user4@example.com', 'password4', 'profile4.jpg'),
(5, 'user5', 'user5@example.com', 'password5', 'profile5.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`CategoryId`);

--
-- Indexes for table `groceries`
--
ALTER TABLE `groceries`
  ADD PRIMARY KEY (`GroceryId`),
  ADD KEY `MealId` (`MealId`),
  ADD KEY `IngredientId` (`IngredientId`);

--
-- Indexes for table `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`IngredientId`);

--
-- Indexes for table `meals`
--
ALTER TABLE `meals`
  ADD PRIMARY KEY (`MealId`),
  ADD KEY `RecipeId` (`RecipeId`);

--
-- Indexes for table `recipeingredients`
--
ALTER TABLE `recipeingredients`
  ADD PRIMARY KEY (`RecipeId`,`IngredientId`),
  ADD KEY `IngredientId` (`IngredientId`);

--
-- Indexes for table `recipes`
--
ALTER TABLE `recipes`
  ADD PRIMARY KEY (`RecipeId`),
  ADD KEY `UserId` (`UserId`),
  ADD KEY `FK_Recipes_Categories` (`CategoryId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `CategoryId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `groceries`
--
ALTER TABLE `groceries`
  MODIFY `GroceryId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `IngredientId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `meals`
--
ALTER TABLE `meals`
  MODIFY `MealId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `recipes`
--
ALTER TABLE `recipes`
  MODIFY `RecipeId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `groceries`
--
ALTER TABLE `groceries`
  ADD CONSTRAINT `groceries_ibfk_1` FOREIGN KEY (`MealId`) REFERENCES `meals` (`MealId`),
  ADD CONSTRAINT `groceries_ibfk_2` FOREIGN KEY (`IngredientId`) REFERENCES `ingredients` (`IngredientId`);

--
-- Constraints for table `meals`
--
ALTER TABLE `meals`
  ADD CONSTRAINT `meals_ibfk_1` FOREIGN KEY (`RecipeId`) REFERENCES `recipes` (`RecipeId`);

--
-- Constraints for table `recipeingredients`
--
ALTER TABLE `recipeingredients`
  ADD CONSTRAINT `recipeingredients_ibfk_1` FOREIGN KEY (`RecipeId`) REFERENCES `recipes` (`RecipeId`),
  ADD CONSTRAINT `recipeingredients_ibfk_2` FOREIGN KEY (`IngredientId`) REFERENCES `ingredients` (`IngredientId`);

--
-- Constraints for table `recipes`
--
ALTER TABLE `recipes`
  ADD CONSTRAINT `FK_Recipes_Categories` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`CategoryId`),
  ADD CONSTRAINT `recipes_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
