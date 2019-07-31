echo Installing the ScopeAgent.Runner
dotnet tool install -g ScopeAgent.Runner --version 0.1.10

echo Fix Path
export PATH="$PATH:/root/.dotnet/tools"

echo Clean Solution
dotnet clean

echo Build Solution
dotnet build 


echo Run xUnit on C#
cd tests/csharp/Reference.Tests.CSharp.xUnit
scope-run dotnet test -n CSharp
cd ../../..

echo Run NUnit on C#
cd tests/csharp/Reference.Tests.CSharp.NUnit
scope-run dotnet test -n CSharp
cd ../../..

echo Run MSTest on C#
cd tests/csharp/Reference.Tests.CSharp.MSTest
scope-run dotnet test -n CSharp
cd ../../..



echo Run xUnit on VB.NET
cd tests/vb/Reference.Tests.VB.xUnit
scope-run dotnet test -n VB.NET
cd ../../..

echo Run NUnit on VB.NET
cd tests/vb/Reference.Tests.VB.NUnit
scope-run dotnet test -n VB.NET
cd ../../..

echo Run MSTest on VB.NET
cd tests/vb/Reference.Tests.VB.MSTest
scope-run dotnet test -n VB.NET
cd ../../..



echo Run xUnit on F#
cd tests/fsharp/Reference.Tests.FSharp.xUnit
scope-run dotnet test -n FSharp
cd ../../..

echo Run NUnit on F#
cd tests/fsharp/Reference.Tests.FSharp.NUnit
scope-run dotnet test -n FSharp
cd ../../..

echo Run MSTest on F#
cd tests/fsharp/Reference.Tests.FSharp.MSTest
scope-run dotnet test -n FSharp
cd ../../..



echo Uninstalling ScopeAgent
dotnet tool uninstall -g ScopeAgent.Runner


echo Done.
