using MVC2022.Models;
using Microsoft.AspNetCore.Mvc;
using MVC2022.Repositories.Interfaces;
using MVC2022.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace MVC2022.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILanchesRepository lanchesRepository, CarrinhoCompra carrinhoCompra)
        {
            _lanchesRepository = lanchesRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems= itens;
            var carrinhoCompraViewModel = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraViewModel);
        }
        [Authorize]
        public RedirectToActionResult AdicionarItemAoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
                if(lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
                return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lanchesSelecionado = _lanchesRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lanchesSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lanchesSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
