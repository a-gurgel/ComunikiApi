using System.ComponentModel.DataAnnotations;

namespace ComunikiApi.Dtos;

public class CategoriaDto
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(4)]
    [MaxLength(255)]
    public string? Nome { get; set; }
    public ICollection<ProdutoDto>? Produtos { get; set; }
}
