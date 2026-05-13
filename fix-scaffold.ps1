# fix-scaffold.ps1
# Run this after scaffolding a new Blazor CRUD page set.
# Fixes two patterns the VS scaffolder gets wrong:
#   1. InputText bound to a Guid property  -> <input type="text" @bind="...">
#   2. InputText/ValidationMessage for byte[] (Timestamp) -> removed entirely

param(
    [string]$PagesRoot = "Soft\ConsApp\ConsApp\Components\Pages"
)

$pagesPath = Join-Path $PSScriptRoot $PagesRoot
$razorFiles = Get-ChildItem $pagesPath -Recurse -Filter "*.razor" |
              Where-Object { $_.Name -in "Create.razor","Edit.razor" }

$fixed = 0

foreach ($file in $razorFiles) {
    $content = Get-Content $file.FullName -Raw
    $original = $content

    # ── Pattern 1: InputText bound to a Guid property ──────────────────────
    # The scaffolder emits:
    #   <InputText id="foo" @bind-Value="Model.FooId" class="form-control" />
    # We need:
    #   <input id="foo" type="text" @bind="Model.FooId" class="form-control" />
    #
    # Strategy: find all @bind-Value targets, load the model source, check type.

    # Extract @using namespace from the razor file
    $nsMatch = [regex]::Match($content, '@using\s+(Abc\.Data\S+)')
    $namespace = if ($nsMatch.Success) { $nsMatch.Groups[1].Value } else { $null }

    # Find all InputText @bind-Value usages
    $inputTextMatches = [regex]::Matches($content,
        '<InputText\s[^>]*@bind-Value="(\w+)\.(\w+)"[^>]*/>')

    foreach ($m in $inputTextMatches) {
        $modelType = $m.Groups[1].Value   # e.g. "CourseSelector"
        $propName  = $m.Groups[2].Value   # e.g. "CourseId"

        # Find the model .cs file by class name
        $modelFile = Get-ChildItem $PSScriptRoot -Recurse -Filter "*.cs" -ErrorAction SilentlyContinue |
                     Where-Object { $_.Name -notlike "*.g.cs" } |
                     Select-String -Pattern "class\s+$modelType\b" -List |
                     Select-Object -First 1 -ExpandProperty Path

        if (-not $modelFile) { continue }

        $modelSource = Get-Content $modelFile -Raw

        # Check if this property is Guid
        if ($modelSource -match "public\s+(Guid\??)\s+$propName\s*\{") {
            $old = $m.Value
            # Replace InputText with plain input, @bind-Value -> @bind
            $new = $old -replace '<InputText(\s)', '<input$1' `
                        -replace '@bind-Value=', '@bind=' `
                        -replace '\s*/>', ' type="text" />'
            # Ensure type="text" isn't duplicated
            $new = $new -replace '(type="text"\s+)+', 'type="text" '
            $content = $content.Replace($old, $new)
            Write-Host "  [Guid] Fixed $propName in $($file.Name)"
        }

        # Check if this property is byte[]
        if ($modelSource -match "public\s+byte\[\]\s+$propName\s*\{" -or $propName -eq "Timestamp") {
            # Remove the entire mb-3 div block for this field
            $blockPattern = "(?s)\s*<div class=""mb-3"">.*?<InputText[^>]*@bind-Value=""\w+\.$propName""[^>]*/>\s*.*?</div>"
            $content = [regex]::Replace($content, $blockPattern, '')
            # Also remove standalone ValidationMessage for this prop
            $content = [regex]::Replace($content,
                "\s*<ValidationMessage\s+For=""\(\)\s*=>\s*\w+\.$propName""[^/]*/>\s*", '')
            Write-Host "  [byte[]] Removed $propName from $($file.Name)"
        }
    }

    # ── Pattern 2: standalone Timestamp blocks (display pages) ─────────────
    # In Delete/Details/Index the scaffold emits display-only references.
    # Those are handled separately if needed; this script targets Create/Edit.

    if ($content -ne $original) {
        Set-Content $file.FullName $content -NoNewline
        $fixed++
        Write-Host "FIXED: $($file.FullName)"
    } else {
        Write-Host "OK:    $($file.Name) (no changes needed)"
    }
}

Write-Host ""
Write-Host "$fixed file(s) updated."
