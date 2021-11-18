using DIDecorateTest.Models;
using DIDecorateTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DIDecorateTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayersService _playersService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPlayersService playersService, ILogger<HomeController> logger)
        {
            _playersService = playersService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_playersService.GetPlayersList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}