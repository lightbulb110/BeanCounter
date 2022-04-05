

DECLARE @dbname NVARCHAR(128)
SET @dbname = N'BeanCounter'

IF EXISTS (SELECT NAME FROM master.dbo.sysdatabases WHERE ( '[' + NAME + ']' = @dbname OR NAME = @dbname ) )
BEGIN		

	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = @dbname
	USE [master]
	ALTER DATABASE [BeanCounter] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
	USE [master]
	/****** Object:  Database [BeanCounter]    Script Date: 6/6/2017 1:47:21 PM ******/
	DROP DATABASE [BeanCounter]

END

GO

CREATE DATABASE [BeanCounter]
GO

USE [BeanCounter]
CREATE USER BeanCounter FOR LOGIN BeanCounter WITH DEFAULT_SCHEMA=[dbo]
GO
USE [BeanCounter]
GO
ALTER ROLE [db_datareader] ADD MEMBER [BeanCounter]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [BeanCounter]
GO

USE [BeanCounter]
GO
GRANT EXECUTE TO [BeanCounter]
GO