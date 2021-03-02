using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Antinew.AspNetCore3._1.Demo.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        public FirstController(ILogger<FirstController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
        }
        public IActionResult Index()
        {
            this._logger.LogError("ILogger：进入FirstController Index方法。。。");
            //this._loggerFactory.CreateLogger<FirstController>().LogError("ILoggerFactory：进入FirstController Index方法。。。");
            base.ViewBag.User1 = "张三";
            base.ViewData["User2"] = "李四";
            base.TempData["User3"] = "王五";
            var res = base.HttpContext.Session.GetString("User4");
            if (string.IsNullOrWhiteSpace(res))
            {
                base.HttpContext.Session.SetString("User4", "隔壁老王Q");
            }
            return View("index","牛六");
        }
    }
}
