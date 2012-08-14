CREATE PROCEDURE [dbo].[sp_PublicPostListByPageGet](
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
			FROM dbo.Posts p WHERE p.Visible = 1		
		)
	INSERT INTO @tab SELECT Id
    FROM 
		PostCTE 
	WHERE 
		RowNumber BETWEEN @startIndex AND @endIndex
	SELECT subTable.[Id]
			,p.[Title]
			,p.[PostUrl]
			,au.Name AS [AuthorName]
			,p.[FullContent]
			,p.[Visible]
			,p.[Modified]
			,c.Name AS [CategoryName]
			,p.LinkToOriginal
	FROM dbo.Posts p, @tab subTable, auth_Users au, Categories c 
		WHERE p.Id = subTable.Id AND p.AuthorId = au.Id AND p.CategoryId = c.Id
	
END