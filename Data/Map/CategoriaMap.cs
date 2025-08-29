using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtivSistemaDeVendas.Models;

namespace AtivSistemaDeVendas.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaModel> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            // Relacionamento 1:N -> Categoria possui vários produtos
            builder.HasMany(c => c.Produtos)
                   .WithOne(p => p.Categoria)
                   .HasForeignKey(p => p.CategoriaId);
        }
    }
}
