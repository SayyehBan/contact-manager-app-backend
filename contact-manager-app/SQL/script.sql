USE [master]
GO
/****** Object:  Database [ContactDB]    Script Date: 26/05/1403 19:21:27 ******/
CREATE DATABASE [ContactDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ContactDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContactDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContactDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ContactDB] SET  MULTI_USER 
GO
ALTER DATABASE [ContactDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContactDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContactDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ContactDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContactDB', N'ON'
GO
USE [ContactDB]
GO
/****** Object:  UserDefinedFunction [dbo].[ASCII]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[ASCII] (@source nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    DECLARE @pattern nvarchar(max)
    SET @pattern = N'rn'
    RETURN REPLACE(@source, @pattern, N' ')
END
GO
/****** Object:  UserDefinedFunction [dbo].[CleanString]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[CleanString] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN dbo.Fa2En(dbo.NullIfEmpty(dbo.FixPersianChars(@str)))
END
GO
/****** Object:  UserDefinedFunction [dbo].[En2Fa]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[En2Fa]
(
    @str NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    SET @str = REPLACE(@str, '0', N'۰')
    SET @str = REPLACE(@str, '1', N'۱')
    SET @str = REPLACE(@str, '2', N'۲')
    SET @str = REPLACE(@str, '3', N'۳')
    SET @str = REPLACE(@str, '4', N'۴')
    SET @str = REPLACE(@str, '5', N'۵')
    SET @str = REPLACE(@str, '6', N'۶')
    SET @str = REPLACE(@str, '7', N'۷')
    SET @str = REPLACE(@str, '8', N'۸')
    SET @str = REPLACE(@str, '9', N'۹')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[Fa2En]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Fa2En]
(
    @str NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    SET @str = REPLACE(@str, N'۰', '0')
    SET @str = REPLACE(@str, N'۱', '1')
    SET @str = REPLACE(@str, N'۲', '2')
    SET @str = REPLACE(@str, N'۳', '3')
    SET @str = REPLACE(@str, N'۴', '4')
    SET @str = REPLACE(@str, N'۵', '5')
    SET @str = REPLACE(@str, N'۶', '6')
    SET @str = REPLACE(@str, N'۷', '7')
    SET @str = REPLACE(@str, N'۸', '8')
    SET @str = REPLACE(@str, N'۹', '9')
    --iphone numeric
    SET @str = REPLACE(@str, N'٠', '0')
    SET @str = REPLACE(@str, N'١', '1')
    SET @str = REPLACE(@str, N'٢', '2')
    SET @str = REPLACE(@str, N'٣', '3')
    SET @str = REPLACE(@str, N'٤', '4')
    SET @str = REPLACE(@str, N'٥', '5')
    SET @str = REPLACE(@str, N'٦', '6')
    SET @str = REPLACE(@str, N'٧', '7')
    SET @str = REPLACE(@str, N'٨', '8')
    SET @str = REPLACE(@str, N'٩', '9')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[FixPersianChars]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[FixPersianChars] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    SET @str = ISNULL(@str, ' ')
    SET @str = CASE WHEN @str = 'string' THEN ' ' ELSE @str END
    SET @str = REPLACE(@str, N'ﮎ', N'ک')
    SET @str = REPLACE(@str, N'ﮏ', N'ک')
    SET @str = REPLACE(@str, N'ﮐ', N'ک')
    SET @str = REPLACE(@str, N'ﮑ', N'ک')
    SET @str = REPLACE(@str, N'ك', N'ک')
    SET @str = REPLACE(@str, N'ي', N'ی')
    SET @str = REPLACE(@str, N' ', N' ')
    SET @str = REPLACE(@str, N'‌', N' ')
    SET @str = REPLACE(@str, N'ھ', N'ه')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[HasValue]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[HasValue] 
(
    @value NVARCHAR(MAX),
    @ignoreWhiteSpace BIT
)
RETURNS BIT
AS
BEGIN
    RETURN CASE @ignoreWhiteSpace 
        WHEN 1 THEN CASE WHEN RTRIM(LTRIM(@value)) <> '' THEN 1 ELSE 0 END 
        ELSE CASE WHEN @value <> '' THEN 1 ELSE 0 END 
        END
END
GO
/****** Object:  UserDefinedFunction [dbo].[Msg]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[Msg] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN REPLACE(@str, N'Core .Net SqlClient Data Provider-', '') + dbo.CleanString(@str)
END
GO
/****** Object:  UserDefinedFunction [dbo].[NullIfEmpty]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   FUNCTION [dbo].[NullIfEmpty] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN CASE WHEN LEN(@str) = 0 THEN NULL ELSE @str END
END
GO
/****** Object:  UserDefinedFunction [dbo].[RemovePoint]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   FUNCTION [dbo].[RemovePoint] (@str nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    SET @str = REPLACE(@str, N',', N'')
    SET @str = REPLACE(@str, N'.', N'')
    SET @str = REPLACE(@str, N'/', N'')
    SET @str = REPLACE(@str, N'.', N'')
    RETURN @str
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToDecimal]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ToDecimal]
(
    @value NVARCHAR(MAX)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    RETURN CONVERT(DECIMAL(18,2), @value)
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToInt]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ToInt]
(
    @value NVARCHAR(MAX)
)
RETURNS INT
AS
BEGIN
    RETURN CONVERT(INT, @value)
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToNumeric]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ToNumeric]
(
    @value INT
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN FORMAT(@value, N'N0')
END
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Photo] [nvarchar](500) NULL,
	[Mobile] [varchar](11) NULL,
	[Email] [nvarchar](100) NULL,
	[JobID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[JobTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Groups]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Jobs] FOREIGN KEY([JobID])
REFERENCES [dbo].[Jobs] ([JobID])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Jobs]
GO
/****** Object:  StoredProcedure [dbo].[DeleteContact]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteContact]
    @ContactID AS INT
AS
    BEGIN
        DECLARE @PhotoPath NVARCHAR(500);

        -- دریافت آدرس تصویر قبل از حذف
        SELECT @PhotoPath = Photo
        FROM Contacts
        WHERE ContactID = @ContactID;

        -- حذف رکورد
        DELETE FROM Contacts
        WHERE ContactID = @ContactID;

        -- نمایش آدرس تصویر (در این مرحله باید NULL باشد)
        SELECT @PhotoPath AS Photo;
    END;
GO
/****** Object:  StoredProcedure [dbo].[FindContactID]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindContactID]
    @ContactID AS INT
AS
    BEGIN
        SELECT
            Contacts.ContactID,
            Contacts.FirstName,
            Contacts.LastName,
            Contacts.Photo,
            Contacts.Mobile,
            Contacts.Email,
            Jobs.JobTitle,
            Jobs.JobID,
            Groups.GroupTitle,
            Groups.GroupID
        FROM Contacts
            INNER JOIN Groups
                ON Contacts.GroupID = Groups.GroupID
            INNER JOIN Jobs
                ON Contacts.JobID = Jobs.JobID
        WHERE (Contacts.ContactID = @ContactID);
    END;
GO
/****** Object:  StoredProcedure [dbo].[GetContacts]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContacts]
AS
    BEGIN
        SELECT
            Contacts.ContactID,
            Contacts.FirstName,
            Contacts.LastName,
            Contacts.Photo,
            Contacts.Mobile,
            Contacts.Email,
            Jobs.JobTitle,
            Groups.GroupTitle
        FROM Contacts
            INNER JOIN Groups
                ON Contacts.GroupID = Groups.GroupID
            INNER JOIN Jobs
                ON Contacts.JobID = Jobs.JobID
        ORDER BY Contacts.LastName,
                 Contacts.FirstName;
    END;
GO
/****** Object:  StoredProcedure [dbo].[GetGroups]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetGroups]
AS
    BEGIN
        SELECT
            GroupID,
            GroupTitle
        FROM Groups
        ORDER BY GroupTitle;
    END;
GO
/****** Object:  StoredProcedure [dbo].[GetJob]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJob]
AS
    BEGIN
        SELECT
            JobID,
            JobTitle
        FROM Jobs
        ORDER BY JobTitle;
    END;
GO
/****** Object:  StoredProcedure [dbo].[InsertContact]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertContact]
    @FirstName AS NVARCHAR(50) = NULL,
    @LastName AS NVARCHAR(50) = NULL,
    @Photo AS NVARCHAR(500) = NULL,
    @Mobile AS NVARCHAR(11) = NULL,
    @Email AS NVARCHAR(100) = NULL,
    @JobID AS INT,
    @GroupID AS INT
AS
    BEGIN
        INSERT INTO Contacts (FirstName, LastName, Photo, Mobile, Email, JobID, GroupID)
        VALUES (@FirstName, @LastName, @Photo, @Mobile, @Email, @JobID, @GroupID);
        SELECT SCOPE_IDENTITY();
    END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateContact]    Script Date: 26/05/1403 19:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateContact]
    @ContactID AS INT,
    @FirstName AS NVARCHAR(50) = NULL,
    @LastName AS NVARCHAR(50) = NULL,
    @Photo AS NVARCHAR(500) = NULL,
    @Mobile AS NVARCHAR(11) = NULL,
    @Email AS NVARCHAR(100) = NULL,
    @JobID AS INT,
    @GroupID AS INT
AS
    BEGIN
        UPDATE Contacts
        SET
            FirstName = @FirstName,
            LastName = @LastName,
            Photo = CASE
                        WHEN @Photo <> N'' THEN
                            @Photo
                        ELSE
                            Photo
                    END,
            Mobile = @Mobile,
            Email = @Email,
            JobID = @JobID,
            GroupID = @GroupID
        WHERE (ContactID = @ContactID);

        EXECUTE dbo.FindContactID @ContactID = @ContactID; -- int
    END;
GO
USE [master]
GO
ALTER DATABASE [ContactDB] SET  READ_WRITE 
GO
