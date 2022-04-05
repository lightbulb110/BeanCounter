CREATE TABLE [dbo].[OriginalTransaction] (
    [OriginalTransactionID] INT           IDENTITY (1, 1) NOT NULL,
    [BankAccountID]         INT           NULL,
    [TransactionID]         VARCHAR (150) NULL,
    [Verified]              BIT           NOT NULL,
    [Business]              VARCHAR (150) NULL,
    [DatePosted]       DATETIME      NOT NULL,
    [TransactionDate]       DATETIME      NULL,
    [TransactionAmount]     MONEY         NULL,
    [BankMemo]              VARCHAR (150) NULL,
    [TransactionType]       VARCHAR (150) NULL,
    [CheckNumber]           INT           NULL,
    [UserMemo]              VARCHAR (255) NULL,
    [CategoryName]          VARCHAR (255) NULL,
    [LegerBalance] MONEY NULL, 
    CONSTRAINT [PK_OriginalTransaction] PRIMARY KEY CLUSTERED ([OriginalTransactionID] ASC),
    CONSTRAINT [FK_OriginalTransaction_BankAccounts] FOREIGN KEY ([BankAccountID]) REFERENCES [dbo].[BankAccounts] ([BankAccountId]) ON DELETE CASCADE
);



