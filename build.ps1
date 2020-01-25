cls

.'.\functions.ps1'

$invokedBuild = (Get-ChildItem('C:\Users\varmiranda\.nuget\packages\invoke-build\5.5.5\tools\Invoke-build.ps1')).FullName | Sort-Object $_ | Select -Last 1
& $invokedBuild $args Tasks.ps1


