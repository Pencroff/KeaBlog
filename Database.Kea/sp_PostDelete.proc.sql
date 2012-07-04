CREATE PROCEDURE [dbo].[sp_PostDelete](
    @postId INT
)
AS
BEGIN
	DELETE FROM [dbo].[Posts]
      WHERE Id = @postId
END