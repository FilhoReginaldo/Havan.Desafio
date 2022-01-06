using System.Collections.Generic;
using Havan.Desafio.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Havan.Desafio.WebApi.Configs
{
    public class HttpTenantProvider : ITenantProvider
    {
        private readonly IActionContextAccessor _actionContext;

        public HttpTenantProvider(IActionContextAccessor actionContext)
        {
            _actionContext = actionContext;
        }

        public string GetTenant()
        {
            var routes = _actionContext.ActionContext.RouteData;
            var val = routes.Values["tenant"]?.ToString() as string;
            return val;
        }

        public string GetTenantConnectionString(string tenantName = null)
        {
            string tenant = GetTenant().Trim();

            if (!string.IsNullOrEmpty(tenantName))
                tenant = tenantName.Trim();

            string ConnectionString = Havan.Desafio.WebApi.Helpers.ConfigurationHelper.getConfigValue("ConnectionStrings:" + tenant);
            return ConnectionString;
        }
    }    
}