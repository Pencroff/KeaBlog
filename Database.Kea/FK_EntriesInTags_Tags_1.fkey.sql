﻿ALTER TABLE [dbo].[PostsInTags]
    ADD CONSTRAINT [FK_EntriesInTags_Tags] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

