USE master;
GO
DROP DATABASE IF EXISTS Television;
GO
CREATE DATABASE Television
GO
USE Television

CREATE TABLE TvCurrent(
Id INT PRIMARY KEY IDENTITY,
Channel INT NOT NULL,
Volume INT NOT NULL,
Source INT NOT NULL,
DateCreated DATETIME NOT NULL DEFAULT(GETDATE())
)

CREATE TABLE TvSettings(
SettingsId INT PRIMARY KEY IDENTITY,
SettingsChannel INT NOT NULL,
SettingsVolume INT NOT NULL,
SettingsSource INT NOT NULL,
DateCreated DATETIME NOT NULL DEFAULT(GETDATE())
)

INSERT INTO TvSettings(SettingsChannel, SettingsVolume, SettingsSource)
VALUES (1, 20, 1)