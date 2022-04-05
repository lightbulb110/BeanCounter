using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeanCounter.BusinessLogic
{
    public class OpenFinancialExchange
    {
        public BankAccount BankAccount { get; set; }

        public List<Transaction> Transactions { get; set; }

        public static OpenFinancialExchange GetData(string filename)
        {
            OpenFinancialExchange data = new OpenFinancialExchange()
            {
                BankAccount = GetBankAccount(filename),
                Transactions = GetTransactions(filename)
            };
            return data;
        }
        internal static BankAccount GetBankAccount(string filename)
        {
            BankAccount bankAccount = null;
            if (Path.GetExtension(filename) == ".qfx")
            {
                string fileContents;
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    fileContents = streamReader.ReadToEnd();
                }
                string accountId = ExtractText(fileContents, "<ACCTID>", 1);
                string organziationId = ExtractText(fileContents, "<ORG>", 1).ToString().Replace(",", " ");
                string financialInstitutionId = ExtractText(fileContents, "<FID>", 1);
                string accountType = "";
                if (fileContents.ToUpper().Contains("BANKACCTFROM"))
                {
                    accountType = ExtractText(fileContents, "<ACCTTYPE>", 1);
                }
                else if (fileContents.ToUpper().Contains("</CCACCTFROM"))
                {
                    accountType = "CREDIT";
                }
                string balanceAmount = ExtractText(fileContents, "<BALAMT>", 1);
                decimal accountBalance = Convert.ToDecimal(balanceAmount);
                string dtasof = ExtractText(fileContents, "<DTASOF>", 1);
                DateTime balanceDate = GetBalanceDateTime(dtasof);
                string timeZone = string.Empty;
                if (dtasof.Length >= 18)
                {
                    dtasof.Substring(18);
                }
                bankAccount = new BankAccount()
                {
                    AccountNumber = accountId,
                    BankName = organziationId,
                    BankFID = financialInstitutionId,
                    AccountType = accountType,
                    Balance = accountBalance,
                    BalanceDate = balanceDate,
                    TimeZone = timeZone
                };
            }
            else if (Path.GetExtension(filename) == ".csv")
            {

            }
            return bankAccount;
        }

        private static DateTime GetBalanceDateTime(string balanceDateTime)
        {
            DateTime _balanceDateTime = new DateTime();
            if (balanceDateTime.Length == 14)
            {
                _balanceDateTime = new DateTime(
                    Convert.ToInt32(balanceDateTime.Substring(0, 4)),
                    Convert.ToInt32(balanceDateTime.Substring(4, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(6, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(8, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(10, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(12, 2))
                );
            }
            else if (balanceDateTime.Length == 18)
            {
                _balanceDateTime = new DateTime(
                    Convert.ToInt32(balanceDateTime.Substring(0, 4)),
                    Convert.ToInt32(balanceDateTime.Substring(4, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(6, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(8, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(10, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(12, 2)),
                    Convert.ToInt32(balanceDateTime.Substring(15, 3))
                );
            }
            else if (balanceDateTime.Length > 18)
            {
                //todo record timezone, etc.
                var year = Convert.ToInt32(balanceDateTime.Substring(0, 4));
                var month = Convert.ToInt32(balanceDateTime.Substring(4, 2));
                var day = Convert.ToInt32(balanceDateTime.Substring(6, 2));
                var hour = Convert.ToInt32(balanceDateTime.Substring(8, 2));
                var minute = Convert.ToInt32(balanceDateTime.Substring(10, 2));
                var second = Convert.ToInt32(balanceDateTime.Substring(12, 2));

                var remander = balanceDateTime.Substring(15, 3);
                
                var remanderIsNumeric = int.TryParse("123", out int microsecond);

                //var microsecond = Convert.ToInt32(remander);

                if (remanderIsNumeric)
                {
                    _balanceDateTime = new DateTime(
                        year,
                        month,
                        day,
                        hour,
                        minute,
                        second,
                        microsecond
                    );
                } else
                {
                    _balanceDateTime = new DateTime(
                        year,
                        month,
                        day,
                        hour,
                        minute,
                        second
                    );

                }
            }
            return _balanceDateTime;
        }

        private static List<Transaction> GetTransactions(string filename)
        {
            List<Transaction> transactions = new List<Transaction>();
            if (Path.GetExtension(filename) == ".qfx")
            {
                string fileContents = string.Empty;
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    fileContents = streamReader.ReadToEnd();
                }
                int index = fileContents.IndexOf("<TRNTYPE>") - 1;
                var numberOfTransactions = GetNumberOfTransactions(fileContents);
                for (int _index = 0; _index != numberOfTransactions; _index++)
                {
                    Transaction transaction = new Transaction()
                    {
                        TransactionType = ExtractText(fileContents, "<TRNTYPE>", index)
                    };
                    if (transaction.TransactionType.ToUpper() == "CHECK")
                    {
                        transaction.CheckNumber = ExtractText(fileContents, "<CHECKNUM>", index);
                    }
                    transaction.DatePosted = ExtractDate(fileContents, "<DTPOSTED>", index);
                    if (fileContents.Contains("<DTUSER>"))
                    {
                        transaction.TransactionDate = ExtractDate(fileContents, "<DTUSER>", index);
                    }
                    transaction.TransactionAmount = Convert.ToDecimal(ExtractText(fileContents, "<TRNAMT>", index));
                    transaction.TransactionID = ExtractText(fileContents, "<FITID>", index);
                    transaction.BusinessName = ExtractText(fileContents, "<NAME>", index).Replace("&amp;", "").Trim();
                    string memo = "";
                    if (fileContents.Contains("<MEMO>"))
                    {
                        memo = ExtractText(fileContents, "<MEMO>", index).Replace("&amp;", "").Trim();
                    }
                    transaction.BankMemo = memo;
                    index = fileContents.IndexOf("<NAME>", index);
                    index = fileContents.IndexOf("<TRNTYPE>", index) - 1;
                    transactions.Add(transaction);
                }
            }
            else if (Path.GetExtension(filename) == ".csv")
            {
                string[] lines = File.ReadAllLines(filename);
                // first line is usually the field names
                var fieldNames = lines[0].ToString().Split(',');
                for (var i = 1; i < lines.Length; i++)
                {
                    Transaction transaction = GetTransaction(fieldNames, lines[1]);
                    transactions.Add(transaction);
                }

            }
            return transactions;
        }

        private static int GetNumberOfTransactions(string text)
        {
            int numberOfTransactions = 0;
            int length = 0;
            while (true)
            {
                int i = text.IndexOf("<TRNTYPE>", length);
                length = i;
                if (i == -1)
                {
                    break;
                }
                length += "<TRNTYPE>".Length;
                numberOfTransactions++;
            }
            return numberOfTransactions;
        }

        private static Transaction GetTransaction(string[] fieldNames, string lineitem)
        {
            Transaction transaction = new Transaction();
            for (int i = 0; i < fieldNames.Length; i++)
            {
                var fieldname = fieldNames[i];
                string field = lineitem.Split(',')[i];
                switch (fieldname)
                {
                    case "Date":
                        transaction.DatePosted = Convert.ToDateTime(field);
                        break;
                    case "Transaction":
                        transaction.TransactionType = field;
                        break;
                    case "Name":
                        transaction.BusinessName = field;
                        break;
                    case "Memo":
                        transaction.BankMemo = field;
                        break;
                    case "Amount":
                        transaction.TransactionAmount = Convert.ToDecimal(field);
                        break;
                }
            }
            return transaction;
        }

        internal static string ExtractText(string fileContents, string fieldName, int currentPosition)
        {
            string str = "";
            int num = fileContents.IndexOf(fieldName, currentPosition);
            int num1 = fileContents.Substring(num + fieldName.Length).IndexOf("<") + num;
            str = fileContents.Substring(num + fieldName.Length, num1 - num);
            if (str.Contains(Environment.NewLine))
            {
                str = str.Replace(Environment.NewLine, "");
            }
            if (str.Contains("\r"))
            {
                str = str.Replace("\r", "");
            }
            if (str.Contains("\n"))
            {
                str = str.Replace("\n", "");
            }
            if (str.Contains("\t"))
            {
                str = str.Replace("\t", "");
            }
            return str;
        }

        private static DateTime ExtractDate(string fileContents, string fieldName, int currentPosition)
        {
            string str = ExtractText(fileContents, fieldName, currentPosition);
            string[] strArrays = new string[] { str.Substring(0, 4), "/", str.Substring(4, 2), "/", str.Substring(6, 2) };
            return Convert.ToDateTime(string.Concat(strArrays));
        }

    }
}