using BackendApi.Models;

namespace BackendApi.ViewModels
{
    public class ClienteViewModel
    {
        public RepresentanteModel Representante { get; set; } = new RepresentanteModel();
        public List<ClienteModel> Clientes { get; set; } = new List<ClienteModel>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
