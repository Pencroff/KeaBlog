CREATE PROCEDURE [dbo].[sp_UserRolesGet](
    @login nvarchar(64)
)
AS
BEGIN
    SELECT ar.[Role]
  FROM dbo.auth_UsersInRoles auir, dbo.auth_Roles ar, auth_Users au
    WHERE au.[Login] = @login AND au.Id = auir.UserId AND auir.RoleId = ar.Id    
END