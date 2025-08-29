using AtivSistemaDeVendas.Data.Map;
using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace AtivSistemaDeVendas.Data
{
    public class SistemaTarefasDbContext : DbContext
    {
        public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options) : base(options)
        {
        }

        // DbSets (tabelas)
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<PedidoProdutoModel> PedidoProdutos { get; set; } // 👈 Nome correto

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar os Maps
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoProdutoMap());
        }
    }
}
