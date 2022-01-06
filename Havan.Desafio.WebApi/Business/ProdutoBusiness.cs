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
    public class ProdutoBusiness : IDisposable
    {
        private DataAccess.DataEngine data = null;
        public ProdutoBusiness(DbContextOptions<HavanContext> options, DataAccess.ITenantProvider tenantProvider) 
        {
            data = new DataAccess.DataEngine(options, false, tenantProvider);
        }

        public IEnumerable<ProdutoResponse> BuscarProdutos(ODataQueryOptions<ProdutoResponse> queryOptions)
        {
            data.Context.ChangeTracker.AutoDetectChangesEnabled = false;

            IQueryable<ProdutoResponse> results = null;

            if (queryOptions.Filter != null)
            {
                var parameters = Helpers.ODataHelper.GetODataParametersList(queryOptions);

                var objID = parameters.Where(whr => whr.Key == "id").ToList();

                if(objID.Count() > 0)
                    results = BuscarProdutoComposto(Convert.ToInt32(objID[0].Value));
                else
                    results = BuscarProdutoSimples();
            }
            else
            {
                results = BuscarProdutoSimples();
            }

            return Helpers.ODataHelper.GetODataResults<ProdutoResponse>(results, queryOptions);

        }

        private IQueryable<ProdutoResponse> BuscarProdutoComposto(Int32 IdProduto)
        {
            var response = data.Connection.Query<ProdutoResponse, FamiliaProdutoResponse, ProdutoResponse>(ProdutoQuery.BuscarProdutosComposto.ToString(),
                 (p, c) => { p.familia = c; return p; }, new { IdProduto = IdProduto }, splitOn: "nome").ToList().AsQueryable();

            return response;
        }

        private IQueryable<ProdutoResponse> BuscarProdutoSimples()
        {
            var response = data.Connection.Query<ProdutoResponse>(ProdutoQuery.BuscarProdutosSimples, new { }).ToList().AsQueryable();

            return response;
        }

        public void Dispose()
        {
            data.Dispose();
        }
    }
}