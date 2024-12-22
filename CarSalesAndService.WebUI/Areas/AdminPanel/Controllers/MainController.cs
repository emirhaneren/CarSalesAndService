using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesAndService.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Policy = "AdminPolicy")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
