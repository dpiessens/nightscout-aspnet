using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nightscout.Models;

namespace Nightscout.Binders
{
    public class QueryFilterModelBinderConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var parameter in action.Parameters)
            {
                if (typeof(QueryFilter).IsAssignableFrom((parameter.ParameterInfo.ParameterType)))
                {
                    parameter.BindingInfo = parameter.BindingInfo ?? new BindingInfo();
                    parameter.BindingInfo.BindingSource = BindingSource.Query;
                    parameter.BindingInfo.BinderType = typeof(QueryFilterModelBinder);
                    break;
                }
            }
        }
    }
}