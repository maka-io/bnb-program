<#
.SYNOPSIS
    Build script for BnB application
.DESCRIPTION
    Builds and publishes the BnB application as a self-contained Windows executable
.PARAMETER Configuration
    Build configuration (Debug or Release). Default: Release
.PARAMETER Publish
    If set, publishes the application as a single-file executable
.PARAMETER Clean
    If set, cleans before building
.EXAMPLE
    .\build.ps1 -Publish
    .\build.ps1 -Clean -Publish
#>

param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",
    [switch]$Publish,
    [switch]$Clean
)

$ErrorActionPreference = "Stop"

# Paths
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$srcDir = Join-Path $scriptDir "src"
$solutionFile = Join-Path $srcDir "BnB.sln"
$winFormsProject = Join-Path $srcDir "BnB.WinForms\BnB.WinForms.csproj"
$publishDir = Join-Path $srcDir "publish\win-x86"
$installerDir = Join-Path $scriptDir "installer"

Write-Host "======================================" -ForegroundColor Cyan
Write-Host "BnB Build Script" -ForegroundColor Cyan
Write-Host "======================================" -ForegroundColor Cyan
Write-Host ""

# Clean if requested
if ($Clean) {
    Write-Host "Cleaning solution..." -ForegroundColor Yellow
    dotnet clean $solutionFile --configuration $Configuration
    if (Test-Path $publishDir) {
        Remove-Item -Path $publishDir -Recurse -Force
    }
    Write-Host "Clean complete." -ForegroundColor Green
    Write-Host ""
}

# Restore NuGet packages
Write-Host "Restoring NuGet packages..." -ForegroundColor Yellow
dotnet restore $solutionFile
Write-Host "Restore complete." -ForegroundColor Green
Write-Host ""

# Build solution
Write-Host "Building solution ($Configuration)..." -ForegroundColor Yellow
dotnet build $solutionFile --configuration $Configuration --no-restore
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}
Write-Host "Build complete." -ForegroundColor Green
Write-Host ""

# Run tests
Write-Host "Running tests..." -ForegroundColor Yellow
$testProject = Join-Path $srcDir "BnB.Tests\BnB.Tests.csproj"
dotnet test $testProject --configuration $Configuration --no-build --verbosity minimal
if ($LASTEXITCODE -ne 0) {
    Write-Host "Tests failed!" -ForegroundColor Red
    exit 1
}
Write-Host "Tests passed." -ForegroundColor Green
Write-Host ""

# Publish if requested
if ($Publish) {
    Write-Host "Publishing application..." -ForegroundColor Yellow

    # Ensure publish directory exists
    if (!(Test-Path $publishDir)) {
        New-Item -ItemType Directory -Path $publishDir -Force | Out-Null
    }

    # Publish using the profile
    dotnet publish $winFormsProject `
        --configuration $Configuration `
        --runtime win-x86 `
        --self-contained true `
        -p:PublishSingleFile=true `
        -p:PublishReadyToRun=true `
        -p:IncludeNativeLibrariesForSelfExtract=true `
        -p:EnableCompressionInSingleFile=true `
        --output $publishDir

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Publish failed!" -ForegroundColor Red
        exit 1
    }

    # Copy appsettings.json to publish directory
    $appSettings = Join-Path $srcDir "BnB.WinForms\appsettings.json"
    if (Test-Path $appSettings) {
        Copy-Item $appSettings -Destination $publishDir -Force
    }

    Write-Host "Publish complete." -ForegroundColor Green
    Write-Host "Output directory: $publishDir" -ForegroundColor Cyan

    # List published files
    Write-Host ""
    Write-Host "Published files:" -ForegroundColor Yellow
    Get-ChildItem $publishDir | Format-Table Name, Length, LastWriteTime
}

Write-Host ""
Write-Host "======================================" -ForegroundColor Cyan
Write-Host "Build completed successfully!" -ForegroundColor Green
Write-Host "======================================" -ForegroundColor Cyan
