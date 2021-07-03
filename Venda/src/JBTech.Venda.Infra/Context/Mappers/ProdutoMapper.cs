using JBTech.Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Infra.Context.Mappers
{
    public class ProdutoMapper : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                   .HasAnnotation("Relational:ColumnName", "Id");

            builder.Property(x => x.CategoriaId)
                   .HasAnnotation("Relational:ColumnName", "CategoriaId");

            builder.Property(x => x.NomeCategoria)
                   .HasAnnotation("Relational:ColumnName", "NomeCategoria");

            builder.Property(x => x.Nome)
                   .HasAnnotation("Relational:ColumnName", "Nome");

            builder.Property(x => x.PrecoVenda)
                   .HasAnnotation("Relational:ColumnName", "PrecoVenda");

            builder.Property(x => x.TotalEstoque)
                  .HasAnnotation("Relational:ColumnName", "TotalEstoque");


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
