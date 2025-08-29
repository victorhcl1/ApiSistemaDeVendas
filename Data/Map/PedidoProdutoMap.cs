using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtivSistemaDeVendas.Models;

public class PedidoProdutoMap : IEntityTypeConfiguration<PedidoProdutoModel>
{
    public void Configure(EntityTypeBuilder<PedidoProdutoModel> builder)
    {
        builder.HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

        builder.HasOne(pp => pp.Pedido)
               .WithMany(p => p.PedidosProdutos)
               .HasForeignKey(pp => pp.PedidoId);

        builder.HasOne(pp => pp.Produto)
               .WithMany()
               .HasForeignKey(pp => pp.ProdutoId);
    }
}
