CREATE PROCEDURE [dbo].[sp_TagListByPostGet](
    @postId INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT pit.TagId
	FROM dbo.PostsInTags pit WHERE pit.PostId = @postId 
END