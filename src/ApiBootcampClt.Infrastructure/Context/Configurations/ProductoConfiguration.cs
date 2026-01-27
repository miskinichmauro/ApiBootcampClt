using ApiBootcampClt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBootcampClt.Infrastructure.Context.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("productos");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.Codigo)
            .IsUnique()
            .HasDatabaseName("idx_productos_codigo");

        builder.Property(x => x.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Descripcion)
            .HasColumnName("descripcion");

        builder.Property(x => x.Precio)
            .HasColumnName("precio")
            .HasPrecision(50, 2) // respeta tu script (aunque recomendado 18,2)
            .IsRequired();

        builder.Property(x => x.Activo)
            .HasColumnName("activo")
            .IsRequired();

        builder.Property(x => x.CategoriaId)
            .HasColumnName("categoria_id")
            .IsRequired();

        builder.Property(x => x.FechaCreacion)
            .HasColumnName("fecha_creacion")
            .IsRequired();

        builder.Property(x => x.FechaActualizacion)
            .HasColumnName("fecha_actualizacion");

        builder.Property(x => x.CantidadStock)
            .HasColumnName("cantidad_stock")
            .IsRequired();
    }
}