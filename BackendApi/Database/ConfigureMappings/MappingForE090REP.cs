// using BackendApi.Database.Entityes;
using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE090REP : IEntityTypeConfiguration<E090REP>
    {
        public void Configure(EntityTypeBuilder<E090REP> entity)
        {
            entity.HasKey(e => e.Codrep)
                .HasName("cp_e090rep")
                .IsClustered(false);

            entity.ToTable("e090rep", tb =>
            {
                tb.HasTrigger("t090repd");
                tb.HasTrigger("t090repu");
            });

            entity.Property(e => e.Codrep)
                .ValueGeneratedNever()
                .HasColumnName("codrep");
            entity.Property(e => e.Aperep)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aperep");
            entity.Property(e => e.Bairep)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("bairep");
            entity.Property(e => e.Calins)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("calins");
            entity.Property(e => e.Calirf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("calirf");
            entity.Property(e => e.Caliss)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("caliss");
            entity.Property(e => e.Ceprep).HasColumnName("ceprep");
            entity.Property(e => e.Cgccpf).HasColumnName("cgccpf");
            entity.Property(e => e.Cidrep)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cidrep");
            entity.Property(e => e.Codcdi).HasColumnName("codcdi");
            entity.Property(e => e.Codmot).HasColumnName("codmot");
            entity.Property(e => e.Cplend)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cplend");
            entity.Property(e => e.Cxapst).HasColumnName("cxapst");
            entity.Property(e => e.Datatu)
                .HasColumnType("datetime")
                .HasColumnName("datatu");
            entity.Property(e => e.Datcad)
                .HasColumnType("datetime")
                .HasColumnName("datcad");
            entity.Property(e => e.Datmot)
                .HasColumnType("datetime")
                .HasColumnName("datmot");
            entity.Property(e => e.Datnas)
                .HasColumnType("datetime")
                .HasColumnName("datnas");
            entity.Property(e => e.Datpal)
                .HasColumnType("datetime")
                .HasColumnName("datpal");
            entity.Property(e => e.Datrge)
                .HasColumnType("datetime")
                .HasColumnName("datrge");
            entity.Property(e => e.Eenrep)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("eenrep");
            entity.Property(e => e.Endrep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endrep");
            entity.Property(e => e.Faxrep)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("faxrep");
            entity.Property(e => e.Firind)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("firind");
            entity.Property(e => e.Fonre2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fonre2");
            entity.Property(e => e.Fonre3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fonre3");
            entity.Property(e => e.Fonrep)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fonrep");
            entity.Property(e => e.Gertit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gertit");
            entity.Property(e => e.Horatu).HasColumnName("horatu");
            entity.Property(e => e.Horcad).HasColumnName("horcad");
            entity.Property(e => e.Hormot).HasColumnName("hormot");
            entity.Property(e => e.Horpal).HasColumnName("horpal");
            entity.Property(e => e.Indexp).HasColumnName("indexp");
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
            entity.Property(e => e.Intwmw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("intwmw");
            entity.Property(e => e.Nenrep)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nenrep");
            entity.Property(e => e.Nomrep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomrep");
            entity.Property(e => e.Numidf)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("numidf");
            entity.Property(e => e.Numrge)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numrge");
            entity.Property(e => e.Obsmot)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("obsmot");
            entity.Property(e => e.Orgrge)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("orgrge");
            entity.Property(e => e.Qtddep).HasColumnName("qtddep");
            entity.Property(e => e.Repcli).HasColumnName("repcli");
            entity.Property(e => e.Repfor).HasColumnName("repfor");
            entity.Property(e => e.Senrep)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("senrep");
            entity.Property(e => e.Sigufs)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("sigufs");
            entity.Property(e => e.Sitrep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("sitrep");
            entity.Property(e => e.Sitwmw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("sitwmw");
            entity.Property(e => e.Tiprep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tiprep");
            entity.Property(e => e.UsuAterep).HasColumnName("usu_aterep");
            entity.Property(e => e.UsuBairep)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("usu_bairep");
            entity.Property(e => e.UsuCeprep).HasColumnName("usu_ceprep");
            entity.Property(e => e.UsuCgccpf).HasColumnName("usu_cgccpf");
            entity.Property(e => e.UsuCidrep)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("usu_cidrep");
            entity.Property(e => e.UsuCodcrd).HasColumnName("usu_codcrd");
            entity.Property(e => e.UsuCodrgn).HasColumnName("usu_codrgn");
            entity.Property(e => e.UsuCplend)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("usu_cplend");
            entity.Property(e => e.UsuEndrep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usu_endrep");
            entity.Property(e => e.UsuNenrep)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("usu_nenrep");
            entity.Property(e => e.UsuSigufs)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("usu_sigufs");
            entity.Property(e => e.Usuatu).HasColumnName("usuatu");
            entity.Property(e => e.Usucad).HasColumnName("usucad");
            entity.Property(e => e.Usumot).HasColumnName("usumot");
            entity.Property(e => e.Zipcod)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("zipcod");
        
        }
    }
}
