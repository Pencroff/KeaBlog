ALTER TABLE [dbo].[PostsInCategories]
    ADD CONSTRAINT [FK_PostsInCategories_PostsInCategories] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

