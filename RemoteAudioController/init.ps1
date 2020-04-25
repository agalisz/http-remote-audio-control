Write-Host "Restoring npm javascript packages..."
npm i
Write-Host "Packages restored."

Write-Host "Preparing wwwroot..."
$jsDir = "wwwroot\js\"
$cssDir = "wwwroot\css\"
if (!(Test-Path -path $jsDir)) { New-Item $jsDir -Type Directory }
if (!(Test-Path -path $cssDir)) { New-Item $cssDir -Type Directory }
Copy-Item "node_modules\jquery\dist\jquery.min.js" -Destination $jsDir
Copy-Item "node_modules\rangeslider.js\dist\rangeslider.min.js" -Destination $jsDir
Copy-Item "node_modules\rangeslider.js\dist\rangeslider.css" -Destination $cssDir
Write-Host "wwwroot prepared."
