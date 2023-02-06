using MVC2022.Models;

namespace MVC2022.ViewModel
{
    public class LancheListViewModel
    {
        public  IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
