CREATE PROCEDURE [dbo].[sp_CategoryListTopGet](
    @categoryTop INT
)
AS
BEGIN

IF (@categoryTop IS NULL) OR (@categoryTop = 0)
	BEGIN
		WITH CategoryCTE ( Id
				,[Count]
				) AS 
			( 
				SELECT p.CategoryId AS [Id]
					  ,Count(p.[Id]) AS [Count]
				FROM Posts p GROUP BY p.CategoryId 
			)
		SELECT cte.Id
				,c.Name
				,cte.[Count]
		FROM 
			CategoryCTE cte, Categories c
		WHERE 
			cte.Id = c.Id ORDER BY cte.[Count] DESC	
	END	
ELSE
	BEGIN
		WITH CategoryCTE ( Id
				,[Count]
				) AS 
			( 
				SELECT p.CategoryId AS [Id]
					  ,Count(p.[Id]) AS [Count]
				FROM Posts p GROUP BY p.CategoryId 
			)
		SELECT TOP(@categoryTop) cte.Id
				,c.Name
				,cte.[Count]
		FROM 
			CategoryCTE cte, Categories c
		WHERE 
			cte.Id = c.Id ORDER BY cte.[Count] DESC	
	END
END