using BackendApi.Models;

namespace BackendApi.ViewModels
{
    public class PainelViewModel
    {
        public RepresentanteModel? Representante { get; set; }
        public IEnumerable<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
        public IEnumerable<PedidoClienteModel> Cliente { get; set; } = new List<PedidoClienteModel>();
        public List<PedidoModel>? Produtos { get; set; }
        public int PaginaAtual { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
