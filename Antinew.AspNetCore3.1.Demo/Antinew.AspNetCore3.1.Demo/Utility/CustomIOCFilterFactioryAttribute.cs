using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antinew.AspNetCore3._1.Demo.Utility
{
    /// <summary>
    /// ServiceFilter、TypeFilter的本质就是CustomIOCFilterFactioryAttribute
    /// Attribute会现寻找FilterFactory如果存在就调用CreateInstance
    /// </summary>
    public class CustomIOCFilterFactioryAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService(typeof(CustomExceptionFilterAttribute)) as IFilterMetadata;
        }
    }
}
