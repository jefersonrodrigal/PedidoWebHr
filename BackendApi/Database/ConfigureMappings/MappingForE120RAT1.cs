using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendApi.Database.ConfigureMappings
{
    public class MappingForE120RAT1 : IEntityTypeConfiguration<E120RAT1>
    {
        public void Configure(EntityTypeBuilder<E120RAT1> entity)
        {
            entity.HasKey(e => new { e.Codemp, e.Codfil, e.Numped, e.Seqrat })
                .HasName("cp_e120rat")
                .IsClustered(false);

            entity.ToTable("e120rat", "sapiens");

            entity.Property(e => e.Codemp).HasColumnName("codemp");
            entity.Property(e => e.Codfil).HasColumnName("codfil");
            entity.Property(e => e.Numped).HasColumnName("numped");
            entity.Property(e => e.Seqrat).HasColumnName("seqrat");
            entity.Property(e => e.Codccu)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("codccu");
            entity.Property(e => e.Codfpj).HasColumnName("codfpj");
            entity.Property(e => e.Crirat).HasColumnName("crirat");
            entity.Property(e => e.Ctafin).HasColumnName("ctafin");
            entity.Property(e => e.Ctared).HasColumnName("ctared");
            entity.Property(e => e.Datger)
                .HasColumnType("datetime")
                .HasColumnName("datger");
            entity.Property(e => e.Horger).HasColumnName("horger");
            entity.Property(e => e.Numprj).HasColumnName("numprj");
            entity.Property(e => e.Obsrat)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("obsrat");
            entity.Property(e => e.Percta)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("percta");
            entity.Property(e => e.Perrat)
                .HasColumnType("numeric(7, 4)")
                .HasColumnName("perrat");
            entity.Property(e => e.Seqipd).HasColumnName("seqipd");
            entity.Property(e => e.Seqisp).HasColumnName("seqisp");
            entity.Property(e => e.Somsub).HasColumnName("somsub");
            entity.Property(e => e.Tipori)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipori");
            entity.Property(e => e.Tnspro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tnspro");
            entity.Property(e => e.Tnsser)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tnsser");
            entity.Property(e => e.Usuger).HasColumnName("usuger");
            entity.Property(e => e.Vlrcta)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrcta");
            entity.Property(e => e.Vlrrat)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("vlrrat");
        }
    }
}
