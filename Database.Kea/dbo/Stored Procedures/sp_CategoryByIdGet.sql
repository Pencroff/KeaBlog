CREATE PROCEDURE [dbo].[sp_CategoryByIdGet](
    @categoryId INT
)
AS
BEGIN
	SELECT c.[Id]
		  ,c.[Name]
		  ,c.[Description]
  FROM [dbo].Categories c
	WHERE c.[Id] = @categoryId
END