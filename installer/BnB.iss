; BnB Installer Script for Inno Setup
; This script creates a Windows installer for the BnB application
; Download Inno Setup from: https://jrsoftware.org/isinfo.php

#define MyAppName "BnB - Bed and Breakfast Management"
#define MyAppVersion "2.0.0"
#define MyAppPublisher "Hawaii's Best Bed & Breakfasts"
#define MyAppURL "https://www.hawaiisbestbnb.com"
#define MyAppExeName "BnB.exe"
#define MyAppAssocName "BnB Database"
#define MyAppAssocExt ".bnb"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; Basic installer information
AppId={{B7E9C8A5-3D2F-4E1B-A6C8-9D0E2F3A4B5C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

; Installation directories
DefaultDirName={autopf}\BnB
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes

; Output settings
OutputDir=output
OutputBaseFilename=BnB-Setup-{#MyAppVersion}
SetupIconFile=..\src\BnB.WinForms\BNBHale1.ico
UninstallDisplayIcon={app}\{#MyAppExeName}

; Compression
Compression=lzma2/ultra64
SolidCompression=yes
LZMAUseSeparateProcess=yes

; Requirements
WizardStyle=modern
MinVersion=10.0.17763
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog

; Versioning
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription=BnB Management System Installer
VersionInfoCopyright=Copyright (c) 2024-2026 {#MyAppPublisher}
VersionInfoProductName={#MyAppName}
VersionInfoProductVersion={#MyAppVersion}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1; Check: not IsAdminInstallMode

[Files]
; Main application (published single-file executable)
Source: "..\src\publish\win-x86\BnB.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\src\publish\win-x86\appsettings.json"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist

; Any additional native DLLs that may not be embedded
Source: "..\src\publish\win-x86\*.dll"; DestDir: "{app}"; Flags: ignoreversion; Excludes: "*.resources.dll"

; Copy icon for shortcuts
Source: "..\src\BnB.WinForms\BNBHale1.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\BNBHale1.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\BNBHale1.ico"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
// Check if .NET 8 Desktop Runtime is installed (for framework-dependent deployment)
// Not needed for self-contained deployment, but useful for smaller installer size option
function IsDotNet8Installed(): Boolean;
var
  ResultCode: Integer;
begin
  // For self-contained deployment, always return true
  Result := True;
end;

procedure InitializeWizard;
begin
  // Custom initialization code here if needed
end;

function InitializeSetup(): Boolean;
begin
  Result := True;

  // Check Windows version (Windows 10 version 1809 or later required)
  if not IsWindows10OrGreater then
  begin
    MsgBox('This application requires Windows 10 version 1809 or later.', mbCriticalError, MB_OK);
    Result := False;
  end;
end;

function IsWindows10OrGreater(): Boolean;
begin
  Result := (GetWindowsVersion >= $0A000000);
end;
