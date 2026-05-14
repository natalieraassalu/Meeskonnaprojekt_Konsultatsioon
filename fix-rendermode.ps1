# fix-rendermode.ps1
# Removes the per-page @rendermode InteractiveServer directive (and its comment)
# from every scaffolded .razor file under ConsApp/Components/Pages/ subfolders.
#
# WHY: Setting @rendermode InteractiveServer on individual page components creates
# a separate SignalR circuit per page. When navigating away the circuit tears down,
# and any in-flight work (DB call, NavigateTo, StateHasChanged) hits a non-Connected
# SignalR state and throws. The correct approach is to set interactivity once on
# <Routes> in App.razor (already done), which keeps one persistent circuit alive
# across all navigations. Individual pages should inherit it — no directive needed.

param(
    [string]$PagesRoot = "Soft\ConsApp\ConsApp\Components\Pages"
)

$pagesPath = Join-Path $PSScriptRoot $PagesRoot
$razorFiles = Get-ChildItem $pagesPath -Recurse -Filter "*.razor" |
              Where-Object { $_.DirectoryName -ne $pagesPath }

$fixed = 0

foreach ($file in $razorFiles) {
    $content = Get-Content $file.FullName -Raw
    $original = $content

    # Remove the comment line and the @rendermode line (both or either)
    $content = $content -replace '\r?\n@\* Stay on the server, don''t move to the browser \*@', ''
    $content = $content -replace '\r?\n@rendermode InteractiveServer', ''

    if ($content -ne $original) {
        Set-Content $file.FullName $content -NoNewline
        $fixed++
        Write-Host "FIXED: $($file.Name)"
    } else {
        Write-Host "OK:    $($file.Name) (nothing to remove)"
    }
}

Write-Host ""
Write-Host "$fixed file(s) updated."
