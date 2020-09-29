SET packageVersion=2.0.0-alpha03

NuGet.exe pack ../Springboard365.Tools.DynamicsCrm.ExportCustomizations.nuspec -Build -symbols -Version %packageVersion% -Properties Configuration=Release;id="Springboard365.Tools.DynamicsCrm.ExportCustomizations";author="Springboard 365 Ltd";repo="https://github.com/SpringBoard365/Springboard365.Tools.DynamicsCrm.ExportCustomizations";description="Export customizations application to allow for automation of Application Lifecycle Management.";tags="Microsoft Dynamics 365 CRM 2011 2013 2015 2016 SDK XRM 365 D365 Power Platform";

NuGet.exe push Springboard365.Tools.DynamicsCrm.ExportCustomizations.%packageVersion%.nupkg -Source "https://api.nuget.org/v3/index.json"

pause