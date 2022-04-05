CREATE TABLE [dbo].[BalanceHistory] (
    [BalanceHistoryId] INT            IDENTITY (1, 1) NOT NULL,
    [BankAccountId]    INT            NOT NULL,
    [Balance]          MONEY NOT NULL,
    [CreateDate] DATETIME2 (7)    DEFAULT (getdate()) NOT NULL,
    [BalanceDate] DATETIME NOT NULL , 
    [TimeZone] VARCHAR(10) NULL, 
    CONSTRAINT [PK_BalanceHistory] PRIMARY KEY CLUSTERED ([BalanceHistoryId] ASC),
    CONSTRAINT [FK_BalanceHistory_BankAccounts] FOREIGN KEY ([BankAccountId]) REFERENCES [dbo].[BankAccounts] ([BankAccountId])
);


