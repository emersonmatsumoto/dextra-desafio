# dextra-desafio

mkdir LancheService
cd LancheService
dotnet new sln
dotnet new webapi -o LancheAPI
dotnet new xunit -o LancheTest
dotnet sln add LancheAPI\LancheAPI.csproj
dotnet sln add LancheTest\LancheTest.csproj
dotnet add LancheTest\LancheTest.csproj reference LancheAPI\LancheAPI.csproj

cd LancheAPI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

Adicione em LancheAPI.csproj
  <ItemGroup>
    ...  
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.0.2" />
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.2" />
  </ItemGroup>
  
dotnet restore
dotnet ef migrations add InitialCreate