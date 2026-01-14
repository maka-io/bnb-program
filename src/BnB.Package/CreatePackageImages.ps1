# CreatePackageImages.ps1
# Creates placeholder images for the MSIX package
# Run this script once to generate the required image assets

param(
    [string]$OutputDir = ".\Images"
)

Add-Type -AssemblyName System.Drawing

# Ensure output directory exists
if (-not (Test-Path $OutputDir)) {
    New-Item -ItemType Directory -Path $OutputDir -Force | Out-Null
}

# Brand colors
$backgroundColor = [System.Drawing.Color]::FromArgb(0, 120, 215)  # Windows blue
$textColor = [System.Drawing.Color]::White

function Create-PlaceholderImage {
    param(
        [string]$OutputPath,
        [int]$Width,
        [int]$Height,
        [string]$Text = "BnB"
    )

    $bitmap = New-Object System.Drawing.Bitmap($Width, $Height)
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)

    # Set high quality rendering
    $graphics.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
    $graphics.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::AntiAlias

    # Fill background
    $brush = New-Object System.Drawing.SolidBrush($backgroundColor)
    $graphics.FillRectangle($brush, 0, 0, $Width, $Height)

    # Calculate font size based on image dimensions
    $fontSize = [Math]::Min($Width, $Height) / 3
    if ($fontSize -lt 8) { $fontSize = 8 }

    $font = New-Object System.Drawing.Font("Segoe UI", $fontSize, [System.Drawing.FontStyle]::Bold)
    $textBrush = New-Object System.Drawing.SolidBrush($textColor)

    # Center the text
    $format = New-Object System.Drawing.StringFormat
    $format.Alignment = [System.Drawing.StringAlignment]::Center
    $format.LineAlignment = [System.Drawing.StringAlignment]::Center

    $rect = New-Object System.Drawing.RectangleF(0, 0, $Width, $Height)
    $graphics.DrawString($Text, $font, $textBrush, $rect, $format)

    # Save as PNG
    $bitmap.Save($OutputPath, [System.Drawing.Imaging.ImageFormat]::Png)

    # Cleanup
    $font.Dispose()
    $brush.Dispose()
    $textBrush.Dispose()
    $graphics.Dispose()
    $bitmap.Dispose()

    Write-Host "Created: $OutputPath ($Width x $Height)"
}

# Create all required images
Write-Host "Creating MSIX package images..."
Write-Host ""

# StoreLogo - 50x50
Create-PlaceholderImage -OutputPath "$OutputDir\StoreLogo.png" -Width 50 -Height 50

# Square44x44Logo.scale-200 - 88x88
Create-PlaceholderImage -OutputPath "$OutputDir\Square44x44Logo.scale-200.png" -Width 88 -Height 88

# Square44x44Logo.targetsize-24_altform-unplated - 24x24
Create-PlaceholderImage -OutputPath "$OutputDir\Square44x44Logo.targetsize-24_altform-unplated.png" -Width 24 -Height 24

# Square150x150Logo.scale-200 - 300x300
Create-PlaceholderImage -OutputPath "$OutputDir\Square150x150Logo.scale-200.png" -Width 300 -Height 300

# Wide310x150Logo.scale-200 - 620x300
Create-PlaceholderImage -OutputPath "$OutputDir\Wide310x150Logo.scale-200.png" -Width 620 -Height 300 -Text "BnB Management"

# SplashScreen.scale-200 - 1240x600
Create-PlaceholderImage -OutputPath "$OutputDir\SplashScreen.scale-200.png" -Width 1240 -Height 600 -Text "BnB - Bed and Breakfast Management"

# LockScreenLogo.scale-200 - 48x48
Create-PlaceholderImage -OutputPath "$OutputDir\LockScreenLogo.scale-200.png" -Width 48 -Height 48

Write-Host ""
Write-Host "All images created successfully!"
Write-Host "You can replace these placeholder images with custom branded artwork later."
