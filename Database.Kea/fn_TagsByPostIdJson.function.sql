CREATE FUNCTION [dbo].[fn_TagsByPostIdJson]
(
	@postId INT
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @tags NVARCHAR(MAX)
	SELECT @tags = COALESCE(@tags,'')+ ',{"Id":' + cast(t.[Id] as varchar(max))
			+',"Name":"' + REPLACE(t.[Name],'"','\"') + '"'
			+'}'
		FROM dbo.Tags t, dbo.PostsInTags pit 
		WHERE pit.PostId = @postId AND pit.TagId = t.Id
	SET @tags = '['+STUFF(@tags,1,1,'')+']'
	RETURN @tags
END