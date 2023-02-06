using Microsoft.AspNetCore.Mvc;

namespace MVC2022.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
