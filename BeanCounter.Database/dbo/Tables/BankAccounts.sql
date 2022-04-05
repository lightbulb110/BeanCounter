CREATE TABLE [dbo].[BankAccounts] (
    [BankAccountId]       INT            NOT NULL IDENTITY,
    [AccountName]         VARCHAR (150) NOT NULL,
    [WebAddress]          VARCHAR (50)  NOT NULL,
    [AccountNumber]       VARCHAR (50)  NULL,
    [BankName]            VARCHAR (100) NOT NULL,
    [BankFID]             VARCHAR (50)  NOT NULL,
    [AccountType]         VARCHAR (20)  NOT NULL,
    [RemoveFromBusiness]  VARCHAR (50)  NULL,
    [ReverseFields]       BIT            NOT NULL,
    [OnlineBalance]       MONEY          NULL,
    [RemoveFromBankMemo]  VARCHAR (255) NULL,
    [ExcludeFromBalances] TINYINT        NULL,
    [Inactive]            TINYINT        NULL, 
    CONSTRAINT [PK_BankAccounts] PRIMARY KEY ([BankAccountId])
);

