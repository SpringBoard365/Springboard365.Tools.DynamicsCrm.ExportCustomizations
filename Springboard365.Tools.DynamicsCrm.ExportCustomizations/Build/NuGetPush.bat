SET packageVersion=2.0.0-alpha01

NuGet.exe pack ../Springboard365.Tools.DynamicsCrm.ExportCustomizations.csproj -Build -symbols -Version %packageVersion%

NuGet.exe push Springboard365.Tools.DynamicsCrm.ExportCustomizations.%packageVersion%.nupkg -Source "https://api.nuget.org/v3/index.json"

pause