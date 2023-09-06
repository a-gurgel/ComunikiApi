using ComunikiApi.Data;
using ComunikiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunikiApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Delete(int id)
        {
            var categoria = await GetById(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _context.Categorias.Where(c=> c.CategoriaId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return await _context.Categorias.Include(c=> c.Produtos).ToListAsync();

        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoria;

        }
    }
}
