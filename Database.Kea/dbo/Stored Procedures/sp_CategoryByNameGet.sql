CREATE PROCEDURE [dbo].[sp_CategoryByNameGet](
    @categoryName NVARCHAR(64)
)
AS
BEGIN
	SELECT c.[Id]
		  ,c.[Name]
		  ,c.[Description]
  FROM [dbo].Categories c
	WHERE c.[Name] = @categoryName
END