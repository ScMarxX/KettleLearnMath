# InjectGitVersion.ps1
#
# Set the version in the projects AssemblyInfo.cs file
#


# Get version info from Git. example 1.2.3-45-g6789abc
$gitVersion = git describe --long --tags;

# Parse Git version info into semantic pieces
if($gitVersion.Length -gt "0")
{
    $gitVersion -match '(.*)-(\d+)-[g](\w+)$';
    $gitTag = $Matches[1];
    $gitCount = $Matches[2];
    $gitSHA1 = $Matches[3];
}
else
{
    $gitTag = "1.0.0"
    $gitCount = "0"
    $gitSHA1 = "0000000"
}

# Define file variables
$templateFile = $args[0] + "\AssemblyInfo_template.cs";
echo "templateFile: $templateFile"
$assemblyFile = $args[1] + "\Properties\AssemblyInfo.cs";
echo "assemblyFile: $assemblyFile"
$GUIDFile =  $args[1] + "\Properties\Guid.txt";
echo "GUIDFile: $GUIDFile" 
$TAGETNAME = $args[2];
echo "TargetName: $TAGETNAME"

$GUID = Get-Content $GUIDFile
# Read template file, overwrite place holders with git version info
if(($gitTag.Length -ge 1) -and ($gitCount.Length -ge 1) -and ($gitSHA1.Length -ge 1))
{
    $newAssemblyContent = Get-Content $templateFile |
        %{$_ -replace '\$FILEVERSION\$', ($gitTag + "." + $gitCount) } |
        %{$_ -replace '\$INFOVERSION\$', ($gitTag + "." + $gitCount + "-" + $gitSHA1) } |
        %{$_ -replace '\$TAGETNAME\$', ($TAGETNAME) } |
        %{$_ -replace '\$GUID\$', ($GUID) };

    # Write AssemblyInfo.cs file only if there are changes
    If (-not (Test-Path $assemblyFile) -or ((Compare-Object (Get-Content $assemblyFile) $newAssemblyContent))) {
        echo "Injecting Git Version Info to AssemblyInfo.cs"
        $newAssemblyContent > $assemblyFile;
    }
}
