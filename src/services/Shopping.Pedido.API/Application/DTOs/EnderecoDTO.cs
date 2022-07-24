
using Shopping.Pedido.Domain.Pedidos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Application.DTOs
{
    public class EnderecoDTO
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public EnderecoDTO()
        {

        }
        public EnderecoDTO(Endereco endereco)
        {
            this.Logradouro = endereco.Logradouro;
            this.Numero = endereco.Numero;
            this.Complemento = endereco.Complemento;
            this.Bairro = endereco.Bairro;
            this.Cep = endereco.Cep;
            this.Cidade = endereco.Cidade;
            this.Estado = endereco.Estado;
        }
    }
}
