using Shopping.Core.DomainObjects;
using Shopping.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Catalogo.API.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public string Imagem { get; set; }
        public int QntEstoque { get; set; }
    }
}
