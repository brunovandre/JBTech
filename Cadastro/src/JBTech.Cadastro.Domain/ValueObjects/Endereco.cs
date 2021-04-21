using System;
using System.Collections.Generic;
using System.Text;

namespace JBTech.Cadastro.Domain.ValueObjects
{
    public class Endereco
    {
        public string Localidade { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }

        public Endereco(string localidade, string numero, string bairro, string complemento, string cep, string cidade, string estado, string pais)
        {
            Localidade = localidade;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
    }
}
