namespace Havan.Desafio.WebApi.Query
{
    public class ProdutoQuery
    {
        public static string BuscarProdutosComposto = @"SELECT prd.id,prd.idfamilia,prd.preco,prd.sku,prd.nome,prd.urlimagem, faPrd.nome, faPrd.id  FROM public.produto prd inner join public.familiaproduto faPrd on faPrd.id = prd.idfamilia where prd.id = @IdProduto;";

        public static string BuscarProdutosSimples = @"SELECT 
                                                    id
                                                    ,idfamilia
                                                    ,preco
                                                    ,sku
                                                    ,nome
                                                    ,urlimagem
                                                FROM public.produto";
        public static string BuscarFamiliaProduto = @"SELECT id
	                                                        ,nome
                                                      FROM public.familiaproduto";

    }
}
