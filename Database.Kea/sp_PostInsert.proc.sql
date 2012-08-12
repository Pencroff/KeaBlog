CREATE PROCEDURE [dbo].[sp_PostInsert](
    @title nvarchar(256),
    @postUrl nvarchar(256),
    @authorId UNIQUEIDENTIFIER,
    @fullContent NVARCHAR (MAX),
    @visible BIT,
    @modified DATETIME,
    @seoKeywords NVARCHAR(128),
    @seoDescription NVARCHAR(256),
    @categoryId INT,
	@linkToOriginal NVARCHAR(512),
	@originalTitle NVARCHAR(128)
)
AS
BEGIN
	INSERT INTO [dbo].Posts
	(
		-- Id -- this column value is auto-generated
		Title,
		PostUrl,
		AuthorId,
		FullContent,
		Visible,
		Modified,
		SEOKeywords,
		SEODescription,
		CategoryId,
		LinkToOriginal,
		OriginalTitle
	)
	VALUES
	(
		@title /*{ Title }*/,
		@postUrl /*{ PostUrl }*/,
		@authorId /*{ AuthorId }*/,
		@fullContent /*{ FullContent }*/,
		@visible /*{ Visible }*/,
		@modified /*{ Modified }*/,
		@seoKeywords /*{ SEOKeywords }*/,
		@seoDescription /*{ SEODescription }*/,
		@categoryId /*{ CategoryId }*/,
		@linkToOriginal /*{ LinkToOriginal }*/,
		@originalTitle /*{ OriginalTitle }*/
	)   
	SELECT SCOPE_IDENTITY() 
END