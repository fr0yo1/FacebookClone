
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/16/2018 14:35:58
-- Generated from EDMX file: C:\Users\Adrian-Sandru\FacebookClone\FacebookClone\FacebookClone\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DefaultConnection];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- Populate script

insert into [dbo].[MessageTypes] values ('normalMessage')
insert into [dbo].[MessageTypes] values ('friendRequest')
insert into [dbo].[MessageTypes] values ('groupRequest')
insert into [dbo].[MessageTypes] values ('adminWarning')

insert into AspNetRoles (id,Name) values (1,'User')
insert into AspNetRoles (id,Name) values (2,'Admin')

-- --------------------------------------------------
-- Populate script has ended
-- --------------------------------------------------