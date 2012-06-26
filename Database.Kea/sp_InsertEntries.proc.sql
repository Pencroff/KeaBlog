CREATE PROCEDURE [dbo].[sp_InsertEntries](
    @title nvarchar(256),
    @entryUrl nvarchar(256),
    @authorId UNIQUEIDENTIFIER,
    @shortContent NVARCHAR (1024),
    @fullContent NVARCHAR (MAX),
    @visible BIT,
    @created DATETIME,
    @modified DATETIME,
    @seoKeywords NVARCHAR(128),
    @seoDescription NVARCHAR(256)
)
AS
BEGIN
	INSERT INTO Entries
	(
		-- Id -- this column value is auto-generated
		Title,
		EntryUrl,
		AuthorId,
		ShortContent,
		FullContent,
		Visible,
		Created,
		Modified,
		SEOKeywords,
		SEODescription
	)
	VALUES
	(
		@title /*{ Title }*/,
		@entryUrl /*{ EntryUrl }*/,
		@authorId /*{ AuthorId }*/,
		@shortContent /*{ ShortContent }*/,
		@fullContent /*{ FullContent }*/,
		@visible /*{ Visible }*/,
		@created /*{ Created }*/,
		@modified /*{ Modified }*/,
		@seoKeywords /*{ SEOKeywords }*/,
		@seoDescription /*{ SEODescription }*/
	)    
END