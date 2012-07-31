CREATE PROCEDURE [dbo].[sp_PostByIdGet](
    @postId INT
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
	WHERE pst.Id = @postId AND pst.AuthorId = au.Id AND pst.CategoryId = c.Id
END