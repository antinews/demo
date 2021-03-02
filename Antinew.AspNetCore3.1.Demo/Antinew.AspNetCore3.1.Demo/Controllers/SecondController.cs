using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antinew.AspNetCore3._1.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Antinew.AspNetCore3._1.Demo.Startup;

namespace Antinew.AspNetCore3._1.Demo.Controllers
{
    public class SecondController : Controller
    {
        private readonly ILogger<SecondController> _logger;
        private readonly ITestServiceA _testServiceA;
        public SecondController(ILogger<SecondController> logger, ITestServiceA testServiceA)
        {
            _logger = logger;
            _testServiceA = testServiceA;
        }
        public IActionResult Index()
        {
            this._logger.LogWarning("进入 SecondController Index....");
            _testServiceA.Show();
            return View();
        }
    }
}
