using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtivSistemaDeVendas.Models;

namespace AtivSistemaDeVendas.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.Senha)
                   .IsRequired();

            // Um usuário pode ter vários pedidos
            //builder.HasMany(u => u.Pedidos)
            //.WithOne(p => p.Usuario)
            //.HasForeignKey(p => p.UsuarioId);
        }
    }
}
