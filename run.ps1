[System.IO.DirectoryInfo] $dotnetRoot = [System.IO.DirectoryInfo]::new([System.IO.Path]::Combine($PSScriptRoot, '.dotnet'));
[System.IO.FileInfo] $dotnetInstall = [System.IO.FileInfo]::new([System.IO.Path]::Combine($dotnetRoot.FullName, 'dotnet-install.ps1'))

$dotnetRoot.Create()

If (!$dotnetInstall.Exists)
{
    Invoke-WebRequest -Uri 'https://dot.net/v1/dotnet-install.ps1' -OutFile $dotnetInstall.FullName
}

& "$($dotnetInstall.FullName)" -Channel 7.0 -InstallDir "$($dotnetRoot.FullName)" -NoPath

$Env:DOTNET_LOGO=0
$Env:DOTNET_MULTILEVEL_LOOKUP=0
$Env:DOTNET_ROOT="$($dotnetRoot.FullName)"

[System.IO.FileInfo] $dotnet = [System.IO.FileInfo]::new([System.IO.Path]::Combine($dotnetRoot.FullName, 'dotnet.exe'));
[System.IO.FileInfo] $projectFile = [System.IO.FileInfo]::new([System.IO.Path]::Combine($dotnetRoot.FullName, 'Test.csproj'));


& "$($dotnet.FullName)" run "$($projectFile.FullName)"