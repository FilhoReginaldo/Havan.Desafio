using System.Collections.Generic;
using Havan.Desafio.DataAccess.Entities;
using Havan.Desafio.Model.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Havan.Desafio.WebApi.Business;
using Havan.Desafio.Model.Response;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Havan.Desafio.DataAccess;
using Microsoft.AspNetCore.OData.Query;

namespace Havan.Desafio.WebApi.Controllers
{
    /// <summary>
    /// Para trabalhar com os registros referentes ao produtos.
    /// </summary>
    [Route("{tenant}")]
    public class ProdutoController : Controller
    {
        DbContextOptions<HavanContext> contextOptions = null;
        ITenantProvider tenantProvider = null;

        public ProdutoController(DbContextOptions<HavanContext> options, ITenantProvider tenant)
        {
            contextOptions = options;
            tenantProvider = tenant;
        }

        /// <summary>
        /// Buscar Produtos
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        [HttpGet]
        [EnableQuery]
        [Route("produtos/buscar")]
        public IEnumerable<ProdutoResponse> BuscarProdutos(ODataQueryOptions<ProdutoResponse> queryOptions)
        {
            using (ProdutoBusiness business = new ProdutoBusiness(contextOptions, tenantProvider))
            {
                return business.BuscarProdutos(queryOptions);
            }
        }
        
    }
}