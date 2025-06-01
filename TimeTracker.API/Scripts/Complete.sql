IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE TABLE [Projects] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [DateCreated] datetime2 NOT NULL,
        [DateUpdated] datetime2 NULL,
        [IsDeleted] bit NOT NULL,
        [DateDeleted] datetime2 NULL,
        CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE TABLE [ProjectDetails] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NULL,
        [StartDate] datetime2 NULL,
        [EndDate] datetime2 NULL,
        [ProjectId] int NOT NULL,
        CONSTRAINT [PK_ProjectDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProjectDetails_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE TABLE [TimeEntries] (
        [Id] int NOT NULL IDENTITY,
        [Project] nvarchar(max) NOT NULL,
        [Start] datetime2 NOT NULL,
        [End] datetime2 NULL,
        [DateCreated] datetime2 NOT NULL,
        [DateUpdated] datetime2 NULL,
        [ProjectId] int NULL,
        CONSTRAINT [PK_TimeEntries] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TimeEntries_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE TABLE [ProjectUser] (
        [ProjectsId] int NOT NULL,
        [UsersId] int NOT NULL,
        CONSTRAINT [PK_ProjectUser] PRIMARY KEY ([ProjectsId], [UsersId]),
        CONSTRAINT [FK_ProjectUser_Projects_ProjectsId] FOREIGN KEY ([ProjectsId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProjectUser_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_ProjectDetails_ProjectId] ON [ProjectDetails] ([ProjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_ProjectUser_UsersId] ON [ProjectUser] ([UsersId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_TimeEntries_ProjectId] ON [TimeEntries] ([ProjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250506193114_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250506193114_InitialCreate', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    DROP TABLE [ProjectUser];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    DROP INDEX [IX_ProjectDetails_ProjectId] ON [ProjectDetails];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TimeEntries]') AND [c].[name] = N'Project');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [TimeEntries] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [TimeEntries] DROP COLUMN [Project];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    ALTER TABLE [Projects] ADD [UserId] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    CREATE INDEX [IX_Projects_UserId] ON [Projects] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    CREATE INDEX [IX_ProjectDetails_ProjectId] ON [ProjectDetails] ([ProjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    ALTER TABLE [Projects] ADD CONSTRAINT [FK_Projects_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510181019_Projects'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250510181019_Projects', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510185542_ProjectDetails'
)
BEGIN
    DROP INDEX [IX_ProjectDetails_ProjectId] ON [ProjectDetails];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510185542_ProjectDetails'
)
BEGIN
    CREATE UNIQUE INDEX [IX_ProjectDetails_ProjectId] ON [ProjectDetails] ([ProjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510185542_ProjectDetails'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250510185542_ProjectDetails', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510190256_UserProjectsRelation'
)
BEGIN
    ALTER TABLE [Projects] DROP CONSTRAINT [FK_Projects_Users_UserId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510190256_UserProjectsRelation'
)
BEGIN
    DROP INDEX [IX_Projects_UserId] ON [Projects];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510190256_UserProjectsRelation'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'UserId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Projects] DROP COLUMN [UserId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510190256_UserProjectsRelation'
)
BEGIN
    CREATE TABLE [ProjectUser] (
        [ProjectsId] int NOT NULL,
        [UsersId] int NOT NULL,
        CONSTRAINT [PK_ProjectUser] PRIMARY KEY ([ProjectsId], [UsersId]),
        CONSTRAINT [FK_ProjectUser_Projects_ProjectsId] FOREIGN KEY ([ProjectsId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProjectUser_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510190256_UserProjectsRelation'
)
BEGIN
    CREATE INDEX [IX_ProjectUser_UsersId] ON [ProjectUser] ([UsersId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250510190256_UserProjectsRelation'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250510190256_UserProjectsRelation', N'9.0.2');
END;

COMMIT;
GO

