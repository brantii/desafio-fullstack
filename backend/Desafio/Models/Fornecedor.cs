using System.Collections.Generic;  
using Desafio.Models;            

public class Fornecedor
{
    public Guid Id { get; set; }
    public string Documento { get; set; } = string.Empty; 
    public string Nome { get; set; } = string.Empty;      
    public string Email { get; set; } = string.Empty;     
    public string Cep { get; set; } = string.Empty;       
    public string? Rg { get; set; }                       
    public DateOnly? DataNascimento { get; set; }         
    public Guid EmpresaId { get; set; }
    public Empresa Empresa { get; set; } = null!;         
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>(); 
}