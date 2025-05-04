$projectPath = Split-Path -Parent $MyInvocation.MyCommand.Path

$binPath = Join-Path -Path $projectPath -ChildPath "OnlineShopWebApp\bin"
$objPath = Join-Path -Path $projectPath -ChildPath "OnlineShopWebApp\obj"

if (Test-Path $binPath) {
    Remove-Item -Path $binPath -Recurse -Force
    Write-Host "Папка 'bin' успешно очищена."
} else {
    Write-Host "Папка 'bin' не найдена."
}

if (Test-Path $objPath) {
    Remove-Item -Path $objPath -Recurse -Force
    Write-Host "Папка 'obj' успешно очищена."
} else {
    Write-Host "Папка 'obj' не найдена."
}
