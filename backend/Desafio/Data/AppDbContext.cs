using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
}
