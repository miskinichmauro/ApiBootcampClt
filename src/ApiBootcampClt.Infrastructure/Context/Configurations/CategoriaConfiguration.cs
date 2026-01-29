using ApiBootcampClt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBootcampClt.Infrastructure.Context.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("categorias");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Descripcion)
            .HasColumnName("descripcion");

        builder.Property(x => x.Estado)
            .HasColumnName("estado")
            .IsRequired();

        builder.HasMany(x => x.Productos)
            .WithOne(x => x.Categoria)
            .HasForeignKey(x => x.CategoriaId)
            .HasConstraintName("fk_productos_categorias");
    }
}