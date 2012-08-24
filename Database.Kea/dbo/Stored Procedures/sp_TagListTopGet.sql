﻿CREATE PROCEDURE [dbo].[sp_TagListTopGet](
    @tagTop INT
)
AS
BEGIN

IF (@tagTop IS NULL) OR (@tagTop = 0)
	BEGIN
		WITH TagCTE ( Id
				,Cnt
				) AS 
			( 
				SELECT pit.[TagId] AS [Id]
					  ,Count(pit.[PostId]) AS [Cnt]
				FROM PostsInTags pit GROUP BY pit.TagId 
			)
		SELECT cte.Id
				,t.Name
				,cte.Cnt
		FROM 
			TagCTE cte,Tags t
		WHERE 
			cte.Id = t.Id ORDER BY cte.Cnt DESC	
	END	
ELSE
	BEGIN
		WITH TagCTE ( Id
			,Cnt
			) AS 
			( 
				SELECT pit.[TagId] AS [Id]
					  ,Count(pit.[PostId]) AS [Cnt]
				FROM PostsInTags pit GROUP BY pit.TagId 
			)
		SELECT TOP (@tagTop)cte.Id
				,t.Name
				,cte.Cnt
		FROM 
			TagCTE cte,Tags t
		WHERE 
			cte.Id = t.Id ORDER BY cte.Cnt DESC	
	END
END