namespace Havan.Desafio.DataAccess
{
    public interface ITenantProvider 
    {
        string GetTenant();
        string GetTenantConnectionString(string tenantName = null);
    }
}