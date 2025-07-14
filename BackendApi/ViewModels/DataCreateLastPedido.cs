namespace BackendApi.ViewModels
{
    public class DataCreateLastPedido
    {
        public DateTime DatEmi { get; set; }
        public string NumPpd { get; set; } = string.Empty;
        public int TipFat {  get; set; }
        public int CodCpg { get; set; }
        public int RetMer {  get; set; }
        public string PerDsc { get; set; } = string.Empty;
        public int TipDis {  get; set; }
        public string PedCli {  get; set; } = string.Empty;
        public int PedIme { get; set; }
        public int NecAge { get; set; }
        public DateTime DatPrv { get; set; }
        public int NatOpe { get; set; }
        public string SitPpd { get; set; } = string.Empty;
        public string ObsPed { get; set; } = string.Empty;
        public int CodCli { get; set; }

    }
}
