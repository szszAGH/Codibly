﻿CREATE TABLE [dbo].[Mail]
(
	[IdMail] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[IdPriority] INT NOT NULL, 
    [Titel] NVARCHAR(MAX) NULL, 
    [Body] TEXT NULL
)
