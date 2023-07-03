@echo off

rem Set the program path variable
set "programPath=%ProgramFiles(x86)%\Aurora\Aurora Character Builder\Aurora Builder.exe"

rem Check if the program path exists
if exist "%programPath%" (
    echo Aurora program found. Launching...
    start "" "%programPath%"
) else (
    echo Aurora program not found. Opening URL...
    start "" "https://aurorabuilder.com/"
)
