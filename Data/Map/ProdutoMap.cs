using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtivSistemaDeVendas.Models;

namespace AtivSistemaDeVendas.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Preco)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Descricao)
                   .HasMaxLength(500);
        }
    }
}
