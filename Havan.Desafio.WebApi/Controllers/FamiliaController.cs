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
    /// Para trabalhar com os registros referentes a familia.
    /// </summary>
    [Route("{tenant}")]
    public class FamiliaController: Controller
    {
        DbContextOptions<HavanContext> contextOptions = null;
        ITenantProvider tenantProvider = null;

        public FamiliaController(DbContextOptions<HavanContext> options, ITenantProvider tenant)
        {
            contextOptions = options;
            tenantProvider = tenant;
        }

        /// <summary>
        /// Buscar Familia Produtos
        /// </summary>
        /// <returns>Retorna uma lista de familia de produtos</returns>
        [HttpGet]
        [EnableQuery]
        [Route("familia/buscar")]
        public IEnumerable<FamiliaProdutoResponse> BuscarFamiliaProdutos(ODataQueryOptions<FamiliaProdutoResponse> queryOptions)
        {
            using (FamiliaBusiness business = new FamiliaBusiness(contextOptions, tenantProvider))
            {
                return business.BuscarFamiliaProdutos(queryOptions);
            }
        }
    }
}
