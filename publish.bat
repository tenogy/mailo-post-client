set NugetDir=C:/nuget
set NugetSrc=https://api.nuget.org/v3/index.json
set /p Key=<%NugetDir%/key.txt

dotnet pack -c Release -o %NugetDir%  Tenogy.MailoPost.Client\Tenogy.MailoPost.Client.csproj
dotnet nuget push %NugetDir%/Tenogy.MailoPost.Client.1.0.0.nupkg -k %Key% -s %NugetSrc%