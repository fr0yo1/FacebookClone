
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/15/2018 20:28:31
-- Generated from EDMX file: C:\Users\Adrian-Sandru\FacebookClone\FacebookClone\FacebookClone\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FacebookDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Albums_ToUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Albums] DROP CONSTRAINT [FK_Albums_ToUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Picture_ToAlbum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pictures] DROP CONSTRAINT [FK_Picture_ToAlbum];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_ToUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_ToUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Message_ToRUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Message_ToRUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Message_ToUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Message_ToUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Post_ToUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Post_ToUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Profile_ToAspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profiles] DROP CONSTRAINT [FK_Profile_ToAspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Comment_ToPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comment_ToPost];
GO
IF OBJECT_ID(N'[dbo].[FK_Posts_ToPicture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Posts_ToPicture];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRole];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Friendship_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friendship] DROP CONSTRAINT [FK_Friendship_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Friendship_AspNetUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friendship] DROP CONSTRAINT [FK_Friendship_AspNetUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles1_AspNetRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles1] DROP CONSTRAINT [FK_AspNetUserRoles1_AspNetRole];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles1_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles1] DROP CONSTRAINT [FK_AspNetUserRoles1_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Groups_ToUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_Groups_ToUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Post_ToGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Post_ToGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_Group];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Albums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Albums];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Pictures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pictures];
GO
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profiles];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[Friendship]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friendship];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles1];
GO
IF OBJECT_ID(N'[dbo].[GroupUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Albums'
CREATE TABLE [dbo].[Albums] (
    [album_id] int IDENTITY(1,1) NOT NULL,
    [user_id] nvarchar(128)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [date] datetime  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [comment_id] int IDENTITY(1,1) NOT NULL,
    [post_id] int  NOT NULL,
    [date] datetime  NOT NULL,
    [content] varchar(50)  NOT NULL,
    [user_id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [message_id] int IDENTITY(1,1) NOT NULL,
    [sender_id] nvarchar(128)  NOT NULL,
    [receiver_id] nvarchar(128)  NOT NULL,
    [date] datetime  NOT NULL,
    [content] varchar(50)  NOT NULL
);
GO

-- Creating table 'Pictures'
CREATE TABLE [dbo].[Pictures] (
    [picture_id] int IDENTITY(1,1) NOT NULL,
    [album_id] int  NOT NULL,
    [path] varchar(50)  NOT NULL,
    [date] datetime  NOT NULL,
    [description] varchar(50)  NOT NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [post_id] int IDENTITY(1,1) NOT NULL,
    [sender_id] nvarchar(128)  NOT NULL,
    [group_id] int  NULL,
    [picture_id] int  NULL,
    [date] datetime  NOT NULL,
    [content] varchar(50)  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [Id] nvarchar(128)  NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL,
    [age] nvarchar(max)  NOT NULL,
    [gender] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [group_id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(50)  NOT NULL,
    [administrator] nvarchar(128)  NOT NULL,
    [picture_path] varchar(50)  NOT NULL
);
GO

-- Creating table 'Friendship'
CREATE TABLE [dbo].[Friendship] (
    [AspNetUsers_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers1_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'GroupUser'
CREATE TABLE [dbo].[GroupUser] (
    [AspNetUsers_Id] nvarchar(128)  NOT NULL,
    [Groups_group_id] int  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [RoleId] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [album_id] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [PK_Albums]
    PRIMARY KEY CLUSTERED ([album_id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [comment_id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([comment_id] ASC);
GO

-- Creating primary key on [group_id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([group_id] ASC);
GO

-- Creating primary key on [message_id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([message_id] ASC);
GO

-- Creating primary key on [picture_id] in table 'Pictures'
ALTER TABLE [dbo].[Pictures]
ADD CONSTRAINT [PK_Pictures]
    PRIMARY KEY CLUSTERED ([picture_id] ASC);
GO

-- Creating primary key on [post_id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([post_id] ASC);
GO

-- Creating primary key on [Id] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetUsers_Id], [AspNetUsers1_Id] in table 'Friendship'
ALTER TABLE [dbo].[Friendship]
ADD CONSTRAINT [PK_Friendship]
    PRIMARY KEY CLUSTERED ([AspNetUsers_Id], [AspNetUsers1_Id] ASC);
GO

-- Creating primary key on [AspNetUsers_Id], [Groups_group_id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [PK_GroupUser]
    PRIMARY KEY CLUSTERED ([AspNetUsers_Id], [Groups_group_id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([RoleId], [UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [user_id] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [FK_Albums_ToUsers]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Profiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Albums_ToUsers'
CREATE INDEX [IX_FK_Albums_ToUsers]
ON [dbo].[Albums]
    ([user_id]);
GO

-- Creating foreign key on [album_id] in table 'Pictures'
ALTER TABLE [dbo].[Pictures]
ADD CONSTRAINT [FK_Picture_ToAlbum]
    FOREIGN KEY ([album_id])
    REFERENCES [dbo].[Albums]
        ([album_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Picture_ToAlbum'
CREATE INDEX [IX_FK_Picture_ToAlbum]
ON [dbo].[Pictures]
    ([album_id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [user_id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_ToUser]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_ToUser'
CREATE INDEX [IX_FK_Comments_ToUser]
ON [dbo].[Comments]
    ([user_id]);
GO

-- Creating foreign key on [administrator] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_Groups_ToUser]
    FOREIGN KEY ([administrator])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Groups_ToUser'
CREATE INDEX [IX_FK_Groups_ToUser]
ON [dbo].[Groups]
    ([administrator]);
GO

-- Creating foreign key on [receiver_id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Message_ToRUser]
    FOREIGN KEY ([receiver_id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Message_ToRUser'
CREATE INDEX [IX_FK_Message_ToRUser]
ON [dbo].[Messages]
    ([receiver_id]);
GO

-- Creating foreign key on [sender_id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Message_ToUser]
    FOREIGN KEY ([sender_id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Message_ToUser'
CREATE INDEX [IX_FK_Message_ToUser]
ON [dbo].[Messages]
    ([sender_id]);
GO

-- Creating foreign key on [sender_id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_ToUser]
    FOREIGN KEY ([sender_id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_ToUser'
CREATE INDEX [IX_FK_Post_ToUser]
ON [dbo].[Posts]
    ([sender_id]);
GO

-- Creating foreign key on [Id] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [FK_Profile_ToAspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [post_id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comment_ToPost]
    FOREIGN KEY ([post_id])
    REFERENCES [dbo].[Posts]
        ([post_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_ToPost'
CREATE INDEX [IX_FK_Comment_ToPost]
ON [dbo].[Comments]
    ([post_id]);
GO

-- Creating foreign key on [group_id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_ToGroup]
    FOREIGN KEY ([group_id])
    REFERENCES [dbo].[Groups]
        ([group_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_ToGroup'
CREATE INDEX [IX_FK_Post_ToGroup]
ON [dbo].[Posts]
    ([group_id]);
GO

-- Creating foreign key on [picture_id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Posts_ToPicture]
    FOREIGN KEY ([picture_id])
    REFERENCES [dbo].[Pictures]
        ([picture_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Posts_ToPicture'
CREATE INDEX [IX_FK_Posts_ToPicture]
ON [dbo].[Posts]
    ([picture_id]);
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'Friendship'
ALTER TABLE [dbo].[Friendship]
ADD CONSTRAINT [FK_Friendship_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers1_Id] in table 'Friendship'
ALTER TABLE [dbo].[Friendship]
ADD CONSTRAINT [FK_Friendship_AspNetUser1]
    FOREIGN KEY ([AspNetUsers1_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Friendship_AspNetUser1'
CREATE INDEX [IX_FK_Friendship_AspNetUser1]
ON [dbo].[Friendship]
    ([AspNetUsers1_Id]);
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Groups_group_id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_Group]
    FOREIGN KEY ([Groups_group_id])
    REFERENCES [dbo].[Groups]
        ([group_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupUser_Group'
CREATE INDEX [IX_FK_GroupUser_Group]
ON [dbo].[GroupUser]
    ([Groups_group_id]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------