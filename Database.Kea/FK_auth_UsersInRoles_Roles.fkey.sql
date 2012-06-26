ALTER TABLE [dbo].[auth_UsersInRoles]
    ADD CONSTRAINT [FK_auth_UsersInRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[auth_Roles] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

