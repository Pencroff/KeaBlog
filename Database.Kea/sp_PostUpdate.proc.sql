CREATE PROCEDURE [dbo].[sp_PostUpdate](
	@postId INT,
    @title nvarchar(256),
    @entryUrl nvarchar(256),
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
	UPDATE [dbo].[Posts]
	   SET [Title] = @title
		  ,[EntryUrl] = @entryUrl
		  ,[FullContent] = @fullContent
		  ,[Visible] = @visible
		  ,[Modified] = @modified
		  ,[SEOKeywords] = @seoKeywords
		  ,[SEODescription] = @seoDescription
		  ,CategoryId = @categoryId
		  ,LinkToOriginal = @linkToOriginal
		  ,OriginalTitle = @originalTitle
	 WHERE Id = @postId   
END