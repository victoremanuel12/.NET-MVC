using Microsoft.AspNetCore.Mvc;
using MVC2022.Repositories.Interfaces;

namespace MVC2022.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(c=> c.CategoriaNome);
            return View(categorias);
        }
    }
}
