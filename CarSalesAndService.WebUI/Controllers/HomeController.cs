using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using CarSalesAndService.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarSalesAndService.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> _serviceSlider;

        public HomeController(IService<Slider> serviceSlider)
        {
            _serviceSlider = serviceSlider;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _serviceSlider.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
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
