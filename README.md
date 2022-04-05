# BeanCounter
BeanCounter is a Windows Forms Application written in C# and utilizing SQL Server for the backend. BeanCounter has been continuously developed for over 15 years now. The windows forms application will allow you to import QFX files into a SQL Server Backend. You can then run reports from within the application and also verify your transactions as they come in. It logs daily balances and is compatible with many banking institutions. 

The Project also contains the database schema in the form of a MS Database Project (solution). You can also find the PowerShell scripts that will create the SQL Server Database for you, using the schema provided within the database Project. 

The project was originally written in Visual Basic and then many years ago I rewrote it in C#. I will occasionally go in and do a debug session to the old project. I have not made any UI changes in years. I have mostly just been refactoring the code as of late as it was written a lifetime ago and my coding as infinity improved since then.

It would be cool to modernize it someday be giving it a new UI and perhaps refactor it to be service oriented. Feel free to create a branch and submit a pull request.

If you encounter any trouble importing the transactions, the application can be easily customized to account for any issues. In fact, a specific method already exists to account for anything special relating to a specific bank. 