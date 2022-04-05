CREATE TABLE [dbo].[Businesses] (
    [BusinessID]     INT           IDENTITY (1, 1) NOT NULL,
    [BusinessName]   VARCHAR (255) NOT NULL,
    [AutoCategorize] BIT           NOT NULL,
    [LocalBusiness]  BIT           NOT NULL DEFAULT 0,
    [CategoryName]   VARCHAR (120) NULL,
    CONSTRAINT [PK_Businesses] PRIMARY KEY CLUSTERED ([BusinessID] ASC),
    CONSTRAINT [AK_Businesses] UNIQUE NONCLUSTERED ([BusinessName] ASC)
);



