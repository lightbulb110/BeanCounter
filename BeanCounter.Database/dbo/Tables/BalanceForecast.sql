CREATE TABLE [dbo].[BalanceForecast] (
    [CashForecastID] INT      NOT NULL IDENTITY,
    [c1]             MONEY    NULL,
    [c2]             MONEY    NULL,
    [c3]             MONEY    NULL,
    [c4]             MONEY    NULL,
    [c5]             MONEY    NULL,
    [c6]             MONEY    NULL,
    [c7]             MONEY    NULL,
    [c8]             MONEY    NULL,
    [c9]             MONEY    NULL,
    [c10]            MONEY    NULL,
    [c11]            MONEY    NULL,
    [c12]            MONEY    NULL,
    [DateCalculated] DATETIME NULL,
    [AddOverages]    BIT      NOT NULL,
    [Overages]       INT      NULL, 
    CONSTRAINT [PK_BalanceForecast] PRIMARY KEY ([CashForecastID])
);

