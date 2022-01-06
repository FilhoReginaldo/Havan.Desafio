using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model
{
    public class Pedido
    {
        [Required(ErrorMessage = "O Campo id é Obrigatório.")]
        public Int32 id { get; set; }
        public Int32? idcupom { get; set; }
        public Int32? idcliente { get; set; }
        public Int32? idclienteendereco { get; set; }
        public Decimal? percentualdesconto { get; set; }
    }
}