using BackendApi.Models;

namespace BackendApi.ViewModels
{
    public class ClienteViewModel
    {
        public RepresentanteModel Representante { get; set; } = new RepresentanteModel();
        public List<ClienteModel> Clientes { get; set; } = new List<ClienteModel>();
    }
}
