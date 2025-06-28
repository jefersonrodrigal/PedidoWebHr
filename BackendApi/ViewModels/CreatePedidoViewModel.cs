using BackendApi.Enums;
using BackendApi.Models;

namespace BackendApi.ViewModels
{
    public class CreatePedidoViewModel
    {
        public RepresentanteModel Representante { get; set; } = new RepresentanteModel();
        public DateTime DataLancamento { get; } = DateTime.Now;
        public long? NumeroPedido { get; set; }
        public Status StatusPedido { get; set; } = Status.NaoEnviado;
    }
}
