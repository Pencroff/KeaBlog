CREATE PROCEDURE [dbo].[sp_PostListByPageGet](
    @startIndex INT
   ,@endIndex INT
   ,@Count INT OUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @tab TABLE (Id INT)
	
	SET @Count = (SELECT COUNT(Id) FROM dbo.Posts p);
				  
	--SET @sql = 'SELECT subTable.Category 
	--	  ,subTable.[Id]
	--FROM(
	--	SELECT pc.CategoryId AS Category 
	--		  ,pr.[Id]
	--		  ,ROW_NUMBER() OVER (PARTITION BY pc.CategoryId ORDER BY pr.QuantityOrdered DESC, pr.Id) AS ''RowNo''
	--	FROM dbo.Products pr, ProductCategories pc
	--	WHERE pc.CategoryId IN (' + @categoriesList + ') 
	--	AND pc.ProductId = pr.Id AND pr.Available = 1
	--)subTable WHERE subTable.RowNo <= ' + CAST(@quantity AS nvarchar(10)) + ' ORDER BY subTable.Category, subTable.RowNo;'
	
	--INSERT INTO @tab EXEC sp_executesql @sql		
	
	WITH PostCTE ( Id
			,RowNumber
			) AS 
		( 
			SELECT p.Id AS Id
				,ROW_NUMBER() OVER (ORDER BY p.Modified DESC, p.Id)AS 'RowNumber'
			FROM dbo.Posts p		
		)
	INSERT INTO @tab SELECT Id
    FROM 
		PostCTE 
	WHERE 
		RowNumber BETWEEN @startIndex AND @endIndex		
		
	SELECT subTable.[Id]
			,p.[Title]
			,p.[EntryUrl]
			,p.[AuthorId]
			,au.Name AS [AuthorName]
			,p.[ShortContent]
			,p.[Visible]
			,p.[Created]
			,p.[Modified]
			,p.[SEOKeywords]
			,p.[SEODescription]
	FROM dbo.Posts p, @tab subTable, [dbo].auth_Users au WHERE p.Id = subTable.Id AND p.AuthorId = au.Id
	
	
	--SELECT TOP(@quantity) pc.CategoryId AS Category 
	--	  ,pr.[Id]
	--	  ,pr.[Title]
	--	  ,pr.[TitleEn]
	--	  ,pr.[MainPicture]
	--	  ,pr.[Description]
	--	  ,pr.[Currency]
	--	  ,pr.[Price]
	--	  ,pr.[Available]
	--	  ,pr.[FriendlyUrl]
	--	  ,dbo.fn_AuthorsShortJsonByProductId(pr.[Id])AS AuthorsJson
	--	  ,dbo.fn_PublishersShortJsonByProductId(pr.[Id])AS PublishersJson
	--FROM dbo.Products pr, ProductCategories pc
 --   WHERE pc.CategoryId = @categoryId AND pc.ProductId = pr.Id AND pr.Available = 1
	--ORDER BY pr.QuantityOrdered DESC
	
	--WITH Products_CTE(
	--	 [Id]
	--	)
	--  AS
	--  (
	--  SELECT pc.ProductId AS Id
	--  FROM dbo.ProductCategories pc
	--	WHERE pc.CategoryId = @categoryId
	--  )
	--SELECT TOP(@quantity) @categoryId AS Category 
	--	  ,pr.[Id]
	--	  ,pr.[Title]
	--	  ,pr.[TitleEn]
	--	  ,pr.[MainPicture]
	--	  ,pr.[Currency]
	--	  ,pr.[Price]
	--	  ,pr.[Available]
	--	  ,pr.[FriendlyUrl]
	--	  ,dbo.fn_AuthorsXmlByProductId(pr.[Id])AS AuthorsXml
	--	  ,dbo.fn_PublishersXmlByProductId(pr.[Id])AS PublishersXml
	--FROM Products_CTE pcte, Products pr 
	--WHERE pcte.Id = pr.Id AND pr.Available = 1
	--ORDER BY pr.QuantityOrdered DESC
END