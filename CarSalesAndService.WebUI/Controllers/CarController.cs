using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using CarSalesAndService.Service.Concrete;
using CarSalesAndService.WebUI.Models;
using CarSalesAndService.WebUI.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarSalesAndService.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _serviceArac;
        private readonly IService<Musteri> _serviceMusteri;
        private readonly IUserService _serviceUser;

        public CarController(ICarService serviceArac, IService<Musteri> serviceMusteri, IUserService serviceUser)
        {
            _serviceArac = serviceArac;
            _serviceMusteri = serviceMusteri;
            _serviceUser = serviceUser;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                return BadRequest();

            var modelArac = await _serviceArac.GetCustomCar(id.Value);
            if (modelArac == null)
                return NotFound();

            var model = new CustomerCarDetailViewModel();
            model.Car = modelArac;
            if (User.Identity.IsAuthenticated)
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var guid = User.FindFirst(ClaimTypes.UserData)?.Value;
                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(guid))
                {
                    var user = _serviceUser.Get(x => x.Email == email && x.UserGuid.ToString() == guid.ToString());
                    if (user != null)
                    {
                        model.Customer = new Musteri
                        {
                            Adi = user.Adi,
                            Soyadi = user.Soyadi,
                            Email = user.Email,
                            Telefon = user.Telefon
                        };
                    }
                }
            }
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
                    //await MailHelper.SendMailAsync(musteri); TODO
                    TempData["Message"] = "<div class='alert alert-success'> Talebiniz alınmıştır. En kısa zamanda sizlerle iletişime geçeceğiz. </div>";
                    return Redirect("/Car/Index/" + musteri.AracId);
                }
                catch
                {
                    TempData["Message"] = "<div> class='alert alert-danger' Bir hata oluştu ! </div>";
                    ModelState.AddModelError("", "Bir hata oluştu !");
                }
            }
            return View();
        }
    }
}
