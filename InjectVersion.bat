@echo off
powershell -ExecutionPolicy ByPass -File ".\tools\BuildScripts\InjectGitVersion.ps1" ".\tools\BuildScripts" ".\KettleLearnMath\" "KettleLearnMath"

ping -n 5 127.1
