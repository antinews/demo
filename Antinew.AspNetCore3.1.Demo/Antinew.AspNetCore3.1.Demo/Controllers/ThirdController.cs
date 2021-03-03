using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Antinew.AspNetCore3._1.Demo.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Antinew.AspNetCore3._1.Demo.Controllers
{

    //[TypeFilter(typeof(CustomActionAuthorization))]
    [CustomControllerFilterAttribute(Order = -10)]
    [CustomControllerFilterAttribute]
    [Authorize]
    //[CustomActionCacheFilterAttribute(Order = -1)]
    public class ThirdController : Controller
    {
        private readonly IConfiguration _configuration;
        public ThirdController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [CustomIOCFilterFactioryAttribute]
        [CustomActionFilterAttribute(Order =100)]
        //[CustomResourceFilterAttribute]
        //[TypeFilter(typeof(CustomExceptionFilterAttribute))]
        //[ServiceFilter(typeof(CustomExceptionFilterAttribute))]
        public IActionResult Index()
        {
            Console.WriteLine(_configuration["A:C:0"]);
            //string str = _configuration["saddsa"].ToString();
            base.ViewBag.Now = DateTime.Now;
            Thread.Sleep(1999);
            return View("index","213");
        }
    }
}
