@echo off
IF NOT EXIST Springboard365.Tools.DynamicsCrm.ExportCustomizations\tools\ExportCustomizations.exe (
  nuget install Springboard365.Tools.DynamicsCrm.ExportCustomizations -x -PreRelease 
)

Springboard365.Tools.DynamicsCrm.ExportCustomizations\tools\ExportCustomizations.exe

pause