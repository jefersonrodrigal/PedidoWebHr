using System;

namespace BackendApi.Database.Entities;

public partial class T009PPI
{
    public long UsuNumppd { get; set; }

    public short UsuSeqipd { get; set; }

    public string? UsuCodpro { get; set; }

    public decimal? UsuQtdped { get; set; }

    public decimal? UsuPreuni { get; set; }

    public decimal? UsuVlrtot { get; set; }

    public string? UsuCodagc { get; set; }

    public string? UsuCodfam { get; set; }

    public int? UsuFinrec { get; set; }

    public string? UsuDesnfv { get; set; }

    public string? UsuUnimed { get; set; }

    public short UsuCodemp { get; set; }
}
