CREATE TABLE [dbo].[SpecialCategories] (
    [AutoTransactionId] INT          IDENTITY (1, 1) NOT NULL,
    [Amount]            MONEY        NOT NULL,
    [Business] NCHAR(150) NOT NULL, 
	[CategoryName]   VARCHAR (255) NOT NULL,
	[TransactionType]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SpecialCategories] PRIMARY KEY CLUSTERED ([AutoTransactionId] ASC)
);


