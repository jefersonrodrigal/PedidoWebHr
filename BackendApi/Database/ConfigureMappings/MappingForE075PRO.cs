using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE075PRO : IEntityTypeConfiguration<E075PRO>
    {
        public void Configure(EntityTypeBuilder<E075PRO> entity)
        {
            entity.HasKey(e => new { e.Codemp, e.Codpro })
                .HasName("cp_e075pro")
                .IsClustered(false);

            entity.ToTable("e075pro", tb =>
            {
                tb.HasTrigger("t075prod");
                tb.HasTrigger("t075prou");
            });

            entity.HasIndex(e => new { e.Codemp, e.Tippro }, "e075proindice1");

            entity.HasIndex(e => new { e.Codemp, e.Codfam }, "e075proindice2");

            entity.HasIndex(e => e.Unimed, "e075proindice3");

            entity.HasIndex(e => new { e.Codemp, e.Codori }, "e075proindice4");

            entity.Property(e => e.Codemp).HasColumnName("codemp");
            entity.Property(e => e.Codpro)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("codpro");
            entity.Property(e => e.Admtmp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("admtmp");
            entity.Property(e => e.Agrccr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("agrccr");
            entity.Property(e => e.Agrqcr).HasColumnName("agrqcr");
            entity.Property(e => e.Altpro)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("altpro");
            entity.Property(e => e.Apragr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("apragr");
            entity.Property(e => e.Art119)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("art119");
            entity.Property(e => e.Bascre).HasColumnName("bascre");
            entity.Property(e => e.Basrec)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("basrec");
            entity.Property(e => e.Bxaorp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("bxaorp");
            entity.Property(e => e.Caldzf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("caldzf");
            entity.Property(e => e.Calfaf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("calfaf");
            entity.Property(e => e.Catpro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("catpro");
            entity.Property(e => e.Ciatst)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ciatst");
            entity.Property(e => e.Claalc).HasColumnName("claalc");
            entity.Property(e => e.Clacat)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("clacat");
            entity.Property(e => e.Clacni).HasColumnName("clacni");
            entity.Property(e => e.Clapro).HasColumnName("clapro");
            entity.Property(e => e.Codaga)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codaga");
            entity.Property(e => e.Codagc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codagc");
            entity.Property(e => e.Codage)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codage");
            entity.Property(e => e.Codagf)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codagf");
            entity.Property(e => e.Codagg)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codagg");
            entity.Property(e => e.Codagm)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codagm");
            entity.Property(e => e.Codagp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codagp");
            entity.Property(e => e.Codagu)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codagu");
            entity.Property(e => e.Codanp).HasColumnName("codanp");
            entity.Property(e => e.Codbic)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codbic");
            entity.Property(e => e.Codces)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("codces");
            entity.Property(e => e.Codclc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codclc");
            entity.Property(e => e.Codclf)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codclf");
            entity.Property(e => e.Codcor).HasColumnName("codcor");
            entity.Property(e => e.Coddfs).HasColumnName("coddfs");
            entity.Property(e => e.Codend)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codend");
            entity.Property(e => e.Codenq).HasColumnName("codenq");
            entity.Property(e => e.Codfam)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("codfam");
            entity.Property(e => e.Codfie)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("codfie");
            entity.Property(e => e.Codfif)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codfif");
            entity.Property(e => e.Codfim)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codfim");
            entity.Property(e => e.Codicl).HasColumnName("codicl");
            entity.Property(e => e.Codmar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codmar");
            entity.Property(e => e.Codmdp)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("codmdp");
            entity.Property(e => e.Codmod)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("codmod");
            entity.Property(e => e.Codntg).HasColumnName("codntg");
            entity.Property(e => e.Codori)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codori");
            entity.Property(e => e.Codpdv).HasColumnName("codpdv");
            entity.Property(e => e.Codpin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codpin");
            entity.Property(e => e.Codpr2)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("codpr2");
            entity.Property(e => e.Codpr3)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("codpr3");
            entity.Property(e => e.Codpr4)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("codpr4");
            entity.Property(e => e.Codprc)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codprc");
            entity.Property(e => e.Codpri)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codpri");
            entity.Property(e => e.Codref)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("codref");
            entity.Property(e => e.Codrot)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("codrot");
            entity.Property(e => e.Codroy).HasColumnName("codroy");
            entity.Property(e => e.Codstc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstc");
            entity.Property(e => e.Codstp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codstp");
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
            entity.Property(e => e.Codtst)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codtst");
            entity.Property(e => e.Colisi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("colisi");
            entity.Property(e => e.Compro)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("compro");
            entity.Property(e => e.Conagu).HasColumnName("conagu");
            entity.Property(e => e.Conene).HasColumnName("conene");
            entity.Property(e => e.Conmon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("conmon");
            entity.Property(e => e.Cplpro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cplpro");
            entity.Property(e => e.Crirat).HasColumnName("crirat");
            entity.Property(e => e.Cstcoc)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cstcoc");
            entity.Property(e => e.Cstcof)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cstcof");
            entity.Property(e => e.Cstipc)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cstipc");
            entity.Property(e => e.Cstipi)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cstipi");
            entity.Property(e => e.Cstpic)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cstpic");
            entity.Property(e => e.Cstpis)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cstpis");
            entity.Property(e => e.Ctadcd).HasColumnName("ctadcd");
            entity.Property(e => e.Ctadci).HasColumnName("ctadci");
            entity.Property(e => e.Ctafcr).HasColumnName("ctafcr");
            entity.Property(e => e.Ctafdv).HasColumnName("ctafdv");
            entity.Property(e => e.Ctarcr).HasColumnName("ctarcr");
            entity.Property(e => e.Ctared).HasColumnName("ctared");
            entity.Property(e => e.Ctrlot)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ctrlot");
            entity.Property(e => e.Ctrsep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ctrsep");
            entity.Property(e => e.Ctrvis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ctrvis");
            entity.Property(e => e.Ctrvld)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ctrvld");
            entity.Property(e => e.Datalt)
                .HasColumnType("datetime")
                .HasColumnName("datalt");
            entity.Property(e => e.Datger)
                .HasColumnType("datetime")
                .HasColumnName("datger");
            entity.Property(e => e.Datpal)
                .HasColumnType("datetime")
                .HasColumnName("datpal");
            entity.Property(e => e.Datvis)
                .HasColumnType("datetime")
                .HasColumnName("datvis");
            entity.Property(e => e.Deppad)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("deppad");
            entity.Property(e => e.Derpr2)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("derpr2");
            entity.Property(e => e.Derpr3)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("derpr3");
            entity.Property(e => e.Derpr4)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("derpr4");
            entity.Property(e => e.Desanp)
                .HasMaxLength(95)
                .IsUnicode(false)
                .HasColumnName("desanp");
            entity.Property(e => e.Desfis)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desfis");
            entity.Property(e => e.Desnfv)
                .HasMaxLength(99)
                .IsUnicode(false)
                .HasColumnName("desnfv");
            entity.Property(e => e.Despro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("despro");
            entity.Property(e => e.Discol)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("discol");
            entity.Property(e => e.Emigtr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("emigtr");
            entity.Property(e => e.Emirec)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("emirec");
            entity.Property(e => e.Exgccl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("exgccl");
            entity.Property(e => e.Exinfe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("exinfe");
            entity.Property(e => e.Expwms).HasColumnName("expwms");
            entity.Property(e => e.Fatcet)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("fatcet");
            entity.Property(e => e.Ficcat).HasColumnName("ficcat");
            entity.Property(e => e.Filprd).HasColumnName("filprd");
            entity.Property(e => e.Fincdp).HasColumnName("fincdp");
            entity.Property(e => e.Fincrp).HasColumnName("fincrp");
            entity.Property(e => e.Frteqp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("frteqp");
            entity.Property(e => e.Gerorp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gerorp");
            entity.Property(e => e.Grpfrt)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("grpfrt");
            entity.Property(e => e.Gruist)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gruist");
            entity.Property(e => e.Gruten).HasColumnName("gruten");
            entity.Property(e => e.Horalt).HasColumnName("horalt");
            entity.Property(e => e.Horger).HasColumnName("horger");
            entity.Property(e => e.Horpal).HasColumnName("horpal");
            entity.Property(e => e.Horvis).HasColumnName("horvis");
            entity.Property(e => e.Idemia).HasColumnName("idemia");
            entity.Property(e => e.Idepar)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("idepar");
            entity.Property(e => e.Idepro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idepro");
            entity.Property(e => e.Ideren).HasColumnName("ideren");
            entity.Property(e => e.Impscf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("impscf");
            entity.Property(e => e.Indaco)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indaco");
            entity.Property(e => e.Indafe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indafe");
            entity.Property(e => e.Indcpr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indcpr");
            entity.Property(e => e.Indenc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indenc");
            entity.Property(e => e.Indexp).HasColumnName("indexp");
            entity.Property(e => e.Indfpr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indfpr");
            entity.Property(e => e.Indfrt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indfrt");
            entity.Property(e => e.Indicp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indicp");
            entity.Property(e => e.Indkit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indkit");
            entity.Property(e => e.Indmis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indmis");
            entity.Property(e => e.Indoct)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indoct");
            entity.Property(e => e.Indppc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indppc");
            entity.Property(e => e.Indreq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indreq");
            entity.Property(e => e.Indspr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indspr");
            entity.Property(e => e.Indven)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indven");
            entity.Property(e => e.Indvma)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indvma");
            entity.Property(e => e.Indvol)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indvol");
            entity.Property(e => e.Intzfm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("intzfm");
            entity.Property(e => e.Itefis)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("itefis");
            entity.Property(e => e.Larpro)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("larpro");
            entity.Property(e => e.Limicp).HasColumnName("limicp");
            entity.Property(e => e.Lotbas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("lotbas");
            entity.Property(e => e.Matdir)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("matdir");
            entity.Property(e => e.Modfab)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("modfab");
            entity.Property(e => e.Motdes).HasColumnName("motdes");
            entity.Property(e => e.Natcof).HasColumnName("natcof");
            entity.Property(e => e.Natpis).HasColumnName("natpis");
            entity.Property(e => e.Natren)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("natren");
            entity.Property(e => e.Notfor)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("notfor");
            entity.Property(e => e.Numanx).HasColumnName("numanx");
            entity.Property(e => e.Numori).HasColumnName("numori");
            entity.Property(e => e.Origti).HasColumnName("origti");
            entity.Property(e => e.Orimer)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("orimer");
            entity.Property(e => e.Parcom)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("parcom");
            entity.Property(e => e.Pdifcp)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("pdifcp");
            entity.Property(e => e.Percim)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("percim");
            entity.Property(e => e.Percof)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("percof");
            entity.Property(e => e.Percsl)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("percsl");
            entity.Property(e => e.Perdif)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perdif");
            entity.Property(e => e.Perdii)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perdii");
            entity.Property(e => e.Perfun)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perfun");
            entity.Property(e => e.Pergas)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("pergas");
            entity.Property(e => e.Pergil)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("pergil");
            entity.Property(e => e.Perglp)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perglp");
            entity.Property(e => e.Pergni)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("pergni");
            entity.Property(e => e.Perifp)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perifp");
            entity.Property(e => e.Peripi)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("peripi");
            entity.Property(e => e.Perirf)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perirf");
            entity.Property(e => e.Permis)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("permis");
            entity.Property(e => e.Perour)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perour");
            entity.Property(e => e.Perpim)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("perpim");
            entity.Property(e => e.Perpis)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perpis");
            entity.Property(e => e.Persen)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("persen");
            entity.Property(e => e.Pesbru)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("pesbru");
            entity.Property(e => e.Pesliq)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("pesliq");
            entity.Property(e => e.Procsg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("procsg");
            entity.Property(e => e.Prodci)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("prodci");
            entity.Property(e => e.Proent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("proent");
            entity.Property(e => e.Proepe).HasColumnName("proepe");
            entity.Property(e => e.Profol)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("profol");
            entity.Property(e => e.Proimp).HasColumnName("proimp");
            entity.Property(e => e.Promis)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("promis");
            entity.Property(e => e.Promon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("promon");
            entity.Property(e => e.Prostq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("prostq");
            entity.Property(e => e.Proves)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("proves");
            entity.Property(e => e.Przrec).HasColumnName("przrec");
            entity.Property(e => e.Qtdafe).HasColumnName("qtdafe");
            entity.Property(e => e.Qtdgop)
                .HasColumnType("numeric(12, 5)")
                .HasColumnName("qtdgop");
            entity.Property(e => e.Qtdmax)
                .HasColumnType("numeric(12, 5)")
                .HasColumnName("qtdmax");
            entity.Property(e => e.Qtdmin)
                .HasColumnType("numeric(12, 5)")
                .HasColumnName("qtdmin");
            entity.Property(e => e.Qtdmlt)
                .HasColumnType("numeric(12, 5)")
                .HasColumnName("qtdmlt");
            entity.Property(e => e.Qtdmve)
                .HasColumnType("numeric(12, 5)")
                .HasColumnName("qtdmve");
            entity.Property(e => e.Qtdvol).HasColumnName("qtdvol");
            entity.Property(e => e.Reccof)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("reccof");
            entity.Property(e => e.Recicm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("recicm");
            entity.Property(e => e.Recipi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("recipi");
            entity.Property(e => e.Recpis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("recpis");
            entity.Property(e => e.Regtri)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("regtri");
            entity.Property(e => e.Rotanx).HasColumnName("rotanx");
            entity.Property(e => e.Rotpro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("rotpro");
            entity.Property(e => e.Seqhas).HasColumnName("seqhas");
            entity.Property(e => e.Sitpro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("sitpro");
            entity.Property(e => e.Somicl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("somicl");
            entity.Property(e => e.Somico)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("somico");
            entity.Property(e => e.Somiil)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("somiil");
            entity.Property(e => e.Somiim)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("somiim");
            entity.Property(e => e.Somipl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("somipl");
            entity.Property(e => e.Somips)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("somips");
            entity.Property(e => e.Temicm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("temicm");
            entity.Property(e => e.Tipcbt).HasColumnName("tipcbt");
            entity.Property(e => e.Tipcic).HasColumnName("tipcic");
            entity.Property(e => e.Tipfte)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipfte");
            entity.Property(e => e.Tipgti).HasColumnName("tipgti");
            entity.Property(e => e.Tipint).HasColumnName("tipint");
            entity.Property(e => e.Tiplig).HasColumnName("tiplig");
            entity.Property(e => e.Tipmfr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipmfr");
            entity.Property(e => e.Tippbk)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tippbk");
            entity.Property(e => e.Tippro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tippro");
            entity.Property(e => e.Tipres).HasColumnName("tipres");
            entity.Property(e => e.Tiputi).HasColumnName("tiputi");
            entity.Property(e => e.Tmpdse).HasColumnName("tmpdse");
            entity.Property(e => e.Tolpes)
                .HasColumnType("numeric(5, 3)")
                .HasColumnName("tolpes");
            entity.Property(e => e.Tolqmx)
                .HasColumnType("numeric(5, 3)")
                .HasColumnName("tolqmx");
            entity.Property(e => e.Tprcof)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tprcof");
            entity.Property(e => e.Tprcoi)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tprcoi");
            entity.Property(e => e.Tprimo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tprimo");
            entity.Property(e => e.Tpripi)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tpripi");
            entity.Property(e => e.Tprpii)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tprpii");
            entity.Property(e => e.Tprpis)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tprpis");
            entity.Property(e => e.Tricof)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tricof");
            entity.Property(e => e.Tripis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tripis");
            entity.Property(e => e.Unibcp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unibcp");
            entity.Property(e => e.Unifrt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("unifrt");
            entity.Property(e => e.Unime2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unime2");
            entity.Property(e => e.Unime3)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unime3");
            entity.Property(e => e.Unimed)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unimed");
            entity.Property(e => e.Unimet)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unimet");
            entity.Property(e => e.Unipad)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unipad");
            entity.Property(e => e.Uniwms)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("uniwms");
            entity.Property(e => e.Usocus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usocus");
            entity.Property(e => e.UsuAltapa)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_altapa");
            entity.Property(e => e.UsuAltpr2)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_altpr2");
            entity.Property(e => e.UsuAprcot)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_aprcot");
            entity.Property(e => e.UsuArecil)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_arecil");
            entity.Property(e => e.UsuBobfar)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_bobfar");
            entity.Property(e => e.UsuChapro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_chapro");
            entity.Property(e => e.UsuCmppr2)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_cmppr2");
            entity.Property(e => e.UsuCmppro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_cmppro");
            entity.Property(e => e.UsuCnsmen)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("usu_cnsmen");
            entity.Property(e => e.UsuCodcli).HasColumnName("usu_codcli");
            entity.Property(e => e.UsuCoddu2).HasColumnName("usu_coddu2");
            entity.Property(e => e.UsuCoddun).HasColumnName("usu_coddun");
            entity.Property(e => e.UsuCodea2).HasColumnName("usu_codea2");
            entity.Property(e => e.UsuCodean).HasColumnName("usu_codean");
            entity.Property(e => e.UsuCodibo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("usu_codibo");
            entity.Property(e => e.UsuColpro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_colpro");
            entity.Property(e => e.UsuConbar)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_conbar");
            entity.Property(e => e.UsuCorno1)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("usu_corno1");
            entity.Property(e => e.UsuCorno2)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("usu_corno2");
            entity.Property(e => e.UsuCorno3)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("usu_corno3");
            entity.Property(e => e.UsuCortbt).HasColumnName("usu_cortbt");
            entity.Property(e => e.UsuCtbcmv).HasColumnName("usu_ctbcmv");
            entity.Property(e => e.UsuCtbcus).HasColumnName("usu_ctbcus");
            entity.Property(e => e.UsuCtbdes).HasColumnName("usu_ctbdes");
            entity.Property(e => e.UsuCtbest).HasColumnName("usu_ctbest");
            entity.Property(e => e.UsuCtbpat).HasColumnName("usu_ctbpat");
            entity.Property(e => e.UsuCtbrec).HasColumnName("usu_ctbrec");
            entity.Property(e => e.UsuCubpro)
                .HasColumnType("numeric(9, 5)")
                .HasColumnName("usu_cubpro");
            entity.Property(e => e.UsuDenpro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_denpro");
            entity.Property(e => e.UsuDescbo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("usu_descbo");
            entity.Property(e => e.UsuDesemb)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("usu_desemb");
            entity.Property(e => e.UsuDeshpk)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("usu_deshpk");
            entity.Property(e => e.UsuDesnfv)
                .HasMaxLength(99)
                .IsUnicode(false)
                .HasColumnName("usu_desnfv");
            entity.Property(e => e.UsuDestar)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("usu_destar");
            entity.Property(e => e.UsuDesvaz)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_desvaz");
            entity.Property(e => e.UsuEsppr1)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_esppr1");
            entity.Property(e => e.UsuEsppro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_esppro");
            entity.Property(e => e.UsuEtimar)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_etimar");
            entity.Property(e => e.UsuFarcor)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("usu_farcor");
            entity.Property(e => e.UsuFatre2)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_fatre2");
            entity.Property(e => e.UsuFatrea)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_fatrea");
            entity.Property(e => e.UsuFindes).HasColumnName("usu_findes");
            entity.Property(e => e.UsuFinrec).HasColumnName("usu_finrec");
            entity.Property(e => e.UsuFunpro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_funpro");
            entity.Property(e => e.UsuImband).HasColumnName("usu_imband");
            entity.Property(e => e.UsuLarpr2)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_larpr2");
            entity.Property(e => e.UsuLarpro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_larpro");
            entity.Property(e => e.UsuLocpro)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("usu_locpro");
            entity.Property(e => e.UsuMovblo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_movblo");
            entity.Property(e => e.UsuNumbpm).HasColumnName("usu_numbpm");
            entity.Property(e => e.UsuNumcpc)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_numcpc");
            entity.Property(e => e.UsuNumenc)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_numenc");
            entity.Property(e => e.UsuNumpim)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_numpim");
            entity.Property(e => e.UsuNumpis).HasColumnName("usu_numpis");
            entity.Property(e => e.UsuPescai)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("usu_pescai");
            entity.Property(e => e.UsuPesger)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("usu_pesger");
            entity.Property(e => e.UsuPesmax)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("usu_pesmax");
            entity.Property(e => e.UsuPesrea)
                .HasColumnType("numeric(15, 12)")
                .HasColumnName("usu_pesrea");
            entity.Property(e => e.UsuPreuni)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("usu_preuni");
            entity.Property(e => e.UsuProesp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_proesp");
            entity.Property(e => e.UsuPromas)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("usu_promas");
            entity.Property(e => e.UsuProrcp)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("usu_prorcp");
            entity.Property(e => e.UsuProref)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_proref");
            entity.Property(e => e.UsuProrpc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("usu_prorpc");
            entity.Property(e => e.UsuQtdbal)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("usu_qtdbal");
            entity.Property(e => e.UsuQtdsac)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("usu_qtdsac");
            entity.Property(e => e.UsuSacblo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_sacblo");
            entity.Property(e => e.UsuSacbob)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_sacbob");
            entity.Property(e => e.UsuSacfa2)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_sacfa2");
            entity.Property(e => e.UsuSacfar)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_sacfar");
            entity.Property(e => e.UsuSanpro)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("usu_sanpro");
            entity.Property(e => e.UsuSetnor).HasColumnName("usu_setnor");
            entity.Property(e => e.UsuSetsim).HasColumnName("usu_setsim");
            entity.Property(e => e.UsuTipcai)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_tipcai");
            entity.Property(e => e.UsuTipden).HasColumnName("usu_tipden");
            entity.Property(e => e.UsuTipemb).HasColumnName("usu_tipemb");
            entity.Property(e => e.UsuTipfun).HasColumnName("usu_tipfun");
            entity.Property(e => e.UsuTiplog).HasColumnName("usu_tiplog");
            entity.Property(e => e.UsuTipplt)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_tipplt");
            entity.Property(e => e.UsuTippro).HasColumnName("usu_tippro");
            entity.Property(e => e.UsuUniven)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("usu_univen");
            entity.Property(e => e.Usualt).HasColumnName("usualt");
            entity.Property(e => e.Usuger).HasColumnName("usuger");
            entity.Property(e => e.Utidum)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("utidum");
            entity.Property(e => e.Varpro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("varpro");
            entity.Property(e => e.Vlrpar)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrpar");
            entity.Property(e => e.Vltpro).HasColumnName("vltpro");
            entity.Property(e => e.Volpro)
                .HasColumnType("numeric(11, 5)")
                .HasColumnName("volpro");
            entity.Property(e => e.Zessba)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("zessba");
        }
    }
}
