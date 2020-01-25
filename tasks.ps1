
param(
	$outputDirectory = (property outputDirectory "output"),
	$configuration = (property configuration "Release")
)

$absoluteOutputDirectory = "$((Get-Location).Path)\$outputDirectory"
$projects = Get-SolutionProjects

task Clean {
	if((Test-Path $absoluteOutputDirectory)) 
	{
		Write-Host "Cleaning output directory $absoluteOutputDirectory"
		Remove-Item "$absoluteOutputDirectory" -Recurse -Force -ErrorAction SilentlyContinue | Out-Null
	}

	New-Item $absoluteOutputDirectory -ItemType Directory | Out-Null

	$projects | 
		ForEach-Object {
			Write-Host "Cleaning bin and obj folders for $($_.Directory)"
			Remove-Item "$($_.Directory)\bin" -Recurse -Force -ErrorAction SilentlyContinue | Out-Null
			Remove-Item "$($_.Directory)\obj" -Recurse -Force -ErrorAction SilentlyContinue | Out-Null
		}
}

task Compile {
	use "14.0" MSBuild
	$projects | 
		ForEach-Object {
			if($_.IsWebProject)
			{
				$webOutDir = "$absoluteOutputDirectory\$($_.Name)"
				$outDir = "$absoluteOutputDirectory\$($_.Name)\bin"

				exec {MSBuild $($_.Path) /p:Configuration=$configuration /p:OutDir=$outDir `
										 /p:WebProjectOutputDir=$webOutDir /nologo /p:DebugType=None /p:Platform=AnyCpu /verbosity:quite}
			}
			else {
				Write-Host "Not a web proj $absoluteOutputDirectory"
				$outDir = "$absoluteOutputDirectory\$($_.Name)"
				exec {MSBuild $($_.Path)} 
			}
		}
}

Task init {
	Write-Host "Hello"
}

Task init2 {
	Write-Host "Hello2"
}