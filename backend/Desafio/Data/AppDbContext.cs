using Microsoft.EntityFrameworkCore;

namespace Desafio.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
}