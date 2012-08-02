CREATE PROCEDURE [dbo].[sp_CategoryListByPageGet](
    @startIndex INT
   ,@endIndex INT
   ,@count INT OUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @tab TABLE (Id INT)
	
	SET @Count = (SELECT COUNT(Id) FROM dbo.Posts p);
				  
	WITH CategoryCTE ( Id
			,RowNumber
			) AS 
		( 
			SELECT c.Id AS Id
				,ROW_NUMBER() OVER (ORDER BY c.Id)AS 'RowNumber'
			FROM dbo.Categories c		
		)
	INSERT INTO @tab SELECT Id
    FROM 
		CategoryCTE 
	WHERE 
		RowNumber BETWEEN @startIndex AND @endIndex		
		
	SELECT subTable.[Id]
			,c.[Name]
			,c.[Description]
	FROM dbo.Categories c, @tab subTable 
		WHERE c.Id = subTable.Id
	
END