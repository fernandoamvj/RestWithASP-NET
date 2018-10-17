CREATE TABLE `books` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Author` varchar(50) DEFAULT NULL,
  `LaunchDate` datetime(6) DEFAULT NULL,
  `Price` decimal(65,2) DEFAULT NULL,
  `Title` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
