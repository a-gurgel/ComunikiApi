using System.ComponentModel.DataAnnotations;

namespace ComunikiApi.Data.Dtos;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    public string NomeProduto { get; set; }
    [Required(ErrorMessage = "O preço do produto é obrigatório")]
    public decimal Preco { get; set; }
    [Required(ErrorMessage = "A descrição do produto é obrigatória")]
    public string Descricao { get; set; }
    public long Estoque { get; set; }
    public string ImageURL { get; set; }
}
