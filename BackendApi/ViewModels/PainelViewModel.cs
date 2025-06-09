using BackendApi.Models;

namespace BackendApi.ViewModels
{
    public class PainelViewModel
    {
        public RepresentanteModel? Representante { get; set; }
        public List<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
        public IEnumerable<PedidoClienteModel> Cliente { get; set; } = new List<PedidoClienteModel>();
        public IEnumerable<PedidoProdutoModel> Produtos { get; set; } = new List<PedidoProdutoModel>();
        public int PaginaAtual { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}
