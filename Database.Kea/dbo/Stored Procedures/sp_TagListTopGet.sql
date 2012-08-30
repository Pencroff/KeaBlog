CREATE PROCEDURE [dbo].[sp_TagListTopGet](
    @tagTop INT
)
AS
BEGIN

IF (@tagTop IS NULL) OR (@tagTop = 0)
	BEGIN
		WITH TagCTE ( Id
				,[Count]
				) AS 
			( 
				SELECT pit.[TagId] AS [Id]
					  ,Count(pit.[PostId]) AS [Count]
				FROM PostsInTags pit, Posts p WHERE p.Id = pit.PostId AND p.Visible = 1 GROUP BY pit.TagId 
			)
		SELECT cte.Id
				,t.Name
				,cte.[Count]
		FROM 
			TagCTE cte,Tags t
		WHERE 
			cte.Id = t.Id ORDER BY cte.[Count] DESC	
	END	
ELSE
	BEGIN
		WITH TagCTE ( Id
			,[Count]
			) AS 
			( 
				SELECT pit.[TagId] AS [Id]
					  ,Count(pit.[PostId]) AS [Count]
				FROM PostsInTags pit, Posts p WHERE p.Id = pit.PostId AND p.Visible = 1 GROUP BY pit.TagId 
			)
		SELECT TOP (@tagTop)cte.Id
				,t.Name
				,cte.[Count]
		FROM 
			TagCTE cte,Tags t
		WHERE 
			cte.Id = t.Id ORDER BY cte.[Count] DESC	
	END
END