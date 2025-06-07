namespace BackendApi.Database.Entities
{
    public class T009PPD
    {
        public long UsuNumppd { get; set; }

        public DateTime? UsuDatemi { get; set; }

        public string? UsuObsped { get; set; }

        public int? UsuCodcli { get; set; }

        public int? UsuCodrep { get; set; }

        public int? UsuCodcpg { get; set; }

        public string? UsuPedcli { get; set; }

        public DateTime? UsuDatprv { get; set; }

        public short? UsuPedime { get; set; }

        public short? UsuTipfat { get; set; }

        public short? UsuNatope { get; set; }

        public decimal? UsuPerdsc { get; set; }

        public int? UsuNumped { get; set; }

        public int? UsuNumpe2 { get; set; }

        public short? UsuSitppd { get; set; }

        public string? UsuCiffob { get; set; }

        public string? UsuCodcrt { get; set; }

        public short? UsuCodfpg { get; set; }

        public int? UsuCodtra { get; set; }

        public short? UsuTipdis { get; set; }

        public int? UsuNumnfv { get; set; }

        public int? UsuNumnf2 { get; set; }

        public DateTime? UsuDatfat { get; set; }

        public string? UsuObsfin { get; set; }

        public DateTime? UsuPrvfat { get; set; }

        public string? UsuRetmer { get; set; }

        public short UsuCodemp { get; set; }

        public string? UsuNecage { get; set; }

        public static implicit operator T009PPD(int v)
        {
            throw new NotImplementedException();
        }
    }
}
