@echo off
cls
.\tools\nuget\nuget.exe install FAKE.Core -OutputDirectory tools -ExcludeVersion -Version 3.27.5
.\tools\nuget\nuget.exe install xunit.runner.console -OutputDirectory tools -ExcludeVersion -Version 2.0.0
.\tools\FAKE.Core\tools\Fake.exe build.fsx %1