using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class FamiliaProduto
    {
        [Required(ErrorMessage = "O Campo id é Obrigatório.")]
        public Int32 id { get; set; }

        [MaxLength(120, ErrorMessage = "O Campo nome suporta o tamanho de 120 Caracteres.")]
        public String nome { get; set; }
        
    }
}