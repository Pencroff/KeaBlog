﻿ALTER TABLE [dbo].[Posts]
    ADD CONSTRAINT [FK_Post_auth_Users] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[auth_Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

