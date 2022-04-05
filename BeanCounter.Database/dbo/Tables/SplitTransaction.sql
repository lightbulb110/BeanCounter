CREATE TABLE [dbo].[SplitTransaction] (
    [SplitTransactionID]   INT            IDENTITY (1, 1) NOT NULL,
    [OriginalTransactionID] INT            NULL,
    [TransactionAmount]    MONEY          NULL,
    [UserMemo]             VARCHAR (150) NULL,
    [CategoryName]         VARCHAR (255) NULL,
    CONSTRAINT [PK_SplitTransaction] PRIMARY KEY CLUSTERED ([SplitTransactionID] ASC),
    CONSTRAINT [FK_SplitTransaction_OriginalTransaction] FOREIGN KEY ([OriginalTransactionID]) REFERENCES [dbo].[OriginalTransaction] ([OriginalTransactionID]) ON DELETE CASCADE
);



