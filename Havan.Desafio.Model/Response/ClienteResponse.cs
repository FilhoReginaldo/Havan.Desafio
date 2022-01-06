using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model.Response
{
    public class ClienteResponse: Cliente
    {
        public ClienteEndereco Endereco { get;set; }
    }
}