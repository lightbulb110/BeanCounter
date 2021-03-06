# Written by Nathan Overbey
# Open Source, please contribute back to the project if you make improvements.

$ErrorActionPreference = 'Stop'

$mypath = split-path $($MyInvocation.MyCommand.Path)
$workspace = resolve-path $("$mypath\..\")
$refreshDatabaseScript = "$($workspace)Scripts\DropCreate.sql"
$sourceFile = "$($workspace)bin\Debug\BeanCounter.Database.dacpac"
$sqlServerName = "."
$targetConnectionString = "Data Source=$sqlServerName;Initial Catalog=BeanCounter;Integrated Security=True"
$solutionFile = "$($workspace)BeanCounter.Database.sqlproj"

function Check-Exit-Code() {
	if ($LASTEXITCODE -gt 0) { 
		Write-Host "* exit code: $LASTEXITCODE"
		exit 1
	}
}

Write-Host "* Refreshing database"
& sqlcmd -S $sqlServerName -b -i $refreshDatabaseScript
Check-Exit-Code

Write-Host "* Building solution"
& "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild" $solutionFile
Check-Exit-Code

Write-Host "* Publishing" 
& "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\150\sqlpackage.exe" -Action:Publish -SourceFile:$sourceFile -TargetConnectionString:$targetConnectionString #-TargetDatabaseName:BeanCounter
if ($LASTEXITCODE -gt 0) { 
	throw "sqlpackage exit code: $LASTEXITCODE" 
	exit 1
}
Write-Host ""

Write-Host "* Default-Categories.sql"
& sqlcmd -S $sqlServerName -d "BeanCounter" -b -i "$($workspace)Scripts\DML\Default-Categories-insert.sql" -U "BeanCounter" -P "password"
Check-Exit-Code

Write-Host "* National-Businesses.sql"
& sqlcmd -S $sqlServerName -d "BeanCounter" -b -i "$($workspace)Scripts\DML\National-Businesses-insert.sql" -U "BeanCounter" -P "password"
Check-Exit-Code

Write-Host "* dbo.Custom-Categories.sql"
& sqlcmd -S $sqlServerName -d "BeanCounter" -b -i "$($workspace)Scripts\DML\Custom-Categories-insert.sql" -U "BeanCounter" -P "password"
Check-Exit-Code

Write-Host "* Local-Businesses-insert.sql"
& sqlcmd -S $sqlServerName -d "BeanCounter" -b -i "$($workspace)Scripts\DML\Local-Businesses-insert.sql" -U "BeanCounter" -P "password"
Check-Exit-Code

Write-Host "* Custom-Transactions-insert.sql"
& sqlcmd -S $sqlServerName -d "BeanCounter" -b -i "$($workspace)Scripts\DML\Custom-Transactions-insert.sql" -U "BeanCounter" -P "password"
Check-Exit-Code


Write-Host "* Success"