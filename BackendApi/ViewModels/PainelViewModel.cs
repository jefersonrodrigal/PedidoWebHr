using BackendApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackendApi.ViewModels
{
    public class PainelViewModel
    {
        public RepresentanteModel? Representante { get; set; }
        public IEnumerable<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
        public List<PedidoModel>? Produtos { get; set; }
        public int PaginaAtual { get; set; }
        public int PageSize { get; set; }

    }
}
