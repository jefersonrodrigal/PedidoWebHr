using System;
using System.Collections.Generic;

namespace BackendApi.Database.Entities;

public partial class E120IPD
{
    public short CodEmp { get; set; }

    public int CodFil { get; set; }

    public int NumPed { get; set; }

    public short SeqIpd { get; set; }

    public string? TnsPro { get; set; }

    public string? PedCli { get; set; }

    public string? SeqPcl { get; set; }

    public string PedPrv { get; set; } = null!;

    public string? CodPro { get; set; }

    public string? CodDer { get; set; }

    public string? CplIpd { get; set; }

    public string? CodFam { get; set; }

    public short? CodAgr { get; set; }

    public string? CodTic { get; set; }

    public string? CodTrd { get; set; }

    public string? CodTst { get; set; }

    public string? CodStp { get; set; }

    public string? CodStc { get; set; }

    public string? CodDep { get; set; }

    public string? CodLot { get; set; }

    public string ResEst { get; set; } = null!;

    public decimal QtdPed { get; set; }

    public decimal? QtdAen { get; set; }

    public decimal? QtdPoc { get; set; }

    public decimal? QtdFat { get; set; }

    public decimal? QtdCan { get; set; }

    public decimal? QtdAbe { get; set; }

    public decimal? QtdRae { get; set; }

    public decimal? QtdNlp { get; set; }

    public decimal? QtdRes { get; set; }

    public string UniMed { get; set; } = null!;

    public string? CodMcp { get; set; }

    public DateTime? DatMfp { get; set; }

    public decimal? CotMfp { get; set; }

    public DateTime? DatMoe { get; set; }

    public decimal? CotMoe { get; set; }

    public string? FecMoe { get; set; }

    public string? CodTpr { get; set; }

    public decimal? PreUni { get; set; }

    public string? CodMoe { get; set; }

    public string PreFix { get; set; } = null!;

    public decimal? PerDsc { get; set; }

    public decimal? PerOfe { get; set; }

    public decimal? PerAcr { get; set; }

    public decimal? PerIpi { get; set; }

    public decimal? PerIcm { get; set; }

    public decimal? PerCom { get; set; }

    public DateTime DatEnt { get; set; }

    public DateTime DatAne { get; set; }

    public DateTime DatPoc { get; set; }

    public string? CodPvp { get; set; }

    public int? NumPrj { get; set; }

    public short? CodFpj { get; set; }

    public int? CtaFin { get; set; }

    public int? CtaRed { get; set; }

    public string? CodCcu { get; set; }

    public decimal? VlrFre { get; set; }

    public decimal? VlrSeg { get; set; }

    public decimal? VlrEmb { get; set; }

    public decimal? VlrEnc { get; set; }

    public decimal? VlrOut { get; set; }

    public decimal? VlrDar { get; set; }

    public decimal? VlrFrd { get; set; }

    public decimal? VlrOud { get; set; }

    public decimal? VlrBru { get; set; }

    public decimal? VlrDsc { get; set; }

    public decimal? VlrDs1 { get; set; }

    public decimal? VlrDs2 { get; set; }

    public decimal? VlrDs3 { get; set; }

    public decimal? VlrDs4 { get; set; }

    public decimal? VlrOfe { get; set; }

    public decimal? VlrDzf { get; set; }

    public decimal? VlrBip { get; set; }

    public decimal? VlrIpi { get; set; }

    public decimal? VlrBic { get; set; }

    public decimal? VlrIcm { get; set; }

    public decimal? VlrBsi { get; set; }

    public decimal? VlrIcs { get; set; }

    public decimal? VlrBsp { get; set; }

    public decimal? VlrStp { get; set; }

    public decimal? VlrBsc { get; set; }

    public decimal? VlrStc { get; set; }

    public decimal? VlrBco { get; set; }

    public decimal? VlrCom { get; set; }

    public decimal? VlrLpr { get; set; }

    public decimal? VlrLou { get; set; }

    public decimal? VlrLiq { get; set; }

    public decimal? VlrFin { get; set; }

    public short SitIpd { get; set; }

    public int? CodMot { get; set; }

    public string? ObsMot { get; set; }

    public short GerNec { get; set; }

    public string GerCga { get; set; } = null!;

    public string ResMan { get; set; } = null!;

    public string IndAed { get; set; } = null!;

    public int? NumCtr { get; set; }

    public DateTime? DatCpt { get; set; }

    public short? SeqCvp { get; set; }

    public long? UsuGer { get; set; }

    public DateTime DatGer { get; set; }

    public int? HorGer { get; set; }

    public decimal? QtdPpf { get; set; }

    public string CmpKit { get; set; } = null!;

    public int? FilOcp { get; set; }

    public int? NumOcp { get; set; }

    public short? SeqIpo { get; set; }

    public string? UniVen { get; set; }

    public decimal? QtdVen { get; set; }

    public decimal? PreVen { get; set; }

    public decimal? PreBru { get; set; }

    public int? FilCtr { get; set; }

    public int? CtrCvs { get; set; }

    public DateTime? CptCvs { get; set; }

    public short? SeqCvs { get; set; }

    public int? CodAvc { get; set; }

    public string? CodFxa { get; set; }

    public string? CodPgr { get; set; }

    public int? IdxGrd { get; set; }

    public string? CodMar { get; set; }

    public string? CodClc { get; set; }

    public decimal? PerDs1 { get; set; }

    public decimal? PerDs2 { get; set; }

    public decimal? PerDs3 { get; set; }

    public decimal? PerDs4 { get; set; }

    public int? FilPrd { get; set; }

    public decimal? VlrRis { get; set; }

    public string? IndPce { get; set; }

    public string? IndPcr { get; set; }

