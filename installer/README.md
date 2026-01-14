# BnB Installer

This directory contains the installer configuration for the BnB application.

## Prerequisites

1. **Inno Setup** - Download from [https://jrsoftware.org/isinfo.php](https://jrsoftware.org/isinfo.php)
2. **.NET 8 SDK** - Download from [https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

## Building the Installer

### Step 1: Build and Publish the Application

From the repository root, run:

```powershell
# Build and publish the application
.\build.ps1 -Publish

# Or manually:
cd src
dotnet publish BnB.WinForms/BnB.WinForms.csproj -c Release -r win-x86 --self-contained true -p:PublishSingleFile=true -o publish/win-x86
```

This creates a self-contained executable in `src/publish/win-x86/`.

### Step 2: Create the Installer

1. Open Inno Setup Compiler
2. Open `BnB.iss` from this directory
3. Click Build > Compile (or press F9)

The installer will be created in the `installer/output/` directory.

## Installer Features

- Self-contained deployment (no .NET runtime required on target machine)
- Single-file executable (all dependencies bundled)
- Desktop and Start Menu shortcuts
- Windows 10+ compatible
- Modern wizard-style installer

## Manual Deployment (Without Installer)

For simple deployments, you can also just copy:

1. `BnB.exe` - The main application executable
2. `appsettings.json` - Configuration file

To a directory on the target machine and run the executable directly.

## Version Information

- **Application Version**: 2.0.0
- **Minimum Windows Version**: Windows 10 (version 1809 / build 17763)
- **Target Runtime**: .NET 8.0 (self-contained)
- **Platform**: x86 (32-bit)

## Database Configuration

On first run, the application will create a SQLite database in:
`%LOCALAPPDATA%\BnB\bnb.db`

To use PostgreSQL instead, edit `appsettings.json`:

```json
{
  "Database": {
    "Provider": "PostgreSQL",
    "PostgreSQL": {
      "Host": "localhost",
      "Port": "5432",
      "Database": "bnb",
      "Username": "your_username",
      "Password": "your_password"
    }
  }
}
```
