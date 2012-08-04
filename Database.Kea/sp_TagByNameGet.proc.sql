CREATE PROCEDURE [dbo].[sp_TagByNameGet](
    @tagName NVARCHAR(64)
)
AS
BEGIN
	SELECT t.[Id]
		  ,t.[Name]
  FROM [dbo].[Tags] t
	WHERE t.[Name] = @tagName
END