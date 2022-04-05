CREATE TABLE [dbo].[Category] (
    [CategoryID]        INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName]      VARCHAR (120) NOT NULL,
    [Type]              VARCHAR (50)  NULL,
    [Frequency]         VARCHAR (255) NULL,
    [SpecificDate]      DATETIME      NULL,
    [StaticAmount]      MONEY         NULL,
    [DayOfMonth]        INT           NULL,
    [ExcludeFromBudget] BIT           NOT NULL,
    [NextOccurance]     DATETIME      NULL,
    [c1]                MONEY         NULL,
    [c2]                MONEY         NULL,
    [c3]                MONEY         NULL,
    [c4]                MONEY         NULL,
    [c5]                MONEY         NULL,
    [c6]                MONEY         NULL,
    [c7]                MONEY         NULL,
    [c8]                MONEY         NULL,
    [c9]                MONEY         NULL,
    [c10]               MONEY         NULL,
    [c11]               MONEY         NULL,
    [c12]               MONEY         NULL,
    [EndDate]           DATETIME      NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [IX_CategoryName] UNIQUE NONCLUSTERED ([CategoryName] ASC)
);



