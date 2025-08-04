using System;

namespace Desafio;

public class Fornecedor
{
    public Guid Id { get; set; }
    public string Documento { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cep { get; set; }
    public string? Rg { get; set; }
    public DateOnly? DataNascimento { get; set; }
    public Guid EmpresaId { get; set; }
    public Empresa Empresa { get; set; }
}