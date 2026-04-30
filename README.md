# FCG - FIAP Cloud Games

Plataforma de biblioteca de jogos desenvolvida como projeto de pós-graduação em Arquitetura de Sistemas .NET na FIAP. Permite que usuários se cadastrem, façam login e gerenciem sua biblioteca de jogos.

---
## Miro 
https://miro.com/welcomeonboard/eHAxT3V6cTNmS1psMThHZzNWdmZ5T0F4bC9pdmZ6T0thOEVjT2RrcHBmVk4weGFXbTdRWFdJSUtTMVBPK01XU0c5cU9SeE93TSt1WFlOdkpFcTZQb0VOTElodm5YL1NJbkx1cCthSlRiU0YyRmdSUUJ4dkJwUnRPc1c4NU4yVWhhWWluRVAxeXRuUUgwWDl3Mk1qRGVRPT0hdjE=?share_link_id=907530410148
---
## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Azure SQL Server
- ASP.NET Identity
- JWT Bearer Authentication
- FluentValidation
- Swagger / OpenAPI

---

## Arquitetura

O projeto segue os princípios de Clean Architecture e Domain-Driven Design (DDD), organizado em quatro camadas:

- FCG.Domain — entidades, interfaces, enums, validações e regras de negócio
- FCG.Application — serviços de aplicação, interfaces, requests e DTOs
- FCG.Infrastructure — contexto EF Core, repositórios, Identity e migrations
- FCG.Presentation — controllers, configuração de DI, Swagger e JWT

---

## Bounded Contexts

- Autenticacao / Usuario — cadastro, login, alteração de senha
- Jogos — catálogo de jogos com gênero, preço e status
- Biblioteca / Compras — biblioteca de jogos do usuário

---

## Funcionalidades implementadas

- Cadastro de usuário com ASP.NET Identity e entidade de domínio vinculada via IdentityUserId
- Login com geração de JWT
- Alteração de senha
- Cadastro e listagem de jogos
- Autenticação e autorização por roles (Usuario, Admin)

---

## Como rodar localmente

### Pré-requisitos

- .NET 8 SDK
- SQL Server ou Azure SQL
- Visual Studio 2022 ou VS Code

### Configuração

1. Clone o repositório:

```bash
git clone https://github.com/caarolinadso/FCG.git
cd FCG
```

2. Configure a connection string e o JWT no `appsettings.json` do projeto `FCG.Presentation`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "sua-connection-string-aqui"
  },
  "JwtSettings": {
    "Segredo": "sua-chave-secreta-aqui",
    "Emissor": "FCG",
    "Audiencia": "FCG.Client",
    "ExpiracaoHoras": 2
  }
}
```

3. Aplique as migrations:

```bash
dotnet ef database update --project FCG.Infrastructure --startup-project FCG.Presentation
```

4. Rode o projeto:

```bash
dotnet run --project FCG.Presentation
```

5. Acesse o Swagger em:

```
http://localhost:{porta}/swagger
```

---

## Estrutura de pastas

```
FCG/
  FCG.Domain/
    Entities/
    Interfaces/
    Enums/
    Validations/
  FCG.Application/
    Interfaces/
    Services/
    Requests/
    Configuration/
  FCG.Infrastructure/
    Context/
    Identity/
    Repository/
    Migrations/
  FCG.Presentation/
    Controllers/
    Swagger/
    Configuration/
    Program.cs
```

---

## Decisões de arquitetura

- ASP.NET Identity separado da entidade de dominio Usuario, vinculados por IdentityUserId
- Repositorio generico base (Repository<TEntity>) com implementacoes especificas por entidade
- Registro de dependencias separado por camada: AddApplication, AddInfrastructure, AddPresentation
- Sealed records para requests de entrada
- Mapeamento manual sem AutoMapper
- FluentValidation para validacao de requests e entidades de dominio

---

## Convenções de commit

O projeto utiliza commits convencionais:

- feat: nova funcionalidade
- fix: correcao de bug
- refactor: refatoracao sem alteracao de comportamento
- chore: tarefas de manutencao

---

## Autora

Carolina Oliveira
Pos-graduacao em Arquitetura de Sistemas .NET — FIAP Curitiba