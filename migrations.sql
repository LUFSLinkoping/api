CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220514204845_CreateNews') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220514204845_CreateNews') THEN

    CREATE TABLE `News` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Status` int NOT NULL,
        `PublishedAt` datetime(6) NULL,
        `Title` longtext CHARACTER SET utf8mb4 NULL,
        `Image` longtext CHARACTER SET utf8mb4 NULL,
        `Content` longtext CHARACTER SET utf8mb4 NULL,
        `Featured` tinyint(1) NOT NULL,
        `Category` int NOT NULL,
        `AuthorId` bigint NULL,
        `CreatedAt` datetime(6) NULL,
        `UpdatedAt` datetime(6) NULL,
        CONSTRAINT `PK_News` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220514204845_CreateNews') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20220514204845_CreateNews', '6.0.5');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220528154908_CreateMember') THEN

    CREATE TABLE `Members` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Token` char(36) COLLATE ascii_general_ci NOT NULL,
        `PersonalNumber` varchar(16) CHARACTER SET utf8mb4 NULL,
        `FirstName` varchar(32) CHARACTER SET utf8mb4 NULL,
        `LastName` varchar(64) CHARACTER SET utf8mb4 NULL,
        `EmailAdress` varchar(128) CHARACTER SET utf8mb4 NULL,
        `PhoneNumber` varchar(16) CHARACTER SET utf8mb4 NULL,
        `PostAdress` varchar(64) CHARACTER SET utf8mb4 NULL,
        `ZipCode` varchar(7) CHARACTER SET utf8mb4 NULL,
        `City` varchar(32) CHARACTER SET utf8mb4 NULL,
        `JoinedDate` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_Members` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220528154908_CreateMember') THEN

    CREATE TABLE `MemberRegistrations` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Year` int NOT NULL,
        `MemberId` bigint NOT NULL,
        `RegistrationType` int NOT NULL,
        `SDGF` int NOT NULL,
        `PDGA` int NOT NULL,
        `Status` int NOT NULL,
        CONSTRAINT `PK_MemberRegistrations` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_MemberRegistrations_Members_MemberId` FOREIGN KEY (`MemberId`) REFERENCES `Members` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220528154908_CreateMember') THEN

    CREATE INDEX `IX_MemberRegistrations_MemberId` ON `MemberRegistrations` (`MemberId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220528154908_CreateMember') THEN

    CREATE UNIQUE INDEX `IX_MemberRegistrations_Year_MemberId` ON `MemberRegistrations` (`Year`, `MemberId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220528154908_CreateMember') THEN

    CREATE UNIQUE INDEX `IX_Members_PersonalNumber` ON `Members` (`PersonalNumber`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220528154908_CreateMember') THEN

    CREATE UNIQUE INDEX `IX_Members_Token` ON `Members` (`Token`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220528154908_CreateMember') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20220528154908_CreateMember', '6.0.5');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

