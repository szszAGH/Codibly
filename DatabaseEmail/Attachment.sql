CREATE TABLE [dbo].[Attachment]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL, 
	[IdMail] BIGINT NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Content] IMAGE NOT NULL, 
    CONSTRAINT [PK_Attachment] PRIMARY KEY ([Id])
)
