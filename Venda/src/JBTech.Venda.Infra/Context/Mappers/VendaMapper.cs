using JBTech.Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBTech.Vendas.Infra.Context.Mappers
{
    public class VendaMapper : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasAnnotation("Relational:ColumnName", "Id");

            builder.Property(x => x.DataCompra)
                   .HasAnnotation("Relational:ColumnName", "DataCompra");

            builder.Property(x => x.DataCancelamento)
                 .HasAnnotation("Relational:ColumnName", "DataCancelamento");

            builder.Property(x => x.DataFinalizacao)
                 .HasAnnotation("Relational:ColumnName", "DataFinalizacao");

            builder.Property(x => x.NumeroCancelamento)
                 .HasAnnotation("Relational:ColumnName", "NumeroCancelamento");

            builder.Property(x => x.IdUsuario)
                   .HasAnnotation("Relational:ColumnName", "IdUsuario");

            builder.Property(x => x.FormaPagamento)
                   .HasAnnotation("Relational:ColumnName", "FormaPagamento");

            builder.Property(x => x.Status)
                   .HasAnnotation("Relational:ColumnName", "Status");

            builder.Property(x => x.ValorTotal)
                   .HasAnnotation("Relational:ColumnName", "ValorTotal");

            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.Vendas)
                   .HasForeignKey(x => x.IdUsuario)
                   .HasConstraintName("FK_Venda_Usuario");


            builder.Property(x => x.Deletado)
               .HasAnnotation("Relational:ColumnName", "Deletado");

            builder.Property(x => x.DataCriacao)
                 .HasAnnotation("Relational:ColumnName", "DataCriacao");

            builder.Property(x => x.UltimaModificacao)
                 .HasAnnotation("Relational:ColumnName", "UltimaModificacao");

            builder.Property(x => x.DataDelecao)
                 .HasAnnotation("Relational:ColumnName", "DataDelecao");
        }
    }
}