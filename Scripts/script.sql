IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Brands] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Brand] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Description] varchar(500) NOT NULL,
    [NumberTumble] varchar(50) NOT NULL,
    [BrandId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Brand_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Brand_BrandId] ON [Brand] ([BrandId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181213013113_Initial', N'2.2.0-rtm-35687');

GO

ALTER TABLE [Brand] DROP CONSTRAINT [FK_Brand_Brands_BrandId];

GO

DROP TABLE [Brands];

GO

DROP INDEX [IX_Brand_BrandId] ON [Brand];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Brand]') AND [c].[name] = N'BrandId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Brand] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Brand] DROP COLUMN [BrandId];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Brand]') AND [c].[name] = N'Description');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Brand] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Brand] DROP COLUMN [Description];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Brand]') AND [c].[name] = N'NumberTumble');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Brand] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Brand] DROP COLUMN [NumberTumble];

GO

CREATE TABLE [Patrimony] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Description] varchar(500) NOT NULL,
    [NumberTumble] varchar(50) NOT NULL,
    [BrandId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Patrimony] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Patrimony_Brand_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Patrimony_BrandId] ON [Patrimony] ([BrandId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181213142650_CorrecaoMap', N'2.2.0-rtm-35687');

GO
