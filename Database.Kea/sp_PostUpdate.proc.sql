CREATE PROCEDURE [dbo].[sp_PostUpdate](
	@postId INT,
    @title nvarchar(256),
    @entryUrl nvarchar(256),
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
	UPDATE [dbo].[Posts]
	   SET [Title] = @title
		  ,[EntryUrl] = @entryUrl
		  ,[ShortContent] = @shortContent
		  ,[FullContent] = @fullContent
		  ,[Visible] = @visible
		  ,[Modified] = @modified
		  ,[SEOKeywords] = @seoKeywords
		  ,[SEODescription] = @seoDescription
	 WHERE Id = @postId   
END