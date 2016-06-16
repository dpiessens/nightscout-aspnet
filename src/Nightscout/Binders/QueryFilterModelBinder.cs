using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nightscout.Controllers;
using Nightscout.Models;

namespace Nightscout.Binders
{
    public class QueryFilterModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!typeof(QueryFilter).IsAssignableFrom(bindingContext.ModelType))
            {
                return Task.FromResult(false);
            }
            
            var key = bindingContext.ModelName;

            var query = bindingContext.OperationBindingContext.HttpContext.Request.Query;
            var keyList = GetKeyList(query, key);
            if (keyList.Count > 0)
            {
                var queryFilter = new QueryFilter();
                
                foreach (var value in keyList)
                {
                    var keyData = ParseKey(value);
                    var val = query[value];
                    queryFilter.Filters.Add(new QueryItem(keyData.Item1, val, keyData.Item2));
                }
                bindingContext.Result = ModelBindingResult.Success(key, queryFilter);

                return Task.FromResult(true);
            }

            bindingContext.Result = ModelBindingResult.Failed(key);
            return Task.FromResult(false);
        }

        private static IList<string> GetKeyList(IQueryCollection query, string key)
        {
            var bracketKey = $"{key}[";
            return query.Keys.Where(k => k.StartsWith(bracketKey)).ToList();
        }

        private static Tuple<string, string> ParseKey(string key)
        {
            string field = null;
            string comparitor = null;

            var buffer = new StringBuilder();
            var inParam = false;
            foreach (var c in key)
            {
                switch (c)
                {
                    case '[':
                        buffer = new StringBuilder();
                        inParam = true;
                        break;
                    case ']':
                        if (field == null)
                        {
                            field = buffer.ToString();
                        }
                        else
                        {
                            comparitor = buffer.ToString();
                        }
                        buffer.Clear();
                        inParam = false;

                        break;
                    default:
                        if (inParam)
                        {
                            buffer.Append(c);
                        }
                        break;
                }
            }

            return new Tuple<string, string>(field, comparitor);
        }
    }
}