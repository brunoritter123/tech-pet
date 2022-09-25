# TechPet_Server

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
Execute `dotnet watch run --project TechPet.API/` para iniciar o servidor. Navegue em `http://localhost:5000/`. O aplicativo será recarregado automaticamente se você alterar qualquer um dos arquivos de origem.

## Criando migrations
Execute comando a baixo para gerar uma nova *migration* do banco de dados.
```bash
dotnet ef migrations add "nome-da-migration-identity" --project ./TechPet.Identity/ --startup-project ./TechPet.API/ --context IdentityContext

dotnet ef migrations add "nome-da-migration-projeto" --project ./TechPet.Data/ --startup-project ./TechPet.API/ --context TechPetContext
```

## Atualizando o banco de dados
Execute a baixo para atulizar o banco de banco de dados com as migrations do projeto.
``` bash
dotnet ef database update --project ./TechPet.Identity/ --startup-project ./TechPet.API/ --context IdentityContext

dotnet ef database update --project ./TechPet.Data/ --startup-project ./TechPet.API/ --context TechPetContext
```

## Build
Execute `dotnet build tech-pet-bff.sln` para contruir os executaveis do projeto.

## Teste unitários
Execute `dotnet test tech-pet-bff.sln` para iniciar os testes unitários via [xUnit](https://xunit.net/). \

### Cobertura de testes
Entre na pasta de testes, execute `cd .\TechPet.Tests\` \
Execute `dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura` para avaliar a combertura de testes via [Coverlet](https://github.com/coverlet-coverage/coverlet).
Execute `dotnet reportgenerator -targetdir:C:\report` para gerar um relatório detalhado de cobertura via [ReportGenerator](https://github.com/danielpalme/ReportGenerator).

### Testes mutantes
Entre na pasta de testes, execute `cd .\TechPet.Tests\` \
Execute o teste mutante para cada projeto e avaliar se todos os mutantes foram mortos:
- `dotnet stryker --project-file=TechPet.API.csproj`
- `dotnet stryker --project-file=TechPet.Application.csproj`
- `dotnet stryker --project-file=TechPet.CrossCutting.csproj`
- `dotnet stryker --project-file=TechPet.Data.csproj`
- `dotnet stryker --project-file=TechPet.Domain.csproj`
