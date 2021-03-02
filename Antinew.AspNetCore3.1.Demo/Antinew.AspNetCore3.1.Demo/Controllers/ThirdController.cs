using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Antinew.AspNetCore3._1.Demo.Controllers
{
    public class ThirdController : Controller
    {
        private readonly IConfiguration _configuration;
        public ThirdController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            Console.WriteLine(_configuration["A:C:0"]);
            return View();
        }
    }
}
