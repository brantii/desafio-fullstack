# Desafio Full-Stack

Sistema CRUD de Empresas e Fornecedores com validações, autenticação e deploy com Docker.

## Tecnologias

- ASP.NET Core 8
- Angular 17
- PostgreSQL
- Docker + docker-compose
- GitHub Actions (CI)
- Swagger
- xUnit
- JWT Auth

## Executando com Docker

```bash
docker-compose up --build
```

## Endpoints

- `GET /api/empresa`
- `POST /api/empresa`
- `GET /api/fornecedor?search=xxx`
- `POST /api/fornecedor`

Autenticação JWT obrigatória para todos os endpoints.

## Autenticação

- `POST /api/auth/login` com body:

```json
{
  "username": "admin",
  "password": "123456"
}
```

## Testes

```bash
dotnet test
```

## Diagrama ER

Veja o arquivo `er-diagram.md`.
