
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/17/2024 21:45:19
-- Generated from EDMX file: C:\Users\spg-admin\source\repos\CMIForAll\CMIForAll\Models\CMIModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CMIBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CMIObjetivo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objetivos] DROP CONSTRAINT [FK_CMIObjetivo];
GO
IF OBJECT_ID(N'[dbo].[FK_PerspectivaObjetivo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objetivos] DROP CONSTRAINT [FK_PerspectivaObjetivo];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjetivoIndicador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Indicadores] DROP CONSTRAINT [FK_ObjetivoIndicador];
GO
IF OBJECT_ID(N'[dbo].[FK_IndicadorIndicador_Dato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Indicador_Datos] DROP CONSTRAINT [FK_IndicadorIndicador_Dato];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoIndicador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Indicadores] DROP CONSTRAINT [FK_TipoIndicador];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CMISet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CMISet];
GO
IF OBJECT_ID(N'[dbo].[Perspectivas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perspectivas];
GO
IF OBJECT_ID(N'[dbo].[Objetivos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objetivos];
GO
IF OBJECT_ID(N'[dbo].[Indicadores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Indicadores];
GO
IF OBJECT_ID(N'[dbo].[Indicador_Datos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Indicador_Datos];
GO
IF OBJECT_ID(N'[dbo].[Tipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CMISet'
CREATE TABLE [dbo].[CMISet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Periodo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Perspectivas'
CREATE TABLE [dbo].[Perspectivas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Objetivos'
CREATE TABLE [dbo].[Objetivos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Metrica] nvarchar(max)  NOT NULL,
    [Ponderacion] nvarchar(max)  NOT NULL,
    [CMIId] int  NOT NULL,
    [PerspectivaId] int  NOT NULL
);
GO

-- Creating table 'Indicadores'
CREATE TABLE [dbo].[Indicadores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Frecuencia_Medicion] nvarchar(max)  NOT NULL,
    [Unidad_Medida] nvarchar(max)  NOT NULL,
    [ObjetivoId] int  NOT NULL,
    [TipoId] int  NOT NULL
);
GO

-- Creating table 'Indicador_Datos'
CREATE TABLE [dbo].[Indicador_Datos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] nvarchar(max)  NOT NULL,
    [Fecha] nvarchar(max)  NOT NULL,
    [IndicadorId] int  NOT NULL
);
GO

-- Creating table 'Tipos'
CREATE TABLE [dbo].[Tipos] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Metas'
CREATE TABLE [dbo].[Metas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Valor_esperado] nvarchar(max)  NOT NULL,
    [Fecha_limite] nvarchar(max)  NOT NULL,
    [IndicadorId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CMISet'
ALTER TABLE [dbo].[CMISet]
ADD CONSTRAINT [PK_CMISet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Perspectivas'
ALTER TABLE [dbo].[Perspectivas]
ADD CONSTRAINT [PK_Perspectivas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [PK_Objetivos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Indicadores'
ALTER TABLE [dbo].[Indicadores]
ADD CONSTRAINT [PK_Indicadores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Indicador_Datos'
ALTER TABLE [dbo].[Indicador_Datos]
ADD CONSTRAINT [PK_Indicador_Datos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tipos'
ALTER TABLE [dbo].[Tipos]
ADD CONSTRAINT [PK_Tipos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Metas'
ALTER TABLE [dbo].[Metas]
ADD CONSTRAINT [PK_Metas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CMIId] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [FK_CMIObjetivo]
    FOREIGN KEY ([CMIId])
    REFERENCES [dbo].[CMISet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CMIObjetivo'
CREATE INDEX [IX_FK_CMIObjetivo]
ON [dbo].[Objetivos]
    ([CMIId]);
GO

-- Creating foreign key on [PerspectivaId] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [FK_PerspectivaObjetivo]
    FOREIGN KEY ([PerspectivaId])
    REFERENCES [dbo].[Perspectivas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerspectivaObjetivo'
CREATE INDEX [IX_FK_PerspectivaObjetivo]
ON [dbo].[Objetivos]
    ([PerspectivaId]);
GO

-- Creating foreign key on [ObjetivoId] in table 'Indicadores'
ALTER TABLE [dbo].[Indicadores]
ADD CONSTRAINT [FK_ObjetivoIndicador]
    FOREIGN KEY ([ObjetivoId])
    REFERENCES [dbo].[Objetivos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetivoIndicador'
CREATE INDEX [IX_FK_ObjetivoIndicador]
ON [dbo].[Indicadores]
    ([ObjetivoId]);
GO

-- Creating foreign key on [IndicadorId] in table 'Indicador_Datos'
ALTER TABLE [dbo].[Indicador_Datos]
ADD CONSTRAINT [FK_IndicadorIndicador_Dato]
    FOREIGN KEY ([IndicadorId])
    REFERENCES [dbo].[Indicadores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndicadorIndicador_Dato'
CREATE INDEX [IX_FK_IndicadorIndicador_Dato]
ON [dbo].[Indicador_Datos]
    ([IndicadorId]);
GO

-- Creating foreign key on [TipoId] in table 'Indicadores'
ALTER TABLE [dbo].[Indicadores]
ADD CONSTRAINT [FK_TipoIndicador]
    FOREIGN KEY ([TipoId])
    REFERENCES [dbo].[Tipos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoIndicador'
CREATE INDEX [IX_FK_TipoIndicador]
ON [dbo].[Indicadores]
    ([TipoId]);
GO

-- Creating foreign key on [IndicadorId] in table 'Metas'
ALTER TABLE [dbo].[Metas]
ADD CONSTRAINT [FK_IndicadorMeta]
    FOREIGN KEY ([IndicadorId])
    REFERENCES [dbo].[Indicadores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndicadorMeta'
CREATE INDEX [IX_FK_IndicadorMeta]
ON [dbo].[Metas]
    ([IndicadorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------