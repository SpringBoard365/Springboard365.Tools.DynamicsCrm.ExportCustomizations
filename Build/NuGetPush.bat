@echo off
SET packageVersion=2.0.0

SET configuration=Release
SET id=Springboard365.Tools.DynamicsCrm.ExportCustomizations
SET author="Springboard 365 Ltd"
SET repo="https://github.com/SpringBoard365/Springboard365.Tools.DynamicsCrm.ExportCustomizations"
SET description="Export customizations application to allow for automation of Power Platform Application Lifecycle Management."
SET tags="Springboard365BuildTool PowerPlatformBuildTool Dynamics365BuildTool DynamicsCrmBuildTool XrmBuildTool"

dotnet restore ../%id%.sln

dotnet build ../%id%.sln -c  %configuration% -p:Version=%packageVersion% -f net462 --nologo

pause

NuGet.exe pack ../src/ExportCustomizations.nuspec -Build -symbols -Version %packageVersion% -Properties Configuration=%configuration%;id=%id%;author=%author%;repo=%repo%;description=%description%;tags=%tags%;

NuGet.exe push %id%.%packageVersion%.nupkg -Source "https://api.nuget.org/v3/index.json"

pause