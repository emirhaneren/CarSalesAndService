using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesAndService.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
