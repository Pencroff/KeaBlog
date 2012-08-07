CREATE PROCEDURE [dbo].[sp_TagListGet]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT t.[Id]
		  ,t.[Name]
	FROM dbo.Tags t
END