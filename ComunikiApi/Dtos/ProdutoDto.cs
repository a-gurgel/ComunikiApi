using System.ComponentModel.DataAnnotations;

namespace ComunikiApi.Dtos;

public class ProdutoDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [MinLength(4)]
    [MaxLength(255)]
    public string? NomeProduto { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatório")]
    [MinLength(4)]
    [MaxLength(255)]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O valor paraa estoque é obrigatório")]
    [Range(1, 9999)]
    public long Estoque { get; set; }
    public string? ImageURL { get; set; }

    //propriedades de navegacao
    public CategoriaDto? Categoria { get; set; }
    public int CategoriaId { get; set; }
}
