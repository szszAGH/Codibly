﻿CREATE TABLE [dbo].[Address]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[IdMail] BIGINT  NOT NULL, 
    [IdType] INT NOT NULL,
	[Address] NVARCHAR(MAX) NOT NULL
)