﻿using BackendApi.Models;
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
