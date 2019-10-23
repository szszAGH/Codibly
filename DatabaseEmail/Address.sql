CREATE TABLE [dbo].[Address] (
    [Id]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [IdMail]  BIGINT         NOT NULL,
    [IdType]  INT            NOT NULL,
    [Address] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Address_Mail] FOREIGN KEY ([IdMail]) REFERENCES [dbo].[Mail] ([IdMail]),
    CONSTRAINT [FK_Address_Types] FOREIGN KEY ([IdType]) REFERENCES [dbo].[Types] ([IdType])
);


