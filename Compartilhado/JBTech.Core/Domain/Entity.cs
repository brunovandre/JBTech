using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime UltimaModificacao { get; protected set; }
        public DateTime? DataDelecao { get; protected set; }

        public bool Deletado { 
            get { return DataDelecao.HasValue; } 
        }

        protected void GerarId()
            => Id = Id == Guid.Empty ? Guid.NewGuid() : Id;
    }
}
