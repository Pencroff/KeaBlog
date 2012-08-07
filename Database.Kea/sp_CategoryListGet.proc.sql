CREATE PROCEDURE [dbo].[sp_CategoryListGet]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT c.[Id]
		  ,c.[Name]
		  ,c.[Description]
	FROM dbo.Categories c
END