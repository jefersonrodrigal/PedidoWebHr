namespace BackendApi.Models
{
    public class ProdutoModel
    {
        public string? CodPro {  get; set; }
        public int? SeqIpd { get; set; }
        public long? NumPpd { get; set; }
        public string? Unimed { get; set; }
        public decimal? PreUni { get; set; }
        public decimal? Quantidade { get; set; }
        public string? DescPro { get; set; }
        public decimal? TotalPreco { get; set; }
    }
}
