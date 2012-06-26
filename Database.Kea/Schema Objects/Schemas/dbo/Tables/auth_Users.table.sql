CREATE TABLE [dbo].[auth_Users] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Login]    NVARCHAR (64)    NOT NULL,
    [PassHash] NVARCHAR (64)    NOT NULL,
    [PassSalt] NVARCHAR (16)    NOT NULL,
    [Name]     NVARCHAR (64)    NULL,
    [Phone]    NVARCHAR (16)    NULL,
    [Email]    NCHAR (128)      NULL,
    [Address]  NVARCHAR (256)   NULL
);

