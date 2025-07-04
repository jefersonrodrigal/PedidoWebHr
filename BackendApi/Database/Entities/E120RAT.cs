using System;
using System.Collections.Generic;

namespace BackendApi.Database.Entities;

public partial class E120RAT
{
    public short CodEmp { get; set; }

    public int CodFil { get; set; }

    public int NumPed { get; set; }

    public short SeqRat { get; set; }

    public string? TnsPro { get; set; }

    public string? TnsSer { get; set; }

    public short? SeqIpd { get; set; }

    public short? SeqIsp { get; set; }

    public short CriRat { get; set; }

    public short SomSub { get; set; }

    public int? NumPrj { get; set; }

    public short? CodFpj { get; set; }

    public int? CtaFin { get; set; }

    public int? CtaRed { get; set; }

    public decimal? PerCta { get; set; }

    public decimal? VlrCta { get; set; }

    public string? CodCcu { get; set; }

    public decimal? PerRat { get; set; }

    public decimal? VlrRat { get; set; }

    public string? ObsRat { get; set; }

    public long? UsuGer { get; set; }

    public DateTime? DatGer { get; set; }

    public int? HorGer { get; set; }

    public string? Tipori { get; set; }
}
