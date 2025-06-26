using BackendApi.Models;

namespace BackendApi.ViewModels
{
    public class PedidoViewModel
    {
        public string? NomCli {  get; set; }
        public IEnumerable<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
    }
}
