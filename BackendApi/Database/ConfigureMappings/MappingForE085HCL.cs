using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE085HCL : IEntityTypeConfiguration<E085HCL>
    {
        public void Configure(EntityTypeBuilder<E085HCL> entity)
        {
            entity.HasKey(e => new { e.CodCli, e.CodEmp, e.CodFil })
                .HasName("cp_e085hcl")
                .IsClustered(false);

            entity.ToTable("E085HCL", tb =>
            {
                tb.HasTrigger("U_E085HCL_01");
                tb.HasTrigger("t085hcld");
                tb.HasTrigger("t085hcli");
                tb.HasTrigger("t085hclu");
            });

            entity.HasIndex(e => new { e.CodEmp, e.CodFil }, "e085hclindice1");

            entity.Property(e => e.AcePar)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AcrDia).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.AntDsc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ApmDen)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Avaati)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("avaati");
            entity.Property(e => e.Avamot).HasColumnName("avamot");
            entity.Property(e => e.Avaobs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("avaobs");
            entity.Property(e => e.Avavlr)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("avavlr");
            entity.Property(e => e.Avavls)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("avavls");
            entity.Property(e => e.Avavlu)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("avavlu");
            entity.Property(e => e.Avdalt)
                .HasColumnType("datetime")
                .HasColumnName("avdalt");
            entity.Property(e => e.Avdger)
                .HasColumnType("datetime")
                .HasColumnName("avdger");
            entity.Property(e => e.Avhalt).HasColumnName("avhalt");
            entity.Property(e => e.Avhger).HasColumnName("avhger");
            entity.Property(e => e.Avualt).HasColumnName("avualt");
            entity.Property(e => e.Avuger).HasColumnName("avuger");
            entity.Property(e => e.CcbCli)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.CifFob)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CodAge)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.CodBan)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodCpg)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CodCrp)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodCrt)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CodFcr)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodFrj)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodIn1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodIn2)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodMar)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodRve)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTab)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodTpr)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Codcca)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codcca");
            entity.Property(e => e.Codfin).HasColumnName("codfin");
            entity.Property(e => e.Codstr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstr");
            entity.Property(e => e.Codtic)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtic");
            entity.Property(e => e.Codtrd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtrd");
            entity.Property(e => e.Confin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("confin");
            entity.Property(e => e.CriEdv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Ctaaad).HasColumnName("ctaaad");
            entity.Property(e => e.Ctaaux).HasColumnName("ctaaux");
            entity.Property(e => e.DatAtr).HasColumnType("datetime");
            entity.Property(e => e.DatLim).HasColumnType("datetime");
            entity.Property(e => e.DatMac).HasColumnType("datetime");
            entity.Property(e => e.DatMfa).HasColumnType("datetime");
            entity.Property(e => e.DatPal).HasColumnType("datetime");
            entity.Property(e => e.DatPmr).HasColumnType("datetime");
            entity.Property(e => e.DatUfa).HasColumnType("datetime");
            entity.Property(e => e.DatUpc).HasColumnType("datetime");
            entity.Property(e => e.DatUpe).HasColumnType("datetime");
            entity.Property(e => e.DatUpg).HasColumnType("datetime");
            entity.Property(e => e.Datalt)
                .HasColumnType("datetime")
                .HasColumnName("datalt");
            entity.Property(e => e.Datger)
                .HasColumnType("datetime")
                .HasColumnName("datger");
            entity.Property(e => e.DiaEsp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Dscant)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("dscant");
            entity.Property(e => e.Dscpon)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("dscpon");
            entity.Property(e => e.Dscprd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("dscprd");
            entity.Property(e => e.EcpCnp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EpcPed)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExiAge)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExiLcp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FveCpg)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FveFpg)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FveTns)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GerTcc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Horalt).HasColumnName("horalt");
            entity.Property(e => e.Horger).HasColumnName("horger");
            entity.Property(e => e.IndAgr)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Indorf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indorf");
            entity.Property(e => e.Indpre)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indpre");
            entity.Property(e => e.JunPed)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LimApr)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Motdes).HasColumnName("motdes");
            entity.Property(e => e.Pdifcp)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("pdifcp");
            entity.Property(e => e.PerAqa).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerCom).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDs1).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDs2).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDs3).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDs4).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerDsc).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.PerEmb).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerEnc).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerFre).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerIss).HasColumnType("numeric(6, 4)");
            entity.Property(e => e.PerOf1).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerOf2).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerOut).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.PerSeg).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.Perccr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("perccr");
            entity.Property(e => e.Perdif)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perdif");
            entity.Property(e => e.Perds5)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds5");
            entity.Property(e => e.Perisr)
                .HasColumnType("numeric(6, 4)")
                .HasColumnName("perisr");
            entity.Property(e => e.PorNa1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.PorNa2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.PorSi1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.PorSi2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Prddsc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("prddsc");
            entity.Property(e => e.Qdiprt).HasColumnName("qdiprt");
            entity.Property(e => e.RecJmm).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.RecMul).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.RecTjr)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SalCre).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.SalDup).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.SalOut).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.Seqcob).HasColumnName("seqcob");
            entity.Property(e => e.Seqent).HasColumnName("seqent");
            entity.Property(e => e.Tiptcc).HasColumnName("tiptcc");
            entity.Property(e => e.UltSnf)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.UsuCodCpg)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("USU_CodCpg");
            entity.Property(e => e.UsuCodRep).HasColumnName("USU_CodRep");
            entity.Property(e => e.UsuCtaAdt).HasColumnName("USU_CtaAdt");
            entity.Property(e => e.UsuCtaAux).HasColumnName("USU_CtaAux");
            entity.Property(e => e.UsuCtaCli).HasColumnName("USU_CtaCli");
            entity.Property(e => e.UsuPerSup)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("USU_PerSup");
            entity.Property(e => e.Usualt).HasColumnName("usualt");
            entity.Property(e => e.Usuger).HasColumnName("usuger");
            entity.Property(e => e.VlrAcr).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrAtr).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrLim).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrMac).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrMfa).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrPfa).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrPrt).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrUfa).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrUpc).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrUpe).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrUpg).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.Volsep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("volsep");
            entity.Property(e => e.Zerdif)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("zerdif");
        }
    }
}
