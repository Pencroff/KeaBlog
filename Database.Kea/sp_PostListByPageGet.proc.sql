CREATE PROCEDURE [dbo].[sp_PostListByPageGet](
    @startIndex INT
   ,@endIndex INT
   ,@count INT OUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @tab TABLE (Id INT)
	
	SET @Count = (SELECT COUNT(Id) FROM dbo.Posts p);
				  
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
			,au.Name AS [AuthorName]
			,p.[ShortContent]
			,p.[Visible]
			,p.[Created]
			,p.[Modified]
	FROM dbo.Posts p, @tab subTable, [dbo].auth_Users au WHERE p.Id = subTable.Id AND p.AuthorId = au.Id
	
END