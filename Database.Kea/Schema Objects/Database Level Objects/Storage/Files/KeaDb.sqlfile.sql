﻿ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [KeaDb], FILENAME = 'D:\SqlDatabase\KeaDb.mdf', SIZE = 3072 KB, FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

