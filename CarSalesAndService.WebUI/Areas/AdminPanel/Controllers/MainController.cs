using Microsoft.AspNetCore.Mvc;

namespace CarSalesAndService.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
