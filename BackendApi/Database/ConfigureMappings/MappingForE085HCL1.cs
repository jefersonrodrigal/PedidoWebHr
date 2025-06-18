using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE085HCL1 : IEntityTypeConfiguration<E085HCL1>
    {
        public void Configure(EntityTypeBuilder<E085HCL1> entity)
        {
            entity.HasKey(e => new { e.Codcli, e.Codemp, e.Codfil })
                .HasName("cp_e085hcl")
                .IsClustered(false);

            entity.ToTable("e085hcl", "sapiens", tb =>
            {
                tb.HasTrigger("t085hcld");
                tb.HasTrigger("t085hcli");
                tb.HasTrigger("t085hclu");
            });

            entity.Property(e => e.Codcli).HasColumnName("codcli");
            entity.Property(e => e.Codemp).HasColumnName("codemp");
            entity.Property(e => e.Codfil).HasColumnName("codfil");
            entity.Property(e => e.Acepar)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("acepar");
            entity.Property(e => e.Acrdia)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("acrdia");
            entity.Property(e => e.Antdsc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("antdsc");
            entity.Property(e => e.Apmden)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("apmden");
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
            entity.Property(e => e.Catcli).HasColumnName("catcli");
            entity.Property(e => e.Ccbcli)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("ccbcli");
            entity.Property(e => e.Ciffob)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ciffob");
            entity.Property(e => e.Codage)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("codage");
            entity.Property(e => e.Codban)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codban");
            entity.Property(e => e.Codcca)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codcca");
            entity.Property(e => e.Codcpg)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("codcpg");
            entity.Property(e => e.Codcrp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codcrp");
            entity.Property(e => e.Codcrt)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("codcrt");
            entity.Property(e => e.Codfcr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codfcr");
            entity.Property(e => e.Codfin).HasColumnName("codfin");
            entity.Property(e => e.Codfpg).HasColumnName("codfpg");
            entity.Property(e => e.Codfrj)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codfrj");
            entity.Property(e => e.Codin1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codin1");
            entity.Property(e => e.Codin2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codin2");
            entity.Property(e => e.Codmar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codmar");
            entity.Property(e => e.Codpdv).HasColumnName("codpdv");
            entity.Property(e => e.Codred).HasColumnName("codred");
            entity.Property(e => e.Codrep).HasColumnName("codrep");
            entity.Property(e => e.Codrve)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codrve");
            entity.Property(e => e.Codstr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstr");
            entity.Property(e => e.Codtab)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codtab");
            entity.Property(e => e.Codtic)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtic");
            entity.Property(e => e.Codtpr)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codtpr");
            entity.Property(e => e.Codtra).HasColumnName("codtra");
            entity.Property(e => e.Codtrd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtrd");
            entity.Property(e => e.Codven).HasColumnName("codven");
            entity.Property(e => e.Confin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("confin");
            entity.Property(e => e.Criedv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("criedv");
            entity.Property(e => e.Crirat).HasColumnName("crirat");
            entity.Property(e => e.Ctaaad).HasColumnName("ctaaad");
            entity.Property(e => e.Ctaaux).HasColumnName("ctaaux");
            entity.Property(e => e.Ctafcr).HasColumnName("ctafcr");
            entity.Property(e => e.Ctafdv).HasColumnName("ctafdv");
            entity.Property(e => e.Ctarcr).HasColumnName("ctarcr");
            entity.Property(e => e.Ctared).HasColumnName("ctared");
            entity.Property(e => e.Ctrpad).HasColumnName("ctrpad");
            entity.Property(e => e.Datalt)
                .HasColumnType("datetime")
                .HasColumnName("datalt");
            entity.Property(e => e.Datatr)
                .HasColumnType("datetime")
                .HasColumnName("datatr");
            entity.Property(e => e.Datger)
                .HasColumnType("datetime")
                .HasColumnName("datger");
            entity.Property(e => e.Datlim)
                .HasColumnType("datetime")
                .HasColumnName("datlim");
            entity.Property(e => e.Datmac)
                .HasColumnType("datetime")
                .HasColumnName("datmac");
            entity.Property(e => e.Datmfa)
                .HasColumnType("datetime")
                .HasColumnName("datmfa");
            entity.Property(e => e.Datpal)
                .HasColumnType("datetime")
                .HasColumnName("datpal");
            entity.Property(e => e.Datpmr)
                .HasColumnType("datetime")
                .HasColumnName("datpmr");
            entity.Property(e => e.Datufa)
                .HasColumnType("datetime")
                .HasColumnName("datufa");
            entity.Property(e => e.Datupc)
                .HasColumnType("datetime")
                .HasColumnName("datupc");
            entity.Property(e => e.Datupe)
                .HasColumnType("datetime")
                .HasColumnName("datupe");
            entity.Property(e => e.Datupg)
                .HasColumnType("datetime")
                .HasColumnName("datupg");
            entity.Property(e => e.Diaesp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("diaesp");
            entity.Property(e => e.Diame1).HasColumnName("diame1");
            entity.Property(e => e.Diame2).HasColumnName("diame2");
            entity.Property(e => e.Diame3).HasColumnName("diame3");
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
            entity.Property(e => e.Ecpcnp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ecpcnp");
            entity.Property(e => e.Epcped)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("epcped");
            entity.Property(e => e.Exiage)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("exiage");
            entity.Property(e => e.Exilcp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("exilcp");
            entity.Property(e => e.Fvecpg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fvecpg");
            entity.Property(e => e.Fvefpg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fvefpg");
            entity.Property(e => e.Fvetns)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fvetns");
            entity.Property(e => e.Gertcc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gertcc");
            entity.Property(e => e.Horalt).HasColumnName("horalt");
            entity.Property(e => e.Horger).HasColumnName("horger");
            entity.Property(e => e.Horpal).HasColumnName("horpal");
            entity.Property(e => e.Indagr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indagr");
            entity.Property(e => e.Indexp).HasColumnName("indexp");
            entity.Property(e => e.Indorf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indorf");
            entity.Property(e => e.Indpre)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indpre");
            entity.Property(e => e.Junped)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("junped");
            entity.Property(e => e.Limapr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("limapr");
            entity.Property(e => e.Maiatr).HasColumnName("maiatr");
            entity.Property(e => e.Medatr).HasColumnName("medatr");
            entity.Property(e => e.Motdes).HasColumnName("motdes");
            entity.Property(e => e.Peraqa)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("peraqa");
            entity.Property(e => e.Perccr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("perccr");
            entity.Property(e => e.Percom)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("percom");
            entity.Property(e => e.Perdif)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perdif");
            entity.Property(e => e.Perds1)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds1");
            entity.Property(e => e.Perds2)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds2");
            entity.Property(e => e.Perds3)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds3");
            entity.Property(e => e.Perds4)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds4");
            entity.Property(e => e.Perds5)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perds5");
            entity.Property(e => e.Perdsc)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perdsc");
            entity.Property(e => e.Peremb)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("peremb");
            entity.Property(e => e.Perenc)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perenc");
            entity.Property(e => e.Perfre)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perfre");
            entity.Property(e => e.Periss)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("periss");
            entity.Property(e => e.Perof1)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perof1");
            entity.Property(e => e.Perof2)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perof2");
            entity.Property(e => e.Perout)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perout");
            entity.Property(e => e.Perseg)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("perseg");
            entity.Property(e => e.Porna1)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("porna1");
            entity.Property(e => e.Porna2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("porna2");
            entity.Property(e => e.Porsi1)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("porsi1");
            entity.Property(e => e.Porsi2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("porsi2");
            entity.Property(e => e.Prddsc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("prddsc");
            entity.Property(e => e.Przmrt).HasColumnName("przmrt");
            entity.Property(e => e.Qdiprt).HasColumnName("qdiprt");
            entity.Property(e => e.Qtdchs).HasColumnName("qtdchs");
            entity.Property(e => e.Qtddcv).HasColumnName("qtddcv");
            entity.Property(e => e.Qtdmfp).HasColumnName("qtdmfp");
            entity.Property(e => e.Qtdpgt).HasColumnName("qtdpgt");
            entity.Property(e => e.Qtdprt).HasColumnName("qtdprt");
            entity.Property(e => e.Qtdrpm).HasColumnName("qtdrpm");
            entity.Property(e => e.Qtdtpc).HasColumnName("qtdtpc");
            entity.Property(e => e.Recdtj).HasColumnName("recdtj");
            entity.Property(e => e.Recdtm).HasColumnName("recdtm");
            entity.Property(e => e.Recjmm)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("recjmm");
            entity.Property(e => e.Recmul)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("recmul");
            entity.Property(e => e.Rectjr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("rectjr");
            entity.Property(e => e.Salcre)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("salcre");
            entity.Property(e => e.Saldup)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("saldup");
            entity.Property(e => e.Salout)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("salout");
            entity.Property(e => e.Seqcob).HasColumnName("seqcob");
            entity.Property(e => e.Seqent).HasColumnName("seqent");
            entity.Property(e => e.Toldsc).HasColumnName("toldsc");
            entity.Property(e => e.Ultnfv).HasColumnName("ultnfv");
            entity.Property(e => e.Ultsnf)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ultsnf");
            entity.Property(e => e.UsuCodcpg)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("usu_codcpg");
            entity.Property(e => e.UsuCodrep).HasColumnName("usu_codrep");
            entity.Property(e => e.UsuCtaadt).HasColumnName("usu_ctaadt");
            entity.Property(e => e.UsuCtaaux).HasColumnName("usu_ctaaux");
            entity.Property(e => e.UsuCtacli).HasColumnName("usu_ctacli");
            entity.Property(e => e.UsuPersup)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("usu_persup");
            entity.Property(e => e.Usuage).HasColumnName("usuage");
            entity.Property(e => e.Usualt).HasColumnName("usualt");
            entity.Property(e => e.Usuger).HasColumnName("usuger");
            entity.Property(e => e.Vlracr)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlracr");
            entity.Property(e => e.Vlratr)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlratr");
            entity.Property(e => e.Vlrlim)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrlim");
            entity.Property(e => e.Vlrmac)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrmac");
            entity.Property(e => e.Vlrmfa)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrmfa");
            entity.Property(e => e.Vlrpfa)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrpfa");
            entity.Property(e => e.Vlrprt)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrprt");
            entity.Property(e => e.Vlrufa)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrufa");
            entity.Property(e => e.Vlrupc)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrupc");
            entity.Property(e => e.Vlrupe)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrupe");
            entity.Property(e => e.Vlrupg)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrupg");
            entity.Property(e => e.Volsep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("volsep");
        }
    }
}
