using DoggosApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Data;

namespace DoggosApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DatabaseInit _dbInit;

        public HomeController(ILogger<HomeController> logger, DatabaseInit dbInit)
        {
            _logger = logger;
            _dbInit = dbInit;   
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public async Task<IActionResult> Populate()
        {
            return await _dbInit.PopulateBreeds() ? StatusCode(204) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Remove()
        {
            return await _dbInit.RemoveBreeds() ? StatusCode(204) : StatusCode(400);
        }
    }
}