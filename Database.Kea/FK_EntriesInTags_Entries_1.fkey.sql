﻿ALTER TABLE [dbo].[PostsInTags]
    ADD CONSTRAINT [FK_EntriesInTags_Entries] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