    public decimal? PerPit { get; set; }

    public decimal? VlrBpt { get; set; }

    public decimal? VlrPit { get; set; }

    public decimal? PerCrt { get; set; }

    public decimal? VlrBct { get; set; }

    public decimal? VlrCrt { get; set; }

    public decimal? PerCsl { get; set; }

    public decimal? VlrBcl { get; set; }

    public decimal? VlrCsl { get; set; }

    public decimal? PerOur { get; set; }

    public decimal? VlrBor { get; set; }

    public decimal? VlrOur { get; set; }

    public decimal? PerIrf { get; set; }

    public decimal? VlrBir { get; set; }

    public decimal? VlrIrf { get; set; }

    public int? FilNfc { get; set; }

    public int? ForNfc { get; set; }

    public int? NumNfc { get; set; }

    public string? SnfNfc { get; set; }

    public short? SeqIpc { get; set; }

    public string? NctLcl { get; set; }

    public string? NreCli { get; set; }

    public long? NosIcl { get; set; }

    public long? NosFcl { get; set; }

    public string? NocCl1 { get; set; }

    public string? NocCl2 { get; set; }

    public string? NocCl3 { get; set; }

    public string? CodAgc { get; set; }

    public int? CtrCvp { get; set; }

    public DateTime? CptCvp { get; set; }

    public short? SeqCtr { get; set; }

    public short? IndApe { get; set; }

    public string? ObsIpd { get; set; }

    public short? SeqIsp { get; set; }

    public short? EmpOcp { get; set; }

    public decimal? VlrBpf { get; set; }

    public decimal? PerPif { get; set; }

    public decimal? VlrPif { get; set; }

    public decimal? VlrBcf { get; set; }

    public decimal? PerCff { get; set; }

    public decimal? VlrCff { get; set; }

    public decimal? UsuQtdFat { get; set; }

    public int? UsuQtdEmb { get; set; }

    public decimal? UsuQtdAbe { get; set; }

    public decimal? UsuPesPro { get; set; }

    public decimal? UsuQtdVen { get; set; }

    public decimal? Perds5 { get; set; }

    public decimal? Vlrds5 { get; set; }

    public string? UsuEstemp { get; set; }

    public decimal? UsuVenabe { get; set; }

    public string? Orires { get; set; }

    public string? Agrnec { get; set; }

    public string? Agrpai { get; set; }

    public decimal? Qtdbpf { get; set; }

    public decimal? Alipif { get; set; }

    public decimal? Qtdbcf { get; set; }

    public decimal? Alicff { get; set; }

    public decimal? Qtdbip { get; set; }

    public decimal? Aliipi { get; set; }

    public string? Indipm { get; set; }

    public int? Filrem { get; set; }

    public string? Snfrem { get; set; }

    public int? Nfvrem { get; set; }

    public short? Ipvrem { get; set; }

    public short? Codcnv { get; set; }

    public int? Codrep { get; set; }

    public string? Promon { get; set; }

    public string? Proent { get; set; }

    public decimal? Permgc { get; set; }

    public string? Varser { get; set; }

    public string? Retmat { get; set; }

    public string? Senapr { get; set; }

    public long? Usuapr { get; set; }

    public DateTime? Datapr { get; set; }

    public int? Horapr { get; set; }

    public short? Tipcur { get; set; }

    public short? Codfin { get; set; }

    public decimal? UsuQtdpon { get; set; }

    public decimal? UsuPesrea { get; set; }

    public string? Codbar { get; set; }

    public string? Indbrd { get; set; }

    public string? Brdman { get; set; }

    public string? Dscprm { get; set; }

    public decimal? Perjur { get; set; }

    public decimal? Perdif { get; set; }

    public decimal? Basidf { get; set; }

    public decimal? Peridf { get; set; }

    public decimal? Vlridf { get; set; }

    public string? Codstr { get; set; }

    public int? Filnco { get; set; }

    public string? Snfnco { get; set; }

    public int? Numnco { get; set; }

    public short? Seqnco { get; set; }

    public short? Motdes { get; set; }

    public decimal? Vlricd { get; set; }

    public long? Seqrem { get; set; }

    public int? Numrec { get; set; }

    public long? Seqrei { get; set; }

    public decimal? Icmaor { get; set; }

    public decimal? Icmvor { get; set; }

    public decimal? Icmade { get; set; }

    public decimal? Icmvde { get; set; }

    public decimal? Icmbde { get; set; }

    public decimal? Icmafc { get; set; }

    public decimal? Icmvfc { get; set; }

    public int? Seqhas { get; set; }

    public DateTime? Datalt { get; set; }

    public int? Horalt { get; set; }

    public long? Usualt { get; set; }

    public decimal? Vlrtot { get; set; }

    public string? Itecan { get; set; }

    public decimal? Dscvar { get; set; }

    public decimal? Acrvar { get; set; }

    public decimal? Pdsvar { get; set; }

    public decimal? Pacvar { get; set; }

    public int? Filori { get; set; }

    public string? Obsent { get; set; }

    public string? UsuPedrec { get; set; }

    public string? UsuProrec { get; set; }

    public string? Forent { get; set; }

    public string? Numint { get; set; }

    public decimal? Icmbfc { get; set; }

    public decimal? Basfcp { get; set; }

    public decimal? Alifcp { get; set; }

    public decimal? Vlrfcp { get; set; }

    public decimal? Bstfcp { get; set; }

    public decimal? Astfcp { get; set; }

    public decimal? Vstfcp { get; set; }

    public string? Cmpmtg { get; set; }

    public string? UsuProtra { get; set; }

    public decimal? Vicstd { get; set; }

    public short? Mtdist { get; set; }
}
