﻿ALTER TABLE [dbo].[Posts]
    ADD CONSTRAINT [FK_Posts_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE SET DEFAULT ON UPDATE NO ACTION;



