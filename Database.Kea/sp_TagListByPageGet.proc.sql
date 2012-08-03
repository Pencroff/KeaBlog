CREATE PROCEDURE [dbo].[sp_TagListByPageGet](
    @startIndex INT
   ,@endIndex INT
   ,@count INT OUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @tab TABLE (Id INT)
	
	SET @Count = (SELECT COUNT(Id) FROM dbo.Tags);
				  
	WITH TagCTE ( Id
			,RowNumber
			) AS 
		( 
			SELECT t.Id AS Id
				,ROW_NUMBER() OVER (ORDER BY t.Id)AS 'RowNumber'
			FROM dbo.Tags t		
		)
	INSERT INTO @tab SELECT Id
    FROM 
		TagCTE 
	WHERE 
		RowNumber BETWEEN @startIndex AND @endIndex		
		
	SELECT subTable.[Id]
			,t.[Name]
	FROM dbo.Tags t, @tab subTable 
		WHERE t.Id = subTable.Id
	
END