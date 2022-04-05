CREATE PROCEDURE [dbo].[spLogAccountBalance]
	@BankAccountId INT
	,@Balance money
	,@BalanceDate datetime
	,@TimeZone varchar(12)
AS
BEGIN
	INSERT INTO [dbo].[BalanceHistory] (
		[BankAccountId]
		,[Balance]
		,[BalanceDate]
		,[TimeZone]
	) VALUES (
		@BankAccountId
		,@Balance
		,@BalanceDate
		,@TimeZone
	)
END