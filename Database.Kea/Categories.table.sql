﻿CREATE TABLE [dbo].[Categories] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (512) NOT NULL,
    [Created]     DATETIME       NOT NULL,
    [Modified]    DATETIME       NULL
);
