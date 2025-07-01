namespace BackendApi.ViewModels
{
    public class DataPedidoViewModel
    {
        public string? DatEmi { get; set; }
        public string? ObsPed { get; set; }
        public int? CodCli { get; set; }
        public int? CodRep { get; set; }
        public int? CodCpg { get; set; }
        public string? PedCli { get; set; }
        public string? DatPrv { get; set; }
        public short? PedIme { get; set; }
        public short? TipFat { get; set; }
        public short? NatOpe { get; set; }
        public decimal? PerDsc { get; set; }
        public string? SitPpd { get; set; }
        public short? TiPdis { get; set; }
        public string? RetMer { get; set; }
        public string? NecAge { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

    }
}
