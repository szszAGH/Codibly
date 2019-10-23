CREATE TABLE [dbo].[Mail] (
    [IdMail]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [IdPriority] INT            NOT NULL,
    [Titel]      NVARCHAR (MAX) NULL,
    [Body]       TEXT           NULL,
    PRIMARY KEY CLUSTERED ([IdMail] ASC),
    CONSTRAINT [FK_Mail_Priority] FOREIGN KEY ([IdPriority]) REFERENCES [dbo].[Priority] ([IdPriority])
);


