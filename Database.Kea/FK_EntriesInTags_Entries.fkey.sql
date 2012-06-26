ALTER TABLE [dbo].[EntriesInTags]
    ADD CONSTRAINT [FK_EntriesInTags_Entries] FOREIGN KEY ([EntryId]) REFERENCES [dbo].[Entries] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

