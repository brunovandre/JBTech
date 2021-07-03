using JBTech.Core.Domain;
using JBTech.Vendas.Domain.Entities;
using JBTech.Vendas.Infra.Context.Mappers;
using Microsoft.EntityFrameworkCore;

namespace JBTech.Vendas.Infra.Context
{
    public class VendaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItemsVenda { get; set; }

        public VendaContext(DbContextOptions<VendaContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProdutoMapper());
            modelBuilder.ApplyConfiguration(new UsuarioMapper());
            modelBuilder.ApplyConfiguration(new VendaMapper());
            modelBuilder.ApplyConfiguration(new ItemVendaMapper());

            modelBuilder.Entity<Entity>().HasQueryFilter(x => !x.Deletado);

            ApplyTableNameToLowerConventions(modelBuilder);
        }

        private void ApplyTableNameToLowerConventions(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());

                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToLower());

                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToLower());

                foreach (var key in entity.GetForeignKeys())
                    key.SetConstraintName(key.GetConstraintName().ToLower());

                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToLower());
            }
        }
    }
}
