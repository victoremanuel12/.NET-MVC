using Microsoft.AspNetCore.Mvc;
using MVC2022.Models;
using MVC2022.Repositories.Interfaces;
using MVC2022.ViewModel;
using System.Diagnostics;

namespace MVC2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;

        public HomeController(ILanchesRepository lanchesRepository)
        {

            _lanchesRepository = lanchesRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lanchesRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

         
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}