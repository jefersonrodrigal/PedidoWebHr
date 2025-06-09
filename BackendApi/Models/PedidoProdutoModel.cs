namespace BackendApi.Models
{
    public class PedidoProdutoModel
    {
        public long? Numppd {  get; set; }
        public string? CodPro { get; set; }
        public string? Unimed { get; set; }
        public decimal? PreUni {  get; set; }
        public decimal? Quantidade { get; set; }
        public string? DescPro { get; set; }
        public string? NomCli {  get; set; }
        public int CodCli {  get; set; }
        public int? NumNfv {  get; set; }
        public DateTime? DateEmi { get; set; }
    }
}
