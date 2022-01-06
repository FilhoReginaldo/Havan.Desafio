using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model.Response
{
    public class PedidoResponse: Pedido
    {
        public PedidoItem Itens { get;set; }
    }
}