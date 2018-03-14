# dextra-desafio

mkdir LancheService
cd LancheService
dotnet new sln
dotnet new webapi -o LancheAPI
dotnet new xunit -o LancheTest
dotnet sln add LancheAPI\LancheAPI.csproj
dotnet sln add LancheTest\LancheTest.csproj
dotnet add LancheTest\LancheTest.csproj reference LancheAPI\LancheAPI.csproj