CREATE PROCEDURE [dbo].[sp_UserByLoginGet](
    @login nvarchar(64)
)
AS
BEGIN
    SELECT [Id]
      ,[Login]
      ,[PassHash]
      ,[PassSalt]
      ,[Name]
      ,[Phone]
      ,[Email]
      ,[Address]
  FROM [dbo].[auth_Users]
    WHERE [Login] = @login
    
END