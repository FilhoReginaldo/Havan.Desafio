using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;

namespace Havan.Desafio.WebApi.Helpers
{
    public static class ODataHelper
    {
        public static IEnumerable<T> GetODataResults<T>(IQueryable<T> source, ODataQueryOptions<T> queryOptions, int? overrideTop = null)
        {

            var querySettings = new ODataQuerySettings();
            var validationSettings = new ODataValidationSettings();
            
          
            if (queryOptions.OrderBy == null && queryOptions.Filter == null && queryOptions.Top == null)
            {
                if (overrideTop.HasValue)
                    return source.Take(overrideTop.Value).ToList();
                else
                    return source.Take(25).ToList();

            }
            else
            {

                if(queryOptions.Top == null && overrideTop == null)
                {
                    validationSettings.MaxTop = 25;
                    querySettings.PageSize = 25;
                }
                else
                {   
                    if (overrideTop.HasValue)
                    {
                        validationSettings.MaxTop = overrideTop.Value;
                        querySettings.PageSize = overrideTop.Value;
                    }
                    else
                    {
                        if (queryOptions.Top.Value > 1000)  
                        {  
                            validationSettings.MaxTop = 1000;
                            querySettings.PageSize = 1000;
                        }
                        else
                        {
                            validationSettings.MaxTop = queryOptions.Top.Value;
                            querySettings.PageSize = queryOptions.Top.Value;
                            
                        }
                    }
                }

                queryOptions.Validate(validationSettings);
            
            }

            

            return queryOptions.ApplyTo(source, querySettings) as IEnumerable<T>;
            
        }
           

        public static List<ODataFiltro> GetODataParametersList<T>(ODataQueryOptions<T> queryOptions)
        {
            if (queryOptions.Filter == null)
                return new List<ODataFiltro>();

            if (string.IsNullOrEmpty(queryOptions.Filter.RawValue))
                return new List<ODataFiltro>();

            const char QUERY_OPTIONS_SEPARATOR = '&';
            const char QUERY_OPTIONS_DELIMITER = '=';
           
            var queryString = queryOptions.Filter.RawValue.Replace("eq","=").Replace("or","&").Replace("and","&").Replace("(","").Replace(")","");

            var queryParameters = queryString
                .Split(new[] { QUERY_OPTIONS_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries)
                .Select(sel => new ODataFiltro(){
                    Key = sel.Split(QUERY_OPTIONS_DELIMITER).FirstOrDefault().Trim(),
                    Value = sel.Split(QUERY_OPTIONS_DELIMITER).LastOrDefault().Trim().Replace("'","") 
                
                }).ToList();
           
            if (queryParameters == null)
                return new List<ODataFiltro>();
            else
                return queryParameters;
            
        }


        public static object GetODataParameterValue<T>(ODataQueryOptions<T> queryOptions, String ParameterName)
        {
            
            var queryParameters = GetODataParametersList(queryOptions);

            if (queryParameters.Count > 0)
            {
                var resultParameter = queryParameters.Where(whr => whr.Key == ParameterName).FirstOrDefault();

                if (resultParameter != null)
                    return resultParameter.Value;
                else
                    return null;
            }
            else
                return null;

        }

            
    }

    
    public class ODataFiltro
    {
        public string Key {get; set;}
        public string Value { get; set;}
        public ODataTipoFiltro Tipo {get; set;}
    }

    public enum ODataTipoFiltro 
    {
        AND, OR, LIKE, IN, ORDERBY, TOP
    }




    
}