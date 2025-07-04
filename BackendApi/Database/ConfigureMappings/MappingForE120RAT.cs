using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE120RAT : IEntityTypeConfiguration<E120RAT>
    {
        public void Configure(EntityTypeBuilder<E120RAT> entity)
        {
            entity.HasKey(e => new { e.CodEmp, e.CodFil, e.NumPed, e.SeqRat })
               .HasName("cp_e120rat")
               .IsClustered(false);

            entity.ToTable("E120RAT");

            entity.Property(e => e.CodCcu)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DatGer).HasColumnType("datetime");
            entity.Property(e => e.ObsRat)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PerCta).HasColumnType("numeric(7, 4)");
            entity.Property(e => e.PerRat).HasColumnType("numeric(7, 4)");
            entity.Property(e => e.Tipori)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipori");
            entity.Property(e => e.TnsPro)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TnsSer)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.VlrCta).HasColumnType("numeric(15, 2)");
            entity.Property(e => e.VlrRat).HasColumnType("numeric(15, 2)");
        }
    }
}
