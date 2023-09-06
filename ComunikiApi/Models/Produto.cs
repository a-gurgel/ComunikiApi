namespace ComunikiApi.Models;

public class Produto
{
    public int Id { get; set; }
    public string? NomeProduto { get; set; }
    public decimal Preco { get; set; }
    public string? Descricao { get; set; }
    public long Estoque { get; set; }
    public string? ImageURL { get; set; }

    //propriedades de navegacao
    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }

}