using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class ClienteEndereco
    {
        [Required(ErrorMessage = "O Campo id é Obrigatório.")]
        public Int32 id { get; set; }

        [Required(ErrorMessage = "O Campo idcliente é Obrigatório.")]
        public Int32 idcliente { get; set; }

        [MaxLength(120, ErrorMessage = "O Campo logradouro suporta o tamanho de 120 Caracteres.")]
        public String logradouro { get; set; }

        [MaxLength(10, ErrorMessage = "O Campo numero suporta o tamanho de 10 Caracteres.")]
        public String numero { get; set; }

        [MaxLength(8, ErrorMessage = "O Campo cep suporta o tamanho de 8 Caracteres.")]
        public String cep { get; set; }

        [MaxLength(120, ErrorMessage = "O Campo bairro suporta o tamanho de 120 Caracteres.")]
        public String bairro { get; set; }

        [MaxLength(120, ErrorMessage = "O Campo cidade suporta o tamanho de 120 Caracteres.")]
        public String cidade { get; set; }

        [MaxLength(2, ErrorMessage = "O Campo uf suporta o tamanho de 2 Caracteres.")]
        public String uf { get; set; }
    }
}