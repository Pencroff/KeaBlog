CREATE PROCEDURE [dbo].[sp_PostByUrlGet](
    @postUrl NVARCHAR(256)
)
AS
BEGIN
	SELECT pst.[Id]
      ,pst.[Title]
      ,pst.[PostUrl]
      ,pst.[AuthorId]
      ,au.Name AS [AuthorName]
      ,pst.[FullContent]
      ,pst.[Visible]
      ,pst.[Modified]
      ,pst.[SEOKeywords]
      ,pst.[SEODescription]
      ,pst.[CategoryId]
      ,c.Name AS [CategoryName]
      ,pst.[LinkToOriginal]
      ,pst.[OriginalTitle]
  FROM [dbo].[Posts] pst, [dbo].auth_Users au, [dbo].Categories c
	WHERE pst.[PostUrl] = @postUrl AND pst.AuthorId = au.Id AND pst.CategoryId = c.Id
END