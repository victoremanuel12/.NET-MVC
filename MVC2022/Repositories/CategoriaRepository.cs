using MVC2022.Context;
using MVC2022.Models;
using MVC2022.Repositories.Interfaces;

namespace MVC2022.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias ;
    }
}
