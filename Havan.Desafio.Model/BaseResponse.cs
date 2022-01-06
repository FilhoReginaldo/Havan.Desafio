using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class BaseResponse
    {
        [Required(ErrorMessage = "O Campo Code é Obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Campo Code suporta o tamanho de 50 Caracteres.")]
        public String Code { get; set; }

        [MaxLength(300, ErrorMessage = "O Campo message suporta o tamanho de 300 Caracteres.")]
        public String message { get; set; }
    }
}