﻿ALTER TABLE [dbo].[PostsInTags]
    ADD CONSTRAINT [FK_PostsInTags_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION;



