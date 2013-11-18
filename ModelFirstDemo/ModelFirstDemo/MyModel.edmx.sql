
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/18/2013 13:26:51
-- Generated from EDMX file: c:\users\instructor\documents\visual studio 2012\Projects\ModelFirstDemo\ModelFirstDemo\MyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KlantProduct_Klant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KlantProduct] DROP CONSTRAINT [FK_KlantProduct_Klant];
GO
IF OBJECT_ID(N'[dbo].[FK_KlantProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KlantProduct] DROP CONSTRAINT [FK_KlantProduct_Product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Klants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klants];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[KlantProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlantProduct];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Klants'
CREATE TABLE [dbo].[Klants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Geboortedatum] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [Prijs] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'KlantProduct'
CREATE TABLE [dbo].[KlantProduct] (
    [Klant_Id] int  NOT NULL,
    [Products_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Klants'
ALTER TABLE [dbo].[Klants]
ADD CONSTRAINT [PK_Klants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Klant_Id], [Products_Id] in table 'KlantProduct'
ALTER TABLE [dbo].[KlantProduct]
ADD CONSTRAINT [PK_KlantProduct]
    PRIMARY KEY NONCLUSTERED ([Klant_Id], [Products_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Klant_Id] in table 'KlantProduct'
ALTER TABLE [dbo].[KlantProduct]
ADD CONSTRAINT [FK_KlantProduct_Klant]
    FOREIGN KEY ([Klant_Id])
    REFERENCES [dbo].[Klants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Products_Id] in table 'KlantProduct'
ALTER TABLE [dbo].[KlantProduct]
ADD CONSTRAINT [FK_KlantProduct_Product]
    FOREIGN KEY ([Products_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KlantProduct_Product'
CREATE INDEX [IX_FK_KlantProduct_Product]
ON [dbo].[KlantProduct]
    ([Products_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------