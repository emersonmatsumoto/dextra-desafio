# dextra-desafio


docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d microsoft/mssql-server-linux:latest

docker build -t ematsumoto/lanche-api .

docker build -t ematsumoto/promocao-api .

docker build -t ematsumoto/pedido-api .



docker run -d -p 5001:5001 -e "ConnectionStrings__LancheContext=Server=172.17.0.2;Database=LancheContext;User Id=sa;Password=yourStrong(!)Password" --name LancheAPI ematsumoto/lanche-api

docker run -d -p 5002:5002 -e "ConnectionStrings__PromocaoContext=Server=172.17.0.2;Database=PromocaoContext;User Id=sa;Password=yourStrong(!)Password" --name PromocaoAPI ematsumoto/promocao-api

docker run -d -p 5003:5003 -e "ConnectionStrings__PedidoContext=Server=172.17.0.2;Database=PedidoContext;User Id=sa;Password=yourStrong(!)Password" --name PedidoAPI ematsumoto/pedido-api





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