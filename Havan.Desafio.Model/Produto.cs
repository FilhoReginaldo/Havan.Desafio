using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class Produto
    {
        [Required(ErrorMessage = "O Campo id é Obrigatório.")]
        public Int32 id { get; set; }
        public Int32 idfamilia { get; set; }

        [Required(ErrorMessage = "O Campo preco é Obrigatório.")]
        public Decimal preco { get;set; }

        [MaxLength(20, ErrorMessage = "O Campo sku suporta o tamanho de 20 Caracteres.")]
        public String sku { get; set; }

        [Required(ErrorMessage = "O Campo nome é Obrigatório.")]
        [MaxLength(120, ErrorMessage = "O Campo nome suporta o tamanho de 120 Caracteres.")]
        public String nome { get; set; }

        [MaxLength(120, ErrorMessage = "O Campo urlimagem suporta o tamanho de 120 Caracteres.")]
        public String urlimagem { get; set; }
    }
}