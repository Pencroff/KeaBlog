CREATE TABLE [dbo].[Tags] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (64) NOT NULL,
    [Created]  DATETIME      NOT NULL,
    [Modified] DATETIME      NULL
);

