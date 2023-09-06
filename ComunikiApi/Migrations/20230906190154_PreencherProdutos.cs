using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComunikiApi.Migrations
{
    /// <inheritdoc />
    public partial class PreencherProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(NomeProduto, Preco, Descricao, Estoque, ImageURL, CategoriaId) " +
                "Values('Funko Pop Homem de Ferro', 170, 'Funko Pop Homem de Ferro em Guerra Infinita', 4, 'funko01.jpg', 1)");

            migrationBuilder.Sql("Insert into Produtos(NomeProduto, Preco, Descricao, Estoque, ImageURL, CategoriaId) " +
               "Values('Funko Pop Homem de Ferro', 140, 'Funko Pop Homem de Ferro em Guerra Infinita', 4, 'funko01.jpg', 1)");

            migrationBuilder.Sql("Insert into Produtos(NomeProduto, Preco, Descricao, Estoque, ImageURL, CategoriaId) " +
               "Values('Funko Pop Homem de Ferro', 179.89, 'Funko Pop Homem de Ferro em Guerra Infinita', 4, 'funko01.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Produtos");
        }
    }
}
