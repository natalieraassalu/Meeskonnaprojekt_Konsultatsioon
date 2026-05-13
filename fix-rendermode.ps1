# fix-rendermode.ps1
# Adds @rendermode InteractiveServer after the first @page line in every
# .razor file inside ConsApp/Components/Pages/ subfolders.

param(
    [string]$PagesRoot = "Soft\ConsApp\ConsApp\Components\Pages"
)

$pagesPath = Join-Path $PSScriptRoot $PagesRoot
$razorFiles = Get-ChildItem $pagesPath -Recurse -Filter "*.razor" |
              Where-Object { $_.DirectoryName -ne $pagesPath }

$rendermodeBlock = @'
@* Stay on the server, don't move to the browser *@
@rendermode InteractiveServer
'@

$fixed = 0

foreach ($file in $razorFiles) {
    $content = Get-Content $file.FullName -Raw

    if ($content -match '@rendermode\s+InteractiveServer') {
        Write-Host "OK:    $($file.Name) (already has @rendermode)"
        continue
    }

    $pageMatch = [regex]::Match($content, '(@page\s+"[^"]*"[^\r\n]*)')
    if (-not $pageMatch.Success) {
        Write-Host "SKIP:  $($file.Name) (no @page directive found)"
        continue
    }

    $afterPage = $pageMatch.Index + $pageMatch.Length
    $content = $content.Substring(0, $afterPage) + [System.Environment]::NewLine + $rendermodeBlock + $content.Substring($afterPage)

    Set-Content $file.FullName $content -NoNewline
    $fixed++
    Write-Host "FIXED: $($file.Name)"
}

Write-Host ""
Write-Host "$fixed file(s) updated."
