CREATE TABLE [dbo].[Posts] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [Title]          NVARCHAR (256)   NOT NULL,
    [EntryUrl]       NVARCHAR (256)   NOT NULL,
    [AuthorId]       UNIQUEIDENTIFIER NOT NULL,
    [FullContent]    NVARCHAR (MAX)   NULL,
    [Visible]        BIT              NOT NULL,
    [Modified]       DATETIME         NOT NULL,
    [SEOKeywords]    NVARCHAR (128)   NULL,
    [SEODescription] NVARCHAR (256)   NULL,
    [CategoryId]     INT              NOT NULL,
    [LinkToOriginal] NVARCHAR (512)   NULL,
    [OriginalTitle]  NVARCHAR (128)   NULL
);





