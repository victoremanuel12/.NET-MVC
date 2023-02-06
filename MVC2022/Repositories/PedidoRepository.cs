using MVC2022.Context;
using MVC2022.Models;
using MVC2022.Repositories.Interfaces;

namespace MVC2022.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();
            var carrinhoDeComraItens = _carrinhoCompra.CarrinhoCompraItems;
            foreach(var carrinhoItem in carrinhoDeComraItens)
            {
                var pedidoDetail = new PedidoDetalhe
                {

                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.LanchePreco
                };
                _appDbContext.PedidoDetalhe.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
