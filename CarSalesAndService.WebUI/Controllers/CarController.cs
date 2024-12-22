using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using CarSalesAndService.Service.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesAndService.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _serviceArac;
        private readonly IService<Musteri> _serviceMusteri;

        public CarController(ICarService serviceArac, IService<Musteri> serviceMusteri)
        {
            _serviceArac = serviceArac;
            _serviceMusteri = serviceMusteri;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model = await _serviceArac.GetCustomCar(id);
            return View(model);
        }

        [Route("tum-araclar")]
        public async Task<IActionResult> List()
        {
            var model = await _serviceArac.GetCustomCarList(x => x.SatistaMi);
            return View(model);
        }
        public async Task<IActionResult> Search(string query)
        {
            var model = await _serviceArac.GetCustomCarList(x => x.SatistaMi && x.Marka.Adi.Contains(query) || x.KasaTipi.Contains(query) || x.Modeli.Contains(query));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceMusteri.AddAsync(musteri);
                    await _serviceMusteri.SaveAsync();
                    return Redirect("/Car/Index/"+musteri.AracId);
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu !");
                }
            }
            return View();
        }
    }
}
