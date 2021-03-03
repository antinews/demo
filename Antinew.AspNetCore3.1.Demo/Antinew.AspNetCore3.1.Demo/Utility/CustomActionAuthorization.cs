using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antinew.AspNetCore3._1.Demo.Utility
{
    public class CustomActionAuthorization:ActionFilterAttribute
    {
        private readonly ILogger<CustomActionAuthorization> _logger;
        public CustomActionAuthorization(ILogger<CustomActionAuthorization> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = context.HttpContext.GetCurrentUserBySession();
            if (currentUser is null)
            {
                currentUser = context.HttpContext.GetCurrentUserByCookie();
                if (currentUser is null) { context.Result = new RedirectResult("~/Fourth/Login"); }
                    
            }
            else
            {
                this._logger.LogDebug($"{DateTime.Now}{currentUser.Name} 进入了系统..");
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
