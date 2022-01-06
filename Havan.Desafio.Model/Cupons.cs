using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class Cupons
    {
        [Required(ErrorMessage = "O Campo id é Obrigatório.")]
        public Int32 id { get; set; }

        [MaxLength(10, ErrorMessage = "O Campo codigo suporta o tamanho de 10 Caracteres.")]
        public String codigo { get; set; }
        
        public Decimal? percentualdesconto { get; set; }
    }
}