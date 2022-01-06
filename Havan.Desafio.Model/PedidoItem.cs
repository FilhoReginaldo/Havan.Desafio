using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class PedidoItem
    {
        [Required(ErrorMessage = "O Campo id é Obrigatório.")]
        public Int32 id { get; set; }

        [Required(ErrorMessage = "O Campo idproduto é Obrigatório.")]
        public Int32 idproduto { get; set; }

        [Required(ErrorMessage = "O Campo idpedido é Obrigatório.")]
        public Int32 idpedido { get; set; }

        [Required(ErrorMessage = "O Campo quantidade é Obrigatório.")]
        public Int32 quantidade { get; set; }

        [Required(ErrorMessage = "O Campo preco é Obrigatório.")]
        public Decimal preco { get; set; }
    }
}