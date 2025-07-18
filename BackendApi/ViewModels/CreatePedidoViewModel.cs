using BackendApi.Enums;
using BackendApi.Models;

namespace BackendApi.ViewModels
{
    public class CreatePedidoViewModel
    {
        public RepresentanteModel Representante { get; set; } = new RepresentanteModel();
        public DateTime DataLancamento { get; } = DateTime.Now;
        public Status StatusPedido { get; set; } = Status.NaoEnviado;
        public string NumPpd {  get; set; } = string.Empty;
        public long CodCli {  get; set; } = 0;
        public List<ProdutoModel>? Produtos { get; set; } = null;
        public ClienteModel? Cliente { get; set; } = null;
    }
}
