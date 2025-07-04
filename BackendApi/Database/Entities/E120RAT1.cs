using System;
using System.Collections.Generic;

namespace BackendApi.Database.Entities;

public partial class E120RAT1
{
    public short Codemp { get; set; }

    public short Codfil { get; set; }

    public int Numped { get; set; }

    public short Seqrat { get; set; }

    public string? Tnspro { get; set; }

    public string? Tnsser { get; set; }

    public short? Seqipd { get; set; }

    public short? Seqisp { get; set; }

    public short Crirat { get; set; }

    public short Somsub { get; set; }

    public int? Numprj { get; set; }

    public short? Codfpj { get; set; }

    public int? Ctafin { get; set; }

    public int? Ctared { get; set; }

    public decimal? Percta { get; set; }

    public decimal? Vlrcta { get; set; }

    public string? Codccu { get; set; }

    public decimal? Perrat { get; set; }

    public decimal? Vlrrat { get; set; }

    public string? Obsrat { get; set; }

    public long? Usuger { get; set; }

    public DateTime? Datger { get; set; }

    public int? Horger { get; set; }

    public string? Tipori { get; set; }
}
