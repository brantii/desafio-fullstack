using System;
using System.Collections.Generic;

namespace Desafio;

public class Empresa
{
    public Guid Id { get; set; }
    public string Cnpj { get; set; }
    public string NomeFantasia { get; set; }
    public string Cep { get; set; }
    public ICollection<Fornecedor> Fornecedores { get; set; }
}