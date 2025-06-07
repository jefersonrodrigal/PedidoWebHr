using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE085CLI1 : IEntityTypeConfiguration<E085CLI1>
    {
        public void Configure(EntityTypeBuilder<E085CLI1> entity)
        {
            entity.HasKey(e => e.Codcli)
                .HasName("cp_e085cli")
                .IsClustered(false);

            entity.ToTable("e085cli", "sapiens", tb =>
            {
                tb.HasTrigger("t085clid");
                tb.HasTrigger("t085clii");
                tb.HasTrigger("t085cliu");
            });

            entity.HasIndex(e => new { e.Cgccpf, e.Codcli }, "e085cliindice2").IsUnique();

            entity.Property(e => e.Codcli)
                .ValueGeneratedNever()
                .HasColumnName("codcli");
            entity.Property(e => e.Apecli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apecli");
            entity.Property(e => e.Baicli)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("baicli");
            entity.Property(e => e.Baicob)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("baicob");
            entity.Property(e => e.Baient)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("baient");
            entity.Property(e => e.Blocre)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("blocre");
            entity.Property(e => e.Calfun)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("calfun");
            entity.Property(e => e.Calsen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("calsen");
            entity.Property(e => e.Cepcli).HasColumnName("cepcli");
            entity.Property(e => e.Cepcob).HasColumnName("cepcob");
            entity.Property(e => e.Cepent).HasColumnName("cepent");
            entity.Property(e => e.Cepfre).HasColumnName("cepfre");
            entity.Property(e => e.Cepini).HasColumnName("cepini");
            entity.Property(e => e.Cgccob).HasColumnName("cgccob");
            entity.Property(e => e.Cgccpf).HasColumnName("cgccpf");
            entity.Property(e => e.Cgcent).HasColumnName("cgcent");
            entity.Property(e => e.Cidcli)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cidcli");
            entity.Property(e => e.Cidcob)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cidcob");
            entity.Property(e => e.Cident)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cident");
            entity.Property(e => e.Clicon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("clicon");
            entity.Property(e => e.Clifor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("clifor");
            entity.Property(e => e.Cliprx)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("cliprx");
            entity.Property(e => e.Clirep).HasColumnName("clirep");
            entity.Property(e => e.Clitra).HasColumnName("clitra");
            entity.Property(e => e.Codama)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codama");
            entity.Property(e => e.Codcnv).HasColumnName("codcnv");
            entity.Property(e => e.Codfor).HasColumnName("codfor");
            entity.Property(e => e.Codgal)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codgal");
            entity.Property(e => e.Codgre).HasColumnName("codgre");
            entity.Property(e => e.Codmot).HasColumnName("codmot");
            entity.Property(e => e.Codms2).HasColumnName("codms2");
            entity.Property(e => e.Codms3).HasColumnName("codms3");
            entity.Property(e => e.Codms4).HasColumnName("codms4");
            entity.Property(e => e.Codmsg).HasColumnName("codmsg");
            entity.Property(e => e.Codpai)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codpai");
            entity.Property(e => e.Codpdv).HasColumnName("codpdv");
            entity.Property(e => e.Codram)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codram");
            entity.Property(e => e.Codroe)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codroe");
            entity.Property(e => e.Codrtr).HasColumnName("codrtr");
            entity.Property(e => e.Codsab)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codsab");
            entity.Property(e => e.Codsro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("codsro");
            entity.Property(e => e.Codsuf)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codsuf");
            entity.Property(e => e.Confin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("confin");
            entity.Property(e => e.Cplcob)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cplcob");
            entity.Property(e => e.Cplend)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cplend");
            entity.Property(e => e.Cplent)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cplent");
            entity.Property(e => e.Cxapst).HasColumnName("cxapst");
            entity.Property(e => e.Datatu)
                .HasColumnType("datetime")
                .HasColumnName("datatu");
            entity.Property(e => e.Datcad)
                .HasColumnType("datetime")
                .HasColumnName("datcad");
            entity.Property(e => e.Datfim)
                .HasColumnType("datetime")
                .HasColumnName("datfim");
            entity.Property(e => e.Daticv)
                .HasColumnType("datetime")
                .HasColumnName("daticv");
            entity.Property(e => e.Datmot)
                .HasColumnType("datetime")
                .HasColumnName("datmot");
            entity.Property(e => e.Datpal)
                .HasColumnType("datetime")
                .HasColumnName("datpal");
            entity.Property(e => e.Datpdv)
                .HasColumnType("datetime")
                .HasColumnName("datpdv");
            entity.Property(e => e.Datsuf)
                .HasColumnType("datetime")
                .HasColumnName("datsuf");
            entity.Property(e => e.Datvct)
                .HasColumnType("datetime")
                .HasColumnName("datvct");
            entity.Property(e => e.Eencli)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("eencli");
            entity.Property(e => e.Eencob)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("eencob");
            entity.Property(e => e.Eenent)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("eenent");
            entity.Property(e => e.Emanfe)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emanfe");
            entity.Property(e => e.Endcli)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endcli");
            entity.Property(e => e.Endcob)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endcob");
            entity.Property(e => e.Endent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endent");
            entity.Property(e => e.Entcor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("entcor");
            entity.Property(e => e.Estcob)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("estcob");
            entity.Property(e => e.Estent)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("estent");
            entity.Property(e => e.Faxcli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("faxcli");
            entity.Property(e => e.Foncl2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("foncl2");
            entity.Property(e => e.Foncl3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("foncl3");
            entity.Property(e => e.Foncl4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("foncl4");
            entity.Property(e => e.Foncl5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("foncl5");
            entity.Property(e => e.Foncli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("foncli");
            entity.Property(e => e.Horatu).HasColumnName("horatu");
            entity.Property(e => e.Horcad).HasColumnName("horcad");
            entity.Property(e => e.Horfim).HasColumnName("horfim");
            entity.Property(e => e.Hormot).HasColumnName("hormot");
            entity.Property(e => e.Horpal).HasColumnName("horpal");
            entity.Property(e => e.Horpdv).HasColumnName("horpdv");
            entity.Property(e => e.Idecli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idecli");
            entity.Property(e => e.Indcoo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("indcoo");
            entity.Property(e => e.Indexp).HasColumnName("indexp");
            entity.Property(e => e.Inicob).HasColumnName("inicob");
            entity.Property(e => e.Inient).HasColumnName("inient");
            entity.Property(e => e.Insanp).HasColumnName("insanp");
            entity.Property(e => e.Insent)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("insent");
            entity.Property(e => e.Insest)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("insest");
            entity.Property(e => e.Insmun)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("insmun");
            entity.Property(e => e.Intnet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("intnet");
            entity.Property(e => e.Limret)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("limret");
            entity.Property(e => e.Marcli)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("marcli");
            entity.Property(e => e.Natcof).HasColumnName("natcof");
            entity.Property(e => e.Natcsl).HasColumnName("natcsl");
            entity.Property(e => e.Natirp).HasColumnName("natirp");
            entity.Property(e => e.Natpis).HasColumnName("natpis");
            entity.Property(e => e.Natret).HasColumnName("natret");
            entity.Property(e => e.Nencli)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nencli");
            entity.Property(e => e.Nencob)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nencob");
            entity.Property(e => e.Nenent)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nenent");
            entity.Property(e => e.Nomcli)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomcli");
            entity.Property(e => e.Numanx).HasColumnName("numanx");
            entity.Property(e => e.Numidf)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("numidf");
            entity.Property(e => e.Obsmot)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("obsmot");
            entity.Property(e => e.Perain)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("perain");
            entity.Property(e => e.Qtdatu).HasColumnName("qtdatu");
            entity.Property(e => e.Regest).HasColumnName("regest");
            entity.Property(e => e.Retcof)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retcof");
            entity.Property(e => e.Retcsl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retcsl");
            entity.Property(e => e.Retirf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retirf");
            entity.Property(e => e.Retour)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retour");
            entity.Property(e => e.Retpis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retpis");
            entity.Property(e => e.Retpro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("retpro");
            entity.Property(e => e.Rotanx).HasColumnName("rotanx");
            entity.Property(e => e.Sencli)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sencli");
            entity.Property(e => e.Seqroe).HasColumnName("seqroe");
            entity.Property(e => e.Sigufs)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("sigufs");
            entity.Property(e => e.Sitcli)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("sitcli");
            entity.Property(e => e.Temcob)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("temcob");
            entity.Property(e => e.Tement)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tement");
            entity.Property(e => e.Tipace).HasColumnName("tipace");
            entity.Property(e => e.Tipcli)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipcli");
            entity.Property(e => e.Tipemc).HasColumnName("tipemc");
            entity.Property(e => e.Tipemp).HasColumnName("tipemp");
            entity.Property(e => e.Tipmer)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipmer");
            entity.Property(e => e.Tricof)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tricof");
            entity.Property(e => e.Triicm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("triicm");
            entity.Property(e => e.Triipi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("triipi");
            entity.Property(e => e.Tripis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tripis");
            entity.Property(e => e.UsuBlocli)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_blocli");
            entity.Property(e => e.UsuCobtde)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_cobtde");
            entity.Property(e => e.UsuCodcli).HasColumnName("usu_codcli");
            entity.Property(e => e.UsuConnfs)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_connfs");
            entity.Property(e => e.UsuConped)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_conped");
            entity.Property(e => e.UsuConstb)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_constb");
            entity.Property(e => e.UsuDescpg)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usu_descpg");
            entity.Property(e => e.UsuEmafin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usu_emafin");
            entity.Property(e => e.UsuEmbipi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_embipi");
            entity.Property(e => e.UsuObsped)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("usu_obsped");
            entity.Property(e => e.UsuPagant)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_pagant");
            entity.Property(e => e.UsuPerven)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("usu_perven");
            entity.Property(e => e.Usuatu).HasColumnName("usuatu");
            entity.Property(e => e.Usucad).HasColumnName("usucad");
            entity.Property(e => e.Usumot).HasColumnName("usumot");
            entity.Property(e => e.Usuope).HasColumnName("usuope");
            entity.Property(e => e.Zipcod)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("zipcod");
            entity.Property(e => e.Zonfra).HasColumnName("zonfra");
        
        }
    }
}
