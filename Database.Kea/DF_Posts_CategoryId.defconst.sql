ALTER TABLE [dbo].[Posts]
    ADD CONSTRAINT [DF_Posts_CategoryId] DEFAULT ((0)) FOR [CategoryId];

