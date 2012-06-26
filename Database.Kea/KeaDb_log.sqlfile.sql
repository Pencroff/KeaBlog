ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [KeaDb_log], FILENAME = 'D:\SqlDatabase\KeaDb_log.ldf', SIZE = 1024 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

