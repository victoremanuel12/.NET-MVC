using MVC2022.Models;

namespace MVC2022.ViewModel
{
    public class HomeViewModel
    {

        //exibir os lanches preferidos na home
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
