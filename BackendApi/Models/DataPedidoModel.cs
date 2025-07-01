namespace BackendApi.Models
{
    public class DataPedidoModel
    {
        public long NumPpd { get; set; }
        public DateTime? DatEmi { get; set; }
        public string? ObsPed { get; set; }
        public int? CodCli { get; set; }
        public int? CodRep { get; set; }
        public int? CodCpg { get; set; }
        public string? PedCli { get; set; }
        public DateTime? DatPrv { get; set; }
        public short? PedIme { get; set; }
        public short? TipFat { get; set; }
        public short? NatOpe { get; set; }
        public decimal? PerDsc { get; set; }
        // public int? NumPed { get; set; }
        // public int? NumPe2 { get; set; }
        public short? SitPpd { get; set; }
        //public string? CifFob { get; set; }
        // public string? CodCrt { get; set; }
        // public short? CodFpg { get; set; }
        // public int? CodTra { get; set; }
        public short? TiPdis { get; set; }
        // public int? NumNfv { get; set; }
        // public int? NumNf2 { get; set; }
        // public DateTime? DatFat { get; set; }
        // public string? ObsFin { get; set; }
        // public DateTime? PrvFat { get; set; }
        public string? RetMer { get; set; }
        // public short CodEmp { get; set; }
        public string? NecAge { get; set; }
    }
}
