```mermaid
erDiagram
    EMPRESA ||--o{ FORNECEDOR : has
    EMPRESA {
        UUID Id
        string Cnpj
        string NomeFantasia
        string Cep
    }
    FORNECEDOR {
        UUID Id
        string Documento
        string Nome
        string Email
        string Cep
        string? Rg
        date? DataNascimento
        UUID EmpresaId
    }
```
