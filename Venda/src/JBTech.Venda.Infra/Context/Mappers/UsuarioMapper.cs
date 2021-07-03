using JBTech.Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Vendas.Infra.Context.Mappers
{
    public class UsuarioMapper : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasAnnotation("Relational:ColumnName", "Id");

            builder.Property(x => x.Nome)
                   .HasAnnotation("Relational:ColumnName", "Nome");

            builder.Property(x => x.Sobrenome)
                   .HasAnnotation("Relational:ColumnName", "Sobrenome");

            builder.Property(x => x.Email)
                   .HasAnnotation("Relational:ColumnName", "Email");

            builder.Property(x => x.Cpf)
                   .HasAnnotation("Relational:ColumnName", "Cpf");


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
