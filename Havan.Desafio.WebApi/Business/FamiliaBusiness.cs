using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Havan.Desafio.DataAccess.Entities;
using Havan.Desafio.Model.Response;
using Microsoft.EntityFrameworkCore;
using Havan.Desafio.WebApi.Helpers;
using Dapper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.OData.Query;
using Havan.Desafio.WebApi.Query;

namespace Havan.Desafio.WebApi.Business
{
    public class FamiliaBusiness: IDisposable
    {
        private DataAccess.DataEngine data = null;
        public FamiliaBusiness(DbContextOptions<HavanContext> options, DataAccess.ITenantProvider tenantProvider)
        {
            data = new DataAccess.DataEngine(options, false, tenantProvider);
        }
        public IEnumerable<FamiliaProdutoResponse> BuscarFamiliaProdutos(ODataQueryOptions<FamiliaProdutoResponse> queryOptions)
        {

            var response = data.Connection.Query<FamiliaProdutoResponse>(ProdutoQuery.BuscarFamiliaProduto, new { }).ToList().AsQueryable();

            return Helpers.ODataHelper.GetODataResults<FamiliaProdutoResponse>(response, queryOptions);
        }

        public void Dispose()
        {
            data.Dispose();
        }
    }
}
