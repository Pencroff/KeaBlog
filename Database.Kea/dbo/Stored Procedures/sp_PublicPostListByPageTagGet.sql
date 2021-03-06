﻿CREATE PROCEDURE [dbo].[sp_PublicPostListByPageTagGet](
    @tagId INT
   ,@startIndex INT
   ,@endIndex INT
   ,@count INT OUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @tab TABLE (Id INT)
	
	SET @Count = (SELECT COUNT(Id) FROM dbo.Posts p, dbo.PostsInTags pit WHERE p.Visible = 1 AND pit.TagId = @tagId AND pit.PostId = p.Id);
				  
	WITH PostCTE ( Id
			,RowNumber
			) AS 
		( 
			SELECT p.Id AS Id
				,ROW_NUMBER() OVER (ORDER BY p.Modified DESC, p.Id)AS 'RowNumber'
			FROM dbo.Posts p, dbo.PostsInTags pit WHERE p.Visible = 1 AND pit.TagId = @tagId AND pit.PostId = p.Id		
		)
	INSERT INTO @tab SELECT Id
    FROM 
		PostCTE 
	WHERE 
		RowNumber BETWEEN @startIndex AND @endIndex
	SELECT subTable.[Id]
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
      ,dbo.fn_TagsByPostIdJson( pst.[Id])AS TagsJson
  FROM [dbo].[Posts] pst, @tab subTable, [dbo].auth_Users au, [dbo].Categories c
	WHERE pst.Id = subTable.Id AND pst.AuthorId = au.Id AND pst.CategoryId = c.Id	
END