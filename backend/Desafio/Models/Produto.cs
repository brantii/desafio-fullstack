#nullable enable

using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Models;

public class Produto
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    [Range(0.01, double.MaxValue)]
    public decimal Preco { get; set; }
    
    // Relacionamento com Fornecedor
    public Guid FornecedorId { get; set; }
    public virtual Fornecedor? Fornecedor { get; set; }
}