using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtivSistemaDeVendas.Models;

namespace AtivSistemaDeVendas.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataPedido)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.FormaPagamento)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(p => p.Usuario)
                   .WithMany(u => u.Pedidos)
                   .HasForeignKey(p => p.UsuarioId);

            // Pedido possui vários itens (Produtos através da tabela intermediária)
            builder.HasMany(p => p.PedidosProdutos)
                   .WithOne(pp => pp.Pedido)
                   .HasForeignKey(pp => pp.PedidoId);
        }
    }
}
