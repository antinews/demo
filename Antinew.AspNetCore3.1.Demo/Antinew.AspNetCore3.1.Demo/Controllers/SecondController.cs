using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Antinew.AspNetCore3._1.Demo.Startup;

namespace Antinew.AspNetCore3._1.Demo.Controllers
{
    public class SecondController : Controller
    {
        private readonly ILogger<SecondController> _logger;
        private readonly ITestService _testService;
        public SecondController(ILogger<SecondController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }
        public IActionResult Index()
        {
            this._logger.LogWarning("进入 SecondController Index....");
            _testService.Show();
            return View();
        }
    }
}
