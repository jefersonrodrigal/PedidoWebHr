using BackendApi.Enums;

namespace BackendApi.Models
{
    public class PedidoModel
    {
        public long NumPpd { get; set; }
        public string? NomCli {  get; set; }
        public DateTime? DatEmi { get; set; }
        public long? CodCli {  get; set; }
        public int? NumNfv {  get; set; }

        public List<ProdutoModel> Produtos = new List<ProdutoModel>();
    }
}
