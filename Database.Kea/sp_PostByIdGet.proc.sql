CREATE PROCEDURE [dbo].[sp_PostByIdGet](
    @postId INT
)
AS
BEGIN
	SELECT pst.[Id]
      ,pst.[Title]
      ,pst.[EntryUrl]
      ,pst.[AuthorId]
      ,au.Name AS [AuthorName]
      ,pst.[ShortContent]
      ,pst.[FullContent]
      ,pst.[Visible]
      ,pst.[Created]
      ,pst.[Modified]
      ,pst.[SEOKeywords]
      ,pst.[SEODescription]
  FROM [dbo].[Posts] pst, [dbo].auth_Users au 
	WHERE pst.Id = @postId AND pst.AuthorId = au.Id
END