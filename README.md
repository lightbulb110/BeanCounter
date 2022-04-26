# BeanCounter

BeanCounter is a Windows Forms Application written in C# and utilizing SQL Server for the backend. It has been continuously developed for over 15 years now. The application will allow you to import QFX files into a SQL Server Backend. You can then run reports from within the application and also verify your transactions as they come in. It keeps a log of your balances everytime you import your transactions and is compatible with many banking institutions. 

The Project also contains the database schema in the form of a MS Database Project (solution). You can also find the PowerShell scripts that will create the SQL Server Database for you, using the schema provided within the database Project. 

The project was originally written in Visual Basic when I was pretty green and then many years ago I rewrote it in C#. I will occasionally go in and do a debug session to the old project and make some improvements to the code to account for very unsual scenerios (maintentance, you know how it is). I have not made any UI changes in years. I have mostly just been refactoring the code as of late as it was written a lifetime ago and my coding as infinity improved since then.

It would be cool to modernize it someday by giving it a new UI and perhaps refactor it to be more service oriented. Feel free to create a branch and submit a pull request for anything you do with it.

If you encounter any trouble importing the transactions, the application can be easily customized to account for any issues that you may face such as something specific to a certain bank. Some banks like to play tricks like reversing the fields to throw off vendors. However, we can easily account for such issues using our skills in C#.

# Debugging

Simply pass your .qfx filename in as a argument (Project Settings). We talking Windows here.

# Security

This solution doesn't make any outbound connections and stores all necessary data locally. The solution is available for inspection. Very secure, doesn't require any firewall exceptions or modifications.

# Setup

Clone the repository. Build the solution and deploy the binaries. Install Sql Server Developer edition (or SQL Express), you might even be able to run it on Sql Lite, although I've never tried it.

You can either create the database and sync the schema using the Database Project or find the powershell scripts which will create it for you.

Download your <QuickenFile>.qfx from your bank. Right click on file and chose Open With. Select BeanCounter.exe and make default. 