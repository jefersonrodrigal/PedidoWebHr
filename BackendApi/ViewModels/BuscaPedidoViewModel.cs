using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackendApi.ViewModels
{
    public class BuscaPedidoViewModel
    {
        public string? Cliente { get; set; }
        public int? Status { get; set; }
        public int? Periodo { get; set; }
        public int? OrdenarPor { get; set; }
        public int? OrdemData { get; set; }

        public IEnumerable<SelectListItem>? StatusList { get; set; }
        public IEnumerable<SelectListItem>? PeriodoList { get; set; }
        public IEnumerable<SelectListItem>? OrdenarPorList { get; set; }
        public IEnumerable<SelectListItem>? OrdemDataList { get; set; }

    }
}
