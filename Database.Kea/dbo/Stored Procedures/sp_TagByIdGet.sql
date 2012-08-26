CREATE PROCEDURE [dbo].[sp_TagByIdGet](
    @tagId INT
)
AS
BEGIN
	SELECT t.[Id]
		  ,t.[Name]
  FROM [dbo].[Tags] t
	WHERE t.[Id] = @tagId
END