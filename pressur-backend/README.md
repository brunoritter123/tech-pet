# Pressur_Server

Esse projeto foi gerado com  [.Net Core](https://dotnet.microsoft.com/download/dotnet-core/6.0) versão 6.0

## Instalação
- **dotnet** - Fazer a instalção do [.NET Core 6.0](https://dotnet.microsoft.com/download/dotnet-core/6.0)

## Ferramentas
Execute `dotnet tool restore` para instalar as ferramentas.
- **dotnet ef**
- **Stryker.Net**

## Configurando 'appsettings.json'
Acesse o arquivo appsettings.[Ambiente].json (Ambiente é conforme configurado na variável de ambiente ASPNETCORE_ENVIRONMENT).
- Informe a configuração do *TokenConfig*
- Informe a configuração do *EmailConfig*
- Informe a configuração do *ConnectionStrings*


## Servidor de desenvolvimento
Execute `dotnet watch run --project Pressur.API/` para iniciar o servidor. Navegue em `http://localhost:5000/`. O aplicativo será recarregado automaticamente se você alterar qualquer um dos arquivos de origem.

## Criando migrations
Execute comando a baixo para gerar uma nova *migration* do banco de dados.
```bash
dotnet ef migrations add "nome-da-migration-identity" --project ./Pressur.Identity/ --startup-project ./Pressur.API/ --context IdentityContext
```
```bash
dotnet ef migrations add "nome-da-migration-projeto" --project ./Pressur.Data/ --startup-project ./Pressur.API/ --context PressurContext
```

## Atualizando o banco de dados
Execute a baixo para atualizar o banco de dados com as migrations do projeto.
``` bash
dotnet ef database update --project ./Pressur.Identity/ --startup-project ./Pressur.API/ --context IdentityContext
```
```bash
dotnet ef database update --project ./Pressur.Data/ --startup-project ./Pressur.API/ --context PressurContext
```

## Build
Execute `dotnet build pressur.sln` para construir os executaveis do projeto.

## Teste unitários
Execute `dotnet test pressur.sln` para iniciar os testes unitários via [xUnit](https://xunit.net/). \

### Cobertura de testes
Entre na pasta de testes, execute `cd .\Pressur.Tests\` \
Execute `dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura` para avaliar a combertura de testes via [Coverlet](https://github.com/coverlet-coverage/coverlet).
Execute `dotnet reportgenerator -targetdir:C:\report` para gerar um relatório detalhado de cobertura via [ReportGenerator](https://github.com/danielpalme/ReportGenerator).

### Testes mutantes
Entre na pasta de testes, execute `cd .\Pressur.Tests\` \
Execute o teste mutante para cada projeto e avaliar se todos os mutantes foram mortos:
- `dotnet stryker --project-file=Pressur.API.csproj`
- `dotnet stryker --project-file=Pressur.Application.csproj`
- `dotnet stryker --project-file=Pressur.CrossCutting.csproj`
- `dotnet stryker --project-file=Pressur.Data.csproj`
- `dotnet stryker --project-file=Pressur.Domain.csproj`
