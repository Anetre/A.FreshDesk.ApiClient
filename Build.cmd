rem %PATH%

set msbuildpath="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin"

cd "C:\Projects\GitHub\Anetre\A.FreshDesk.ApiClient\Build\"

%msbuildpath%\MSBuild.exe /v:d "Build.proj" /p:WarningLevel=4 /p:VisualStudioVersion=14.0 /tv:15.0


cd "C:\Projects\GitHub\Anetre\A.FreshDesk.ApiClient\A.FreshDesk.ApiClient\" 
"C:\Projects\IS\Tools\NuGet\NuGet.exe" pack A.FreshDesk.ApiClient.csproj -Prop Configuration=Release-MsBuild

@echo off
echo Would you like to upload the build?(Y/N)
set INPUT=
set /p INPUT=Type input: %=%
If /I "%INPUT%"=="y" goto yes 
If /I "%INPUT%"=="n" goto no

goto no
:yes
@echo on
cd "C:\Projects\GitHub\Anetre\A.FreshDesk.ApiClient\"
call upload.bat
@echo off
goto end
:no
echo No upload

:end
echo Hit enter to exit
pause

rem "C:\Projects\IS\Tools\NuGet\NuGet.exe" push IM.Libraries.Model.4.1.0.50.nupkg -Source https://integrationsoftware.pkgs.visualstudio.com/DefaultCollection/_packaging/IntegrationManagerInternalFeed/nuget/v3/index.json -ApiKey VSTS