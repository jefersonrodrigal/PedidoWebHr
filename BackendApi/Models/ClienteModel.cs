namespace BackendApi.Models
{
    public class ClienteModel
    {
        public long? CodCli { get; set; }
        public string? NomCli { get; set; } = "";
        public string? NomFantCli { get; set; } = "";
        public string? Complemento { get; set; } = "";
        public string? Bairro { get; set; } = "";
        public int? CepCli { get; set; }
        public string? EmailCli { get; set; } = "";
        public string? Cidade { get; set; } = "";
        public string? UfCli { get; set; } = "";
        public string? SitCli { get; set; } = "";
        public long? Cgccpf { get; set; }
        public string? Endereço { get; set; } = "";
        public string? Contato { get; set; } = "";
        public string? Contato2 { get; set; } = "";

        public string? FaxCli { get; set; } = "";
    }
}
