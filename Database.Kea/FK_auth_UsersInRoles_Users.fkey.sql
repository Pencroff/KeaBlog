ALTER TABLE [dbo].[auth_UsersInRoles]
    ADD CONSTRAINT [FK_auth_UsersInRoles_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[auth_Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

