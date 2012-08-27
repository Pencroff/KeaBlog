CREATE PROCEDURE [dbo].[sp_SearchPublicPostByPageQueryGet](
    @query  NVARCHAR(64)
   ,@startIndex INT
   ,@endIndex INT
   ,@count INT OUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @all TABLE (Id INT, RowNumber INT) 
	DECLARE @tab TABLE (Id INT)
	
	INSERT INTO @all SELECT p.Id AS Id
				,ROW_NUMBER() OVER (ORDER BY p.Modified DESC) AS 'RowNumber'
			FROM dbo.Posts p
					  WHERE ((@query IS NULL OR p.Title LIKE '%' + @query + '%' )
					OR    (@query IS NULL OR p.FullContent LIKE '%' + @query + '%' )) 
					AND p.Visible = 1
	SET @Count = (SELECT COUNT(Id) FROM @all)
	
	INSERT INTO @tab SELECT Id FROM @all WHERE RowNumber BETWEEN @StartIndex AND @EndIndex		
		
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
      ,dbo.fn_TagsByPostIdJson(pst.[Id]) AS TagsJson
  FROM [dbo].[Posts] pst, @tab subTable, [dbo].auth_Users au, [dbo].Categories c
	WHERE pst.Id = subTable.Id AND pst.AuthorId = au.Id AND pst.CategoryId = c.Id
END