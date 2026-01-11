$dbPath = "C:\Users\mjc\Desktop\BnB\BnBCode\BNB1_MDB\bnb1.mdb"

# Try ACE driver first (64-bit Office), then Jet (32-bit)
$providers = @(
    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$dbPath",
    "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=$dbPath",
    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=$dbPath"
)

$conn = $null
foreach ($connString in $providers) {
    try {
        $conn = New-Object System.Data.OleDb.OleDbConnection($connString)
        $conn.Open()
        Write-Host "Connected using: $connString" -ForegroundColor Green
        break
    } catch {
        Write-Host "Failed with: $connString" -ForegroundColor Yellow
        $conn = $null
    }
}

if ($conn -eq $null) {
    Write-Host "Could not connect to Access database. You may need to install Access Database Engine." -ForegroundColor Red
    exit 1
}

# Get all tables
Write-Host "`n=== TABLES ===" -ForegroundColor Cyan
$tables = $conn.GetSchema("Tables") | Where-Object { $_.TABLE_TYPE -eq "TABLE" }
$tableNames = $tables | Select-Object -ExpandProperty TABLE_NAME
$tableNames | ForEach-Object { Write-Host "  $_" }

# Get columns for each table
Write-Host "`n=== TABLE SCHEMAS ===" -ForegroundColor Cyan
foreach ($tableName in $tableNames) {
    Write-Host "`n[$tableName]" -ForegroundColor Yellow

    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "SELECT TOP 1 * FROM [$tableName]"

    try {
        $reader = $cmd.ExecuteReader()
        $schemaTable = $reader.GetSchemaTable()

        foreach ($row in $schemaTable.Rows) {
            $colName = $row["ColumnName"]
            $colType = $row["DataType"].Name
            $colSize = $row["ColumnSize"]
            $allowNull = $row["AllowDBNull"]
            Write-Host "  $colName : $colType ($colSize) $(if($allowNull){'NULL'}else{'NOT NULL'})"
        }
        $reader.Close()
    } catch {
        Write-Host "  Error reading table: $_" -ForegroundColor Red
    }
}

$conn.Close()
Write-Host "`nDone!" -ForegroundColor Green
