using System;
using System.ComponentModel.DataAnnotations;

namespace Havan.Desafio.Model.Response
{
    public class ProdutoResponse: Produto
    {
        public FamiliaProdutoResponse familia { get;set; }
    }
}