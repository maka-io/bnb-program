# BnB Startup Script - Build and Run
# Usage: .\run.ps1

Write-Host "Building BnB solution..." -ForegroundColor Cyan
dotnet build src/BnB.sln

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}

Write-Host "Starting BnB application..." -ForegroundColor Green
dotnet run --project src/BnB.WinForms/BnB.WinForms.csproj
