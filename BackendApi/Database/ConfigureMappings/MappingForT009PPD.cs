using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForT009PPD : IEntityTypeConfiguration<T009PPD>
    {
        public void Configure(EntityTypeBuilder<T009PPD> builder)
        {
            builder.ToTable("usu_t009ppd");

            builder.HasKey(x => x.UsuNumppd);

            builder.Property(x => x.UsuNumppd).HasColumnName("usu_numppd");
            builder.Property(x => x.UsuDatemi).HasColumnName("usu_datemi");
            builder.Property(x => x.UsuObsped).HasColumnName("usu_obsped");
            builder.Property(x => x.UsuCodcli).HasColumnName("usu_codcli");
            builder.Property(x => x.UsuCodrep).HasColumnName("usu_codrep");
            builder.Property(x => x.UsuCodcpg).HasColumnName("usu_codcpg");
            builder.Property(x => x.UsuPedcli).HasColumnName("usu_pedcli");
            builder.Property(x => x.UsuDatprv).HasColumnName("usu_datprv");
            builder.Property(x => x.UsuPedime).HasColumnName("usu_pedime");
            builder.Property(x => x.UsuTipfat).HasColumnName("usu_tipfat");
            builder.Property(x => x.UsuNatope).HasColumnName("usu_natope");
            builder.Property(x => x.UsuPerdsc).HasColumnName("usu_perdsc");
            builder.Property(x => x.UsuNumped).HasColumnName("usu_numped");
            builder.Property(x => x.UsuNumpe2).HasColumnName("usu_numpe2");
            builder.Property(x => x.UsuSitppd).HasColumnName("usu_sitppd");
            builder.Property(x => x.UsuCiffob).HasColumnName("usu_ciffob");
            builder.Property(x => x.UsuCodcrt).HasColumnName("usu_codcrt");
            builder.Property(x => x.UsuCodfpg).HasColumnName("usu_codfpg");
            builder.Property(x => x.UsuCodtra).HasColumnName("usu_codtra");
            builder.Property(x => x.UsuTipdis).HasColumnName("usu_tipdis");
            builder.Property(x => x.UsuNumnfv).HasColumnName("usu_numnfv");
            builder.Property(x => x.UsuNumnf2).HasColumnName("usu_numnf2");
            builder.Property(x => x.UsuDatfat).HasColumnName("usu_datfat");
            builder.Property(x => x.UsuObsfin).HasColumnName("usu_obsfin");
            builder.Property(x => x.UsuPrvfat).HasColumnName("usu_prvfat");
            builder.Property(x => x.UsuRetmer).HasColumnName("usu_retmer");
            builder.Property(x => x.UsuCodemp).HasColumnName("usu_codemp");
            builder.Property(x => x.UsuNecage).HasColumnName("usu_necage");
        }
    }
}
