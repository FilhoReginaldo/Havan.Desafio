using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class Cliente
    {
        [Required(ErrorMessage = "O Campo id é Obrigatório.")]
        public Int32 id { get; set; }

        [Required(ErrorMessage = "O Campo nome é Obrigatório.")]
        [MaxLength(120, ErrorMessage = "O Campo nome suporta o tamanho de 120 Caracteres.")]
        public String nome { get; set; }

        [Required(ErrorMessage = "O Campo documento é Obrigatório.")]
        [MaxLength(14, ErrorMessage = "O Campo documento suporta o tamanho de 14 Caracteres.")]
        public String documento { get; set; }

        [MaxLength(30, ErrorMessage = "O Campo email suporta o tamanho de 30 Caracteres.")]
        public String email { get; set; }

        [MaxLength(11, ErrorMessage = "O Campo telefone suporta o tamanho de 11 Caracteres.")]
        public String telefone { get; set; }
    }
}