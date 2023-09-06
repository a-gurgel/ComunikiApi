using ComunikiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunikiApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts)
        : base(opts)
    {
        
    }

    //acesso as categorias dos produtos
    public DbSet<Categoria> Categorias { get; set; }
    //acesso aos produtos que estao na base
    public DbSet<Produto> Produtos { get; set; }

    //criando a fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //categoria
        modelBuilder.Entity<Categoria>().HasKey(c => c.CategoriaId);

        modelBuilder.Entity<Categoria>().
            Property(c => c.Nome).HasMaxLength(100).IsRequired();

        //produto
        modelBuilder.Entity<Produto>().
            Property(c => c.NomeProduto).HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Produto>().
            Property(c => c.Descricao).HasMaxLength(400).IsRequired();

        modelBuilder.Entity<Produto>().
            Property(c => c.ImageURL).HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Produto>().
            Property(c => c.Preco).HasPrecision(12, 2);

        // quando excluir uma categoria os produtos relacionais serao excluidos em Cascade
        modelBuilder.Entity<Categoria>().
            HasMany(g => g.Produtos).WithOne(c => c.Categoria).IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria
            {
                CategoriaId = 1,
                Nome = "Funko",
            },
            new Categoria
            {
                CategoriaId = 2,
                Nome = "Caneca",
            }
         );
    }
}
