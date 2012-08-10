CREATE PROCEDURE [dbo].[sp_PostTagsInsert](
    @postId INT,
    @tags nvarchar(256)
)
AS
BEGIN
	DECLARE @sql nvarchar(max)
	DELETE FROM [dbo].[PostsInTags] WHERE PostId = @postId
	IF (@tags IS NOT NULL AND @tags <> '' )
	BEGIN
		SET @sql = 'SELECT ' + CAST(@postId AS nvarchar(10)) +', t.Id FROM dbo.Tags t WHERE t.Id IN (' + @tags +')'
		INSERT INTO [dbo].PostsInTags EXEC sp_executesql @sql	
	END
END