﻿CREATE TABLE [dbo].[RegisterUsers]
(
	[IdUser] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL
)