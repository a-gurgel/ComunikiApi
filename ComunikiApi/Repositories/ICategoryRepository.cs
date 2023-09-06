using ComunikiApi.Models;

namespace ComunikiApi.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Categoria>> GetAll();
    Task<IEnumerable<Categoria>> GetCategoriasProdutos();
    Task<Categoria> GetById(int id);
    Task<Categoria> Create(Categoria categoria);
    Task<Categoria> Update(Categoria categoria);
    Task<Categoria> Delete(int id); 


}
