using JBTech.Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Infra.Context.Mappers
{
    public class ItemVendaMapper : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItemVenda");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasAnnotation("Relational:ColumnName", "Id");

            builder.Property(x => x.IdProduto)
                   .HasAnnotation("Relational:ColumnName", "IdProduto");

            builder.Property(x => x.IdVenda)
                  .HasAnnotation("Relational:ColumnName", "IdVenda");

            builder.Property(x => x.PrecoVenda)
                  .HasAnnotation("Relational:ColumnName", "PrecoVenda");

            builder.Property(x => x.Quantidade)
                 .HasAnnotation("Relational:ColumnName", "Quantidade");

            builder.HasOne(x => x.Produto)
                   .WithMany(x => x.ItemsVenda)
                   .HasForeignKey(x => x.IdProduto)
                   .HasConstraintName("FK_ItemVenda_Produto");

            builder.HasOne(x => x.Venda)
                   .WithMany(x => x.ItemsVenda)
                   .HasForeignKey(x => x.IdVenda)
                   .HasConstraintName("FK_ItemVenda_Venda"); ;

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
