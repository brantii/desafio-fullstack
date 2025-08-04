using Xunit;

namespace Desafio.Tests;

public class EmpresaTests
{
    [Fact]
    public void Deve_Criar_Empresa_Valida()
    {
        var empresa = new Empresa
        {
            Cnpj = "12345678000199",
            NomeFantasia = "Empresa Teste",
            Cep = "01001000"
        };
        Assert.NotNull(empresa);
        Assert.Equal("Empresa Teste", empresa.NomeFantasia);
    }
}