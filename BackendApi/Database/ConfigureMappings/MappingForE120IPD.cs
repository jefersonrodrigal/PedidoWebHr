using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE120IPD : IEntityTypeConfiguration<E120IPD>
    {
        public void Configure(EntityTypeBuilder<E120IPD> entity)
        {
            entity.HasKey(e => new { e.CodEmp, e.CodFil, e.NumPed, e.SeqIpd })
                .HasName("cp_e120ipd")
                .IsClustered(false);

            entity.ToTable("E120IPD", tb =>
            {
                tb.HasTrigger("E120IPD_04");
                tb.HasTrigger("T120IPDD");
                tb.HasTrigger("USU_E120IPD_03");
                tb.HasTrigger("U_E120IPD_02");
            });

            entity.HasIndex(e => new { e.CodPro, e.CodDer, e.DatEnt, e.CodEmp, e.CodFil }, "e120ipdindice2");

            entity.HasIndex(e => new { e.DatEnt, e.CodPro, e.CodDer, e.CodEmp, e.CodFil }, "e120ipdindice3");

            entity.HasIndex(e => new { e.CodEmp, e.FilNfc, e.ForNfc, e.SnfNfc, e.NumNfc, e.SeqIpc, e.CodFil }, "e120ipdindice4");

            entity.HasIndex(e => new { e.EmpOcp, e.FilOcp, e.NumOcp, e.SeqIpo }, "e120ipdindice5");

            entity.HasIndex(e => new { e.CodEmp, e.FilCtr, e.CtrCvs, e.CptCvs, e.SeqCvs }, "e120ipdindice6");

            entity.HasIndex(e => new { e.QtdRes, e.SitIpd, e.ResEst, e.CodDep }, "e120ipdindice7");

            entity.Property(e => e.Acrvar)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("acrvar");
            entity.Property(e => e.Agrnec)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("agrnec");
            entity.Property(e => e.Agrpai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("agrpai");
            entity.Property(e => e.Alicff)
                .HasColumnType("numeric(15, 4)")
                .HasColumnName("alicff");
            entity.Property(e => e.Alifcp)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("alifcp");
            entity.Property(e => e.Aliipi)
                .HasColumnType("numeric(15, 4)")
                .HasColumnName("aliipi");
            entity.Property(e => e.Alipif)
                .HasColumnType("numeric(15, 4)")
                .HasColumnName("alipif");
            entity.Property(e => e.Astfcp)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("astfcp");
            entity.Property(e => e.Basfcp)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("basfcp");
            entity.Property(e => e.Basidf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("basidf");
            entity.Property(e => e.Brdman)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("brdman");
            entity.Property(e => e.Bstfcp)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("bstfcp");
            entity.Property(e => e.CmpKit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Cmpmtg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cmpmtg");
            entity.Property(e => e.CodAgc)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodCcu)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.CodClc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodDep)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodDer)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.CodFam)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CodFxa)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CodLot)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodMar)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodMcp)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodMoe)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodPgr)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodPro)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.CodPvp)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CodStc)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodStp)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTic)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTpr)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodTrd)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTst)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Codbar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codbar");
            entity.Property(e => e.Codcnv).HasColumnName("codcnv");
            entity.Property(e => e.Codfin).HasColumnName("codfin");
            entity.Property(e => e.Codrep).HasColumnName("codrep");
            entity.Property(e => e.Codstr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstr");
            entity.Property(e => e.CotMfp).HasColumnType("numeric(19, 10)");
            entity.Property(e => e.CotMoe).HasColumnType("numeric(19, 10)");
            entity.Property(e => e.CplIpd)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CptCvp).HasColumnType("datetime");
            entity.Property(e => e.CptCvs).HasColumnType("datetime");
            entity.Property(e => e.DatAne).HasColumnType("datetime");
            entity.Property(e => e.DatCpt).HasColumnType("datetime");
            entity.Property(e => e.DatEnt).HasColumnType("datetime");
            entity.Property(e => e.DatGer).HasColumnType("datetime");
            entity.Property(e => e.DatMfp).HasColumnType("datetime");
            entity.Property(e => e.DatMoe).HasColumnType("datetime");
            entity.Property(e => e.DatPoc).HasColumnType("datetime");
            entity.Property(e => e.Datalt)
                .HasColumnType("datetime")
                .HasColumnName("datalt");
            entity.Property(e => e.Datapr)
                .HasColumnType("datetime")
                .HasColumnName("datapr");
            entity.Property(e => e.Dscprm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("dscprm");
            entity.Property(e => e.Dscvar)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("dscvar");
            entity.Property(e => e.FecMoe)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Filnco).HasColumnName("filnco");
            entity.Property(e => e.Filori).HasColumnName("filori");
            entity.Property(e => e.Filrem).HasColumnName("filrem");
            entity.Property(e => e.Forent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("forent");
            entity.Property(e => e.GerCga)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Horalt).HasColumnName("horalt");
            entity.Property(e => e.Horapr).HasColumnName("horapr");
            entity.Property(e => e.Icmade)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("icmade");
            entity.Property(e => e.Icmafc)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("icmafc");
            entity.Property(e => e.Icmaor)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("icmaor");
            entity.Property(e => e.Icmbde)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmbde");
            entity.Property(e => e.Icmbfc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmbfc");
            entity.Property(e => e.Icmvde)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmvde");
            entity.Property(e => e.Icmvfc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmvfc");
            entity.Property(e => e.Icmvor)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("icmvor");
            entity.Property(e => e.IndAed)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.IndPce)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.IndPcr)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Indbrd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indbrd");
            entity.Property(e => e.Indipm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indipm");
            entity.Property(e => e.Ipvrem).HasColumnName("ipvrem");
            entity.Property(e => e.Itecan)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("itecan");
            entity.Property(e => e.Motdes).HasColumnName("motdes");
            entity.Property(e => e.Mtdist).HasColumnName("mtdist");
            entity.Property(e => e.NctLcl)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nfvrem).HasColumnName("nfvrem");
            entity.Property(e => e.NocCl1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NocCl2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NocCl3)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NreCli)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Numint)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numint");
            entity.Property(e => e.Numnco).HasColumnName("numnco");
            entity.Property(e => e.Numrec).HasColumnName("numrec");
            entity.Property(e => e.ObsIpd)
                .HasMaxLength(999)
                .IsUnicode(false);
            entity.Property(e => e.ObsMot)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Obsent)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("obsent");
            entity.Property(e => e.Orires)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("orires");
            entity.Property(e => e.Pacvar)
                .HasColumnType("numeric(10, 5)")
                .HasColumnName("pacvar");
            entity.Property(e => e.Pdsvar)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("pdsvar");
            entity.Property(e => e.PedCli)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PedPrv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PerAcr).HasColumnType("numeric(10, 5)");
            entity.Property(e => e.PerCff).HasColumnType("numeric(8, 4)");
            entity.Property(e => e.PerCom).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerCrt).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.PerCsl).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.PerDs1).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDs2).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDs3).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDs4).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDsc).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerIcm).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerIpi).HasColumnType("numeric(8, 4)");
            entity.Property(e => e.PerIrf).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.PerOfe).HasColumnType("numeric(10, 5)");
            entity.Property(e => e.PerOur).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.PerPif).HasColumnType("numeric(8, 4)");
            entity.Property(e => e.PerPit).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.Perdif)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perdif");
            entity.Property(e => e.Perds5)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds5");
            entity.Property(e => e.Peridf)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("peridf");
            entity.Property(e => e.Perjur)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perjur");
            entity.Property(e => e.Permgc)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("permgc");
            entity.Property(e => e.PreBru).HasColumnType("numeric(21, 10)");
            entity.Property(e => e.PreFix)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PreUni).HasColumnType("numeric(21, 10)");
            entity.Property(e => e.PreVen).HasColumnType("numeric(21, 10)");
            entity.Property(e => e.Proent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("proent");
            entity.Property(e => e.Promon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("promon");
            entity.Property(e => e.QtdAbe).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdAen).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdCan).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdFat).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdNlp).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdPed).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdPoc).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdPpf).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdRae).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdRes).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.QtdVen).HasColumnType("numeric(14, 5)");
            entity.Property(e => e.Qtdbcf)
                .HasColumnType("numeric(15, 3)")
                .HasColumnName("qtdbcf");
            entity.Property(e => e.Qtdbip)
                .HasColumnType("numeric(15, 3)")
                .HasColumnName("qtdbip");
            entity.Property(e => e.Qtdbpf)
                .HasColumnType("numeric(15, 3)")
                .HasColumnName("qtdbpf");
            entity.Property(e => e.ResEst)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResMan)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Retmat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retmat");
            entity.Property(e => e.Senapr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senapr");
            entity.Property(e => e.SeqPcl)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Seqhas).HasColumnName("seqhas");
            entity.Property(e => e.Seqnco).HasColumnName("seqnco");
            entity.Property(e => e.Seqrei).HasColumnName("seqrei");
            entity.Property(e => e.Seqrem).HasColumnName("seqrem");
            entity.Property(e => e.SnfNfc)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Snfnco)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("snfnco");
            entity.Property(e => e.Snfrem)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("snfrem");
            entity.Property(e => e.Tipcur).HasColumnName("tipcur");
            entity.Property(e => e.TnsPro)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.UniMed)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.UniVen)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.UsuEstemp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_estemp");
            entity.Property(e => e.UsuPedrec)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_pedrec");
            entity.Property(e => e.UsuPesPro)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("USU_PesPro");
            entity.Property(e => e.UsuPesrea)
                .HasColumnType("numeric(15, 12)")
                .HasColumnName("usu_pesrea");
            entity.Property(e => e.UsuProrec)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("usu_prorec");
            entity.Property(e => e.UsuProtra)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_protra");
            entity.Property(e => e.UsuQtdAbe)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("USU_QtdAbe");
            entity.Property(e => e.UsuQtdEmb).HasColumnName("USU_QtdEmb");
            entity.Property(e => e.UsuQtdFat)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("USU_QtdFat");
            entity.Property(e => e.UsuQtdVen)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("USU_QtdVen");
            entity.Property(e => e.UsuQtdpon)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_qtdpon");
            entity.Property(e => e.UsuVenabe)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_venabe");
            entity.Property(e => e.Usualt).HasColumnName("usualt");
            entity.Property(e => e.Usuapr).HasColumnName("usuapr");
            entity.Property(e => e.Varser)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("varser");
            entity.Property(e => e.Vicstd)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vicstd");
            entity.Property(e => e.VlrBcf).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBcl).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBco).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBct).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBic).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBip).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBir).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBor).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBpf).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBpt).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBru).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBsc).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBsi).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrBsp).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrCff).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrCom).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrCrt).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrCsl).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrDar).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrDs1).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrDs2).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrDs3).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrDs4).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrDsc).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrDzf).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrEmb).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrEnc).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrFin).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrFrd).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrFre).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrIcm).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrIcs).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrIpi).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrIrf).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrLiq).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrLou).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrLpr).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrOfe).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrOud).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrOur).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrOut).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrPif).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrPit).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrRis).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrSeg).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrStc).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrStp).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.Vlrds5)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrds5");
            entity.Property(e => e.Vlrfcp)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrfcp");
            entity.Property(e => e.Vlricd)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlricd");
            entity.Property(e => e.Vlridf)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlridf");
            entity.Property(e => e.Vlrtot)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrtot");
            entity.Property(e => e.Vstfcp)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vstfcp");
        }
    }
}
