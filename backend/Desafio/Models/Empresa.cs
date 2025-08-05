namespace Desafio.Models;  

public class Empresa
{
    public Guid Id { get; set; }
    public string Cnpj { get; set; } = string.Empty;     
    public string NomeFantasia { get; set; } = string.Empty; 
    public string Cep { get; set; } = string.Empty;       
    public ICollection<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
}