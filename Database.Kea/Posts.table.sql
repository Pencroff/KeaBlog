CREATE TABLE [dbo].[Posts] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [Title]          NVARCHAR (256)   NOT NULL,
    [EntryUrl]       NVARCHAR (256)   NOT NULL,
    [AuthorId]       UNIQUEIDENTIFIER NULL,
    [ShortContent]   NVARCHAR (1024)  NOT NULL,
    [FullContent]    NVARCHAR (MAX)   NOT NULL,
    [Visible]        BIT              NOT NULL,
    [Created]        DATETIME         NOT NULL,
    [Modified]       DATETIME         NULL,
    [SEOKeywords]    NVARCHAR (128)   NULL,
    [SEODescription] NVARCHAR (256)   NULL
);

