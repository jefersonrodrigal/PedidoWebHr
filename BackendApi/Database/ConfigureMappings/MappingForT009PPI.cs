using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForT009PPI : IEntityTypeConfiguration<T009PPI>
    {
        public void Configure(EntityTypeBuilder<T009PPI> entity)
        {
            entity.HasKey(e => new { e.UsuNumppd, e.UsuSeqipd })
               .HasName("cp_usu_t009ppi")
               .IsClustered(false);

            entity.ToTable("usu_t009ppi");

            entity.Property(e => e.UsuNumppd).HasColumnName("usu_numppd");
            entity.Property(e => e.UsuSeqipd).HasColumnName("usu_seqipd");
            entity.Property(e => e.UsuCodagc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("usu_codagc");
            entity.Property(e => e.UsuCodemp).HasColumnName("usu_codemp");
            entity.Property(e => e.UsuCodfam)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("usu_codfam");
            entity.Property(e => e.UsuCodpro)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("usu_codpro");
            entity.Property(e => e.UsuDesnfv)
                .HasMaxLength(99)
                .IsUnicode(false)
                .HasColumnName("usu_desnfv");
            entity.Property(e => e.UsuFinrec).HasColumnName("usu_finrec");
            entity.Property(e => e.UsuPreuni)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("usu_preuni");
            entity.Property(e => e.UsuQtdped)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("usu_qtdped");
            entity.Property(e => e.UsuUnimed)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("usu_unimed");
            entity.Property(e => e.UsuVlrtot)
                .HasColumnType("numeric(14, 5)")
                .HasColumnName("usu_vlrtot");
        
        }
    }
}
